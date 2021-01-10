using System;
using System.Collections.Generic;
using System.Text;
using TravelAssistbyTowsif.DAL.BaseRepo;
using TravelAssistbyTowsif.Entity.Models;

namespace TravelAssistbyTowsif.DAL.ChildRepos
{
    public class CommentRepository : Repository<CommentModel>, ICommentRepository
    {
        public CommentRepository(AuthenticationContext dbContext) : base(dbContext) { }

        public AuthenticationContext dbCtx
        {
            get { return dbCtx as AuthenticationContext; }
        }

        public void AddComment(CommentModel comment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentModel> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public CommentModel GetCommentbyId(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveComment(int id)
        {
            throw new NotImplementedException();
        }
    }
}
