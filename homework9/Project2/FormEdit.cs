using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace project1
{
    public partial class FormEdit : Form
    {
        bool addForm = false;
        OrderService orderService = new OrderService();
        public FormEdit()
        {
            InitializeComponent();
        }
        public Order temp{ set;get;}
        public FormEdit(Order order) : this()
        {
            if(order == null)
            {
                temp = new Order();
                addForm = true;
            }
            else
            {
                temp = order;
            }
            orderBindingSource.DataSource = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (test())
            {
                if (addForm)
                {
                    temp.ID = textBox1.Text;
                    temp.Name = comboBox2.Text;
                    temp.phoneNum = textBox2.Text;
                    if (orderService.SearchOrderbyID(temp.ID).Count() != 0)
                    {
                        MessageBox.Show("订单号已存在！");
                    }
                    else
                        orderService.AddOrder(temp);
                }
                else
                {
                    if (orderService.SearchOrderbyID(temp.ID).Count() > 1)
                    {
                        MessageBox.Show("订单号已存在！");
                    }
                    else
                    { orderService.Update(temp); }
                }
                this.Close();
            }
        }
        private void FormEdit_Load(object sender, EventArgs e)
        {
            textBox1.Text = ((Order)orderBindingSource.Current).ID;
            textBox2.Text = ((Order)orderBindingSource.Current).phoneNum;
        }
        
        public bool test()
        {
            Regex idTest = new Regex(@"\d{4}((0[1-9])|(1[0-2]))(([0-2][0-9])|(3[01]))\d{3}");
            bool ok = idTest.IsMatch(textBox1.Text);

            Regex phoneDianxinTest = new Regex(@"^1[3578][01379]\d{8}$");
            Regex phoneLiantongTest = new Regex(@"^1[34578][01256]\d{8}$");
            Regex phoneYidongTest = new Regex(@"^(134[012345678]\d{7}|1[34578][012356789]\d{8})$");
            bool ok_2 = (
                phoneDianxinTest.IsMatch(textBox2.Text) ||
                phoneLiantongTest.IsMatch(textBox2.Text) ||
                phoneYidongTest.IsMatch(textBox2.Text));
            if (textBox1.Text == null || comboBox2.Text == null)
            {
                MessageBox.Show("订单号/姓名不能为空！");
                return false;
            }
            else if (ok == false)
            {
                MessageBox.Show("订单号格式不正确！");
                return false;
            }
            else if (ok_2 == false)
            {
                MessageBox.Show("电话号码格式不正确！");
                return false;
            }
            else
                return true;
        }
    }
}
