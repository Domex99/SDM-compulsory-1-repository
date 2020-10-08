using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Core.Entity

{
    public class Reviewer
    {
        public int Id { get; set; }
        public List<Reviews> mReviews;
    }
}
