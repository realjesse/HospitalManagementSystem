using HospitalClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalClient.Forms
{
    public partial class InventoryForm : Form
    {
        private readonly string _baseUrl = "http://localhost:5265";
        private List<InventoryItemDto> _items = new List<InventoryItemDto>();

        public InventoryForm()
        {
            InitializeComponent();
        }

        private async void InventoryForm_Load(object sender, EventArgs e)
        {
            await LoadInventoryAsync();
        }

        private async Task LoadInventoryAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseUrl + "/api/inventory");

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Could not load inventory.");
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();
                _items = JsonConvert.DeserializeObject<List<InventoryItemDto>>(json) ?? new List<InventoryItemDto>();

                inventoryGridView.DataSource = null;
                inventoryGridView.DataSource = _items;
            }

            foreach (DataGridViewRow row in inventoryGridView.Rows)
            {
                var item = row.DataBoundItem as InventoryItemDto;

                if (item != null && item.IsLowStock)
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        private InventoryItemRequest GetRequestFromForm()
        {
            return new InventoryItemRequest
            {
                ItemName = itemNameTextBox.Text,
                Category = categoryTextBox.Text,
                Quantity = (int)quantityNumericUpDown.Value,
                MinimumStockLevel = (int)minimumStockNumericUpDown.Value,
                Unit = unitTextBox.Text
            };
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            var request = GetRequestFromForm();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(_baseUrl + "/api/inventory", content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Could not add inventory item.");
                    return;
                }
            }

            MessageBox.Show("Inventory item added.");
            await LoadInventoryAsync();
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (inventoryGridView.CurrentRow == null)
            {
                MessageBox.Show("Select an item to update.");
                return;
            }

            var item = inventoryGridView.CurrentRow.DataBoundItem as InventoryItemDto;
            if (item == null) return;

            var request = GetRequestFromForm();
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsync(_baseUrl + "/api/inventory/" + item.InventoryItemId, content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Could not update inventory item.");
                    return;
                }
            }

            MessageBox.Show("Inventory item updated.");
            await LoadInventoryAsync();
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (inventoryGridView.CurrentRow == null)
            {
                MessageBox.Show("Select an item to delete.");
                return;
            }

            var item = inventoryGridView.CurrentRow.DataBoundItem as InventoryItemDto;
            if (item == null) return;

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(_baseUrl + "/api/inventory/" + item.InventoryItemId);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Could not delete inventory item.");
                    return;
                }
            }

            MessageBox.Show("Inventory item deleted.");
            await LoadInventoryAsync();
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            await LoadInventoryAsync();
        }

        private void inventoryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (inventoryGridView.CurrentRow == null) return;

            var item = inventoryGridView.CurrentRow.DataBoundItem as InventoryItemDto;
            if (item == null) return;

            itemNameTextBox.Text = item.ItemName;
            categoryTextBox.Text = item.Category;
            quantityNumericUpDown.Value = item.Quantity;
            minimumStockNumericUpDown.Value = item.MinimumStockLevel;
            unitTextBox.Text = item.Unit;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
        }
    }
}
