using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace MAC_Example
{
    public partial class UC_DashboardMesas : UserControl
    {
        Form2 formprincipal;
        
        public UC_DashboardMesas(Form2 form = null)
        {
            InitializeComponent();
            this.LoadMesa();
            if (form != null)
            {
                this.formprincipal = form;
            }
        }

        private Guna2Button FindMesa(string TagButton) {
            foreach (Guna2Button button in Controls.OfType<Guna2Button>()) {
                if ((string)button.Tag == TagButton) {
                    return button;
                }
            }
            return null;
        }

        private void LoadMesa()
        {
            try
            {
                ConexaoMySql load = new ConexaoMySql();
                
                load.Open();
                
                MySqlCommand Query = new MySqlCommand("SELECT * FROM mesa;", load.Conexao);
                MySqlDataReader Data = Query.ExecuteReader();
                
                while (Data.Read())
                {
                    Guna2Button button = FindMesa((string)Data["Codigo"]);

                    if (button != null) {
                        if ((int)Data["status"] == 0)
                        {
                            button.FillColor = Color.Green;
                            button.BorderColor = Color.Green;
                        }
                        else if ((int)Data["status"] == 1)
                        {
                            button.FillColor = Color.Red;
                            button.BorderColor = Color.Red;
                        }
                        else {
                            button.FillColor = Color.FromArgb(200, 200, 200);
                            button.BorderColor = Color.FromArgb(200, 200, 200);
                        }
                    }
                }

                load.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void OnClickMesa(object sender,EventArgs e)
        {
            Guna2Button mesas = (Guna2Button) sender;
            switch (mesas.Tag)
            {
                case "M1": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
                case "M2": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
                case "M3": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
                case "M4": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
                case "M5": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
                case "M6": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
                case "G1": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
                case "G2": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
                case "G3": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
                case "G4": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
                case "B1": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
                case "B2": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
                case "B3": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
                case "B4": formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, (string)mesas.Tag)); break;
            }
        }
    }
}
