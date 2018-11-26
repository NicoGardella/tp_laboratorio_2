using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainCorreo
{
    public partial class frmPpal : Form
    {
        Correo correo = new Correo();
        Paquete paquete;
        public frmPpal()
        {           
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string trackingID = mtxtTrackingID.Text;
            string direccion = txtDireccion.Text;
            paquete = new Paquete(direccion, trackingID);
            paquete.InformaEstado += Paq_InformarEstado;
            paquete.InformarConexion += Paq_InformarConexion;

            try
            {
                correo += paquete;
                ActualizarEstados();
            }
            catch (TrackingIdRepetidoException)
            {
                MessageBox.Show("ERROR, el id ya fue utilizaddo");
            }

        }
       
       

        /// <summary>
        /// Muestro la información de un paquete en particular de la lista de Entregados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Al cerrarse el formulario, termino todos los hilos en ejecución.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Comprueba y actualiza los estados de envio de los paquetes,
        /// colocando cada paquete en el ListBox correspondiente.
        /// </summary>
        private void ActualizarEstados()
        {
            // Limpio las listas
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(item);
                        break;
                }
            }
        }

        #region Alumno

       

        private void Paq_InformarConexion(object sender, Exception inner)
        {
            MessageBox.Show(inner.Message);
        }

        private void Paq_InformarEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                DelegadoEstado d = new DelegadoEstado(Paq_InformarEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        /// <summary>
        /// Mostrará la información del elemento en RichTextBox rtbMostrar
        /// y utilizará el método de extensión para guardar el texto en this.rtbMostrar.Text
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!object.ReferenceEquals(elemento, null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                string archivo = "salida.txt";
                elemento.MostrarDatos(elemento).Guardar(archivo);
            }
        }

        #endregion

        private void FrmPpal_Load(object sender, EventArgs e)
        {
            this.lstEstadoEntregado.ContextMenuStrip = cmsListas;
        }
        /// <summary>
        /// Muestro la información de todos los paquetes del correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click_1(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        
    }
}
