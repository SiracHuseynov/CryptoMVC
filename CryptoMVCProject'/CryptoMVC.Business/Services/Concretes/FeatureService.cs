using CryptoMVC.Business.Services.Abstracts;
using CryptoMVC.Core.Models;
using CryptoMVC.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMVC.Business.Services.Concretes
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task AddFeatureAsync(Feature feature)
        {
            await _featureRepository.AddAsync(feature);
            await _featureRepository.CommitAsync();
        }

        public void DeleteFeature(int id)
        {
            Feature existFeature = _featureRepository.Get(x => x.Id == id);

            if (existFeature == null)
                throw new NullReferenceException("Feature yoxdur!");

            _featureRepository.Delete(existFeature);
            _featureRepository.Commit();
        }

        public List<Feature> GetAllFeatures(Func<Feature, bool>? func = null)
        {
            return _featureRepository.GetAll(func);
        }

        public Feature GetFeature(Func<Feature, bool>? func = null)
        {
            return _featureRepository.Get(func);
        }

        public void UpdateFeature(int id, Feature newFeature)
        {
            Feature oldFeature = _featureRepository.Get(x=> x.Id == id);

            if (oldFeature == null)
                throw new NullReferenceException("Feature yoxdur!");

            oldFeature.Icon = newFeature.Icon;
            oldFeature.Title = newFeature.Title;
            oldFeature.Description = newFeature.Description;

            _featureRepository.Commit();
        }
    }
}
