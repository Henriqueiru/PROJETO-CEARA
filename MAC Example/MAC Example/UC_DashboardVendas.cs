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
using System.Xml;

namespace MAC_Example
{
    public partial class UC_DashboardVendas : UserControl
    {
        Form2 formprincipal;
        string CodigoMesa;

        public UC_DashboardVendas(Form2 form, string CodigoMesa)
        {
            InitializeComponent();
            this.formprincipal = form;

            this.CodigoMesa = CodigoMesa;
            lblMesa.Text = "Mesa " + CodigoMesa;

            this.LoadLista();
            this.LoadProduto();
        }

        private void LimparFormulario()
        {
            txtids.Text = "";
            txtProduto.Text = "";
            txtPreco.Text = "";
            txtQuantidade.Text = "";
        }
        private void VerificarStatusMesa()
        {
            try
            {
                ConexaoMySql Verificar = new ConexaoMySql();

                Verificar.Open();

                MySqlCommand Query = new MySqlCommand("SELECT Status FROM mesa WHERE Codigo = @Codigo LIMIT 1;", Verificar.Conexao);
                Query.Parameters.AddWithValue("@Codigo", CodigoMesa);

                MySqlDataReader Data = Query.ExecuteReader();

                while (Data.Read())
                {
                    if ((int)Data["Status"] == 0)
                    {
                        UpdateStatusMesa(1);
                    }
                }

                Verificar.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void UpdateStatusMesa(int Status)
        {
            try
            {
                ConexaoMySql Update = new ConexaoMySql();

                Update.Open();

                MySqlCommand Query = new MySqlCommand("UPDATE mesa SET Status = @Status WHERE Codigo = @Codigo LIMIT 1;", Update.Conexao);
                Query.Parameters.AddWithValue("@Status", Status);
                Query.Parameters.AddWithValue("@Codigo", this.CodigoMesa);
                Query.ExecuteNonQuery();

                Update.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Cadastrar()
        {
            try
            {
                if (String.IsNullOrEmpty(txtids.Text))
                {
                    ConexaoMySql Cadastrar = new ConexaoMySql();
                    Cadastrar.Open();
                    MySqlCommand Query = new MySqlCommand("INSERT INTO vendas (Mesa,Produto,Preco,Quantidade,Data) VALUES (@Mesa,@Produto,@Preco,@Quantidade,Current_Time());", Cadastrar.Conexao);

                    Query.Parameters.AddWithValue("@Mesa", CodigoMesa);
                    Query.Parameters.AddWithValue("@Produto", txtProduto.SelectedValue);
                    Query.Parameters.AddWithValue("@Preco", txtPreco.Text);
                    Query.Parameters.AddWithValue("@Quantidade", txtQuantidade.Text);

                    Query.ExecuteNonQuery();

                    Cadastrar.Close();

                    this.VerificarStatusMesa();

                    this.LoadLista();

                    this.LimparFormulario();

                    MessageBox.Show("Foi adicionado com sucesso");
                }
                else
                {
                    throw new Exception("Limpe o Formulário antes de prosseguir");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Editar()
        {
            try
            {
                if (!String.IsNullOrEmpty(txtids.Text))
                {
                    ConexaoMySql Editar = new ConexaoMySql();
                    Editar.Open();
                    MySqlCommand Query = new MySqlCommand("UPDATE vendas SET Mesa = @Mesa, Produto = @Produto, Preco = @Preco, Quantidade = @Quantidade WHERE id = @id;", Editar.Conexao);

                    Query.Parameters.AddWithValue("@Mesa", CodigoMesa);
                    Query.Parameters.AddWithValue("@Produto", txtProduto.SelectedValue);
                    Query.Parameters.AddWithValue("@Preco", txtPreco.Text);
                    Query.Parameters.AddWithValue("@Quantidade", txtQuantidade.Text);
                    Query.Parameters.AddWithValue("@id", txtids.Text);

                    Query.ExecuteNonQuery();
                    Editar.Close();
                    this.LoadLista();

                    this.LimparFormulario();
                    MessageBox.Show("Foi editado com sucesso");
                }
                else
                {
                    throw new Exception("Selecione um Cliente para editar");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Excluir()
        {
            try
            {
                if (!String.IsNullOrEmpty(txtids.Text))
                {
                    DialogResult Escruir = MessageBox.Show("Deseja realmente excluir este item?", "Excluir", MessageBoxButtons.YesNo);

                    if (Escruir == DialogResult.Yes)
                    {
                        ConexaoMySql Excluir = new ConexaoMySql();
                        Excluir.Open();
                        MySqlCommand Query = new MySqlCommand("DELETE FROM vendas WHERE id = @id;", Excluir.Conexao);
                        Query.Parameters.AddWithValue("@id", txtids.Text);
                        Query.ExecuteNonQuery();
                        Excluir.Close();
                        this.LoadLista();

                        this.LimparFormulario();
                        MessageBox.Show("Excluido com Sucesso");
                    }
                }
                else
                {
                    throw new Exception("Selecione um Cliente para excluir");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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

                Listar.Close();
                dgvlista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvlista.Columns[0].Visible = false;
                dgvlista.Columns[1].Visible = false;
                dgvlista.Columns[2].Visible = false;
                dgvlista.Columns[6].DisplayIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void LoadProduto()
        {
            try
            {
                ConexaoMySql Listar = new ConexaoMySql();
                Listar.Open();

                MySqlCommand Query = new MySqlCommand("SELECT * FROM estoque WHERE Cardapio = 1;", Listar.Conexao);               
                MySqlDataAdapter Adapter = new MySqlDataAdapter(Query);
                DataTable table = new DataTable();
                
                Adapter.Fill(table);
                txtProduto.ValueMember = "id";
                txtProduto.DisplayMember = "Nome";
                txtProduto.DataSource = table;

                Listar.Close();
               
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void OnDoubleClickLista(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvlista.Rows[e.RowIndex];

                txtids.Text = row.Cells[0].Value.ToString();
                txtProduto.SelectedValue = row.Cells[2].Value.ToString();
                txtPreco.Text = row.Cells[3].Value.ToString();
                txtQuantidade.Text = row.Cells[4].Value.ToString();
                //txtphone.Text = row.Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnClickBotoes(object sender, EventArgs e)
        {
            Guna2Button Botoes = (Guna2Button)sender;
            switch (Botoes.Tag)
            {
                case "Cadastrar": this.Cadastrar(); break;
                case "Editar": this.Editar(); break;
                case "Limpar": this.LimparFormulario(); break;
                case "Excluir": this.Excluir(); break;
                case "Voltar": this.formprincipal.addUserControl(new UC_DashboardMesas(formprincipal)); break;
                case "Fechar": this.formprincipal.addUserControl(new UC_DashboardFecharMesa(formprincipal,CodigoMesa)); break;
            }
        }

        private void OnTextChangedPesquisar(object sender, EventArgs e)
        {
            (dgvlista.DataSource as DataTable).DefaultView.RowFilter =
             string.Format("Nome LIKE '{0}%' OR Sobrenome LIKE '%{0}%'", txtpesquisa.Text);
        }

        private void UC_DashboardVendas_Load(object sender, EventArgs e)
        {

        }
    }
}