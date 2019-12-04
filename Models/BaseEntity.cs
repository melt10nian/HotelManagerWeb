using System;
using System.Runtime.Serialization;

namespace Models
{
    public class BaseEntity
    {
        [DataMember]
        public DateTime CreateOn { get; set; }
        [DataMember]
        public DateTime ModifyOn { get; set; }
        [DataMember]
        public string Creater { get; set; }
        [DataMember]
        public string Modifyer { get; set; }
        [DataMember]
        public string Remark { get; set; }
    }
}