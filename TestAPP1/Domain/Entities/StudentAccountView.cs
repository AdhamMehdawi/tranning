using Microsoft.Identity.Client;

namespace TestAPP1.Domain.Entities
{
  
    public class StudentAccountView
    {
        public string AccoutName { get; set; }
        public string AccountNumber { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int AccountId { get; set; }  
    }
}
