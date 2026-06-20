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

// This is the PATIENT'S view of the patient information.
namespace HospitalClient.Forms
{
    public partial class PatientPatientInfoViewForm : Form
    {
        public PatientPatientInfoViewForm()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
        }

        private async void PatientPatientInfoViewForm_Load(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(
                    $"http://localhost:5265/api/patients/by-user/{Session.CurrentUser.UserId}");

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Could not load your patient information");
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();

                var patient = JsonConvert.DeserializeObject<PatientDto>(json);

                if (patient == null)
                {
                    MessageBox.Show("Could not read patient information.");
                    return;
                }

                firstNameLabel.Text = firstNameLabel.Text + " " + patient.FirstName;
                lastNameLabel.Text = lastNameLabel.Text + " " + patient.LastName;
                dateOfBirthLabel.Text = dateOfBirthLabel.Text + " "+ patient.DateOfBirth.ToShortDateString();
            }
        }
    }
}
