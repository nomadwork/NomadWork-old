using LibraryTrasfFile.locationClass;
using LibraryTrasfFile.myFileClass;
using LibraryTrasfFile.sendClass;
using LibraryTrasfFile.userClass;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TransfFile2._0
{
    [ServiceContract]
    public interface IService1
    {
        #region Testes
        [OperationContract]
        [WebInvoke(Method = "GET",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedResponse,
         UriTemplate = "/test/user/id={id}")]
        User SelectUserTeste(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedResponse,
        UriTemplate = "/test/send={send}")]
        Send DownloadFileTest(string send);
        #endregion

        #region User
        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedResponse,
        UriTemplate = "/login/user={userName}/pass={pass}")]
        User LoggIn(string userName, string pass);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedResponse,
        UriTemplate = "/registration-user")]
        bool UserRegistration(User user);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedResponse,
        UriTemplate = "/getuser/id={id}")]
        User GetUser(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedResponse,
        UriTemplate = "/logout")]
        bool Dislog(User user);

        [OperationContract]
        [WebInvoke(Method = "PUT",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedResponse,
        UriTemplate = "/exit")]
        bool Exit(User user);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedResponse,
        UriTemplate = "/listuser?name={name}")]
        List<User> ListUser(string name);
        #endregion

        #region File
        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedResponse,
         UriTemplate = "/transfer")]
        bool TransferFile(Send send);

        [OperationContract]
        [WebInvoke(Method = "GET",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedResponse,
         UriTemplate = "/sends/id={id}")]
         List<Send> ListSends(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedResponse,
         UriTemplate = "/downloads/shipping={shipping}")]
        MyFile DownloadFile(string shipping);
        #endregion

        #region Location
        [OperationContract]
        [WebInvoke(Method = "GET",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedResponse,
         UriTemplate = "/listlocation")]
        List<GeoLocation> ListGeoLocation();

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //ResponseFormat = WebMessageFormat.Json,
        //RequestFormat = WebMessageFormat.Json,
        //BodyStyle = WebMessageBodyStyle.WrappedResponse,
        //UriTemplate = "/listlocation")]
        //List<GeoLocation> GetLocation(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedResponse,
         UriTemplate = "/newlocation")]
        bool InsertGeoLocation(GeoLocation location);

        [OperationContract]
        [WebInvoke(Method = "PUT",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedResponse,
        UriTemplate = "/del-location/id={id}")]
        bool DeleteGeoLocation(string id);
        #endregion

    }

}
