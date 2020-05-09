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
        public Form2()
        {
            InitializeComponent();
            UC_Dashboard uC_ = new UC_Dashboard();
            addUserControl(uC_);
        }
        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            ImgSlide.Location = new Point(b.Location.X + 17, b.Location.Y - 82);
            ImgSlide.SendToBack();
        }
        private void addUserControl(UserControl uc)
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
            UC_Dashboard uC_ = new UC_Dashboard();
            addUserControl(uC_);
        }
    }
}
