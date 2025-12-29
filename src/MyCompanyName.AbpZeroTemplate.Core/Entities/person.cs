using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

public class Person : FullAuditedEntity<int>
{
    public string FullName { get; set; }

    public virtual ICollection<LoanContractPerson> LoanContractPersons { get; set; }
}
