using Microsoft.AspNetCore.Mvc;
using MyCompanyName.AbpZeroTemplate.Web.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

public class LoanContractsController : AbpZeroTemplateControllerBase
{
    private readonly LoanContractAppService _service;
    private readonly PersonAppService _personService;

    public LoanContractsController(
        LoanContractAppService service,
        PersonAppService personService)
    {
        _service = service;
        _personService = personService;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _service.GetAll();
        return View(data);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Persons = await _personService.GetAll();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(string title, int borrowerId, List<int> guarantorIds)
    {
        await _service.Create(title, borrowerId, guarantorIds);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var data = await _service.GetDetails(id);
        return View(data);
    }

}
