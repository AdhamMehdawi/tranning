using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPP1.Core.Models
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string AccoutName { get; set; }
        public string AccountNumber { get; set; }
        public DateTime CreateDateTime { get; set; } 
        public int StudentId { get; set; } 
    }
}
