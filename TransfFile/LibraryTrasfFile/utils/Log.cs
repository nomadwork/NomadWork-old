using LibraryTrasfFile.myFileClass;
using LibraryTrasfFile.sendClass;
using LibraryTrasfFile.userClass;
using MySql.Data.MySqlClient;
using System;

namespace LibraryTrasfFile.utils
{
    public static class Log
    {
        static internal void LogIt(int userId, string moment)
        {
            SaveLog(userId,moment);
            
        }

        static internal void LogIt(User user, string moment)
        {
            SaveLog(user.UserId,moment);

        }
        
        static internal void LogIt(Send send, string moment)
        {
            SaveLog(send.Emissary.UserId,moment);
           
        }

        static private void SaveLog(int userId, string moment)
        {

            var db = new Connection().Connect();
            try
            {
                db.Open();
                var insert = new MySqlCommand("INSERT INTO log(user, event) VALUES (?user,?event)", db);

                var param = insert.Parameters;
                param.AddWithValue("?user",userId);
                param.AddWithValue("?event", moment);

                insert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Gerar emissão: " + ex.Message);
            }
            finally
            {
                db.Close();
            }

        }
    }
}
