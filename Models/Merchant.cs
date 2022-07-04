using System.ComponentModel.DataAnnotations;

namespace AndelaTest.Models
{
    public class Merchant
    {
        [Key]
         public int Id { get; set; }
        public string? Name { get; set; }
        public MerchatType? MerchatType  { get; set; }
        public string? PhoneNumber { get; set; }

         public DateTime DateCreated { get; set; }
    }

    public enum MerchatType
    {
       cloths,
         electronics,
    }
}