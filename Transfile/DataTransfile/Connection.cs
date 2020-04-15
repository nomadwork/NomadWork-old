
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataTransfile
{
	public class Connection
	{
		public MySqlConnection Connect()
		{
			
			return new MySqlConnection("Server=www.nomadwork.com.br;Port=3306;Database=nomadwor_test;Uid=nomadwor_usertest;Pwd=123456abc;SslMode=none");

		}
		public MySqlConnection ConnectLocal()
		{
			return new MySqlConnection("Server=localhost;Port=3306;Database=Jerson;Uid=root;Pwd=12345678;");
		}

	}
}
