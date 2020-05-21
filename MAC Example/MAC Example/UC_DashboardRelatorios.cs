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

                MySqlCommand Query = new MySqlCommand("SELECT clientes.Nome, fecharmesa.Pagamento, fecharmesa.ValorTotal AS Valor, fecharmesa.Dividir, IF(fecharmesa.Pago, 'Sim', 'Não') AS Pago, Data FROM fecharmesa LEFT OUTER JOIN clientes ON (fecharmesa.Nome = clientes.id) ORDER BY Data DESC;", Listar.Conexao);
               
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
        private void OnTextPesquisa(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtpesquisa.Text))
            {
                (dgvlista.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nome LIKE '{0}%' OR Nome LIKE '% {0}%'", txtpesquisa.Text);
            }
            else {
                (dgvlista.DataSource as DataTable).DefaultView.RowFilter = null;
            }
        }
    }
}
