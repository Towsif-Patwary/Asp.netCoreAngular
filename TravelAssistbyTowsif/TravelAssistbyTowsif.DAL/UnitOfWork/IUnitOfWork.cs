using System;
using System.Collections.Generic;
using System.Text;
using TravelAssistbyTowsif.DAL.ChildRepos;

namespace TravelAssistbyTowsif.DAL.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IPlaceRepository places { get; }
        int Complete();
    }
}
