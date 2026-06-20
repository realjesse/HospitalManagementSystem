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

// This form shows when a PROVIDER is attempting to register a patient
namespace HospitalClient.Forms
{
    public partial class ProviderRegisteringPatientForm : Form
    {
        public ProviderRegisteringPatientForm()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var providerPatientInfoViewForm = new ProviderPatientInfoViewForm();
            providerPatientInfoViewForm.Show();
            this.Hide();
        }

        private async void registerButton_Click(object sender, EventArgs e)
        {
            var request = new RegisterPatientRequest
            {
                Username = usernameTextBox.Text.Trim(),
                Password = passwordTextBox.Text.Trim(),
                FirstName = firstNameTextBox.Text.Trim(),
                LastName = lastNameTextBox.Text.Trim(),
                DateOfBirth = dateOfBirthPicker.Value.Date
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(
                    "http://localhost:5265/api/auth/register-patient",
                    content);

                if (!response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode}\n{body}");
                }

                MessageBox.Show("Patient registered successfully!");

                // Go back to patient view
                var providerPatientInfoViewForm = new ProviderPatientInfoViewForm();
                providerPatientInfoViewForm.Show();
                this.Hide();
            }
        }
    }
}
