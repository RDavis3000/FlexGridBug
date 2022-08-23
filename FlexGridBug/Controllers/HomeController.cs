using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FlexGridBug.Models;
using C1.Web.Mvc;
using C1.Web.Mvc.Serialization;

namespace FlexGridBug.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

public async Task<IActionResult> GetRecords([C1JsonRequest] CollectionViewRequest<RecordModel> requestData)
{

    var records = new List<RecordModel>();

    for(int i = 0;i<100;i++)
    {
        records.Add(new RecordModel(){Id=i, Country="Australia",Value=$"Australia {i}"});
    }
        for(int i = 0;i<100;i++)
    {
        records.Add(new RecordModel(){Id=i, Country="USA",Value=$"USA {i}"});
    }
        for(int i = 0;i<100;i++)
    {
        records.Add(new RecordModel(){Id=i, Country="France",Value=$"France {i}"});
    }

    var temp2 = CollectionViewHelper.Read(requestData, records);
            
    var result =  this.C1Json(temp2);

    return result;

}

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
