using System;
using System.Collections.Generic;
using System.Text;
using TravelAssistbyTowsif.DAL.ChildRepos;
using TravelAssistbyTowsif.Entity.Models;

namespace TravelAssistbyTowsif.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IPlaceRepository _places;
        public IPlaceRepository places { get; private set; }


        private AuthenticationContext _dbContext;
        public UnitOfWork(AuthenticationContext dbContext)
        {
            _dbContext = dbContext;
            places = new PlaceReposotory(_dbContext);
        }


        public int Complete()
        {
            return _dbContext.SaveChanges(); 
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
