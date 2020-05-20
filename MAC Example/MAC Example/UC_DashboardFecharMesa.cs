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
using Guna.UI2.WinForms;

namespace MAC_Example
{
    public partial class UC_DashboardFecharMesa : UserControl
    {
        Form2 formprincipal;
        string CodigoMesa;
        double valortotal = 0;
            public UC_DashboardFecharMesa(Form2 form,string CodigoMesa)
        {
            InitializeComponent();
            this.formprincipal = form;
            this.CodigoMesa = CodigoMesa;
            this.LoadLista();
            lblMesa.Text = "Mesa " + CodigoMesa;
        }

        private void UC_DashboardFecharMesa_Load(object sender, EventArgs e)
        {

        }
        private void LoadLista()
        {
            try
            {
                ConexaoMySql Listar = new ConexaoMySql();
                Listar.Open();

                MySqlCommand Query = new MySqlCommand("SELECT vendas.*, estoque.Nome AS Pedido FROM vendas LEFT OUTER JOIN estoque ON (vendas.Produto = estoque.id) WHERE vendas.Mesa = @Mesa;", Listar.Conexao);
                Query.Parameters.AddWithValue("@Mesa", this.CodigoMesa);
                MySqlDataAdapter Adapter = new MySqlDataAdapter(Query);
                DataTable table = new DataTable();

                Adapter.Fill(table);
                dgvlista.DataSource = table;

                foreach (DataRow data in table.Rows)
                {
                    valortotal += (Convert.ToDouble(data["Preco"].ToString()) * (int)data["Quantidade"]);
                }
                txtValorTotal.Text = Convert.ToString(valortotal);

                Listar.Close();
                dgvlista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvlista.Columns[0].Visible = false;
                dgvlista.Columns[1].Visible = false;
                dgvlista.Columns[2].Visible = false;
                dgvlista.Columns[5].Visible = false;
                dgvlista.Columns[6].DisplayIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void guna2VSeparator1_Click(object sender, EventArgs e)
        {

        }
        private void OnClickBotoes(object sender, EventArgs e)
        {
            Guna2Button Botoes = (Guna2Button)sender;
            switch (Botoes.Tag)
            {
                case "Concluir":
                    DialogResult FecharMesa = MessageBox.Show("Você Realmente deseja fechar esta mesa?", "Fechar Mesa", MessageBoxButtons.YesNo);
                    if (FecharMesa == DialogResult.Yes)
                    {
                        this.FecharMesa();
                    }
                    break;
                case "Voltar": this.formprincipal.addUserControl(new UC_DashboardVendas(formprincipal, this.CodigoMesa)); break;
            }
        }
        private void FecharMesa()
        {
            try
            {
                ConexaoMySql cadastrar = new ConexaoMySql();
                cadastrar.Open();
                if (valortotal > 0)
                {
                    MySqlCommand Query = new MySqlCommand("INSERT INTO fecharmesa(Nome, Pagamento, ValorTotal, Dividir, Pago, Data) VALUES (@Nome, @Pagamento, @ValorTotal, @Dividir, @Pago, Current_Time())", cadastrar.Conexao);
                    Query.Parameters.AddWithValue("@Nome", txtNome.Text);
                    Query.Parameters.AddWithValue("@Pagamento", cmbPagamento.Text);
                    Query.Parameters.AddWithValue("@ValorTotal", txtValorTotal.Text);
                    Query.Parameters.AddWithValue("@Dividir", txtDividir.Text);
                    Query.Parameters.AddWithValue("@Pago", (chbPago.Checked?1:0));
                    Query.ExecuteNonQuery();

                    this.SubtrairEstoque();

                    MySqlCommand DeletarProdutosMesa = new MySqlCommand("DELETE FROM vendas WHERE Mesa = @Mesa;", cadastrar.Conexao);
                    DeletarProdutosMesa.Parameters.AddWithValue("@Mesa", CodigoMesa);
                    DeletarProdutosMesa.ExecuteNonQuery();
                }
                MySqlCommand UpdateStatusMesa = new MySqlCommand("UPDATE mesa SET Status = 0 WHERE Codigo = @Codigo LIMIT 1;", cadastrar.Conexao);
                UpdateStatusMesa.Parameters.AddWithValue("@Codigo", CodigoMesa);
                UpdateStatusMesa.ExecuteNonQuery();

                cadastrar.Close();
                MessageBox.Show("Mesa Fechada com Sucesso. Agora ela está Aberta para outras pessoas usarem!");
                formprincipal.addUserControl(new UC_DashboardMesas(formprincipal));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void SubtrairEstoque()
        {
            try
            {
                ConexaoMySql Conexao = new ConexaoMySql();
                foreach (DataGridViewRow data in dgvlista.Rows) {
                    if(Convert.ToInt32(data.Cells[2].Value) > 0)
                    {
                        
                        Conexao.Open();
                        MySqlCommand Query = new MySqlCommand("UPDATE estoque SET Quantidade = (Quantidade - @Quantidade) WHERE id = @id;", Conexao.Conexao);
                        Query.Parameters.AddWithValue("@Quantidade", data.Cells[4].Value);
                        Query.Parameters.AddWithValue("@id", data.Cells[2].Value);
                        Query.ExecuteNonQuery();
                        Conexao.Close();
                    }
                    
                }
                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
