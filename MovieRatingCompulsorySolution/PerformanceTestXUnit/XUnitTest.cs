using MovieRating.Core.ApplicationService;
using MovieRating.Core.ApplicationService.Implementation;
using MovieRating.Core.DomainService;
using MovieRating.Infrastructure.Static.Data;
using System;
using Xunit;

namespace PerformanceTestingXUnit
{
    public class XUnitTest
    {
        private IRepository mRep;


        public XUnitTest()
        {
            mRep = new MovieRepositoryFileReader();
        }

        [Fact]
        public void Test1() //Question 1
        {
            Service s = new Service(mRep);

            DateTime start = DateTime.Now;
            s.GetNumberOfReviewsFromReviewer(1);
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= 4000);
        }

        [Fact]
        public void Test2() //Question 2
        {
            Service s = new Service(mRep);

            DateTime start = DateTime.Now;
            s.GetAverageRateFromReviewer(1);
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= 4000);
        }

        [Fact]
        public void Test3() //Question 3
        {
            Service s = new Service(mRep);

            DateTime start = DateTime.Now;
            s.GetNumberOfRatesByReviewer(1,2);
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= 4000);
        }


        [Fact]
        public void Test4() //Question 4
        {
            Service s = new Service(mRep);

            DateTime start = DateTime.Now;
            s.GetNumberOfReviews(1);
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= 4000);
        }


        [Fact]
        public void Test5() //Question 5
        {
            Service s = new Service(mRep);

            DateTime start = DateTime.Now;
            s.GetAverageRateOfMovie(1);
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= 4000);
        }


        [Fact]
        public void Test6() //Question 6
        {
            Service s = new Service(mRep);

            DateTime start = DateTime.Now;
            s.GetNumberOfRates(1,2);
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= 4000);
        }


        [Fact]
        public void Test7() //Question 10
        {
            Service s = new Service(mRep);

            DateTime start = DateTime.Now;
            s.GetTopMoviesByReviewer(1);
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= 4000);
        }

    }
}
