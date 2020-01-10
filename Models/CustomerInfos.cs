using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CustomerInfos
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Disable{ get; set; }
    }
}
