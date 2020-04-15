using LibraryClassTransfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TransfileService
{

    [ServiceContract]
    public interface IServiceTransfile
    {
        [OperationContract]
        void CreateUser(User user);
        [OperationContract]
        void UpdateUser(User user);

        [OperationContract]
        void DeleteUser(User user);

        [OperationContract]
        List<User> ListUser();

        [OperationContract]
        bool VerifyUser(User user);

        [OperationContract]
        void LoggIn(User user);



        [OperationContract]
        void InsertFile(File file);

        [OperationContract]
        void UpdateFile(File file);

        [OperationContract]
        List<File> ListFIle();

        [OperationContract]
        void DeleteFile(File file);

        [OperationContract]
        File TransferFile(File file);

    }
}
