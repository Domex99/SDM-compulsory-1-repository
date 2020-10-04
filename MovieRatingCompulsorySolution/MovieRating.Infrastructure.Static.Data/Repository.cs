using MovieRating.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;
using MovieRating.Core.DomainService;
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
