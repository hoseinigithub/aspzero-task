using Abp.Application.Services;
using Abp.Domain.Repositories;
using System.Collections.Generic;
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
        return await _personRepository.GetAllListAsync();
    }

    public async Task Create(string fullName)
    {
        await _personRepository.InsertAsync(new Person
        {
            FullName = fullName
        });
    }
}
