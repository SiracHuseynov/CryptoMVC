using CryptoMVC.Business.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CryptoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeatureService _featureService;

        public HomeController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IActionResult Index()
        {
            var datas = _featureService.GetAllFeatures();
            return View(datas);
        }

    }
}
