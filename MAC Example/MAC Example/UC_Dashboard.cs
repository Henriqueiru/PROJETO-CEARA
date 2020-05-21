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
        int MetaVendasDiaria = 100;
        int MetaVendasSemanal = 600;
        int MetaVendasMensal = 3000;
        int MetaVendasAnual = 36000;

        double MetaValorDiaria = 100.00;
        double MetaValorMensal = 1200.00;
        double MetaValorAnual = 10000.00;

        DateTime CurrentDate = DateTime.Now;
        public UC_Dashboard()
        {
            InitializeComponent();

            this.LoadVendasDiarias();
            this.LoadVendasMensais();
            this.LoadVendasAnos();

            this.LoadProduto();
            this.TotalClientes();

            lblAno.Text = Convert.ToString(CurrentDate.Year);
            lblMesAno.Text = CurrentDate.ToString("MMMM") + " " + CurrentDate.Year;
        }
        public DateTime GetSunday()
        {
            DateTime SundayDate = new DateTime(1, 1, 1);

            for (int i = 0; i < 7; i++) {
                if (CurrentDate.AddDays(-i).DayOfWeek == DayOfWeek.Sunday) {
                    SundayDate = CurrentDate.AddDays(-i);
                    break;
                }
            }

            return SundayDate;
        }
        private void LoadVendasMensais()
        {
            try
            {
                ConexaoMySql Conexao = new ConexaoMySql();

                Conexao.Open();

                MySqlCommand Query = new MySqlCommand("SELECT COUNT(id) AS TotalVendas, SUM(ValorTotal) AS ValorTotal, Data FROM fecharmesa WHERE MONTH(Data) = MONTH(CURRENT_DATE()) AND YEAR(Data) = YEAR(CURRENT_DATE()) LIMIT 1;", Conexao.Conexao);
                MySqlDataReader Data = Query.ExecuteReader();
                Data.Read();

                lblValorVendasMesAtual.Text = "R$ " + Util.ToReais(Data["ValorTotal"]);

                double Quantidade = Convert.ToDouble(Data["TotalVendas"]);
                double PorcentagemMes = (Quantidade * 100) / MetaVendasMensal;

                PorcentagemMedia.Value = Convert.ToInt32(PorcentagemMes);

                if (PorcentagemMes > 50)
                {
                    PorcentagemMedia.ProgressColor = Color.Green;
                    PorcentagemMedia.ProgressColor2 = Color.Green;
                }
                else
                {
                    PorcentagemMedia.ProgressColor = Color.Red;
                    PorcentagemMedia.ProgressColor2 = Color.Red;
                }

                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void LoadVendasAnos() {
            try
            {
                ConexaoMySql Conexao = new ConexaoMySql();

                Conexao.Open();

                MySqlCommand Query = new MySqlCommand("SELECT COUNT(id) AS TotalVendas, SUM(ValorTotal) AS ValorTotal, Data FROM fecharmesa WHERE YEAR(Data) = YEAR(CURRENT_DATE()) LIMIT 1;", Conexao.Conexao);
                MySqlDataReader Data = Query.ExecuteReader();
                Data.Read();

                lblValorVendasAnoAtual.Text = "R$ " + Util.ToReais(Data["ValorTotal"]);

                double Quantidade = Convert.ToDouble(Data["TotalVendas"]);
                double PorcentagemAno = (Quantidade * 100) / MetaVendasMensal;

                PorcentagemAnual.Value = Convert.ToInt32(PorcentagemAno);

                if (PorcentagemAno > 50)
                {
                    PorcentagemAnual.ProgressColor = Color.Green;
                    PorcentagemAnual.ProgressColor2 = Color.Green;
                }
                else
                {
                    PorcentagemAnual.ProgressColor = Color.Red;
                    PorcentagemAnual.ProgressColor2 = Color.Red;
                }

                Conexao.Close();
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }
        private void LoadVendasDiarias() {
            try
            {
                ConexaoMySql Conexao = new ConexaoMySql();

                Conexao.Open();

                MySqlCommand Query = new MySqlCommand("SELECT COUNT(id) AS Total, SUM(ValorTotal) AS ValorTotal, DATE(Data) as Data FROM fecharmesa GROUP BY DATE(Data) ORDER BY Data DESC LIMIT 7;", Conexao.Conexao);
                MySqlDataReader Data = Query.ExecuteReader();

                DateTime SundayDate = this.GetSunday();
                double Media = 0;

                if (SundayDate != new DateTime(1, 1, 1))
                {
                    while (Data.Read())
                    {
                        if (CurrentDate.Date.ToString() == Convert.ToString(Data["Data"])) {
                            double Quantidade = Convert.ToDouble(Data["Total"]);
                            double Porcentagem = (Quantidade * 100) / MetaVendasDiaria;

                            PorcentagemHoje.Value = Convert.ToInt32(Porcentagem);
                            PorcentagemHoje_.Text = Convert.ToString(Convert.ToInt32(Porcentagem)) + "%";

                            if (Porcentagem > 50)
                            {
                                PorcentagemHoje.ProgressColor = Color.Green;
                                PorcentagemHoje.ProgressColor2 = Color.Green;
                            }
                            else {
                                PorcentagemHoje.ProgressColor = Color.Red;
                                PorcentagemHoje.ProgressColor2 = Color.Red;
                            }
                        }
                        else if (CurrentDate.AddDays(-1).Date.ToString() == Convert.ToString(Data["Data"])) {
                            double Quantidade = Convert.ToDouble(Data["Total"]);
                            double Porcentagem = (Quantidade * 100) / MetaVendasDiaria;

                            PorcentagemOntem.Value = Convert.ToInt32(Porcentagem);
                            PorcentagemOntem_.Text = Convert.ToString(Convert.ToInt32(Porcentagem)) + "%";

                            if (Porcentagem > 50)
                            {
                                PorcentagemOntem.ProgressColor = Color.Green;
                                PorcentagemOntem.ProgressColor2 = Color.Green;
                            }
                            else
                            {
                                PorcentagemOntem.ProgressColor = Color.Red;
                                PorcentagemOntem.ProgressColor2 = Color.Red;
                            }
                        }

                        if (SundayDate.Date.ToString() == Convert.ToString(Data["Data"]))
                        {
                            lblDomingo.Text = Data["Total"].ToString();
                            Media += Convert.ToDouble(Data["Total"].ToString());
                        }
                        else if (SundayDate.AddDays(1).Date.ToString() == Convert.ToString(Data["Data"])) {
                            lblSegunda.Text = Data["Total"].ToString();
                            Media += Convert.ToDouble(Data["Total"].ToString());
                        }
                        else if (SundayDate.AddDays(2).Date.ToString() == Convert.ToString(Data["Data"])) {
                            lblTerca.Text = Data["Total"].ToString();
                            Media += Convert.ToDouble(Data["Total"].ToString());
                        }
                        else if (SundayDate.AddDays(3).Date.ToString() == Convert.ToString(Data["Data"])) {
                            lblQuarta.Text = Data["Total"].ToString();
                            Media += Convert.ToDouble(Data["Total"].ToString());
                        }
                        else if (SundayDate.AddDays(4).Date.ToString() == Convert.ToString(Data["Data"])) {
                            lblQuinta.Text = Data["Total"].ToString();
                            Media += Convert.ToDouble(Data["Total"].ToString());
                        }
                        else if (SundayDate.AddDays(5).Date.ToString() == Convert.ToString(Data["Data"])) {
                            lblSexta.Text = Data["Total"].ToString();
                            Media += Convert.ToDouble(Data["Total"].ToString());
                        }
                        else if (SundayDate.AddDays(6).Date.ToString() == Convert.ToString(Data["Data"])) {
                            lblDomingo.Text = Data["Total"].ToString();
                            Media += Convert.ToDouble(Data["Total"].ToString());
                        }
                    }

                    double PorcentagemSemanal = (Media * 100) / MetaVendasSemanal;

                    PorcentagemMedia.Value = Convert.ToInt32(PorcentagemSemanal);
                    PorcentagemMedia_.Text = Convert.ToString(Convert.ToInt32(PorcentagemSemanal)) + "%";

                    if (PorcentagemSemanal > 50)
                    {
                        PorcentagemMedia.ProgressColor = Color.Green;
                        PorcentagemMedia.ProgressColor2 = Color.Green;
                    }
                    else
                    {
                        PorcentagemMedia.ProgressColor = Color.Red;
                        PorcentagemMedia.ProgressColor2 = Color.Red;
                    }
                }

                Conexao.Close();
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
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
