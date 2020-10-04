using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using MovieRating.Core.ApplicationService;
using MovieRating.Core.ApplicationService.Implementation;
using MovieRating.Core.DomainService;
using MovieRating.Core.Entity;

namespace MovieRatingMockTests
{
    [TestClass]
    public class UnitTest
    {
        Reviews[] returnValue1 = {new Reviews  {ReviewId = 1,
                                                 AssociatedMovieId = 1,
                                                 Rating = 4,
                                                 ReviewDate = DateTime.Now.AddDays(-20),
                                                 ReviewerId = 1 },

                                    new Reviews  {ReviewId = 2,
                                                 AssociatedMovieId = 2,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 1 },

                                    new Reviews  {ReviewId = 3,
                                                 AssociatedMovieId = 3,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-25),
                                                 ReviewerId = 1 },

                                    new Reviews  {ReviewId = 4,
                                                 AssociatedMovieId = 2,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 2 },

                                    new Reviews  {ReviewId = 5,
                                                 AssociatedMovieId = 4,
                                                 Rating = 5,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 2 },

                                    new Reviews  {ReviewId = 6,
                                                 AssociatedMovieId = 2,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-3),
                                                 ReviewerId = 3 },

                                    new Reviews  {ReviewId = 7,
                                                 AssociatedMovieId = 3,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-42),
                                                 ReviewerId = 3 },

                                    new Reviews  {ReviewId = 8,
                                                 AssociatedMovieId = 1,
                                                 Rating = 4,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 4 },

                                    new Reviews  {ReviewId = 9,
                                                 AssociatedMovieId = 2,
                                                 Rating = 5,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 4 },

                                    new Reviews  {ReviewId = 10,
                                                 AssociatedMovieId = 4,
                                                 Rating = 5,
                                                 ReviewDate = DateTime.Now.AddDays(-12),
                                                 ReviewerId = 4 },
        };


        Reviews[] returnValue2 = { };

        [TestInitialize]
        public void setup()
        { }

        [TestMethod]
        public void TestGetAverageRateFromReviewer()
        {
            //  Setup the mock
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            Service service = new Service(mock.Object);
            //  Test Reviewer 1
            double actualResult = service.GetAverageRateFromReviewer(1);
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(actualResult == 2.67, "IsTrue test failed for reviewer 1");
            Assert.IsFalse(actualResult == 22, "IsFalse test failed for reviewer 1");
            //  Test Reviewer 2
            double actualResult2 = service.GetAverageRateFromReviewer(2);
            Assert.IsTrue(actualResult2 == 3.5, "IsTrue test failed for reviewer 2");
            Assert.IsFalse(actualResult2 == 22, "IsFalse test failed for reviewer 2");
            //  Test Reviewer 3
            double actualResult3 = service.GetAverageRateFromReviewer(3);
            Assert.IsTrue(actualResult3 == 2, "IsTrue test failed for reviewer 3");
            Assert.IsFalse(actualResult3 == 22, "IsFalse test failed for reviewer 3");
            //  Test Reviewer 4
            double actualResult4 = service.GetAverageRateFromReviewer(4);
            Assert.IsTrue(actualResult4 == 4.67, "IsTrue test failed for reviewer 4");
            Assert.IsFalse(actualResult4 == 22, "IsFalse test failed for reviewer 4");
            //  Test Exception for average from reviewer
            Assert.ThrowsException<ArgumentException>(() => service.GetAverageRateFromReviewer(200));
        }


    }

}