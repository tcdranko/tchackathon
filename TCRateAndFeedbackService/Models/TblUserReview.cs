using System;
using System.Collections.Generic;

namespace TCRateAndFeedbackService.Models
{
    public partial class UserReview
    {
        public int LngReviewId { get; set; }
        public string StrUsername { get; set; }
        public byte IntRatingId { get; set; }
        public string StrComment { get; set; }
        public DateTime DtmTimeSubmitted { get; set; }

        public virtual UserReviewType IntRating { get; set; }
    }
}
