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
        public void ServicePerformanceTesting()
        {
            Service s = new Service(mRep);
            s.GetNumberOfReviewsFromReviewer(1);
        }
    }
}
