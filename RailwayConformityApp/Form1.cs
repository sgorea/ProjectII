using RailwayConformityApp.Models;
using RailwayConformityApp.Enums;
using RailwayConformityApp.Data;
using System;
using System.Windows.Forms;

namespace RailwayConformityApp
{
    public partial class Form1 : Form
    {
        private TrackElementRepository _repo = new TrackElementRepository();

        public Form1()
        {
            InitializeComponent();

           
            cmbType.DataSource = Enum.GetValues(typeof(ElementType));

            RefreshGrid();

            
            ApplyPermissions();
        }
        private void ApplyPermissions()
        {
            var user = Session.CurrentUser;

            if (user != null)
            {
                this.Text = $"Railway App - Logat ca: {user.Username} ({user.Role})";

                if (user.Role == UserRole.Worker)
                {
                   // if (this.Controls.ContainsKey("btnDelete")) btnDelete.Enabled = false;
                }
                else if (user.Role == UserRole.Engineer)
                {
                }
            }
        }

        private void btnAddElement_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPosition.Text))
                {
                    MessageBox.Show("Te rugăm să completezi toate câmpurile!");
                    return;
                }

                var newElement = new TrackElement
                {
                    Name = txtName.Text,
                    Type = (ElementType)cmbType.SelectedItem,
                    Position = double.Parse(txtPosition.Text),
                    IsActive = true,
                    LineSection = "Sectiunea 1" 
                };

                _repo.Save(newElement);

                MessageBox.Show($"Elementul '{newElement.Name}' a fost salvat cu succes în bază!");

                RefreshGrid();
                ClearInputs();
            }
            catch (FormatException)
            {
                MessageBox.Show("Te rugăm să introduci o valoare numerică validă pentru Poziție (ex: 120.5)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la salvare: " + ex.Message);
            }
        }

        private void RefreshGrid()
        {
            dgvElements.DataSource = null;
            dgvElements.DataSource = _repo.GetAll();

            if (dgvElements.Columns["Id"] != null) dgvElements.Columns["Id"].Visible = false;
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtPosition.Clear();
            txtName.Focus(); 
        }
    }
}