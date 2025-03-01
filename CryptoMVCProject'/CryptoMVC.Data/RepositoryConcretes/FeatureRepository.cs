using CryptoMVC.Core.Models;
using CryptoMVC.Core.RepositoryAbstracts;
using CryptoMVC.Data.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMVC.Data.RepositoryConcretes
{
    public class FeatureRepository : GenericRepository<Feature>, IFeatureRepository
    {
        public FeatureRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
