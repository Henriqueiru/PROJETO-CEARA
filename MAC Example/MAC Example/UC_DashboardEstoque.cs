using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Guna.UI2.WinForms;

namespace MAC_Example
{
    public partial class UC_DashboardEstoque : UserControl
    {
        public UC_DashboardEstoque()
        {
            InitializeComponent();
            this.LoadLista();
            txtquantidade.KeyPress += Util.OnPressOnlyDigit;
        }
        
        private void LimparFormulario() {
            txtid.Clear();
            txtname.Clear();
            txtdesc.Clear();
            datevalidade.Text = "01/01/2020";
            txtpreco.Clear();
            txtquantidade.Clear();
            chbProduto.Checked = false;
        }
        
        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtname.Text)) {
                    ConexaoMySql Conexao = new ConexaoMySql();

                    Conexao.Open();

                    MySqlCommand Query = new MySqlCommand("INSERT INT estoque (Nome, Descricao, Validade, Preco, Quantidade, Cardapio) VALUES (@Nome, @Descricao, @Validade, @Preco, @Quantidade, @Cardapio);", Conexao.Conexao);
                    Query.Parameters.AddWithValue("@Nome", txtname.Text);
                    Query.Parameters.AddWithValue("@Descricao", txtdesc.Text);
                    Query.Parameters.AddWithValue("@Validade", DateTime.Parse(datevalidade.Text));
                    Query.Parameters.AddWithValue("@Preco", Util.ToDecimal(txtpreco.Text));
                    Query.Parameters.AddWithValue("@Quantidade", txtquantidade.Text);
                    Query.Parameters.AddWithValue("@Cardapio", (chbProduto.Checked ? 1 : 0));

                    Query.ExecuteNonQuery();

                    Conexao.Close();

                    this.LoadLista();
                    this.LimparFormulario();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btneditarprod_Click(object sender, EventArgs e)
        {
            try {
                if (!string.IsNullOrWhiteSpace(txtid.Text))
                {
                    ConexaoMySql Conexao = new ConexaoMySql();

                    Conexao.Open();

                    MySqlCommand Query = new MySqlCommand("UPDATE estoque SET Nome = @Nome, Descricao = @Descricao, Validade = @Validade, Preco = @Preco, Quantidade = @Quantidade, Cardapio = @Cardapio WHERE id = @id;", Conexao.Conexao);
                    Query.Parameters.AddWithValue("@Nome", txtname.Text);
                    Query.Parameters.AddWithValue("@Descricao", txtdesc.Text);
                    Query.Parameters.AddWithValue("@Validade", DateTime.Parse(datevalidade.Text));
                    Query.Parameters.AddWithValue("@Preco", Util.ToDecimal(txtpreco.Text));
                    Query.Parameters.AddWithValue("@Quantidade", txtquantidade.Text);
                    Query.Parameters.AddWithValue("@Cardapio", (chbProduto.Checked ? 1 : 0));
                    Query.Parameters.AddWithValue("@id", txtid.Text);

                    Query.ExecuteNonQuery();

                    Conexao.Close();

                    this.LoadLista();
                    this.LimparFormulario();

                    MessageBox.Show("Produto editado com sucesso.");
                }
                else {
                    throw new Exception("Selecione um produto antes de editar.");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvlista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvlista.Rows[e.RowIndex];

                txtid.Text = row.Cells[0].Value.ToString();
                txtname.Text = row.Cells[1].Value.ToString();
                txtdesc.Text = row.Cells[2].Value.ToString();
                datevalidade.Text = row.Cells[3].Value.ToString();
                txtpreco.Text = Util.ToReais(row.Cells[4].Value.ToString());
                txtquantidade.Text = row.Cells[5].Value.ToString();
                chbProduto.Checked = (row.Cells[6].Value.ToString()=="1"?true:false);
                txtname.Enabled = true;
                txtdesc.Enabled = true;
                datevalidade.Enabled = true;
                txtpreco.Enabled = true;
                txtquantidade.Enabled = true;

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        private void btnexcluirprod_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtid.Text))
                {
                    DialogResult Result = MessageBox.Show("Tem certeza que deseja excluir o produto " + txtname.Text + "?", "Excluir", MessageBoxButtons.YesNo);
                    
                    if (Result == DialogResult.Yes) {
                        ConexaoMySql Conexao = new ConexaoMySql();

                        Conexao.Open();

                        MySqlCommand Query = new MySqlCommand("DELETE FROM estoque WHERE id = @id;", Conexao.Conexao);
                        Query.Parameters.AddWithValue("@id", txtid);
                        Query.ExecuteNonQuery();

                        Conexao.Close();

                        MessageBox.Show("Produto " + txtname.Text + " excluido com sucesso.");

                        this.LoadLista();
                        this.LimparFormulario();
                    }
                }
                else {
                    throw new Exception("Selecione um produto para excluir.");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            txtname.Clear();
            txtdesc.Clear();
            datevalidade.Text = "01/01/2020";
            txtpreco.Clear();
            txtquantidade.Clear();
        }



        private void LoadLista()
        {
            try
            {
                ConexaoMySql Conexao = new ConexaoMySql();

                Conexao.Open();

                MySqlCommand objCmd = new MySqlCommand("SELECT * FROM estoque", Conexao.Conexao);


                MySqlDataAdapter Adapter = new MySqlDataAdapter(objCmd);
                DataTable table = new DataTable();

                Adapter.Fill(table);
                dgvlista.DataSource = table;

                /*AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
                foreach (DataRow Row in table.Rows)
                {
                    autotext.Add(Row["Nome"].ToString());
                }
                txtpesquisa.AutoCompleteMode = AutoCompleteMode.Suggest;


                txtpesquisa.AutoCompleteSource = AutoCompleteSource.CustomSource;

                txtpesquisa.AutoCompleteCustomSource = autotext;*/
                
                Conexao.Close();

                dgvlista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void dgvlista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Produtos_Load(object sender, EventArgs e)
        {

        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            String filterField = "Nome";

            (dgvlista.DataSource as DataTable).DefaultView.RowFilter =
    string.Format("Nome LIKE '{0}%' OR Nome LIKE '% {0}%'", txtpesquisa.Text);
        }

        private void UC_DashboardEstoque_Load(object sender, EventArgs e)
        {

        }

        private void OnPrecoChanged(object sender, EventArgs e)
        {
            Guna2TextBox guninha = (Guna2TextBox)sender;
            Util.OnPressMoeda(ref guninha);
        }
    }
}
