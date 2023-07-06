using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPP1.Domain.Entities
{
    [Table("Account"  )]
    public class Account
    {
        public int  Id { get; set; }
        public string  AccoutName { get; set; }
        public string  AccountNumber { get; set; }
        public DateTime  CreateDateTime { get; set; }
        [ForeignKey("StudentId")]
        public int  StudentId { get; set; }
       
        public Student Student { get; set; }
        public int AccountTypeId { get; set; }
        public AccountType AccountType {get; set; }

}
}
