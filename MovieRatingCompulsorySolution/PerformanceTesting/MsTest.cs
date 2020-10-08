using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRating.Core.ApplicationService.Implementation;
using MovieRating.Core.DomainService;
using MovieRating.Infrastructure.Static.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceTesting
{
    [TestClass]
    public class MsTest
    {
        private static IRepository mRep;
        [ClassInitialize]
        public static void SetupRepo(TestContext tc)
        {
            mRep = new MovieRepositoryFileReader();
        }


        [TestMethod]
        [Timeout(4000)]
        public void TestMethod1()
        {
            Service s = new Service(mRep);
            s.GetNumberOfReviewsFromReviewer(1);
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestMethod2()
        {
            Service s = new Service(mRep);
            s.GetAverageRateFromReviewer(1);
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestMethod3()
        {
            Service s = new Service(mRep);
            s.GetNumberOfRatesByReviewer(1,2);
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestMethod4()
        {
            Service s = new Service(mRep);
            s.GetNumberOfReviews(1);
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestMethod5()
        {
            Service s = new Service(mRep);
            s.GetAverageRateOfMovie(1);
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestMethod6()
        {
            Service s = new Service(mRep);
            s.GetNumberOfRates(1,2);
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestMethod7()
        {
            Service s = new Service(mRep);
            s.GetTopMoviesByReviewer(1);
        }

    }
} 
