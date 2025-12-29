using Abp.Domain.Entities;

public class LoanContractPerson : Entity<int>
{
    public int PersonId { get; set; }
    public Person Person { get; set; }

    public int LoanContractId { get; set; }
    public LoanContract LoanContract { get; set; }
    public string Role { get; set; } 
}
