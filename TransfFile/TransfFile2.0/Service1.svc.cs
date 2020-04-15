using System;
using System.Collections.Generic;
using System.ServiceModel;
using LibraryTrasfFile.locationClass;
using LibraryTrasfFile.myFileClass;
using LibraryTrasfFile.sendClass;
using LibraryTrasfFile.userClass;

namespace TransfFile2._0
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]

    public class Service1 : IService1
	{
       

        #region Teste
        public Send DownloadFileTest(string shipping)
        {
            try
            {
                return new SendController().SelectSend(shipping);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public User SelectUserTeste(string id)
        {
            try
            {
                return new UserController().SelectUserTeste(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region User

        public bool UserRegistration(User user)
        {
            try
            {
                return new UserController().UserRegistration(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Exit(User user)
        {
            try
            {
                return new UserController().DeleteUser(user.UserId);
            }
            catch (Exception ex)
            {



                throw new Exception(ex.Message);
            }
        }

        public User GetUser(string id)
        {
            try
            {
                return new UserController().GetUser(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<User> ListUser(string name)
        {
            try
            {
                return new UserController().ListUsers(name);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public User LoggIn(string userName, string pass)
        {
            try
            {
                return new UserController().LoggedUser(userName, pass);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
       
        public bool Dislog(User user)
        {
            try
            {
                return new UserController().Dislog(user.UserId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region File
        public List<Send> ListSends(string id)
        {
            try
            {
                return new SendController().ListSends(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool TransferFile(Send send)
        {
            try
            {
                return new MyFileController().SaveFile(send);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public MyFile DownloadFile(string send)
        {
            try
            {
                return new MyFileController().DownloadFile(send);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
       
        #endregion

        #region Location
        public List<GeoLocation> ListGeoLocation()
        {
            try
            {
                return new GeolocationController().ListLocation();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool InsertGeoLocation(GeoLocation location)
        {
            try
            {
                return new GeolocationController().InsertLocation(location);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool DeleteGeoLocation(string id)
        {
            try
            {
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public bool GetLocation(string id)
        {
            try
            {
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
