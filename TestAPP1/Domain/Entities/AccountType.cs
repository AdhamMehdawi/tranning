namespace TestAPP1.Domain.Entities
{
    public class AccountType
    {
        public int Id { get; set; }
        public string AccountTypeName { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
