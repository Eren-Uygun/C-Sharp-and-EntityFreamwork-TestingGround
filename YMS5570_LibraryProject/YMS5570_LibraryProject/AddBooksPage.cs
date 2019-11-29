using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YMS5570_LibraryProject.DAL.ORM.Concrate;
using YMS5570_LibraryProject.DAL.ORM.Context;

namespace YMS5570_LibraryProject
{
    public partial class btnCategory : Form
    {
        public btnCategory()
        {
            InitializeComponent();
            
        }

        public void GetData()
        {
            dataGridView1.DataSource = db.Books.Select(x=>x).ToList();
        }

        public void txtDeleter()
        {
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                else if (item is ComboBox)
                {
                    item.Text = "";
                }
            }

            foreach (Control item in groupBox3.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                else if (item is ComboBox)
                {
                    item.Text = "";
                }
            }

            foreach (Control item in groupBox4.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }

        }

        ProjectContext db = new ProjectContext();
        private void Button1_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            AppUser appUser = new AppUser();

            Book book = new Book();
            book.Title = txtTitle.Text.ToString();
            book.Content = txtContent.Text.ToString();
            book.CategoryID = (int)cmbAddCategory.SelectedValue;
            book.AppUserID = (int)cmbAddCategory.SelectedValue;
            //book.AppUser.Role = cmbAddUser.DisplayMember;
            book.AddDate = DateTime.Now;
            book.Status = DAL.ORM.Abstarct.Status.Active;
            db.Books.Add(book);
            db.SaveChanges();
            GetData();
            txtDeleter();

            

            
        }

        private void AddBooksPage_Load(object sender, EventArgs e)
        {

            cmbAddUser.DataSource = db.AppUsers.Select(x=>x.FirstName+" "+x.LastName ).ToList();
            cmbAddUser.DisplayMember = "FullName";
  

            cmbUpdateUser.DataSource = db.AppUsers.Select(x => x.FirstName + " " + x.LastName).ToList();
            cmbUpdateUser.DisplayMember = "FullName";


            cmbAddCategory.DataSource = db.Categories.Select(x=>x).ToList();    
            cmbAddCategory.DisplayMember = "Name".ToString();
            cmbAddCategory.ValueMember = "ID";
           
      
            
            cmbUpdateCategory.DataSource = db.Categories.Select(x =>x).ToList();
            cmbUpdateCategory.DisplayMember = "Name".ToString();
            cmbUpdateCategory.ValueMember = "ID";


            GetData();



        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Book book = db.Books.FirstOrDefault(x=>x.ID==id);
            book.Title = txtUpdateTitle.Text.ToString();
            book.Content = txtUpdateContent.Text.ToString();
            book.UpdateDate = DateTime.Now;
            book.Status = DAL.ORM.Abstarct.Status.Updated;

            db.SaveChanges();
            GetData();
            txtDeleter();
            
        }
        int id;
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUpdateTitle.Text = dataGridView1.CurrentRow.Cells["Title"].Value.ToString();
            txtUpdateContent.Text = dataGridView1.CurrentRow.Cells["Content"].Value.ToString();
            cmbUpdateCategory.Text = dataGridView1.CurrentRow.Cells["Category"].Value.ToString();
            cmbUpdateUser.Text = dataGridView1.CurrentRow.Cells["AppUser"].Value.ToString();
            id = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            txtBookDel.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

            

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Book book = db.Books.FirstOrDefault(x=>x.ID == id);
            book.Status = DAL.ORM.Abstarct.Status.Deleted;
            book.DeleteDate = DateTime.Now;
            db.SaveChanges();
            GetData();
            txtDeleter();
            

        }

        private void btnAppUser_Click(object sender, EventArgs e)
        {
            AddAppUser ap1 = new AddAppUser();
            ap1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddCategoryPage acp = new AddCategoryPage();
            acp.Show();
            this.Close();
        }
    }
}
