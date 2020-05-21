using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAC_Example
{
    class Util
    {
        public static void OnPressOnlyDigit(object TextBox, KeyPressEventArgs e) {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
        public static void OnPressMoeda(ref Guna2TextBox ToConvert)
        {
            string numero = string.Empty;
            double valor = 0;

            try
            {
                numero = ToConvert.Text.Replace(",", "").Replace(".", "");

                if (numero.Equals(""))
                {
                    numero = "";
                }

                numero = numero.PadLeft(3, '0');

                if (numero.Length > 3 & numero.Substring(0, 1) == "0")
                {
                    numero = numero.Substring(1, numero.Length - 1);
                }

                valor = Convert.ToDouble(numero) / 100;

                ToConvert.Text = string.Format("{0:N}", valor);
                ToConvert.SelectionStart = ToConvert.Text.Length;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
        public static dynamic ToDecimal(string ToDecimal, bool ConvertToString = false)
        {
            try
            {
                string Decimal = "0";

                if (!string.IsNullOrWhiteSpace(ToDecimal))
                {
                    //Decimal = String.Format("{0:#}", ToDecimal);
                    Decimal = Convert.ToString(decimal.Parse(ToDecimal, NumberStyles.AllowCurrencySymbol | NumberStyles.Number));
                }
                else
                {
                    throw new Exception("Não foi possivel converter o valor.");
                }

                if (ConvertToString == false)
                {
                    return Convert.ToDecimal(Decimal);
                }
                else
                {
                    return Decimal;
                }
            }
            catch (Exception e)
            {
                if (ConvertToString == false)
                {
                    return Convert.ToDecimal(0);
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string ToReais(dynamic ToString)
        {
            try
            {
                string Reais = "";

                if (!string.IsNullOrWhiteSpace(Convert.ToString(ToString)))
                {
                    ToString = Convert.ToDecimal(ToString);
                    Reais = String.Format("{0:N}", ToString);
                }
                else
                {
                    throw new Exception("Não foi Possivel converter Decimal para String.");
                }

                return Reais;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return string.Empty;
            }
        }
    }
}
