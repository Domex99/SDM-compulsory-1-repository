using MovieRating.Core.DomainService;
using System.Collections.Generic;
using MovieRating.Core.Entity;

namespace MovieRating.Infrastructure.Static.Data
{

    public class Repository : IRepository
    {
        List<Reviews> reviews;

        public Repository()
        {
            reviews = new List<Reviews>();
        }


        public IEnumerable<Reviews> GetAllReviews()
        {
            return new List<Reviews>(reviews);
        }
    };

}
