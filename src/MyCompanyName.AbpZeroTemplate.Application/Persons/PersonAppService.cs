using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class PersonAppService : ApplicationService
{
    private readonly IRepository<Person, int> _personRepository;

    public PersonAppService(IRepository<Person, int> personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<List<Person>> GetAll()
    {
        return await _personRepository.GetAll().ToListAsync();
    }

    public async Task<PersonDetailsDto> GetDetails(int personId)
    {
        var person = await _personRepository
            .GetAll()
            .Include(p => p.LoanContractPersons)
                .ThenInclude(lp => lp.LoanContract)
            .FirstOrDefaultAsync(p => p.Id == personId);

        if (person == null)
            throw new System.Exception("Person not found");

        var borrowerContracts = new List<LoanContract>();
        var guarantorContracts = new List<LoanContract>();

        foreach (var lp in person.LoanContractPersons)
        {
            if (lp.Role == PersonRole.Borrower)
                borrowerContracts.Add(lp.LoanContract);
            else if (lp.Role == PersonRole.Guarantor)
                guarantorContracts.Add(lp.LoanContract);
        }

        return new PersonDetailsDto
        {
            Id = person.Id,
            FullName = person.FullName,
            BorrowerContracts = borrowerContracts,
            GuarantorContracts = guarantorContracts
        };
    }

    public async Task Create(string fullName)
    {
        await _personRepository.InsertAsync(new Person
        {
            FullName = fullName
        });
    }
}
