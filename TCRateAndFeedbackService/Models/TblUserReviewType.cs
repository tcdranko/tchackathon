using System;
using System.Collections.Generic;

namespace TCRateAndFeedbackService.Models
{
    public partial class UserReviewType
    {
        public UserReviewType()
        {
            UserReview = new HashSet<UserReview>();
        }

        public byte LngRatingId { get; set; }
        public string StrRatingName { get; set; }

        public virtual ICollection<UserReview> UserReview { get; set; }
    }
}
