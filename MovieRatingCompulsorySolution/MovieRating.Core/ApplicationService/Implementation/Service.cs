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
                throw new ArgumentException($"No reviews for reviewer with id {reviewer} were found, ");
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
            double avg = 0.0;
            var totalMovieRating = 0.0;
            List<Reviews> result = new List<Reviews>();
            List<Reviews> reviews = _repo.GetAllReviews().ToList();
            foreach (Reviews r in reviews)
            {
                if (r.AssociatedMovieId == movie)
                {
                    result.Add(r);
                    totalMovieRating += r.Rating;
                }
            }
            if (result.Count == 0)
            {
                throw new ArgumentException($"No reviews for reviewer with id {movie} were found");
            }
            else
            {
                avg = totalMovieRating / result.Count();
                avg = Math.Round(avg, 2);
            }
            return avg;
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
            List<Reviews> result = new List<Reviews>();
            List<Reviews> reviews = _repo.GetAllReviews().ToList();
            if (rate < 1 || rate > 5)
            {
                throw new ArgumentException("Pick a number between 1-5");
            }
            foreach (Reviews r in reviews)
            {
                if (r.AssociatedMovieId == movie && r.Rating == rate)
                {
                    result.Add(r);
                }
            }
            return result.Count;
        }
        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            List<Reviews> result = new List<Reviews>();
            List<Reviews> reviews = _repo.GetAllReviews().ToList();
            foreach (Reviews r in reviews)
            {
                if (r.ReviewerId == reviewer && r.Rating == rate)
                {
                    result.Add(r);
                }
            }
            return result.Count;
        }

        public int GetNumberOfReviews(int movie)
        {
            List<Reviews> result = new List<Reviews>();
            List<Reviews> reviews = _repo.GetAllReviews().ToList();
            foreach (Reviews r in reviews)
            {
                if (r.AssociatedMovieId == movie)
                {
                    result.Add(r);
                }
            }
            return result.Count;
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            List<Reviews> result = new List<Reviews>();
            List<Reviews> reviews = _repo.GetAllReviews().ToList();
            foreach (Reviews r in reviews)
            {
                if (r.ReviewerId == reviewer)
                {
                    result.Add(r);
                }
            }
            if (result.Count == 0)
            {
                throw new ArgumentException($"No reviews for reviewer with id {reviewer} were found");
            }
            return result.Count();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            List<int> returnList = new List<int>();
            List<Reviews> reviews = _repo.GetAllReviews().ToList();
            List<Reviews> sortedReviews = reviews
              .Where(rid => rid.ReviewerId == reviewer)
              .OrderByDescending(rating => rating.Rating)
              .ThenByDescending(date => date.ReviewDate)
              .ToList();

            foreach (Reviews r in sortedReviews)
            {
                int id = r.AssociatedMovieId;
                returnList.Add(id);
            }
            if (returnList.Count == 0)
            {
                throw new ArgumentException("there are no movies to be found");
            }
            return returnList;
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            throw new NotImplementedException();
        }

    }
}
