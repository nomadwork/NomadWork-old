using LibraryTrasfFile.myFileClass;
using LibraryTrasfFile.userClass;
using System;
using System.Runtime.Serialization;

namespace LibraryTrasfFile.sendClass
{
    [DataContract]
    public class Send
    {
        [DataMember(Name = "emissary", IsRequired = true)]
        public User Emissary { get; set; }

        [DataMember(Name = "destinatary", IsRequired = true)]
        public User Destinatary { get; set; }
       
        [DataMember(Name = "fileSend", IsRequired = true)]
        public MyFile MyFileSend { get; set; }

        [DataMember(Name = "shipping")]
        public string Shipping { get; set; }

        public string GetShipping()
        {
            this.Shipping = Emissary.UserId + DateTime.Now.ToString("yyyyMMddHHmmss") + Destinatary.UserId;
            return this.Shipping;
        }
    }
     
}
