using HospitalClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalClient.Forms
{
    public partial class PatientEditForm : Form
    {

        private readonly string _baseUrl = "http://localhost:5265";
        private readonly PatientDto _patient;

        // Pass a patient as parameter so it can update
        public PatientEditForm(PatientDto patient)
        {
            InitializeComponent();

            _patient = patient;

            firstNameTextBox.Text = patient.FirstName;
            lastNameTextBox.Text = patient.LastName;
            dateOfBirthPicker.Value = patient.DateOfBirth;

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var providerPatientInfoViewForm = new ProviderPatientInfoViewForm();
            providerPatientInfoViewForm.Show();
            this.Hide();
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            // Use values from text boxes to create request structure
            var request = new PatientRequest
            {
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                DateOfBirth = dateOfBirthPicker.Value.Date
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PutAsync(
                        _baseUrl + "/api/patients/" + _patient.PatientId,
                        content
                        );

                    if (!response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Could not update patient.\n\n" + body);
                        return;
                    }
                }

                MessageBox.Show("Patient updated");

                // Go back to patient views
                var providerPatientInfoViewForm = new ProviderPatientInfoViewForm();
                providerPatientInfoViewForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating patient: " + ex.Message);
            }
        }
    }
}
