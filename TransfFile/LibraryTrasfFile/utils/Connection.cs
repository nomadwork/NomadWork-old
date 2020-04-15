using MySql.Data.MySqlClient;
using System;

namespace LibraryTrasfFile.utils
{
    public class Connection
	{
		public MySqlConnection Connect()
		{
            try
            {
                return new MySqlConnection("Server=www.nomadwork.com.br;Port=3306;Database=nomadwor_nomadwork;Uid=nomadwor_pedro;Pwd=85492562Pedro;SslMode=none");
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível conectar o banco!\n Erro: " + ex.Message);
            }
          

		}
        
	}
}
