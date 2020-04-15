using LibraryTrasfFile.sendClass;
using LibraryTrasfFile.utils;
using MySql.Data.MySqlClient;
using System;


namespace LibraryTrasfFile.myFileClass
{
    internal class MyFileData
	{
		private MyFile Load(MySqlDataReader dr)
		{
			return new MyFile
			{
				FileId = int.Parse(dr["file_id"].ToString().Trim()),
				FileName = dr["name"].ToString().Trim(),
				FileType = dr["type"].ToString().Trim(),
                FileBytes = (byte[])(dr["bytes"]),

			};
        }

        internal bool InsertFile(Send send)
		{
            var db = new Connection().Connect();
            int ok;
            try
            {
                db.Open();

                var insert = new MySqlCommand("INSERT INTO file(name, bytes, type, shipping) " +
                    "VALUES(?name,?bytes,?type,?shipping)", db);

                var param = insert.Parameters;
                param.AddWithValue("?name", send.MyFileSend.FileName);
                param.AddWithValue("?bytes", send.MyFileSend.FileBytes);
                param.AddWithValue("?type", send.MyFileSend.FileType);
                param.AddWithValue("?shipping", send.Shipping);

                ok = insert.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                throw new Exception("Erro ao Inserir Arquivo: " + ex.Message);
            }
            finally
            {

                db.Close();
            }
			
			return (ok == 1);
		}

        internal MyFile GetFile(string shipping)
		{
            var myFile = new MyFile();
            var db = new Connection().Connect();
            try
			{
                db.Open();

				var select = new MySqlCommand("SELECT file_id, name, bytes , type FROM file WHERE shipping = ?shipping", db);
				select.Parameters.AddWithValue("?shipping", shipping);

                var dr = select.ExecuteReader();
                dr.Read();

                myFile = Load(dr);
                
            }
            catch (Exception ex)
			{
                throw new Exception("Erro ao Selecionar o Arquivo: " + ex.Message +": " + myFile.FileName + myFile.FileType);
            }
            finally
            {
                db.Close();
            }

			return myFile;
		}

        internal MyFile GetFileTest(string shipping)
        {
            var myFile = new MyFile();
            var db = new Connection().Connect();
            try
            {
                db.Open();

                var select = new MySqlCommand("SELECT file_id, name, bytes , type FROM file WHERE shipping = ?shipping", db);
                select.Parameters.AddWithValue("?shipping", shipping);

                var dr = select.ExecuteReader();
                dr.Read();

                myFile = Load(dr);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Selecionar o Arquivo: " + ex.Message + ": " + myFile.FileName + myFile.FileType);
            }
            finally
            {
                db.Close();
            }

            return myFile;
        }

        internal bool DeleteFile(int fileId)
        {
            int ok;
            var db = new Connection().Connect();
            try
            {
               
                db.Open();

                var delete = new MySqlCommand("DELETE FROM file WHERE file_id = ?", db);
                delete.Parameters.AddWithValue("@file_id", fileId);
               ok =  delete.ExecuteNonQuery();
                db.Close();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (ok == 1);

        }

    }
}
