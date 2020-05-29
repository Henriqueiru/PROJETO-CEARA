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
    public partial class UC_DashboardClientes : UserControl
    {
        public UC_DashboardClientes()
        {
            InitializeComponent();
            this.LoadLista();
        }

        private void LimparFormulario()
        {
            txtid.Text = "";
            txtname.Text = "";
            txtlastname.Text = "";
            txtdoc.Text = "";
            txtphone.Text = "";
        }
       private void CadastrarCliente()
        {
            try
            {
                if (String.IsNullOrEmpty(txtid.Text))
                {
                    ConexaoMySql Cadastrar = new ConexaoMySql();
                    Cadastrar.Open();
                    MySqlCommand Query = new MySqlCommand("INSERT INTO clientes (Nome,Sobrenome,Documentos,Telefone) VALUES (@Nome,@Sobrenome,@Documentos,@Telefone);", Cadastrar.Conexao);
                    
                    Query.Parameters.AddWithValue("@Nome", txtname.Text);
                    Query.Parameters.AddWithValue("@Sobrenome", txtlastname.Text);
                    Query.Parameters.AddWithValue("@Documentos", txtdoc.Text);
                    Query.Parameters.AddWithValue("@Telefone", txtphone.Text);

                    Query.ExecuteNonQuery();
                    Cadastrar.Close();
                    this.LoadLista();

                    this.LimparFormulario();

                    MessageBox.Show("Cliente adicionado com sucesso");
                }
                else
                {
                    throw new Exception("Limpe o Formulário antes de prosseguir");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void EditarCliente()
        {
            try
            {
                if (!String.IsNullOrEmpty(txtid.Text))
                {
                    ConexaoMySql Editar = new ConexaoMySql();
                    Editar.Open();
                    MySqlCommand Query = new MySqlCommand("UPDATE clientes SET Nome = @Nome, Sobrenome = @Sobrenome, Documentos = @Documentos, Telefone = @Telefone WHERE id = @id;", Editar.Conexao);

                    Query.Parameters.AddWithValue("@Nome", txtname.Text);
                    Query.Parameters.AddWithValue("@Sobrenome", txtlastname.Text);
                    Query.Parameters.AddWithValue("@Documentos", txtdoc.Text);
                    Query.Parameters.AddWithValue("@Telefone", txtphone.Text);
                    Query.Parameters.AddWithValue("@id", txtid.Text);
                    
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

        private void ExcluirCliente()
        {
            try
            {
                if (!String.IsNullOrEmpty(txtid.Text))
                {
                    DialogResult Escruir = MessageBox.Show("Deseja realmente excluir este item?", "Excluir", MessageBoxButtons.YesNo);
                    
                    if(Escruir == DialogResult.Yes)
                    {
                        ConexaoMySql Excluir = new ConexaoMySql();
                        Excluir.Open();
                        MySqlCommand Query = new MySqlCommand("DELETE FROM clientes WHERE id = @id;", Excluir.Conexao);
                        Query.Parameters.AddWithValue("@id", txtid.Text);
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
            catch(Exception e)
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

                MySqlCommand Query = new MySqlCommand("SELECT * FROM clientes", Listar.Conexao);
                MySqlDataAdapter Adapter = new MySqlDataAdapter(Query);
                DataTable table = new DataTable();

                Adapter.Fill(table);
                dgvlista.DataSource = table;

                Listar.Close();
                dgvlista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvlista.Columns[0].Visible = false;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UC_DashboardClientes_Load(object sender, EventArgs e)
        {

        }

        private void OnDoubleClickLista(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvlista.Rows[e.RowIndex];

                txtid.Text = row.Cells[0].Value.ToString();
                txtname.Text = row.Cells[1].Value.ToString();
                txtlastname.Text = row.Cells[2].Value.ToString();
                txtdoc.Text = row.Cells[3].Value.ToString();
                txtphone.Text = row.Cells[4].Value.ToString();                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void OnClickBotoes(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button Botoes = (Guna2Button)sender;
            switch (Botoes.Tag)
            {
                case "Cadastrar": this.CadastrarCliente(); break;
                case "Editar": this.EditarCliente(); break;
                case "Limpar": this.LimparFormulario(); break;
                case "Excluir": this.ExcluirCliente(); break;
            }
        }

        private void OnTextChangedPesquisar(object sender, EventArgs e)
        {
            (dgvlista.DataSource as DataTable).DefaultView.RowFilter =
             string.Format("Nome LIKE '{0}%' OR Sobrenome LIKE '%{0}%'", txtpesquisa.Text);
        }
    }
}
