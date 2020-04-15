using LibraryTrasfFile.myFileClass;
using LibraryTrasfFile.userClass;
using LibraryTrasfFile.utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LibraryTrasfFile.sendClass
{
    internal class SendData
    {

        #region Load
        private Send Load(MySqlDataReader dr)
        {
            User emissary = new User
            {
                UserId = int.Parse(dr["emissary"].ToString().Trim()),
            };

            User destinatary = new User
            {
                UserId = int.Parse(dr["destinatary"].ToString().Trim()),
            };

            MyFile myfile = new MyFile
            {
                FileBytes = (byte[])(dr["bytes"]),
                FileType = dr["type"].ToString().Trim(),
                FileId = int.Parse(dr["file_id"].ToString().Trim()),
                FileName = dr["name"].ToString().Trim(),
            };
            return new Send
            {
                Emissary = emissary,
                Destinatary = destinatary,
                MyFileSend = myfile,
                Shipping = dr["shipping"].ToString().Trim(),
            };
        }

        private Send LoadSend(MySqlDataReader dr)
        {
            User emissary = new User
            {
                UserName = dr["name_emissary"].ToString().Trim()
            };
            MyFile file = new MyFile
            {
                FileName = dr["name_file"].ToString().Trim(),
                FileType = dr["type"].ToString().Trim()
            };

            return new Send
            {
                Emissary = emissary,
                MyFileSend = file,
                Shipping = dr["shipping"].ToString().Trim(),
            };
        }
        #endregion

        internal bool InsertSend(Send send)
        {
            int ok;
            var db = new Connection().Connect();
            try
            {
                db.Open();

                var insert = new MySqlCommand("INSERT INTO send( emissary, destinatary, shipping) " +
                    "VALUES (?emissary,?destinatary,?shipping)", db);

                var param = insert.Parameters;
                param.AddWithValue("?emissary", send.Emissary.UserId);
                param.AddWithValue("?destinatary", send.Destinatary.UserId);
                param.AddWithValue("?shipping", send.GetShipping());

               ok = insert.ExecuteNonQuery();
              
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Gerar emissão: " + ex.Message);
            }
            finally
            {
                db.Close();
            }

            return (ok == 1);

        }

        internal List<Send> ListSends(int id)
        {
            var list = new List<Send>();
            var db = new Connection().Connect();

            try
            {
                db.Open();
                var select = new MySqlCommand("SELECT user.name as 'name_emissary',send.shipping , file.name as 'name_file', file.type FROM send" +
                    " INNER JOIN user ON send.emissary = user.user_id INNER JOIN file ON send.shipping = file.shipping" +
                    " WHERE send.destinatary = ?id_user ORDER by send.send_id DESC LIMIT 3", db);
                select.Parameters.AddWithValue("?id_user",id);

                var dr = select.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(LoadSend(dr));
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return list;
        }


        internal Send SelectSend(string shipping)
        {
            var send = new Send();
            var db = new Connection().Connect();
            try
            {
               
                db.Open();

                var select = new MySqlCommand("SELECT emissary, destinatary, send.shipping, file_id, name, bytes, type " +
                    "FROM send inner join file on send.shipping = file.shipping WHERE send.shipping = ?shipping", db);
                select.Parameters.AddWithValue("?shipping", shipping);

                var dr = select.ExecuteReader();
                dr.Read();

                send = Load(dr);

                db.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                db.Close();
            }

            return send;
        }

    }
}

