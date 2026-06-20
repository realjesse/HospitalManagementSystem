using HospitalClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the PROVIDER'S view of the patient information.
// It allows providers to see all patients in the system, and also has a \
// button to create a new patient registration (which will open the RegisterPatientForm).
namespace HospitalClient.Forms
{
    public partial class ProviderPatientInfoViewForm : Form
    {
        private readonly string _baseUrl = "http://localhost:5265";
        public ProviderPatientInfoViewForm()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
        }

        private async void ProviderPatientInfoViewForm_Load(object sender, EventArgs e)
        {
            await LoadPatientsAsync();
        }

        private async Task LoadPatientsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(
                    _baseUrl + "/api/patients");

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Could not load patients");
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();

                var patients = JsonConvert.DeserializeObject<List<PatientDto>>(json);

                patientDataGridView.AutoGenerateColumns = true;
                patientDataGridView.DataSource = patients;
            }
        }

        private async void createButton_Click(object sender, EventArgs e)
        {
            var providerRegisertingPatientForm = new ProviderRegisteringPatientForm();
            providerRegisertingPatientForm.Show();
            this.Hide();
        }

        // Returns the selected patient from the data grid view
        private PatientDto GetSelectedPatient()
        {
            if (patientDataGridView.CurrentRow == null)
            {
                return null;
            }

            return patientDataGridView.CurrentRow.DataBoundItem as PatientDto;
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            var selectedPatient = GetSelectedPatient();

            if (selectedPatient == null)
            {
                MessageBox.Show("Please select a patient first.");
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete " +
                selectedPatient.FirstName + " " + selectedPatient.LastName + "?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(
                    _baseUrl + "/api/patients/" + selectedPatient.PatientId
                    );

                if (!response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Could not delete patient.\n\n" + body);
                    return;
                }
            }

            MessageBox.Show("Patient deleted.");
            await LoadPatientsAsync();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var patientEditForm = new PatientEditForm(GetSelectedPatient());
            patientEditForm.Show();
            this.Hide();
        }
    }
}
