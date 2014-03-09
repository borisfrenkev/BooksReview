using BookReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookReviews
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            using (var dbContext = new BooksReviewContext())
            {
                var book = dbContext.Books;
                this.DetailsFormView.DataSource = book.Where(x=>x.Id==id).ToList();
                this.DetailsFormView.DataBind();
            }
        }
    }
}