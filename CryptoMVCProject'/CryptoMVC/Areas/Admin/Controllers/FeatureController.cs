using CryptoMVC.Business.Services.Abstracts;
using CryptoMVC.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CryptoMVC.Areas.Admin.Controllers
{
    [Area("Admin")] 
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IActionResult Index()
        {
            List<Feature> features = _featureService.GetAllFeatures();
            return View(features);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Feature feature)
        {
            await _featureService.AddFeatureAsync(feature);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var feature = _featureService.GetFeature(x => x.Id == id);

            if (feature == null)
                return NotFound();

            return View(feature);
        }


        [HttpPost]
        public IActionResult Update(int id, Feature newFeature)
        {
            var feature = _featureService.GetFeature(x => x.Id == id);

            if (feature == null)
                return NotFound();

            _featureService.UpdateFeature(id, newFeature);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var existProduct = _featureService.GetFeature(x => x.Id == id);

            if (existProduct == null)
                return NotFound();

            return View(existProduct);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _featureService.DeleteFeature(id);
          
            return RedirectToAction("Index");
        }


    }
}
