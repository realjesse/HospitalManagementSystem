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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
