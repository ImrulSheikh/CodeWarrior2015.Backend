using System.ComponentModel.DataAnnotations;

namespace CW.Backend.Service.Authentication.Models
{
    public class Profile:BaseCoreEntity
    {
        [Key]
        public string Id { get; set; }
        public string ProfileType { get; set; }
        public int ItemSoldPurchased { get; set; }
        public string Address { get; set; }
    }
}