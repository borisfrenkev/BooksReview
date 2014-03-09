using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookReviews.Models
{
    public class Book
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The tite of the book can not be empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The author of the book can not be empty")]
        public string Author { get; set; }

        public string ISBN { get; set; }

        public string SiteURL { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The category of the book must be selected")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }


    }
}