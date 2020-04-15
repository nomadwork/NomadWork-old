using LibraryTrasfFile.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LibraryTrasfFile.userClass
{
    public class UserController
    {
        private User VerifyUser(User user)
        {
            if (new UserData().NameUserExists(user.UserName, user.UserId))
            {
                throw new Exception("Não foi possível Cadastrar usuário!\n" +
                    user.UserName + " já está em uso!\n" +
                    "Escolha outro nome de usuário!");
            }

            if (user.UserName.Length < 6)
            {
                throw new Exception("Não foi possível Cadastrar usuário!\n" +
                    user.UserName + " é muito curto!\n" +
                    "Escolha um nome de usuário com no mínimo 6 e no máximo 20!");
            }

            if (user.UserName.Length > 20)
            {
                throw new Exception("Não foi possível Cadastrar usuário!\n" +
                     user.UserName + " é muito curto!\n" +
                     "Escolha um nome de usuário com no mínimo 6 e no máximo 20!");
            }

            if (user.UserName.Contains("  "))
            {
                throw new Exception("Não foi possível Cadastrar usuário!\n" +
                     user.UserName + " é muito curto!\n" +
                     "Escolha um nome de usuário com no mínimo 6 e no máximo 20!");
            }

            if (Regex.IsMatch(user.UserName, (@"[^a-zA-Z0-9]")))
            {
                throw new Exception("Não foi possível Cadastrar usuário!\n" +
                 user.UserName + "Não utilize caracteres especiais ou acentos!\n" +
                 "Escolha um nome de usuário com no mínimo 6 e no máximo 20!");
            }

            if (user.Pass.Length < 8)
            {
                throw new Exception("Não foi possível Cadastrar usuário!\n" +
                   "Esta senha é muito curta!\n" +
                   "Escolha uma senha de usuário com no mínimo 8 caracteres!");
            }

            if (user.Pass.Length > 45)
            {
                throw new Exception("Não foi possível Cadastrar usuário!\n" +
                   "Esta senha é muito Grande!\n" +
                   "Escolha uma senha de usuário com no mínimo 8 caracteres e no máximo 45!");
            }

            if (!user.Email.Contains("@") || !user.Email.Contains("."))
            {
                throw new Exception("Não foi possível Cadastrar usuário!\n" +
                   "Este endereço de email não é válido!");
            }

            if (string.IsNullOrWhiteSpace(user.FullName))
            {
                throw new Exception("Não foi possível Cadastrar usuário!\n" +
                  user.FullName + " não é um nome válido!");
            }

            if (!user.FullName.Contains(" ") )
            {
                throw new Exception("Não foi possível Cadastrar usuário!\n" +
                  user.FullName + " não é um nome válido!");
            }

            if (user.FullName.Contains("  "))
            {
                throw new Exception("Não foi possível Cadastrar usuário!\n" +
                     user.UserName + " possui múltiplos espaços!\n");
            }

            if (user.UserConfig == null)
            {
                throw new Exception("Não foi possível Cadastrar usuário!\n" +
                 "Informe as configurações de visibilidade!");
            }

            if (user.UserConfig.Visible && user.UserLocation == null)
            {
                throw new Exception("Não foi possível Cadastrar usuário!\n" +
                 "Informe a localização padrão do usuário!");
            }


            return user;
        }

        public User GetUser(string id)
        {
            try
            {
                return new UserData().GetUser(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool DeleteUser(int id)
        {
            var ok = false;

            try
            {
                ok = new UserData().DeleteUser(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return ok;

        }

        public bool UserRegistration(User user)
        {
            var ok = false;
            var data = new UserData();

            try
            {
                if (user.UserId == 0)
                {
                    ok = data.InsertUser(VerifyUser(user));
                    Log.LogIt(user,"add");
                }
                else
                {
                    ok = data.UpdateUser(VerifyUser(user));
                    Log.LogIt(user, "edit");
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return ok;

        }

        public User LoggedUser(string userName, string pass)
        {
            var dUser = new UserData();
            try
            {
                dUser.StatusOn(userName, pass);
                var user = dUser.Login(userName, pass);
                Log.LogIt(user,"in");
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool Dislog(int id)
        {
            var user = new UserData().Logout(id);
            Log.LogIt(id,"out");
            return user;
        }

        public List<User> ListUsers(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new UserData().ListUsers();
            }
            else
            {
                return new UserData().ListUsers().Where(c => c.UserName.Contains(name)).ToList();
            }
        }

        public User SelectUserTeste(string id)
        {
            try
            {
                return new UserData().SelectUserTeste(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
