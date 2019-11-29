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
    public partial class AddAppUser : Form
    {
        btnCategory abp = new btnCategory();
        AddCategoryPage acp = new AddCategoryPage();
        public AddAppUser()
        {
            InitializeComponent();
           
        }

        public void TextBoxEraser()
        {
            foreach (Control item in AddUserGroup.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox2.Controls)
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
            try
            {
                AppUser appUser = new AppUser();
                appUser.FirstName = txtFirstName.Text.ToString();
                appUser.LastName = txtLastname.Text.ToString();
                appUser.Role = (Role)cmbRoleBox.SelectedValue;
                appUser.Password = txtPwd.Text.ToString();
                appUser.UserName = txtUserName.Text.ToString();
                db.AppUsers.Add(appUser);
                db.SaveChanges();
                GetData();
                TextBoxEraser();

            }
            catch (Exception)
            {
                MessageBox.Show("Add Exception");

            }
           

        }

        private void AddAppUser_Load(object sender, EventArgs e)
        {
            //cmbRoleBox.Items.AddRange(Enum.GetNames(typeof(Role))); Role enumlarından isimleri combobox a geçer;
            cmbRoleBox.DataSource = Enum.GetValues(typeof(Role));
            cmbUpdate.DataSource = Enum.GetValues(typeof(Role));
            GetData();

            
        }

        public void GetData()
        {
            dataGridView1.DataSource = db.AppUsers.Select(x=>x).ToList();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox2.Text = dataGridView1.CurrentRow.Cells["FirstName"].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells["LastName"].Value.ToString();
                cmbUpdate.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                UserNameUpdate.Text = dataGridView1.CurrentRow.Cells["UserName"].Value.ToString();

                if (dataGridView1.CurrentRow.Cells["Password"].Value.ToString() == null)
                {
                    txtUpPwd.Text = null;
                }
                else
                {
                    txtUpPwd.Text = dataGridView1.CurrentRow.Cells["Password"].Value.ToString();
                }
                ID = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                txtDeleteUser.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Select Exception");
            }
           
        }

        int ID;
        private void BtnAppUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                AppUser appUser = db.AppUsers.FirstOrDefault(x => x.ID == ID);
                appUser.FirstName = textBox1.Text.ToString();
                appUser.LastName = textBox2.Text.ToString();
                appUser.Role = (Role)cmbUpdate.SelectedValue;
                appUser.Status = DAL.ORM.Abstarct.Status.Updated;
                appUser.Password = txtUpPwd.Text.ToString();
                appUser.UserName = UserNameUpdate.Text.ToString();
                appUser.UpdateDate = DateTime.Now;
                db.SaveChanges();
                GetData();
                TextBoxEraser();
            }
            catch (Exception)
            {

                MessageBox.Show("Update Exception");
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                AppUser appUser = db.AppUsers.FirstOrDefault(x => x.ID == ID);
                appUser.Status = DAL.ORM.Abstarct.Status.Deleted;
                appUser.DeleteDate = DateTime.Now;
                db.SaveChanges();
                GetData();
                TextBoxEraser();
            }
            catch (Exception)
            {

                MessageBox.Show("Delete Exception");
            }
            

        }

        private void AddUserGroup_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            acp.Show();
            this.Hide();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abp.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
