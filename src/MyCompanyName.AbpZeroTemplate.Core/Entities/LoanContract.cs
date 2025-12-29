using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

public class LoanContract : FullAuditedEntity<int>
{
    public string ContractTitle { get; set; }
    public DateTime ContractDate { get; set; }

    public virtual ICollection<LoanContractPerson> LoanContractPersons { get; set; }
}
