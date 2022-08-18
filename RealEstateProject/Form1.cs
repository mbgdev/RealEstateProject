using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstateProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Context context = new Context();


        private void btnList_Click(object sender, EventArgs e)
        {
            var result = context.Categories.ToList();

            dataGridView1.DataSource = result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Category category = new Category();

            category.CategoryName = txtName.Text;
            category.CategoryDetails = txtDetail.Text;
            context.Categories.Add(category);
            context.SaveChanges();
            MessageBox.Show("Kategori Eklendi");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            var result = context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();

            context.Categories.Remove(result);
            context.SaveChanges();
            MessageBox.Show("Kategori Silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            var result = context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            result.CategoryName = txtName.Text;
            result.CategoryDetails = txtDetail.Text;
            context.SaveChanges();
            MessageBox.Show("Kategori Güncellendi");
        }
    }
}
