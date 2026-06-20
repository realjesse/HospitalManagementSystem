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
    }
}
