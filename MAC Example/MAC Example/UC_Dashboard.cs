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
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
            this.LoadProduto();
            this.TotalClientes();
        }
        private void LoadProduto()
        {
            try
            {
                ConexaoMySql Listar = new ConexaoMySql();
                Listar.Open();

                MySqlCommand Query = new MySqlCommand("SELECT Nome,Quantidade,Validade FROM estoque WHERE Quantidade <= 5 OR Current_Time() >= DATE_SUB(Validade, INTERVAL - 5 DAY);", Listar.Conexao);
                MySqlDataAdapter Adapter = new MySqlDataAdapter(Query);
                DataTable table = new DataTable();

                Adapter.Fill(table);
                dgvlista.DataSource = table;

                Listar.Close();
                dgvlista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                Listar.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void TotalClientes()
        {
            try
            {
                ConexaoMySql dashboard = new ConexaoMySql();
                dashboard.Open();
                MySqlCommand Query = new MySqlCommand("SELECT COUNT(Nome) AS Total FROM clientes;",dashboard.Conexao);
                MySqlDataReader Data = Query.ExecuteReader();
                Data.Read();
                lblClientes.Text = Convert.ToString(Data["Total"]);
            }
            catch(Exception e) 
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
