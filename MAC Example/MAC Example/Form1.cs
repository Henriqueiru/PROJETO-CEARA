using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MAC_Example
{
    public partial class Form1 : Form
    {
        Thread nt;
        public Form1()
        {
            InitializeComponent();
        }

    
        private void novoForm(int NivelAcesso)
        {
            Application.Run(new Form2(NivelAcesso));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int NivelAcesso;
                if(txtname2.Text == "Cleiton" && txtsenha2.Text == "1")
                {
                    NivelAcesso = 0;
                }
                else if(txtname2.Text == "Neto" && txtsenha2.Text == "1")
                {
                    NivelAcesso = 1;
                }
                else
                {
                    throw new Exception("Login ou senha incorretos");
                }
                Form form = new Form2(NivelAcesso);
                this.Hide();
                form.Closed += (ss, ee) => this.Close();
                form.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtname2_Click(object sender, EventArgs e)
        {
            
        }

        private void txtsenha2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
