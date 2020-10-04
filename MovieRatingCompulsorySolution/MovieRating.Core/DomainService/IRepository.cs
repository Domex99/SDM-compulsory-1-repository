using MovieRating.Core.Entity;
using System.Collections.Generic;
using System.Text;
namespace MovieRating.Core.DomainService
{
    public interface IRepository
    {
        IEnumerable<Reviews> GetAllReviews();
    }
}