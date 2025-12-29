using System.Collections.Generic;

public class PersonDetailsDto
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public List<LoanContract> BorrowerContracts { get; set; }
    public List<LoanContract> GuarantorContracts { get; set; }
}
