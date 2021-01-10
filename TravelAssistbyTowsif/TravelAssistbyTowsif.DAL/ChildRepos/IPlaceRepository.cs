using System;
using System.Collections.Generic;
using System.Text;
using TravelAssistbyTowsif.DAL.BaseRepo;
using TravelAssistbyTowsif.Entity.Models;

namespace TravelAssistbyTowsif.DAL.ChildRepos
{
    public interface IPlaceRepository : IRepository<PlaceModel>
    {
        IEnumerable<PlaceModel> GetAllPlaces();
        PlaceModel GetPlacebyId(int id);
        void AddPlace(PlaceModel place);
        void RemovePlace(int id);
    }
}
