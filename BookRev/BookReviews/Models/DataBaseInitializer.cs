using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace BookReviews.Models
{
    public class DataBaseInitializer:DropCreateDatabaseIfModelChanges<BooksReviewContext>
    {
        protected override void Seed(BooksReviewContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category{Name="Programming"},
                new Category {Name="Databases"},
                new Category{Name="Web Development"},
                new Category{Name="System Administration"},
                new Category{Name="Algorithms"}
            };
            categories.ForEach(c=>context.Categories.Add(c));
            context.SaveChanges();

             List<Book> books = new List<Book>()
             {

                   new Book
                 {  
                     Title="Professional JavaScript for Web Developers, 3rd Edition",  Author="	Nicholas C. Zakas",CategoryId=categories[2].Id,
                     Description="If you want to achieve JavaScript's full potential, it is critical to understand its nature, history, and limitations. To that end, this updated version of the bestseller by veteran author and JavaScript guru Nicholas C. Zakas covers JavaScript from its very beginning to the present-day incarnations including the DOM, Ajax, and HTML5"
                     ,ISBN="978-1-1180-2669-4", SiteURL="http://wrox.com/"
                 },
                 new Book{Title="Fundamentals of Computer Programming with C#", Author="Svetlin Nakov & Co",
                 SiteURL="http://www.introprogramming.info/english-intro-csharp-book/", Description="The free book Fundamentals of Computer Programming with C#\" aims to provide novice programmers solid foundation of basic knowledge regardless of the programming language. This book covers the fundamentals of programming that have not changed significantly over the last 10 years. Educational content was developed by an authoritative author team led by Svetlin Nakov and covers topics such as variables conditional statements, loops and arrays, and more complex concepts such as data structures (lists, stacks, queues, trees, hash tables, etc.), and recursion recursive algorithms, object-oriented programming and high-quality code. From the book you will learn how to think as programmers and how to solve efficiently programming problems. You will master the fundamental principles of programming and basic data structures and algorithms, without which you can't become a software engineer.",

                 CategoryId=categories[0].Id },
                 new Book
                 {  
                     Title="C# Yellow Book",  Author="Rob Miles",CategoryId=categories[0].Id
                 },
                 new Book
                 {
                     Title="Beginning JavaScript 4th Edition", Author= "Paul Wilton" ,CategoryId=categories[0].Id
                 },

                 new Book
                 {
                     Title="Advanced Linux Programming", Author= "CodeSourcery LLC",CategoryId=categories[1].Id
                 },
                 new Book
                 {  
                     Title="Database Systems: The Complete Book", Author="Hector Garcia-Molina, Jeff Ullman, and Jennifer Widom",
                    CategoryId=categories[1].Id
                 },
                 new Book
                 {  
                     Title="SQL in a Nutshell: A Desktop Quick Reference", Author="Kevin Kline", CategoryId=categories[2].Id
                 },
                 new Book
                 {
                     Title="Programming = ++ Algorithms;", Author="Preslav Nakov and Panayot Dobrikov", CategoryId=categories[3].Id
                 },
                 new Book
                 {
                     Title="Introduction to Algorithms, 3rd Edition", Author="Cormen, Charles E. Leiserson, Ronald L. Rivest, and Clifford Stein",
                     CategoryId=categories[3].Id
                 },
                 new Book
                 {
                     Title="Professional ASP.NET MVC 5", Author="Jon Galloway",
                     CategoryId=categories[4].Id
                 },
                 new Book
                 {
                     Title="Beginning ASP.NET 4.5 in C# Coding Skills Kit", Author="Imar Spaanjaars",
                     CategoryId=categories[4].Id
                 },
                 new Book
                 {  
                     Title="Beginning HTML and CSS", Author="Rob Larsen",
                     CategoryId=categories[4].Id
                 }

             };

             books.ForEach(b => context.Books.Add(b));
             context.SaveChanges();

             //categories[0].Books.Add(books[0]);
             //categories[0].Books.Add(books[1]);
             //categories[0].Books.Add(books[2]);
             //categories[1].Books.Add(books[3]);
             //categories[2].Books.Add(books[4]);
             //categories[2].Books.Add(books[5]);
             //categories[3].Books.Add(books[6]);
             //categories[3].Books.Add(books[7]);
             //categories[4].Books.Add(books[8]);
             //categories[4].Books.Add(books[9]);
             //categories[4].Books.Add(books[10]);
             //context.SaveChanges();   
        }

      

    }
}