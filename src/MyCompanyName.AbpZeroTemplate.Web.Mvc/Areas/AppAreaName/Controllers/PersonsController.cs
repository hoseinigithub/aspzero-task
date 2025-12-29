using Microsoft.AspNetCore.Mvc;
using MyCompanyName.AbpZeroTemplate.Web.Controllers;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Controllers;

  [Area("AppAreaName")]
    public class PersonsController : AbpZeroTemplateControllerBase
{
    private readonly PersonAppService _personAppService;

    public PersonsController(PersonAppService personAppService)
    {
        _personAppService = personAppService;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _personAppService.GetAll();
        return View(data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(string fullName)
    {
        await _personAppService.Create(fullName);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var data = await _personAppService.GetDetails(id);
        return View(data);
    }
}
