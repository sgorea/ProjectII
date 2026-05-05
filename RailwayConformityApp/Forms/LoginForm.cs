using System;
using System.Windows.Forms;
using RailwayConformityApp.Data; // Asigură-te că namespace-ul e corect
using RailwayConformityApp.Models;

namespace RailwayConformityApp
{
    public partial class LoginForm : Form
    {
        private UserRepository _userRepo = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();
            IncarcaUtilizatori();
        }

        private void IncarcaUtilizatori()
        {
            try
            {
                var users = _userRepo.GetAllUsers();

                cmbUsers.DataSource = users;
                cmbUsers.DisplayMember = "Username";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea utilizatorilor: " + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem != null)
            {
                Session.CurrentUser = (User)cmbUsers.SelectedItem;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Te rugăm să selectezi un utilizator!");
            }
        }
    }
}