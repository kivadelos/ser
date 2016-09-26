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
using System.IO;

namespace BiblioReg
{
    public partial class frmLogin : Form
    {
        public static string IdUsuario;
       
       
        public static string Nombre;
        
        public static string Acceso;
        public frmLogin()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbA.Text == "ADM")
            {
                DataTable Datos = BIBLIOREG_Lib.NUsuario.Login(this.txtUser.Text, this.txtPassword.Text);
                //Valuar si existe el usuario
                {
                    if (Datos.Rows.Count == 0)
                    {
                        MessageBox.Show("NO tiene Acceso al Sistema", "BIBLIOREG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        frmPrincipal frm = new frmPrincipal();
                    }
                }
            }
            if (cmbA.Text == "ENCARGADO")
            {
                DataTable Datos = BIBLIOREG_Lib.NUsuario.Login(this.txtUser.Text, this.txtPassword.Text);
                //Valuar si existe el usuario
                {
                    if (Datos.Rows.Count == 0)
                    {
                        MessageBox.Show("NO tiene Acceso al Sistema", "BIBLIOREG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        frmPrincipal frm = new frmPrincipal();
                    }
                }
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtPassword.Focus();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) btnAceptar.Focus();
        }
    }
}
