using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using project1;

namespace project1
{
    public partial class FormEdit : Form
    {
        Order temp = null;
        List<OrderDetails> detailList = new List<OrderDetails>();
        public FormEdit()
        {
            InitializeComponent();
        }
        public Order getOrder()
        {
            return temp;
        }
        public FormEdit(Order order) : this()
        {
            orderBindingSource.DataSource = order;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("订单号/姓名不能为空！");
            }
            temp = new Order();
            ((Order)orderBindingSource.Current).ID = textBox1.Text;
            ((Order)orderBindingSource.Current).Name = comboBox2.Text;

            //if (((Order)orderBindingSource.Current).Items == null)
            //{
            //    ((Order)orderBindingSource.Current).Items.Add(new OrderDetails());
            //}
            List<OrderDetails> detailList = new List<OrderDetails>();
           
            foreach (DataGridViewRow rows in dataGridView1.Rows)
            {
                if (rows.Cells[0].Value == null)
                    break;
                OrderDetails detail = new OrderDetails(
                    rows.Cells[0].Value.ToString(),
                    Convert.ToUInt32(rows.Cells[1].Value),
                    Convert.ToDouble(rows.Cells[2].Value));
                detailList.Add(detail);
            }
            ((Order)orderBindingSource.Current).Items = detailList;
            temp = (Order)orderBindingSource.Current;
            ///MessageBox.Show("添加成功");
            this.Close();
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            textBox1.Text = ((Order)orderBindingSource.Current).ID;
            comboBox2.SelectedItem = ((Order)orderBindingSource.Current).Name;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
