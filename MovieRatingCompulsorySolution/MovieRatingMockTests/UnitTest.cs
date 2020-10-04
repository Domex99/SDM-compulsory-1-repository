using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieRating.Core.ApplicationService.Services;
using MovieRating.Core.DomainService;
using MovieRating.Core.Entity;

namespace MovieRatingMockTests
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void TestGetAverageRateFromReviewer()
        {
            Mock<IRepository> mt = new Mock<IRepository>();

            Reviews[] returnValue =
              { new Reviews  {Reviewer = 1, Movie = 2, Grade = 3 },
                new Reviews {Reviewer = 1, Movie = 2, Grade = 4 },
                new Reviews {Reviewer = 1, Movie = 3, Grade = 2 },
                new Reviews {Reviewer = 3, Movie = 3, Grade = 2 }
            };

            mt.Setup(mt => mt.GetAllReviews()).Returns(() => value);

            ReviewService reviewService = new ReviewService(mt.Object);

            double aResult = reviewService.GetAverageRate(1);

            mt.Verify(mt => mt.GetAllRatings(), Times.Once);

            Assert.IsTrue(actualResult.Count == 1);
            Assert.IsTrue(actualResult.Contains(returnValue[1]));
        }


    }


    public void TestGetNumberOfReviewsFromReviewer()
    {
        Mock<IRepository> mt = new Mock<IRepository>();


        Reviews[] returnValue =
            { new Review  {Reviewer = 1, Movie = 2, Grade = 3 },
                new Review {Reviewer = 2, Movie = 2, Grade = 4 } };

        mt.Setup(mt => mt.GetAllReviews()).Returns(() => value);

        ReviewService reviewService = new ReviewService(mt.Object);

        int aResult = reviewService.GetNumberOfReviewsFromReviewer(2);

        mt.Verify(mt => mt.GetAllReviews(), Times.Once);

        Assert.IsTrue(actualResult.Count == 1);
        Assert.IsTrue(actualResult.Contains(returnValue[1]));

    }



}