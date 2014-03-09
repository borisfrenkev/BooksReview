using BookReviews.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookReviews.Admin
{
    public partial class EditBooks : System.Web.UI.Page
    {
        private bool isInsrtedOrUpdated = false;
        private int editIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
      

        public IQueryable<BookReviews.Models.Book> GridViewBooks_GetData()
        {
            IQueryable<Book> books = null;
            var dbContext = new BooksReviewContext();
            books = dbContext.Books.Include("Category").AsQueryable<Book>();
            return books;
        }

        public IQueryable<BookReviews.Models.Category> GetCategories()
        {
            IQueryable<Category> categories = null;
            var dbContext = new BooksReviewContext();
            categories = dbContext.Categories.AsQueryable<Category>();
            return categories;
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            this.BookPanel.Visible = true;
            this.AddBook.Visible = false;
            this.PanelTitle.Text = "Edit Book";
            this.FormViewBook.ChangeMode(FormViewMode.Edit);
            Button button = sender as Button;
            int id = Convert.ToInt32(button.CommandArgument);
            editIndex = id;
            this.FormViewBook.DataBind();
           
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            this.BookPanel.Visible = true;
            this.AddBook.Visible = false;
            this.PanelTitle.Text = "Delete Book";
            this.FormViewBook.ChangeMode(FormViewMode.ReadOnly);
            Button button = sender as Button;
            int id = Convert.ToInt32(button.CommandArgument);
            editIndex = id;
            this.FormViewBook.DataBind();
        }

        protected void AddBook_Click(object sender, EventArgs e)
        {
            this.BookPanel.Visible = true;
            this.AddBook.Visible = false;
            this.PanelTitle.Text = "Add Book";
            this.FormViewBook.ChangeMode(FormViewMode.Insert);
        }

        

        

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.BookPanel.Visible = false;
            this.PanelTitle.Text = string.Empty;
            this.AddBook.Visible = true;
        }

        
        public BookReviews.Models.Book FormViewBook_GetItem()
        {
            using (var dbContext = new BooksReviewContext())
            {
                Book book = dbContext.Books.Find(editIndex);
                return book;
            }
        }

        public void FormViewBook_InsertItem()
        {
            var item = new BookReviews.Models.Book();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.isInsrtedOrUpdated = true;
                using (var dbContext = new BooksReviewContext())
                {
                    dbContext.Books.Add(item);
                    dbContext.SaveChanges();
                }

            }
        }

        protected void FormViewBook_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            if (this.isInsrtedOrUpdated)
            {
                this.BookPanel.Visible = false;
                this.GridViewBooks.DataBind();
                this.AddBook.Visible = true;
            }
        }

        protected void FormViewBook_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            if (this.isInsrtedOrUpdated)
            {
                this.BookPanel.Visible = false;
                this.GridViewBooks.DataBind();
                this.AddBook.Visible = true;
            }

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormViewBook_UpdateItem(int id)
        {
            BookReviews.Models.Book item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            using (var dbContext = new BooksReviewContext())
            {
                item = dbContext.Books.Find(id);
                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // Save changes here, e.g. MyDataLayer.SaveChanges();
                    this.isInsrtedOrUpdated = true;
                    dbContext.Entry(item).State = EntityState.Modified;
                    dbContext.SaveChanges();

                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormViewBook_DeleteItem(int id)
        {
            BookReviews.Models.Book item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            using (var dbContext = new BooksReviewContext())
            {
                item = dbContext.Books.Find(id);
                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // Save changes here, e.g. MyDataLayer.SaveChanges();
                    this.isInsrtedOrUpdated = true;
                    dbContext.Entry(item).State = EntityState.Deleted;
                    dbContext.SaveChanges();

                }
            }
        }

        protected void FormViewBook_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
            if (this.isInsrtedOrUpdated)
            {
                this.BookPanel.Visible = false;
                this.GridViewBooks.DataBind();
                this.AddBook.Visible = true;
            }
        }

       
    }
}