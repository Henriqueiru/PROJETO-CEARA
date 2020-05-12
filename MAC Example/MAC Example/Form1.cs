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

    
        private void novoForm()
        {
            Application.Run(new Form2());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtname2.Text == "Cleiton" && txtsenha2.Text == "ceara531978")
            {
                this.Close();
                nt = new Thread(novoForm);
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();
            }
            else
            {
                MessageBox.Show("Login ou Senha invalidos!");
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
    }
}
