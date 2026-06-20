using HospitalClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalClient.Forms
{
    public partial class AppointmentForm : Form
    {
        private readonly string _baseUrl = "http://localhost:5265";
        private List<AppointmentDto> _appointments = new List<AppointmentDto>();

        public AppointmentForm()
        {
            InitializeComponent();

            statusComboBox.Items.Add("Scheduled");
            statusComboBox.Items.Add("Cancelled");
            statusComboBox.Items.Add("Completed");
            statusComboBox.SelectedIndex = 0;
        }

        private async void AppointmentForm_Load(object sender, EventArgs e)
        {
            await LoadAppointmentsAsync();
        }

        private async Task LoadAppointmentsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseUrl + "/api/appointments");

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Could not load appointments.");
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();
                _appointments = JsonConvert.DeserializeObject<List<AppointmentDto>>(json) ?? new List<AppointmentDto>();

                appointmentsGridView.DataSource = null;
                appointmentsGridView.DataSource = _appointments;
            }
        }

        private AppointmentRequest GetRequestFromForm()
        {
            return new AppointmentRequest
            {
                PatientId = int.Parse(patientIdTextBox.Text),
                DoctorName = doctorNameTextBox.Text,
                AppointmentDate = appointmentDatePicker.Value,
                Reason = reasonTextBox.Text,
                Status = statusComboBox.Text
            };
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            var request = GetRequestFromForm();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(_baseUrl + "/api/appointments", content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Could not add appointment.");
                    return;
                }
            }

            MessageBox.Show("Appointment added.");
            await LoadAppointmentsAsync();
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (appointmentsGridView.CurrentRow == null)
            {
                MessageBox.Show("Select an appointment to update.");
                return;
            }

            var appointment = appointmentsGridView.CurrentRow.DataBoundItem as AppointmentDto;
            if (appointment == null) return;

            var request = GetRequestFromForm();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsync(_baseUrl + "/api/appointments/" + appointment.AppointmentId, content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Could not update appointment.");
                    return;
                }
            }

            MessageBox.Show("Appointment updated.");
            await LoadAppointmentsAsync();
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (appointmentsGridView.CurrentRow == null)
            {
                MessageBox.Show("Select an appointment to delete.");
                return;
            }

            var appointment = appointmentsGridView.CurrentRow.DataBoundItem as AppointmentDto;
            if (appointment == null) return;

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(_baseUrl + "/api/appointments/" + appointment.AppointmentId);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Could not delete appointment.");
                    return;
                }
            }

            MessageBox.Show("Appointment deleted.");
            await LoadAppointmentsAsync();
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            await LoadAppointmentsAsync();
        }

        private void appointmentsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (appointmentsGridView.CurrentRow == null) return;

            var appointment = appointmentsGridView.CurrentRow.DataBoundItem as AppointmentDto;
            if (appointment == null) return;

            patientIdTextBox.Text = appointment.PatientId.ToString();
            doctorNameTextBox.Text = appointment.DoctorName;
            appointmentDatePicker.Value = appointment.AppointmentDate;
            reasonTextBox.Text = appointment.Reason;
            statusComboBox.Text = appointment.Status;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
        }
    }
}
