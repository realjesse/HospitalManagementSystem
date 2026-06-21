using HospitalClient.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalClient.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();

            if (!CurrentUser.IsProvider)
            {
                button_reportsButton.Enabled = false;
            }
        }

        private void viewPatientInfoButton_Click(object sender, EventArgs e)
        {
            // If the current session user is a patient, open patient form view.
            if (CurrentUser.IsPatient)
            {
                var patientPatientInfoViewForm = new PatientPatientInfoViewForm();
                patientPatientInfoViewForm.Show();
                this.Hide();
            }

            // If the current session user is a provider, open provider form view.
            else if (CurrentUser.IsProvider)
            {
                var providerPatientInfoViewForm = new ProviderPatientInfoViewForm();
                providerPatientInfoViewForm.Show();
                this.Hide();
            }
        }

        private void appointmentsButton_Click(object sender, EventArgs e)
        {
            var appointmentForm = new AppointmentForm();
            appointmentForm.Show();
            this.Hide();
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            var inventoryForm = new InventoryForm();
            inventoryForm.Show();
            this.Hide();
        }

        private void button_reportsButton_Click(object sender, EventArgs e)
        {
            //in case users still try the button when not logged in as provider
            if (!CurrentUser.IsProvider)
            {
                MessageBox.Show("Reports are only available to providers.");
                return;
            }

            var reportsForm = new ReportsForm();
            reportsForm.Show();
            this.Hide();
        }
    }
}
