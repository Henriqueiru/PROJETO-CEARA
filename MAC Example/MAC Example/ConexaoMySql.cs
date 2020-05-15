using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAC_Example
{
    public class ConexaoMySql
    {
        public MySqlConnection Conexao;
        public ConexaoMySql()
        {
            try
            {
                Conexao = new MySqlConnection("server=localhost;port=3307;User Id=root;database=bancodedados; password=usbw; Convert Zero Datetime = True");

            }
            catch(MySqlException e)
            {
                throw e;
            }
        }
        public bool Open()
        {
            try
            {
                Conexao.Open();
                return true;
            }
            catch(MySqlException e)
            {
                throw e;
                return false;
            }

        }
        public bool Close()
        {
            try
            {
                Conexao.Close();
                return true;
            }
            catch (MySqlException e)
            {
                throw e;
                return false;
            }

        }
    }
}
