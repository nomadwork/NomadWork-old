using LibraryClassTransfile;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfile
{
	public class UserData
	{
		internal User Carregar(MySqlDataReader dr)
		{
			return new User
			{
				UserId = int.Parse(dr["IDUSER"].ToString()),
				UserName = dr["NAME"].ToString().Trim(),
				
			};
		}

		public List<User> ListUsers()
		{
			var listUser = new List<User>();
			try
			{
				var db = new Connection().Connect();
				if (!db.Ping())
				{
					db = new Connection().ConnectLocal();
				}

				db.Open();

				var select = new MySqlCommand("SELECT IDUSER, NAME  FROM USER", db);
				select.ExecuteNonQuery();

				var dr = select.ExecuteReader();

				while (dr.Read())
				{
					listUser.Add(Carregar(dr));
				}

				db.Close();
			}
			catch 
			{
				throw new Exception ("Erro ao Listar Usuários");
			}
			return listUser;
		}

		public List<User> ListUsers(string nome)
		{
			var listUser = new List<User>();
			try
			{
				var db = new Connection().Connect();
				db.Open();

				var select = new MySqlCommand("SELECT IDALUNO, NOME FROM ALUNNO WHERE NOME LIKE '%?%'", db);
				select.Parameters.AddWithValue("NOME", nome);

				select.ExecuteNonQuery();

				var dr = select.ExecuteReader();

				while (dr.Read())
				{
					listUser.Add(Carregar(dr));
				}

				db.Close();
			}
			catch
			{

				throw new Exception("Erro ao Listar Usuários");
			}

			return listUser;
		}
		
		public User SelectUser(User userOld)
		{
			var userNew = new User();
			try
			{
				var db = new Connection().Connect();
				db.Open();

				var query = "SELECT IDUSER, NAME FROM USER WHERE {0}";

				if (!string.IsNullOrEmpty(userOld.UserName) && userOld.UserId < 0)
				{
					string.Format(query, "NOME = ?", userOld.UserName);

				}
				else if (string.IsNullOrEmpty(userOld.UserName) && userOld.UserId > 0)
				{

					string.Format(query, "IDALUNO = ?", userOld.UserId);
				}
				else
				{
					string.Format(query, "NOME LIKE ? AND IDALUNO = ?", userOld.UserName, userOld.UserId);

				}

				var select = new MySqlCommand(query, db);

				select.ExecuteNonQuery();

				var dr = select.ExecuteReader();

				userNew = Carregar(dr);

				db.Close();
			}
			catch 
			{

				throw new Exception("Erro ao selecionar Usuários");
			}

			return userNew;
		}

		public bool InsertUser(User user)
		{
			var db = new Connection().Connect();
			bool ok;

			try
			{
				db.Open();

				var insert = new MySqlCommand("insert into USER(IDUSER,NAME) VALUES(?,?)", db);
				var param = insert.Parameters;

				param.AddWithValue("@IDUSER", user.UserId);
				param.AddWithValue("@NAME", user.UserName);

				insert.ExecuteNonQuery();
				
				db.Close();

				Console.WriteLine("Inserido com sucesso");
				ok = true;

			}
			catch
			{
				ok = false;
				throw new Exception("Erro ao inserir Usuários");
				
			}
			return ok;

		}

	}

}
