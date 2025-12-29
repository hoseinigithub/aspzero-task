using System;
using System.Collections.Generic;

public class LoanContractDetailsDto
{
    public int Id { get; set; }
    public string ContractTitle { get; set; }
    public DateTime ContractDate { get; set; }

    public List<LoanContractPersonDto> Persons { get; set; }
}

