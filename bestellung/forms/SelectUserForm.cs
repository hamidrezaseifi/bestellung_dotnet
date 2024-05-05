using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bestellung.models;
using bestellung.DataLayer;
using System.Globalization;

namespace bestellung.forms
{
    public partial class SelectUserForm : Form
    {
        public SelectUserForm()
        {
            InitializeComponent();
        }

        private void SelectUserForm_Load(object sender, EventArgs e)
        {
            UserMongoHelper userMongo = new UserMongoHelper();
            List<User> documentList = userMongo.GetAllDocuments(); //collection.Find(x => true).ToList();
            foreach (User user in documentList)
            {
                Button btn = new Button();
                btn.Text = user.name;
                btn.BackColor = Color.FromArgb(user.RGB);
                btn.Tag = user;
                btn.Click += UserButton_Click;
                panel1.Controls.Add(btn);
                
            }
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            Globals.CURRENT_USER = btn.Tag as User;

            this.Close();
        }
    }
}
