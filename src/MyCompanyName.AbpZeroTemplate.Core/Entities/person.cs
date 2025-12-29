using Abp.Domain.Entities;
using System.Collections.Generic;

public class Person : Entity<int>
{
    public string FullName { get; set; }

    public ICollection<LoanContractPerson> LoanContractPersons { get; set; }
}
