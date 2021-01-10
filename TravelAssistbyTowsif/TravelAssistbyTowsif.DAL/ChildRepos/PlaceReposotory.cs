using System;
using System.Collections.Generic;
using System.Text;
using TravelAssistbyTowsif.DAL.BaseRepo;
using TravelAssistbyTowsif.Entity.Models;

namespace TravelAssistbyTowsif.DAL.ChildRepos
{
    public class PlaceReposotory : Repository<PlaceModel>, IPlaceRepository
    {
        public PlaceReposotory(AuthenticationContext dbContext) : base(dbContext) { }

        public AuthenticationContext dbCtx
        {
            get { return dbCtx as AuthenticationContext; }
        }



        public void AddPlace(PlaceModel place)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlaceModel> GetAllPlaces()
        {
            return dbCtx.Places;
        }

        public PlaceModel GetPlacebyId(int id)
        {
            throw new NotImplementedException();
        }

        public void RemovePlace(int id)
        {
            throw new NotImplementedException();
        }
    }
}
