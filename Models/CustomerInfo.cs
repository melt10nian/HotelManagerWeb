using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CustomerInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}