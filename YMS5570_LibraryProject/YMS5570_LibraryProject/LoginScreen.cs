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
    public partial class LoginScreen : Form
    {
        AddAppUser FormAppUser = new AddAppUser();
        AppUser Person = new AppUser();
        public LoginScreen()
        {
            InitializeComponent();
        }
        ProjectContext db = new ProjectContext();
        private void GirisEkrani_Load(object sender, EventArgs e)
        {

            CmbGetData();
          

        }
        public void CmbGetData()
        {
            cmbUser.DataSource = db.AppUsers.Select(x => x.UserName).ToList();
            cmbUserRole.DataSource = Enum.GetNames(typeof(Role));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (cmbUser.Text == string.Empty|| cmbUserRole.SelectedIndex == 0)
            {
                MessageBox.Show("Kenidinize ait kullanıcı ve rolü seçiniz.");
            }
            else
            {
                if (db.AppUsers.Where(x => x.UserName == cmbUser.Text && x.Password == txtPwd.Text).ToList().Count > 0)
                {
                    Person = db.AppUsers.FirstOrDefault(x => x.UserName == cmbUser.Text);
                    AddCategoryPage addCategoryPage = new AddCategoryPage();
                    addCategoryPage.Show();
                  

                }
            }

        }
    }
}
