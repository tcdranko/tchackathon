using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCRateAndFeedbackService.Models;
using TCRateAndFeedbackServiceClient;

namespace TCRateAndFeedback
{
    public partial class RateAndFeedback : System.Web.UI.Page
    {
        private ModelHttpClient _client;    //create ModelhttpClient instance
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _client = new ModelHttpClient(Settings.ServicesBaseUri);    //initialize _client
            lblMessage.CssClass = "highlight";

                DisplayReviews();
            
            if (Request.QueryString["Load"] != null)
            {
                lblMessage.Visible = true;
            }
        }

        private async void DisplayReviews()
        {
            string userReviews = "";
            var userReviewAll = await _client.GetAsync<List<UserReview>>("UserReviews");
            
            foreach (var p in userReviewAll)
            {
                userReviews = userReviews + "<button type='button' class='collapsible'><div class='ratings username'>"+ p.StrUsername + "</div><div class='ratings ratingtype'>"+ p.IntRating.StrRatingName + "</div><div class='ratings datetime'>" + p.DtmTimeSubmitted.AddHours(-4) + "</div></button><div class='content'><p>" + p.StrComment + "</p></div>";
            }

            ReviewsPanel.Controls.Add(new LiteralControl(userReviews));

            int i = 0;
            var userReviewType = await _client.GetAsync<List<UserReviewType>>("UserReviewTypes");
            foreach (var type in userReviewType)
            {
                ddlRating.Items.Insert(i, new ListItem(type.StrRatingName, type.LngRatingId.ToString()));
                i++;
            }
        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            // create a review entity
            UserReview userreview = new UserReview()
            {
                StrUsername = "testuser1",
                IntRatingId = Convert.ToByte(ddlRating.SelectedValue),
                StrComment = txtComment.Text
            };

            try
            {
                // add the review to the database
                await _client.PostAsync("UserReviews", userreview);
            }
            finally
            {
                Response.Redirect(Request.RawUrl + "?Load=Load");
            }
        }

        private void NoAccess()
        {
            lblMessage.Text = "You do not have access to see reviews.";
            lblMessage.Visible = true;
        }
    }
}