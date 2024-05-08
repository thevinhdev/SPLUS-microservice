using SPLUS.Common.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Common.Application.Services
{
    public interface IFeatureService
    {
        Task<Feature> GetFeatureById(int featureId);
    }
    public class FeatureService : IFeatureService
    {
        private readonly CommonContext _dbContext;

        public FeatureService(CommonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Feature> GetFeatureById(int featureId)
        {
            var feature = _dbContext.Features.Where(x => x.Id == featureId).First();
            return feature;
        }
    }
}
