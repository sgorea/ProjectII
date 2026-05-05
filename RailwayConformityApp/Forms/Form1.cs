using RailwayConformityApp.Models;
using RailwayConformityApp.Enums;
using RailwayConformityApp.Data;
using System;
using System.Windows.Forms;

namespace RailwayConformityApp
{
    public partial class Form1 : Form

    {
        private RailwayConformityApp.Data.TrackElementRepository _repoElements = new RailwayConformityApp.Data.TrackElementRepository();
        private Data.MeasurementRepository _repoMeasurements = new Data.MeasurementRepository();
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
        private void ClearInputFields()
        {
            txtGauge.Clear();
            txtLevel.Clear();
            txtArrow.Clear();
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtPosition.Clear();
            txtName.Focus();
        }


        private void btnAddMeasurement_Click(object sender, EventArgs e)
        {
            // 1. Verificăm dacă un element de cale este selectat în tabel (DataGridView)
            if (dgvElements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Te rog să selectezi mai întâi un element de cale din listă!");
                return;
            }

            // Luăm ID-ul elementului selectat
            var selectedElement = (TrackElement)dgvElements.SelectedRows[0].DataBoundItem;

            try
            {
                // 2. AICI ADAGI COMANDA TA: Creăm obiectul cu datele din interfață
                var newMeasurement = new Measurement
                {
                    ElementId = selectedElement.Id,
                    OperatorId = Session.CurrentUser.Id, // Folosim sesiunea activă pentru trasabilitate
                    Gauge = double.Parse(txtGauge.Text),
                    Level = double.Parse(txtLevel.Text),
                    Arrow = double.Parse(txtArrow.Text),
                    MeasuredAt = DateTime.Now
                };

                // 3. Salvăm în baza de date folosind Repository-ul tău
                _repoMeasurements.Save(newMeasurement);

                MessageBox.Show("Măsurătoarea a fost salvată cu succes!");

                // Opțional: Reîmprospătăm lista sau curățăm câmpurile
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la introducerea datelor: " + ex.Message);
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            // 1. Verificăm dacă utilizatorul a selectat un rând în tabelul de elemente
            if (dgvElements.SelectedRows.Count > 0)
            {
                // 2. Extragem obiectul selectat (șina/elementul de cale)
                var selectedElement = (TrackElement)dgvElements.SelectedRows[0].DataBoundItem;

                try
                {
                    // 3. Mergem la baza de date să luăm toate măsurătorile salvate pentru acest element
                    // Folosim repository-ul de măsurători creat anterior
                    var measRepo = new RailwayConformityApp.Data.MeasurementRepository();
                    var measurements = measRepo.GetByElementId(selectedElement.Id);

                    // Verificăm dacă avem ce să tipărim
                    if (measurements.Count == 0)
                    {
                        MessageBox.Show("Nu există măsurători salvate pentru acest element. Adăugați câteva date mai întâi!", "Lipsă Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 4. Apelăm serviciul ReportGenerator pentru a crea PDF-ul
                    var reportService = new RailwayConformityApp.Services.ReportGenerator();
                    reportService.GeneratePdfReport(selectedElement, measurements);

                    // Mesajul de succes este afișat deja în interiorul serviciului
                }
                catch (Exception ex)
                {
                    // În caz că apare o eroare (ex: baza de date e blocată sau lipsește biblioteca PDF)
                    MessageBox.Show($"A apărut o eroare la generarea raportului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Dacă utilizatorul a apăsat butonul fără să selecteze nimic în tabel
                MessageBox.Show("Vă rugăm să selectați un element din tabel pentru a genera raportul!", "Selecție necesară", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var listaElemente = _repoElements.GetAll(); // Ia datele din SQL
            dgvElements.DataSource = listaElemente;    // Le „varsă” în tabelul de pe ecran
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}