using LibraryTrasfFile.locationClass;
using LibraryTrasfFile.myFileClass;
using LibraryTrasfFile.utils;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LibraryTrasfFile.userClass
{
    [DataContract]
	public class User
    { 
        [DataMember(Name = "userId", IsRequired = true)]
		public int UserId { get; set; }

		[DataMember(Name = "userName", IsRequired = true)]
		public string UserName { get; set; }

		[DataMember(Name = "fullName", IsRequired = true)]
		public string FullName { get; set; }

		[DataMember(Name = "configs", IsRequired = true)]
		public Configs UserConfig { get; set; }

		[DataMember(Name = "number", IsRequired = true)]
		public string Number { get; set; }

		[DataMember(Name = "email", IsRequired = true)]
		public string Email { get; set; }

		[DataMember(Name = "pass", IsRequired = true)]
		public string Pass { get; set; }

		[DataMember(Name = "userLocation", IsRequired = true)]
        public GeoLocation UserLocation { get; set; }

		[DataMember(Name = "files",IsRequired = true)]
		public List<MyFile> UserFiles { get; set; }
	}
}
