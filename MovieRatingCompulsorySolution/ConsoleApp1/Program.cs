using MovieRating.Core.ApplicationService.Implementation;
using MovieRating.Core.DomainService;
using MovieRating.Core.Entity;
using MovieRating.Infrastructure.Static.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository rep = new MovieRepositoryFileReader();
            List<Reviews> reviews = (List<Reviews>)rep.GetAllReviews();
            Service s = new Service(rep);
            List<Reviewer> rev = s.GetReviewers();
            for (int i = 0; i < Math.Min(rev.Count, 100); i++)
            {
                Reviewer c = rev[i];
                Console.WriteLine("Reviewer = " + c.Id + " count = " + c.mReviews.Count);
            }
        }
    }
}
