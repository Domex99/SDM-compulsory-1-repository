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

        [TestMethod] //Question 1
        public void TestGetNumberOfReviewsFromReviewer()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            Service ReviewsService = new Service(mock.Object);
            //1
            int actualResult = ReviewsService.GetNumberOfReviewsFromReviewer(2);
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(actualResult == 2, "It is the right person");
            Assert.IsFalse(actualResult == 22, "It is the wrong person");
            //2
            int actualResult2 = ReviewsService.GetNumberOfReviewsFromReviewer(1);
            Assert.IsTrue(actualResult2 == 3, "It is the right person");
            Assert.IsFalse(actualResult2 == 22, "It is the wrong person");

        }


        [TestMethod] //Question 2
        public void TestGetAverageRateFromReviewer()
        {
            // 1
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            Service ReviewsService = new Service(mock.Object);
            // 2
            double actualResult = ReviewsService.GetAverageRateFromReviewer(1);
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(actualResult == 2.67, "It is the right person");
            Assert.IsFalse(actualResult == 22, "It is the wrong person");

            Assert.ThrowsException<ArgumentException>(() => ReviewsService.GetNumberOfReviewsByReviewer(200));
        }

        [TestMethod] //Question 3
        public void TestGetNumberOfRatesByReviewer()
        {

            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            Service ReviewService = new Service(mock.Object);
            //1
            int actualResult = ReviewService.GetNumberOfRatesByReviewer(1, 4);
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(actualResult == 1, "It is the right person");
            Assert.IsFalse(actualResult == 22, "It is the wrong person");
            //1
            int actualResult2 = ReviewService.GetNumberOfRatesByReviewer(2, 1);
            Assert.IsTrue(actualResult2 == 0, "It is the right person");
            Assert.IsFalse(actualResult2 == 22, "It is the wrong person");

        }

        [TestMethod] //Question 4
        public void TestGetNumberOfReviews()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            Service ReviewService = new Service(mock.Object);
            //1
            int actualResult = ReviewService.GetNumberOfReviews(1);
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(actualResult == 2, "It is the right person");
            Assert.IsFalse(actualResult == 22, "It is the wrong person");
            //2
            int actualResult2 = ReviewService.GetNumberOfReviews(2);
            Assert.IsTrue(actualResult2 == 4, "It is the right person");
            Assert.IsFalse(actualResult2 == 22, "It is the wrong person");

            Assert.ThrowsException<ArgumentException>(() => ReviewService.GetNumberOfReviewsByReviewer(200));
        }

        [TestMethod] //Question 5
        public void TestGetAverageRateOfMovie()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            Service ReviewService = new Service(mock.Object);
            //1
            double actualResult = ReviewService.GetAverageRateOfMovie(1);
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(actualResult == 4, "It is the right person");
            Assert.IsFalse(actualResult == 22, "It is the wrong person");
            //2
            double actualResult2 = ReviewService.GetAverageRateOfMovie(2);
            Assert.IsTrue(actualResult2 == 2.75, "It is the right person");
            Assert.IsFalse(actualResult2 == 22, "It is the wrong person");

            Assert.ThrowsException<ArgumentException>(() => ReviewService.GetNumberOfReviewsByReviewer(200));
        }

        [TestMethod] //Question 6
        public void TestGetNumberOfRates()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            Service ReviewService = new Service(mock.Object);
            //1
            int actualResult = ReviewService.GetNumberOfRates(1, 4);
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(actualResult == 2, "It is the right person");
            Assert.IsFalse(actualResult == 22, "It is the wrong person");
            //2
            int actualResult2 = ReviewService.GetNumberOfRates(2, 2);
            Assert.IsTrue(actualResult2 == 3, "It is the right person");
            Assert.IsFalse(actualResult2 == 22, "It is the wrong person");

            Assert.ThrowsException<ArgumentException>(() => ReviewService.GetNumberOfReviewsByReviewer(200));
        }

        [TestMethod] //Question 10
        public void TestGetTopMoviesByReviewer()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            Service ReviewService = new Service(mock.Object);

            List<int> actualResult = ReviewService.GetTopMoviesByReviewer(1);
            List<int> x1 = new List<int>() { 1, 3, 2 };
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(Enumerable.SequenceEqual(x1, actualResult), "It is the right person");
            Assert.IsFalse(actualResult.Equals(22), "It is the wrong person");

            List<int> actualResult2 = ReviewService.GetTopMoviesByReviewer(2);
            List<int> x2 = new List<int>() { 4, 2 };
            Assert.IsTrue(Enumerable.SequenceEqual(x2, actualResult2), "It is the right person");
            Assert.IsFalse(actualResult2.Equals(22), "It is the wrong person");

            Mock<IRepository> mock2 = new Mock<IRepository>();
            mock2.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue2);
            Service ReviewService2 = new Service(mock2.Object);
            Assert.ThrowsException<ArgumentException>(() => ReviewService2.GetTopMoviesByReviewer(1));
        }


    }

}