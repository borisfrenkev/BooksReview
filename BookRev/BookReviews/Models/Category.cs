using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookReviews.Models
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage="The name of the category can not be empty")]
       
        public string Name { get; set; }

        private ICollection<Book> books;

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }

        public Category()
        {
            this.books = new HashSet<Book>();
        }

    }

}