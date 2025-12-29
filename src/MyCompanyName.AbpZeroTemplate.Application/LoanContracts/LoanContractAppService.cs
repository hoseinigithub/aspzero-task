using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class LoanContractAppService : ApplicationService
{
    private readonly IRepository<LoanContract, int> _loanRepo;
    private readonly IRepository<LoanContractPerson, int> _relationRepo;

    public LoanContractAppService(
        IRepository<LoanContract, int> loanRepo,
        IRepository<LoanContractPerson, int> relationRepo)
    {
        _loanRepo = loanRepo;
        _relationRepo = relationRepo;
    }

    public async Task<List<LoanContract>> GetAll()
    {
        return await _loanRepo
            .GetAll()
            .Include(x => x.LoanContractPersons)
                .ThenInclude(x => x.Person)
            .ToListAsync();
    }

    public async Task Create(string title, int borrowerId, List<int> guarantorIds)
    {
        var contract = await _loanRepo.InsertAsync(new LoanContract
        {
            ContractTitle = title,
            ContractDate = DateTime.Now
        });


        await CurrentUnitOfWork.SaveChangesAsync();

        await _relationRepo.InsertAsync(new LoanContractPerson
        {
            LoanContractId = contract.Id,
            PersonId = borrowerId,
            Role = PersonRole.Borrower
        });


        foreach (var gid in guarantorIds)
        {
            await _relationRepo.InsertAsync(new LoanContractPerson
            {
                LoanContractId = contract.Id,
                PersonId = gid,
                Role = PersonRole.Guarantor
            });
        }
    }

    public async Task<LoanContractDetailsDto> GetDetails(int contractId)
    {
        var contract = await _loanRepo
            .GetAll()
            .Include(c => c.LoanContractPersons)
                .ThenInclude(lp => lp.Person)
            .FirstOrDefaultAsync(c => c.Id == contractId);

        if (contract == null)
            throw new Exception("Contract not found");

        return new LoanContractDetailsDto
        {
            Id = contract.Id,
            ContractTitle = contract.ContractTitle,
            ContractDate = contract.ContractDate,
            Persons = contract.LoanContractPersons
                .Select(lp => new LoanContractPersonDto
                {
                    PersonId = lp.PersonId,
                    FullName = lp.Person.FullName,
                    Role = lp.Role
                }).ToList()
        };
    }

}
