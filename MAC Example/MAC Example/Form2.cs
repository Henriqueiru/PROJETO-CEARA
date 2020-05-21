using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MAC_Example
{
    public partial class Form2 : Form
    {
        public int NivelAcesso;
        public Form2(int NivelAcesso)
        {
            InitializeComponent();
            
            this.NivelAcesso = NivelAcesso;
            if(this.NivelAcesso == 0)
            {
                addUserControl(new UC_Dashboard());
            }
            else
            {
                addUserControl(new UC_DashboardMesas());
            }
        }
        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            ImgSlide.Location = new Point(b.Location.X + 17, b.Location.Y - 82);
            ImgSlide.SendToBack();
        }
        public void addUserControl(UserControl uc)
        {
            panelContener.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            panelContener.Controls.Add(uc);
        }
        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
                        moveImageBox(sender);            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(this.NivelAcesso == 0)
            {

            UC_Dashboard uC_ = new UC_Dashboard();
            addUserControl(uC_);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (this.NivelAcesso == 0)
            {
                UC_DashboardEstoque UC_ = new UC_DashboardEstoque();
                addUserControl(UC_);
            }
        }

        private void panelContener_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UC_DashboardMesas ux_ = new UC_DashboardMesas(this);
            addUserControl(ux_);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (this.NivelAcesso == 0)
            {
                UC_DashboardClientes Uc_ = new UC_DashboardClientes();
                addUserControl(Uc_);
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            DialogResult Fechar = MessageBox.Show("Tem Certeza que deseja fechar o programa?", "Fechar", MessageBoxButtons.YesNo);
            if (Fechar == DialogResult.Yes) 
            {
                Application.Exit();
            }
        }

        private void btnRelatórios_Click(object sender, EventArgs e)
        {
            if (this.NivelAcesso == 0)
            {
                UC_DashboardRelatorios uz_ = new UC_DashboardRelatorios();
                addUserControl(uz_);
            }
        }
    }
}
