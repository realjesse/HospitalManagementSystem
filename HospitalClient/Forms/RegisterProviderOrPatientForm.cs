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
    public partial class RegisterProviderOrPatientForm : Form
    {
        public RegisterProviderOrPatientForm()
        {
            InitializeComponent();
        }

        private void patientButton_Click(object sender, EventArgs e)
        {
            var registerPatientForm = new RegisterPatientForm();
            registerPatientForm.Show();
            this.Hide();
        }

        private void providerButton_Click(object sender, EventArgs e)
        {
            var registerProviderForm = new RegisterForm();
            registerProviderForm.Show();
            this.Hide();
        }
    }
}
