using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Teodor_11a_23.Controller;
using Teodor_11a_23.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Teodor_11a_23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<VegetableType> allVegetables = vegetableTypeController.GetAllVegetables();
            cmbType.DataSource = allVegetables;
            cmbType.DisplayMember = "TypeName";
            cmbType.ValueMember = "Id";
            cmbType.Text = "";
            Add();
        }

        VegetableLogic vegetableController = new VegetableLogic();
        VegetableTypeLogic vegetableTypeController = new VegetableTypeLogic();

        private void LoadVegetable(Vegetable vegetable)
        {
            txtID.Text = vegetable.Id.ToString();
            txtName.Text = vegetable.Name.ToString();
            txtDescription.Text = vegetable.Description;
            txtPrice.Text = Math.Round(vegetable.Price,2).ToString();
            cmbType.Text = $"{vegetable.VegetableTypeId}: {vegetable.VegetableType.TypeName}";
        }

        private void ClearScreen()
        {
            txtID.Clear();
            txtName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            cmbType.Text = "";
        }

        private void White()
        {
            txtID.BackColor = Color.White;
            txtName.BackColor = Color.White;
            txtDescription.BackColor = Color.White;
            txtPrice.BackColor = Color.White;
            cmbType.BackColor = Color.White;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double price;
            White();
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.BackColor = Color.Red;
                txtName.Focus();
                return;
            }
            White();
            if (string.IsNullOrEmpty(txtPrice.Text) || !double.TryParse(txtPrice.Text, out price))
            {
                txtPrice.BackColor = Color.Red;
                txtPrice.Focus();
                return;
            }
            White();
            if (string.IsNullOrEmpty(cmbType.Text))
            {
                cmbType.BackColor = Color.Red;
                cmbType.Focus();
                return;
            }
            White();

            Vegetable _vegetable = new Vegetable();
            _vegetable.Name = txtName.Text;
            _vegetable.Price = Math.Round(price,2);
            _vegetable.Description = txtDescription.Text;
            _vegetable.VegetableTypeId = (int)cmbType.SelectedValue;

            vegetableController.Create(_vegetable);

            MessageBox.Show("Записът е успешно добавен!");
            ClearScreen();
            Add();
        }

        private void Add()
        {
            dgvVegetables.DataSource = vegetableController.GetAll();
            dgvVegetables.Columns["Id"].HeaderText = "ID";
            dgvVegetables.Columns["Name"].HeaderText = "Name";
            dgvVegetables.Columns["Price"].HeaderText = "Price";

            dgvVegetables.Columns["VegetableType"].Visible = false;
            dgvVegetables.Columns["Description"].Visible = false;
            dgvVegetables.Columns["VegetableTypeId"].Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int id;
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Въведете Id за търсене!");
                txtID.BackColor = Color.Red;
                txtID.Focus();
                return;
            }
            if (!int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show("Невалидно Id!");
                txtID.BackColor = Color.Red;
                txtID.Focus();
                return;
            }
            White();

            Vegetable findedVegetable = vegetableController.Get(id);
            if (findedVegetable == null)
            {
                MessageBox.Show("Няма такъв запис в БД! \n Въведете валидно Id за търсене!");
                txtID.BackColor = Color.Red;
                txtID.Focus();
                return;
            }
            LoadVegetable(findedVegetable);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id;
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Въведете Id за търсене!");
                txtID.BackColor = Color.Red;
                txtID.Focus();
                return;
            }
            if (!int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show("Невалидно Id!");
                txtID.BackColor = Color.Red;
                txtID.Focus();
                return;
            }
            White();
            Vegetable findedVegetable = vegetableController.Get(id);
            if (findedVegetable == null)
            {
                MessageBox.Show("Няма такъв запис в БД! \n Въведете валидно Id за търсене!");
                txtID.BackColor = Color.Red;
                txtID.Focus();
                return;
            }
            LoadVegetable(findedVegetable);

            DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис No " + id + " ?",
            "PROMPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                vegetableController.Delete(id);
            }
            Add();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearScreen();
            White();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id;
            double price;
            if (string.IsNullOrEmpty(txtID.Text) )
            {
                MessageBox.Show("Въведете Id за търсене!");
                txtID.BackColor = Color.Red;
                txtID.Focus();
                return;
            }
            White();
            if (!int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show("Невалидно Id!");
                txtID.BackColor = Color.Red;
                txtID.Focus();
                return;
            }
            White();
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Vegetable findVegetable = vegetableController.Get(id);
                if (findVegetable == null)
                {
                    MessageBox.Show("Няма такъв запис в БД! \n Въведете валидно Id за търсене!");
                    txtID.BackColor = Color.Red;
                    txtID.Focus();
                    return;
                }
                LoadVegetable(findVegetable);
            }
            White();
            if (string.IsNullOrEmpty(txtPrice.Text) || !double.TryParse(txtPrice.Text, out price))
            {
                txtPrice.BackColor = Color.Red;
                txtPrice.Focus();
                return;
            }
            White();
            if (string.IsNullOrEmpty(cmbType.Text))
            {
                cmbType.BackColor = Color.Red;
                cmbType.Focus();
                return;
            }
            else 
            {
                Vegetable _vegetable = new Vegetable();
                _vegetable.Name = txtName.Text;
                _vegetable.Description = txtDescription.Text;
                _vegetable.Price = Math.Round(price,2);
                _vegetable.VegetableTypeId = (int)cmbType.SelectedValue;

                vegetableController.Update(id, _vegetable);
            }
            Add();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics mgraphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(5, 5, 220), 1);

            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(5, 5, 220), Color.FromArgb(245, 65, 181)
            , LinearGradientMode.ForwardDiagonal);

            mgraphics.FillRectangle(lgb, area);
            mgraphics.DrawRectangle(pen, area);
        }
    }
}
