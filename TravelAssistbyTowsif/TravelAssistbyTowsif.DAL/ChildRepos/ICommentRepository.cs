using System;
using System.Collections.Generic;
using System.Text;
using TravelAssistbyTowsif.DAL.BaseRepo;
using TravelAssistbyTowsif.Entity.Models;

namespace TravelAssistbyTowsif.DAL.ChildRepos
{
    public interface ICommentRepository : IRepository<CommentModel>
    {
        IEnumerable<CommentModel> GetAllComments();
        CommentModel GetCommentbyId(int id);
        void AddComment(CommentModel comment);
        void RemoveComment(int id);
    }
}
