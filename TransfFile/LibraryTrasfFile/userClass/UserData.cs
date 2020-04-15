using LibraryTrasfFile.locationClass;
using LibraryTrasfFile.utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LibraryTrasfFile.userClass
{
    public class UserData
    {
        internal User SelectUserTeste(string id)
        {
            var db = new Connection().Connect();
            var user = new User();

            try
            {

                db.Open();

                var select = new MySqlCommand("SELECT user_id, name, email, full_name, pass, number, latUser, lngUser, active, visible, logged FROM user WHERE user_id = ?user_id", db);
                select.Parameters.AddWithValue("?user_id", id);

                var dr = select.ExecuteReader();
                dr.Read();

                user = Load(dr);

            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível Localizar este usuário!\n" + ex.Message);
            }
            finally
            {
                db.Close();
            }

            return user;

        }

        #region Load
        private User Load(MySqlDataReader dr)
        {
            return new User
            {
                UserId = int.Parse(dr["user_id"].ToString()),
                UserName = dr["name"].ToString().Trim(),
                Email = dr["email"].ToString().Trim(),
                FullName = dr["full_name"].ToString().Trim(),
                Pass = dr["pass"].ToString().Trim(),
                Number = dr["number"].ToString().Trim(),
                UserLocation = LoadLocation(dr),
                UserConfig = LoadConfigs(dr),
            };
        }
        private User LoadList(MySqlDataReader dr)
        {
            return new User
            {
                UserId = int.Parse(dr["user_id"].ToString()),
                UserName = dr["name"].ToString().Trim(),
                UserLocation = LoadLocation(dr),

            };
        }

        private User LoadToEdit(MySqlDataReader dr)
        {
            return new User
            {
                Email = dr["email"].ToString().Trim(),
                FullName = dr["full_name"].ToString().Trim(),
                Pass = dr["pass"].ToString().Trim(),
                Number = dr["number"].ToString().Trim(),
                UserLocation = LoadLocation(dr),
                UserConfig = LoadConfigs(dr)
            };
        }

        private GeoLocation LoadLocation(MySqlDataReader dr)
        {
            return new GeoLocation
            {
                Latitude = double.Parse(dr["latUser"].ToString()),
                Longitude = double.Parse(dr["lngUser"].ToString()),
            };
        }

        private Configs LoadConfigs(MySqlDataReader dr)
        {
            return new Configs
            {
                Visible = bool.Parse(dr["visible"].ToString()),
                Active = bool.Parse(dr["active"].ToString()),
                LoggedIn = bool.Parse(dr["logged"].ToString())


            };
        }
        #endregion

        #region Consults
        internal List<User> ListUsers()
        {
            var db = new Connection().Connect();
            var listUser = new List<User>();
            try
            {

                db.Open();

                var select = new MySqlCommand("SELECT user_id, name, latUser, lngUser FROM user WHERE logged = true AND active = true AND visible = true", db);
                select.ExecuteNonQuery();

                var dr = select.ExecuteReader();

                while (dr.Read())
                {
                    listUser.Add(LoadList(dr));
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Usuários: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
            return listUser;
        }

        internal User GetUser(string id)
        {
            var db = new Connection().Connect();
            var user = new User();

            try
            {

                db.Open();

                var select = new MySqlCommand("SELECT email, full_name, pass, number, latUser, lngUser, visible, active FROM user WHERE user_id = ?user_id", db);
                select.Parameters.AddWithValue("?user_id", id);

                var dr = select.ExecuteReader();
                dr.Read();

                user = LoadToEdit(dr);

            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível Obter um usuário: " + id + "!\n" + ex.Message);
            }
            finally
            {
                db.Close();
            }

            return user;

        }
        #endregion

        #region Verification
        internal bool NameUserExists(string name,int id)
        {
            var ok = false;
            var db = new Connection().Connect();
            try
            {
                db.Open();
                var select = new MySqlCommand("SELECT COUNT(name) AS 'existis' FROM user WHERE name = ?name and user_id != ?user_id", db);
                select.Parameters.AddWithValue("?name", name);
                select.Parameters.AddWithValue("?user_id", id);

                var dr = select.ExecuteReader();
                dr.Read();

                ok = !dr["existis"].ToString().Trim().Equals("0");
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Verificar nome de usuários!\n" + ex.Message);
            }
            finally
            {
                db.Close();
            }


            return ok;
        }

        #endregion

        #region Login

        internal void StatusOn(string name, string pass)
        {
            var db = new Connection().Connect();
            try
            {
                db.Open();
                var update = new MySqlCommand("UPDATE user SET logged = true WHERE name = ?name and pass = ?pass and active = true", db);

                var param = update.Parameters;
                update.Parameters.AddWithValue("?name", name);
                update.Parameters.AddWithValue("?pass", pass);
                update.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Aletar status!\n" + ex.Message);
            }
            finally
            {
                db.Close();
            }

        }

        internal User Login(string name, string pass)
        {
            var user = new User();
            var db = new Connection().Connect();

            try
            {
                db.Open();
                var select = new MySqlCommand("SELECT user_id, name, email, full_name, pass, number, latUser, lngUser, active, visible, logged FROM user WHERE name = ?name and pass = ?pass and active = true", db);
                select.Parameters.AddWithValue("?name", name);
                select.Parameters.AddWithValue("?pass", pass);

                var dr = select.ExecuteReader();

                if (!dr.Read())
                {
                    throw new Exception("Não foi possível Logar com o usuário: " + name + "!\nEste usuário não existe");
                }
                else
                {
                    user = Load(dr);
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível Logar com o usuário: " + name + "!\n" + ex.Message);
            }
            finally
            {
                db.Close();

            }

            return user;
        }

        internal bool Logout(int id)
        {
            int ok;
            var db = new Connection().Connect();

            try
            {
                db.Open();

                var update = new MySqlCommand("UPDATE user SET logged = false WHERE user_id = ?user_id", db);
                update.Parameters.AddWithValue("?user_id", id);

                ok = update.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao deslogar Usuário!\n" + ex.Message);
            }
            finally
            {
                db.Close();

            }

            return (ok == 1);
        }

        #endregion

        internal bool InsertUser(User user)
        {
            var db = new Connection().Connect();
            int ok;

            try
            {
                db.Open();
                
                    var insert = new MySqlCommand("INSERT INTO user(user_id, name, email, full_name, pass, number, latUser, lngUser, active, visible, logged) " +
                        " VALUES (?user_id,?name,?email,?full_name,?pass,?number,?latUser,?lngUser, ?active,?visible,?logged)", db);
                    var param = insert.Parameters;

                    param.AddWithValue("?user_id", user.UserId);
                    param.AddWithValue("?name", user.UserName);
                    param.AddWithValue("?email", user.Email);
                    param.AddWithValue("?full_name", user.FullName);
                    param.AddWithValue("?pass", user.Pass);
                    param.AddWithValue("?number", user.Number);
                    param.AddWithValue("?latUser", user.UserLocation.Latitude);
                    param.AddWithValue("?lngUser", user.UserLocation.Longitude);
                    param.AddWithValue("?active", user.UserConfig.Active);
                    param.AddWithValue("?visible", user.UserConfig.Visible);
                    param.AddWithValue("?logged", user.UserConfig.LoggedIn);

                ok = insert.ExecuteNonQuery();
               


            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir Usuário!\n" + ex.Message);

            }
            finally
            {
                db.Close();
            }

            return (ok == 1);

        }

        internal bool UpdateUser(User user)
        {
            var db = new Connection().Connect();
            int ok;

            try
            {
                db.Open();

                var update = new MySqlCommand("UPDATE user SET email = ?email, full_name = ?full_name, number = ?number, " +
                    "latUser = ?latUser, lngUser = ?lngUser,  active=?active, visible=?visible, logged=?logged, pass=?pass " +
                    "WHERE user_id = ?user_id", db);

                var param = update.Parameters;
                param.AddWithValue("?user_id", user.UserId);
                param.AddWithValue("?email", user.Email);
                param.AddWithValue("?full_name", user.FullName);
                param.AddWithValue("?number", user.Number);
                param.AddWithValue("?latUser", user.UserLocation.Latitude);
                param.AddWithValue("?lngUser", user.UserLocation.Longitude);
                param.AddWithValue("?pass", user.Pass);
                param.AddWithValue("?active", user.UserConfig.Active);
                param.AddWithValue("?visible", user.UserConfig.Visible);
                param.AddWithValue("?logged", user.UserConfig.LoggedIn);

                ok = update.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Aletar Usuário!\n" + ex.Message);
            }
            finally
            {
                db.Close();
            }

            return (ok == 1);
        }

        internal bool DeleteUser(int id)
        {
            var db = new Connection().Connect();
            int ok;

            try
            {
                db.Open();

                var delete = new MySqlCommand("UPDATE user SET active = false, visible = false WHERE user_id = ?user_id", db);

                var param = delete.Parameters;
                param.AddWithValue("?user_id", id);

                ok = delete.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Deletar Usuário!\n" + ex.Message);
            }
            finally
            {
                db.Close();
            }

            return (ok == 1);
        }
    }
}
