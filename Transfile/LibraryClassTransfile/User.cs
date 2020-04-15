using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClassTransfile
{
    [DataContract]
    public class User
    {
        [DataMember(IsRequired = true)]
        public int UserId { get; set; }

        [DataMember(IsRequired = true)]
        public string UserName { get; set; }

        [DataMember(IsRequired = true)]
        public Configs UserConfig { get; set; }

        [DataMember(IsRequired = true)]
        public GeoLocation UserLocation { get; set; }

        [DataMember(IsRequired = true)]
        public List<File> UserFiles { get; set; }
    }
}
