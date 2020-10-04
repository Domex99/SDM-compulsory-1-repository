using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieRating.Core.DomainService;
using MovieRating.Core.Entity;

namespace MovieRating.Core.ApplicationService.Implementation
{
    public class Service : IService
    {
        IRepository _repo;
        public Service(IRepository repo)
        {
            _repo = repo;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            double avg = 0.0;
            var totalRating = 0.0;
            List<Reviews> result = new List<Reviews>();
            List<Reviews> reviews = _repo.GetAllReviews().ToList();
            foreach (Reviews r in reviews)
            {
                if (r.ReviewerId == reviewer)
                {
                    result.Add(r);
                    totalRating += r.Rating;
                }
            }
            if (result.Count == 0)
            {
                throw new ArgumentException($"No reviews for reviewer with id {reviewer} were found, so an average is not applicable");
            }
            else
            {
                avg = totalRating / result.Count();
                avg = Math.Round(avg, 2);
            }
            return avg;
        }

        public double GetAverageRateOfMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public List<int> GetMostProductiveReviewers()
        {
            throw new NotImplementedException();
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfReviews(int movie)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            throw new NotImplementedException();
        }

    }
}
