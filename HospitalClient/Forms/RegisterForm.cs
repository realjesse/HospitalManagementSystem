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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HospitalClient.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void goToLoginButton_Click(object sender, EventArgs e)
        {
            // Login form
            Form1 form1 = new Form1();

            form1.Show();

            this.Hide();
        }

        private async void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get role
                System.Windows.Forms.RadioButton selectedRole = roleGroupBox.Controls
                    .OfType<System.Windows.Forms.RadioButton>()
                    .FirstOrDefault(rb => rb.Checked);

                // Check if there are inputted values for each field
                if (selectedRole == null)
                {
                    MessageBox.Show("Please select a role.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
                {
                    MessageBox.Show("Please enter a username.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
                {
                    MessageBox.Show("Please enter a password.");
                    return;
                }

                var registerRequest = new RegisterRequest
                {
                    Username = usernameTextBox.Text,
                    Password = passwordTextBox.Text,
                    Role = selectedRole.Text
                };


                var json = JsonConvert.SerializeObject(registerRequest);

                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json"
                 );


                var httpClient = new HttpClient();

                var response = await httpClient.PostAsync("http://localhost:5265/api/auth/register", content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Unable to upload. Please try again.");
                    return;
                }

                // Show success message and return to login
                MessageBox.Show("Registration successful! Please log in.");
                Form1 loginForm = new Form1();

                loginForm.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
