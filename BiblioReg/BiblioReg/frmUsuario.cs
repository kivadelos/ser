using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BIBLIOREG_Lib;

namespace BiblioReg
{
    public partial class frmUsuario : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        public frmUsuario()
        {
            InitializeComponent();
            this.tt.SetToolTip(this.txtbuscar, "Ingrese el Usuario a buscar");
            this.tt.SetToolTip(this.btnBuscar, "Boton para buscar");
            this.tt.SetToolTip(this.btnEliminar, "Elimina el Registro seleccionado");
            this.tt.SetToolTip(this.txtNombre, "Ingrese el Nombre del usuario");
            this.tt.SetToolTip(this.txtUsuario, "Ingrese Usuario");
            this.tt.SetToolTip(this.txtPassword, "Ingrese Password");
            this.tt.SetToolTip(this.btnAlta, "Nuevo usuario");
            this.tt.SetToolTip(this.btnGuardar, "Guarda la informacion");
            this.tt.SetToolTip(this.btnModificar, "Modifca Informacion ya Guardada");
            this.tt.SetToolTip(this.btnCancelar, "Cancela el registro");
            this.txtId.Enabled = false;
        }
        //Mostrar Mensaje de Confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Administracion de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Administracion de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
         //Limpiar Controles del formulario
        private void Limpiar()
        {
            this.txtId.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            
          
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool Valor)
        {
            this.txtId.ReadOnly = !Valor;
            this.txtNombre.ReadOnly = !Valor;
            this.txtUsuario.ReadOnly = !Valor;
            this.txtPassword.ReadOnly = !Valor;
            

           
          
            
         
        
        }
        //Habilita los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnAlta.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnModificar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnAlta.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnModificar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }
        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataUsuario.Columns[0].Visible = false;
        }
        //Método Mostrar()
        private void mostrar()
        {
            this.dataUsuario.DataSource = NUsuario.Mostrar();
            this.OcultarColumnas();
            LblTotal.Text = "Total de registros: " + Convert.ToString(dataUsuario.Rows.Count);
        }
        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataUsuario.DataSource = NUsuario.BuscarNombre(this.txtbuscar.Text);
            this.OcultarColumnas();
            LblTotal.Text = "Total de registros" + Convert.ToString(dataUsuario.Rows.Count);
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.mostrar();
            this.Habilitar(false);
            this.Botones();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea Eliminar los Registros", "Administracion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string IdUsuario;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataUsuario.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            IdUsuario = Convert.ToString(row.Cells[1].Value);
                            Rpta = NUsuario.Eliminar(Convert.ToInt32(IdUsuario));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Elimino Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

           
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataUsuario.Columns[0].Visible = true;
            }
            else
            {
                this.dataUsuario.Columns[0].Visible = false;
            }
        }

        private void dataUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataUsuario.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataUsuario.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtNombre.Text == string.Empty|| this.txtUsuario.Text == string.Empty || this.txtPassword.Text == string.Empty)
                {
                    MensajeError("Falta igresar algunos datos, verifique los campos");
                    
                }
                else
                {
                    //Para almacenar la imagen en el Buffer y despues llamar a nuestra variable imagen a nuestro metodo insertar
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();

                    if (this.IsNuevo)
                    {
                        rpta = NUsuario.Insertar(this.txtNombre.Text.Trim().ToUpper(),this.cmbAcceso.Text, this.txtUsuario.Text, this.txtPassword.Text, imagen);




                    }
                    else
                    {
                        rpta = NUsuario.Editar(
                                Convert.ToInt32(this.txtId.Text),
                                this.txtNombre.Text.Trim().ToUpper(),
                                
                                this.cmbAcceso.Text,
                                this.txtUsuario.Text,
                                this.txtPassword.Text,
                                imagen);
                        this.txtbuscar.Focus();
                    }
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Guardo de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizo de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 100", ex.Message + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.txtId.Text = string.Empty;
            this.txtNombre.Focus();
        }

        private void dataUsuario_DoubleClick(object sender, EventArgs e)
        {
            this.txtId.Text = Convert.ToString(this.dataUsuario.CurrentRow.Cells["idUsuario"].Value);
            
            this.txtNombre.Text = Convert.ToString(this.dataUsuario.CurrentRow.Cells["nombre"].Value);
            
            this.cmbAcceso.Text = Convert.ToString(this.dataUsuario.CurrentRow.Cells["acceso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataUsuario.CurrentRow.Cells["usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataUsuario.CurrentRow.Cells["password"].Value);


            byte[] imagenBuffer = (byte[])this.dataUsuario.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.tabControl1.SelectedIndex = 1;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.txtId.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);

            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a modificar ");
            }
        }

        private void pxImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        
    }
}
