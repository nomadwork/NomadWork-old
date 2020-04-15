using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClassTransfile
{
    [DataContract]
    public class File
    {
        [DataMember(IsRequired = true)]
        public int FileId { get; set; }

        [DataMember(IsRequired = true)]
        public double Size { get; set; }

        [DataMember(IsRequired = true)]
        public string FileName { get; set; }

        [DataMember(IsRequired = true)]
        public byte[] FileStringfied { get; set; }

        [DataMember(IsRequired = true)]
        public string FileType { get; set; }

    }
}
