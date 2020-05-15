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

namespace MAC_Example
{
    public partial class UC_DashboardEstoque : UserControl
    {
        public UC_DashboardEstoque()
        {
            InitializeComponent();
            this.LoadLista();
        }
        MySqlConnection objCon = new MySqlConnection("server=localhost;port=3307;User Id=root;database=bancodedados; password=usbw; Convert Zero Datetime = True");
        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                objCon.Open();

                txtpreco.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", txtpreco.Text);
                int qtd = Convert.ToInt32(txtquantidade.Text);
                string datevenc = datevalidade.Value.ToString("yyyy-MM-dd");

                if (String.IsNullOrEmpty(txtid.Text))
                {
                    MySqlCommand objCmd = new MySqlCommand("INSERT INTO `bancodedados`.`estoque` (`Nome`, `Descricao`, `Validade`, `Preco`, `Quantidade`, `Cardapio`) VALUES ('" + txtname.Text + "', '" + txtdesc.Text + "', '" + datevenc + "', '" + txtpreco.Text + "', '" + qtd + "','"+ (chbProduto.Checked ? 1 : 0) + "');", objCon);
                    objCmd.ExecuteNonQuery();
                    MessageBox.Show("Inserido com Sucesso!", "OK");

                }
                else
                {
                    MessageBox.Show("Selecione a opção Inserir");
                }
                objCon.Close();
                this.LoadLista();

                txtid.Clear();
                txtname.Clear();
                txtdesc.Clear();
                datevalidade.Text = "01/01/2020";
                txtpreco.Clear();
                txtquantidade.Clear();
                chbProduto.Checked = false;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                objCon.Close();


                txtid.Clear();
                txtname.Clear();
                txtdesc.Clear();
                datevalidade.Text = "01/01/2020";
                txtpreco.Clear();
                txtquantidade.Clear();
                chbProduto.Checked = false;
            }
        }

        private void btneditarprod_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtid.Text))
                {
                    objCon.Open();
                    string datevenc = datevalidade.Value.ToString("yyyy-MM-dd");

                    MySqlCommand objCmd = new MySqlCommand("UPDATE `bancodedados`.`estoque` SET `Nome` = '" + txtname.Text + "', `Descricao` = '" + txtdesc.Text + "', `Validade` = '" + datevenc + "', `Preco` = '" + txtpreco.Text + "', `Quantidade` = '" + txtquantidade.Text + "' ,`Cardapio` = '"+(chbProduto.Checked?1:0)+"' WHERE (`id` = '" + txtid.Text + "');", objCon);
                    objCmd.ExecuteNonQuery();
                    MessageBox.Show("Atualizado Com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    objCon.Close();
                    this.LoadLista();
                    txtid.Clear();
                    txtname.Clear();
                    txtdesc.Clear();
                    datevalidade.Text = "01/01/2020";
                    txtpreco.Clear();
                    txtquantidade.Clear();
                    chbProduto.Checked = false;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                objCon.Close();


                txtid.Clear();
                txtname.Clear();
                txtdesc.Clear();
                datevalidade.Text = "01/01/2020";
                txtpreco.Clear();
                txtquantidade.Clear();
                chbProduto.Checked = false;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            txtpesquisa.Text = "";
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            objCon.Open();

            MySqlCommand objCmd = new MySqlCommand("SELECT * FROM estoque", objCon);


            MySqlDataAdapter Adapter = new MySqlDataAdapter(objCmd);
            DataTable table = new DataTable();

            Adapter.Fill(table);
            dgvlista.DataSource = table;

            objCon.Close();

            dgvlista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
                txtpreco.Text = row.Cells[4].Value.ToString();
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
                objCon.Close();


                txtid.Clear();
                txtname.Clear();
                txtdesc.Clear();
                datevalidade.Text = "01/01/2020";
                txtpreco.Clear();
                txtquantidade.Clear();
            }
        }

        private void btnexcluirprod_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtid.Text == String.Empty))
                {
                    objCon.Open();


                    DialogResult Check = MessageBox.Show("Deseja realmente excluir este item?", ".", MessageBoxButtons.YesNo);
                    if (Check == DialogResult.Yes)
                    {
                        MySqlCommand objCmd = new MySqlCommand("DELETE FROM `bancodedados`.`estoque` WHERE (`id` = '" + txtid.Text + "');", objCon);
                        objCmd.ExecuteNonQuery();
                        MessageBox.Show("Deletado Com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }











                    objCon.Close();
                    this.LoadLista();
                    txtid.Clear();
                    txtname.Clear();
                    txtdesc.Clear();
                    datevalidade.Text = "01/01/2020";
                    txtpreco.Clear();
                    txtquantidade.Clear();


                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                objCon.Close();


                txtid.Clear();
                txtname.Clear();
                txtdesc.Clear();
                datevalidade.Text = "01/01/2020";
                txtpreco.Clear();
                txtquantidade.Clear();

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






        private void btnpesquisa_Click(object sender, EventArgs e)
        {
            objCon.Open();

            MySqlCommand objCmd = new MySqlCommand("SELECT * FROM estoque WHERE CONCAT(`Nome`, `Descricao`, `Validade`, `Preco`, `Quantidade`) LIKE '" + txtpesquisa.Text + "%';", objCon);

            objCmd.ExecuteNonQuery();
            MySqlDataAdapter Adapter = new MySqlDataAdapter(objCmd);
            DataTable table = new DataTable();

            Adapter.Fill(table);
            dgvlista.DataSource = table;

            dgvlista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvlista.ClearSelection();
            objCon.Close();
        }


        private void LoadLista()
        {
            objCon.Open();

            MySqlCommand objCmd = new MySqlCommand("SELECT * FROM estoque", objCon);


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
            objCon.Close();

            dgvlista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
    }
}
