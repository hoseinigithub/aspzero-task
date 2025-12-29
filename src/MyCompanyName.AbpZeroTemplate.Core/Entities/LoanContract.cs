using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

public class LoanContract : Entity<int>
{
    public string ContractTitle { get; set; }
    public DateTime ContractDate { get; set; }

    public ICollection<LoanContractPerson> LoanContractPersons { get; set; }
}
