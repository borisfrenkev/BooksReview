using BookReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookReviews
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dbContext = new BooksReviewContext();
            string searchStr= Request.QueryString["str"];
            var books = dbContext.Books.Where(b => (b.Author.Contains(searchStr) || b.Title.Contains(searchStr))).ToList();
            this.RepeaterSearchResult.DataSource = books;
            this.RepeaterSearchResult.DataBind();
        }
    }
}