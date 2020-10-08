using MovieRating.Core.ApplicationService;
using MovieRating.Core.DomainService;
using MovieRating.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MovieRating.Infrastructure.Static.Data
{
    public class MovieRepositoryFileReader : IRepository
    {
        private readonly string _path = "ratings.json";

        public MovieRepositoryFileReader()
        {
            GetReviewsFromFile(_path);
        }

        private IEnumerable<Reviews> _ratingCollection;

        public IEnumerable<Reviews> GetAllReviews()
        {
            return _ratingCollection;
        }

        public void GetReviewsFromFile(string _path)
        {
            using (StreamReader streamReader = File.OpenText(_path))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.CloseInput = true;
                var serializer = new JsonSerializer();
                var ratings = new List<Reviews>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        Reviews review = serializer.Deserialize<Reviews>(reader);
                        ratings.Add(review);
                    }

                }
                _ratingCollection = ratings;
            }
        }
    }
}