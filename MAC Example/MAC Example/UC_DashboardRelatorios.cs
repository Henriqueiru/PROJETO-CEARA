using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MAC_Example
{
    public partial class UC_DashboardRelatorios : UserControl
    {
        public UC_DashboardRelatorios()
        {
            InitializeComponent();
            this.LoadLista();
        }
        private void LoadLista()
        {
            try
            {
                ConexaoMySql Listar = new ConexaoMySql();
                Listar.Open();

                MySqlCommand Query = new MySqlCommand("SELECT Nome, Pagamento, ValorTotal AS Valor, Dividir, IF(Pago, 'Sim', 'Não') AS Pago, Data FROM fecharmesa ORDER BY Data DESC;", Listar.Conexao);
               
                MySqlDataAdapter Adapter = new MySqlDataAdapter(Query);
                DataTable table = new DataTable();

                Adapter.Fill(table);
                dgvlista.DataSource = table;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }

}
