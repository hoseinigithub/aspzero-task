using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        //  ایجاد قرارداد
        var contract = await _loanRepo.InsertAsync(new LoanContract
        {
            ContractTitle = title,
            ContractDate = DateTime.Now
        });

        await CurrentUnitOfWork.SaveChangesAsync(); 

        //  اضافه کردن وام‌گیرنده
        await _relationRepo.InsertAsync(new LoanContractPerson
        {
            LoanContractId = contract.Id,
            PersonId = borrowerId,
            Role = " وام‌گیرنده"
        });

        //  اضافه کردن ضامن‌ها
        foreach (var gid in guarantorIds)
        {
            await _relationRepo.InsertAsync(new LoanContractPerson
            {
                LoanContractId = contract.Id,
                PersonId = gid,
                Role = "ضامن"
            });
        }
    }

}
