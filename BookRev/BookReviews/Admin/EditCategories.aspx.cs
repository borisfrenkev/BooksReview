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
    public partial class EditCategories : System.Web.UI.Page
    {
        private bool isInsrtedOrUpdated = false;
        private int editIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public IQueryable<Category> GridViewCategories_GetData()
        {
            IQueryable<Category> cateories = null;
            var dbContext = new BooksReviewContext();
            cateories = dbContext.Categories.AsQueryable<Category>();
            return cateories;
        }

        public void FormViewID_InsertItem()
        {
            var item = new BookReviews.Models.Category();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.isInsrtedOrUpdated = true;
                using (var dbContext = new BooksReviewContext())
                {
                    dbContext.Categories.Add(item);
                    dbContext.SaveChanges();
                }
            }
        }

        protected void AddCategory_Click(object sender, EventArgs e)
        {
            this.AddCategory.Visible = false;
            this.PanelTitle.Text = "Add Category";
            this.EditOrCreateCategotyPanel.Visible = true;
            this.FormViewID.ChangeMode(FormViewMode.Insert);
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
           this.AddCategory.Visible = false;
           this.PanelTitle.Text = "Edit Category";
           this.FormViewID.ChangeMode(FormViewMode.Edit);
           this.EditOrCreateCategotyPanel.Visible = true;
           Button button = sender as Button;
           int id = Convert.ToInt32(button.CommandArgument);
           editIndex = id;
           this.FormViewID.DataBind(); 
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            this.AddCategory.Visible = false;
            this.PanelTitle.Text = "Delete Category";
            this.FormViewID.ChangeMode(FormViewMode.ReadOnly);
            this.EditOrCreateCategotyPanel.Visible = true;

            Button button = sender as Button;
            int id = Convert.ToInt32(button.CommandArgument);
            editIndex = id;
            this.FormViewID.DataBind();
        }

      

        public void FormViewID_UpdateItem(int id)
        {
            BookReviews.Models.Category item = null;
            using (var dbContext = new BooksReviewContext())
            {
                item = dbContext.Categories.Find(id);
                if (item == null)
                {
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    this.isInsrtedOrUpdated = true;
                    dbContext.Entry(item).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
        }

        public void FormViewID_DeleteItem(int id)
        {
             BookReviews.Models.Category item = null;
             using (var dbContext = new BooksReviewContext())
             {
                 item = dbContext.Categories.Find(id);
                 if (item == null)
                 {
                     ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                     return;
                 }
                 TryUpdateModel(item);
                 if (ModelState.IsValid)
                 {
                     this.isInsrtedOrUpdated = true;
                     dbContext.Entry(item).State = EntityState.Deleted;
                     dbContext.SaveChanges();
                 }
             }
        }
        public BookReviews.Models.Category FormViewID_GetItem()
        {
            using (var dbContext = new BooksReviewContext())
            {
                Category category = dbContext.Categories.Find(editIndex);
                return category;
            }
        }


        protected void FormViewID_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            if (this.isInsrtedOrUpdated)
            {
                this.EditOrCreateCategotyPanel.Visible = false;
                this.GridViewCategories.DataBind();
                this.AddCategory.Visible = true;
            }

        }
        protected void FormViewID_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            if (this.isInsrtedOrUpdated)
            {
                this.EditOrCreateCategotyPanel.Visible = false;
                this.GridViewCategories.DataBind();
                this.AddCategory.Visible = true;
            }
        }

        protected void FormViewID_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
            if (this.isInsrtedOrUpdated)
            {
                this.EditOrCreateCategotyPanel.Visible = false;
                this.GridViewCategories.DataBind();
                this.AddCategory.Visible = true;
            }
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.EditOrCreateCategotyPanel.Visible = false;
            this.PanelTitle.Text = string.Empty;
            this.AddCategory.Visible = true;
        }

       

     

    }
    
}