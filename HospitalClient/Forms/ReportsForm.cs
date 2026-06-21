using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalClient.Forms
{
    public partial class ReportsForm : Form
    {
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HospitalManagementDb;Integrated Security=True;TrustServerCertificate=True";

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void button_generateReport_Click(object sender, EventArgs e)
        {
            string reportType = comboBox_reportType.Text;

            SqlConnection connection;
            SqlDataAdapter adapter;
            DataTable table = new DataTable();
            string sql;

            if (reportType == "Patient Visits")
            {
                sql = "SELECT Appointments.AppointmentId, Patients.FirstName, Patients.LastName, " +
                    "Appointments.DoctorName, Appointments.AppointmentDate, " +
                    "Appointments.Reason, Appointments.Status " +
                    "FROM Appointments " +
                    "INNER JOIN Patients ON Appointments.PatientId = Patients.PatientId " +
                    "ORDER BY Appointments.AppointmentDate DESC";
            }
            else if (reportType == "Common Ailments")
            {
                sql = "SELECT Reason AS Ailment, COUNT(*) AS TotalCases " +
                    "FROM Appointments " +
                    "GROUP BY Reason " +
                    "ORDER BY TotalCases DESC";
            }
            else if (reportType == "Medication")
            {
                sql = "SELECT ItemName AS MedicationName, Quantity, MinimumStockLevel, Unit, LastUpdated " +
                    "FROM InventoryItems " +
                    "WHERE Category = 'Medication' " +
                    "ORDER BY ItemName";
            }
            else
            {
                MessageBox.Show("Please select a valid report type!");
                return;
            }

            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(sql, connection);

            adapter.Fill(table);

            dataGridView_data.DataSource = table;

            MessageBox.Show("Woo hoo, report was generated successfully!");
        }

        private void button_calculateAnalytics_Click(object sender, EventArgs e)
        {
            SqlConnection connection;
            SqlCommand command;
            string sql;

            connection = new SqlConnection(connectionString);
            connection.Open();

            sql = "SELECT COUNT(*) FROM Appointments";
            command = new SqlCommand(sql, connection);
            int totalAppointments = (int)command.ExecuteScalar();

            sql = "SELECT COUNT(*) FROM Appointments WHERE Status = 'Completed'";
            command = new SqlCommand(sql, connection);
            int completedAppointments = (int)command.ExecuteScalar();

            sql = "SELECT TOP 1 Reason " +
                "FROM Appointments " +
                "GROUP BY Reason " +
                "ORDER BY COUNT(*) DESC";
            command = new SqlCommand(sql, connection);
            string topAilment = command.ExecuteScalar()?.ToString();

            sql = "SELECT COUNT(*) " +
                "FROM InventoryItems " +
                "WHERE Category = 'Medication' AND Quantity < MinimumStockLevel";
            command = new SqlCommand(sql, connection);
            int lowStockMedications = (int)command.ExecuteScalar();

            connection.Close();

            MessageBox.Show(
                "Analytics calculated:\n\n" +
                $"Total Appointments: {totalAppointments}\n" +
                $"Completed Appointments: {completedAppointments}\n" +
                $"Top Ailment: {topAilment}\n" +
                $"Low Stock Medications: {lowStockMedications}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView_data.DataSource == null)
            {
                MessageBox.Show("Please make a report first before exporting.");
                return;
            }

            if (comboBox_exportFormat.Text != "CSV")
            {
                MessageBox.Show("Only CSV type is supported currently.");
                return;
            }

            DataTable table = (DataTable)dataGridView_data.DataSource;
            StringBuilder sb = new StringBuilder();

            //Adds the  header row
            foreach (DataColumn column in table.Columns)
            {
                sb.Append(column.ColumnName + ",");
            }

            sb.AppendLine();

            //Add s the data rows
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    sb.Append(row[column].ToString() + ",");
                }

                sb.AppendLine();
            }
            //sets export button filepath to desktop 
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "hospitalReport.csv");

            File.WriteAllText(filePath, sb.ToString());
            MessageBox.Show("Report exported successfully to your Desktop.");
        }

        private void button_backButton_Click(object sender, EventArgs e)
        {
            var menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
        }
    }
}
