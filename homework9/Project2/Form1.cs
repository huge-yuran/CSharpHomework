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

namespace project2
{
    public partial class Form1 : Form
    {
        OrderService orderService = new OrderService();
        public static List<Order> orders = new List<Order>();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    orderBindingSource.DataSource = orderService.SearchOrderbyID(textBox1.Text);
                    break;
                case 1:
                    orderBindingSource.DataSource = orderService.SearchOrderbyName(textBox1.Text);
                    break;
                case 2:
                    orderBindingSource.DataSource = 
                        orderService.SearchPriceMoreThan(Convert.ToDouble(textBox1.Text));
                    break;
                case 3:
                    orderBindingSource.DataSource =
                       orderService.SearchPriceLessThan(Convert.ToDouble(textBox1.Text));
                    break;
                case 4:
                    orderBindingSource.DataSource =
                        orderService.SearchOrderbyItem(textBox1.Text);
                    break;
                default:
                    orderBindingSource.DataSource = orderService.SearchAllOrders();
                   // orderService.SearchAllOrders();
                    break;                  
            }
        }  //search
        private void button2_Click(object sender, EventArgs e)
        {
            FormEdit addform = new FormEdit(null);
            addform.ShowDialog();
            orderBindingSource.DataSource = orderService.SearchAllOrders();
        }  //add

        private void button3_Click(object sender, EventArgs e)
        {
            Order del = (Order)orderBindingSource.Current;
            if(del != null)
            {
                orderService.DeleteByID(del.ID);
                orderBindingSource.DataSource = orderService.SearchAllOrders();
            }
        }  //delete

        private void button4_Click(object sender, EventArgs e)
        {
            FormEdit reviseform = new FormEdit((Order)orderBindingSource.Current);
            reviseform.ShowDialog();
        }    // revise

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult butResult = openFileDialog1.ShowDialog();
            if (butResult.Equals(DialogResult.OK))
            {
                string filename = openFileDialog1.FileName;
                orders.AddRange(orderService.Import1(filename));
                orderBindingSource.DataSource = orderService.SearchAllOrders();
            }
        }      //import xml

        private void button6_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string filename = saveFileDialog1.FileName;
            orderService.Export(filename);
        } //export to xml
        
        private void button7_Click(object sender, EventArgs e)
        {
            string filename = openFileDialog1.FileName;
            orderService.Export(filename);
            orders = orderService.Import1(filename);
            orderBindingSource.DataSource = orders;
        } //refresh

        private void button8_Click(object sender, EventArgs e)
        {
            saveFileDialog2.ShowDialog();
            string filename = saveFileDialog2.FileName;
            orderService.XmlToHtml(filename);
        }   //transport xml to html
    }
}
