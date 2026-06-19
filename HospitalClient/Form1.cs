using HospitalClient.Forms;
using HospitalClient.Models;
using HospitalClient.Session;
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

namespace HospitalClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                var loginRequest = new LoginRequest
                {
                    Username = usernameTextBox.Text,
                    Password = passwordTextBox.Text
                };

                var json = JsonConvert.SerializeObject(loginRequest);

                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json"
                 );


                var httpClient = new HttpClient();

                var response = await httpClient.PostAsync("http://localhost:5265/api/auth/login", content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Invalid credentials.");
                    return;
                }

                // Deserialize content of response to get necessary info for CurrentUser session
                var responseJson = await response.Content.ReadAsStringAsync();

                var authResponse = JsonConvert.DeserializeObject<AuthResponse>(responseJson);

                // Update session CurrentUser with values and enter MenuForm
                CurrentUser.UserId = authResponse.UserId ?? "";
                CurrentUser.UserName = authResponse.Username ?? "";
                CurrentUser.Role = authResponse.Role ?? "";

                // Enter MenuForm
                var menuForm = new MenuForm();
                menuForm.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void goToRegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();

            registerForm.Show();

            this.Hide();
        }
    }
}
