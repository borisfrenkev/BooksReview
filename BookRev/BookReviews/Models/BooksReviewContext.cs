using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace BookReviews.Models
{
    public class BooksReviewContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet <Book>Books { get; set; }

        public BooksReviewContext()
            : base("DefaultConnection")
        {

        }

        


    }
}