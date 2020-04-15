using System.Runtime.Serialization;

namespace LibraryTrasfFile.locationClass
{
    [DataContract]
    public class GeoLocation
	{
        
        [DataMember(Name = "locationId", IsRequired = true)]
		public int LocationId { get; set; }

		[DataMember(Name = "wifi", IsRequired = true)]
		public string Wifi { get; set; }

		[DataMember(Name = "energy", IsRequired = true)]
		public string Energy { get; set; }

		[DataMember(Name = "noise", IsRequired = true)]
		public string Noise { get; set; }

		[DataMember(Name = "price", IsRequired = true)]
		public string Price { get; set; }

		[DataMember(Name = "locationName", IsRequired = true)]
		public string LocationName { get; set; }

		[DataMember(Name = "latitude", IsRequired = true)]
		public double Latitude { get; set; }

		[DataMember(Name = "longitude", IsRequired = true)]
		public double Longitude { get; set; }
		
	}
}
