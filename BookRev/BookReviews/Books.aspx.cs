using BookReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.ComponentModel.DataAnnotations;
namespace BookReviews
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(Request.QueryString["id"]);
            if (id!=null)
            {
                using ( var dbContext = new BooksReviewContext())
                {
                    this.CategoryName.InnerText = dbContext.Categories.Find(id).Name;
                }
            }
	
         
        }
        public IQueryable<Book> GridViewBooks_GetData([QueryString("id")] int? id)
        {
            var dbContext = new BooksReviewContext();
            IQueryable<Book> books = dbContext.Books;
            if (id.HasValue)
            {
                books = books.Where(b => b.CategoryId == id);
            }
            return books;
        }

       
    }
}