using System.Runtime.Serialization;

namespace LibraryTrasfFile.myFileClass
{
    [DataContract]
    public class MyFile
    {
        [DataMember(Name = "fileId", IsRequired = true)]
		public int FileId { get; set; }
        
		[DataMember(Name= "fileName", IsRequired = true)]
		public string FileName { get; set; }

		[DataMember(Name= "fileBytes", IsRequired = true)]
		public byte[] FileBytes { get; set; }

		[DataMember(Name = "fileType", IsRequired = true)]
		public string FileType { get; set; }

    }
}
