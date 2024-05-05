using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using bestellung.models;
using bestellung.DataLayer;

namespace bestellung
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            UserMongoHelper userMongo = new UserMongoHelper();
            List<User> documentList = userMongo.GetAllDocuments(); //collection.Find(x => true).ToList();
            foreach (User user in documentList) {
                Console.WriteLine(user.name);
            }
            
        }
    }
}
