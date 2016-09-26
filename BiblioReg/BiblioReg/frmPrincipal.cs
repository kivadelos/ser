using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblioReg
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aDMINISTRACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLibro libro = new frmLibro();
            libro.ShowDialog();
        }

        private void uSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario usuario = new frmUsuario();
            usuario.ShowDialog();
        }

        private void mANUALDEUSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManual manual = new frmManual();
            manual.ShowDialog();
        }

        private void aCERCADEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcerca acerca = new frmAcerca();
            acerca.ShowDialog();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea cambiar de usuario", "BIBLIOREG", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)== DialogResult.Yes)
          {
              this.Close();
              frmLogin frm = new frmLogin();
              frm.ShowDialog();
              
          }
          else
          {
              
          }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuario();
        }
        private void GestionUsuario()
        {
            //Controlar los accesos
            if (frmLogin.Acceso == "ADM")
            {
                //new frmPrincipalProf().Show();
                this.bIBLIOREGToolStripMenuItem.Enabled = true;
                this.aDMINISTRACIONToolStripMenuItem.Enabled = true;
                this.uSUARIOToolStripMenuItem.Visible = true;
                this.mANUALDEUSUARIOToolStripMenuItem.Enabled = true;
                this.aCERCADEToolStripMenuItem.Enabled = true;


            }
            else if (frmLogin.Acceso == "ENCARGADO")
            {
                this.bIBLIOREGToolStripMenuItem.Enabled = true;
                this.aDMINISTRACIONToolStripMenuItem.Enabled = true;
                this.uSUARIOToolStripMenuItem.Visible = false;
                this.mANUALDEUSUARIOToolStripMenuItem.Enabled = true;
                this.aCERCADEToolStripMenuItem.Enabled = true;

            }
            else
            {
                MessageBox.Show("Usuario no encontrado", "CEV3", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
