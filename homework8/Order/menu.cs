using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    class menu : OrderService
    {
        public void OrderMenu()
        {

            string temp;
            bool ifCircle = true;
            while (ifCircle)
            {
                try
                {
                    Console.WriteLine("菜单：");
                    Console.WriteLine("1.添加" + "\t2.删除" + "\t3.查询" + "\t4.修改" + "\t5.查看所有订单"
                        + "\t6.将所有订单序列化生成xml文件" + "\t7.从xml文件导入订单" + "\t8.按其他任意键退出");
                    temp = Console.ReadLine();
                    switch (temp)
                    {
                        case "1":
                            Console.WriteLine("输入A添加新订单，B添加条目");
                            string myChoice = Console.ReadLine();
                            if ("A" == myChoice)
                            {
                                Console.WriteLine("请输入：订单号、客户:");
                                string ID = Console.ReadLine();
                                string Name = Console.ReadLine();
                                Order temp1 = AddNewOrder(ID, Name);
                                do
                                {
                                    Console.WriteLine("请输入订单物品详细信息：名称、数量、价格");
                                    string Item = Console.ReadLine();
                                    uint Number = Convert.ToUInt32(Console.ReadLine());
                                    double Price = Convert.ToDouble(Console.ReadLine());
                                    AddDetails(Item, Number, Price, temp1);
                                    Console.WriteLine("添加成功！" + "\n是否继续？（Y/N）");
                                } while ("Y" == Console.ReadLine());

                            }
                            else if ("B" == myChoice)
                            {
                                Console.WriteLine("请输入要添加条目的订单号或客户：");
                                string temp1b = Console.ReadLine();
                                if (Search(temp1b).Count() == 0)
                                {
                                    Console.WriteLine("无此订单!");
                                    break;
                                }
                                do
                                {
                                    Console.WriteLine("请输入订单物品详细信息：名称、数量、价格（输入-1结束）");
                                    string Item = Console.ReadLine();
                                    uint Number = Convert.ToUInt32(Console.ReadLine());
                                    double Price = Convert.ToDouble(Console.ReadLine());
                                    foreach (Order n in Search(temp1b))
                                    {
                                        AddDetails(Item, Number, Price, n);
                                        break;
                                    }
                                    Console.WriteLine("添加成功！" + "\n是否继续？（Y/N）");
                                } while ("Y" == Console.ReadLine());
                            }
                            break;
                        case "2":
                            Console.WriteLine("请输入要进行删除操作的订单号或名称：");
                            string temp2 = Console.ReadLine();
                            if (Search(temp2).Count() == 0)
                            {
                                Console.WriteLine("无此订单!");
                                break;
                            }
                            Console.WriteLine("输入A删除订单，B删除条目");
                            myChoice = Console.ReadLine();
                            if ("A" == myChoice)
                            {
                                foreach (Order n in Search(temp2))
                                {
                                    orders.Remove(n);
                                    Console.WriteLine("删除成功！");
                                    break;
                                }
                            }
                            else if ("B" == myChoice)
                            {
                                do
                                {
                                    Console.WriteLine("请输入要删除的商品：");
                                    string temp2b = Console.ReadLine();
                                    foreach (Order n in Search(temp2))
                                    {
                                        var query2 = n.Items.Where(m => m.Item == temp2b);
                                        if (query2.Count() == 0)
                                        {
                                            Console.WriteLine("无此商品！\n是否继续？（Y/N）");
                                            break;
                                        }
                                        RemoveDetails(temp2b, n);
                                        Console.WriteLine("删除成功！\n是否继续？（Y/N）");
                                    }
                                } while ("Y" == Console.ReadLine());
                            }
                            break;
                        case "3": //查询
                            Console.WriteLine("输入A查询订单，B筛选价格范围");
                            myChoice = Console.ReadLine();
                            if ("A" == myChoice)
                            {
                                Console.WriteLine("请输入你想查询的订单号:");
                                string temp3a = Console.ReadLine();
                                SearchOrderbyID(temp3a);
                            }
                            else if ("B" == myChoice)
                            {
                                Console.WriteLine("请输入要筛选的订单的价位区间：");
                                string str1 = Console.ReadLine();
                                double temp3a1 = Convert.ToDouble(str1);
                                string str2 = Console.ReadLine();
                                double temp3a2 = Convert.ToDouble(str2);
                                if (str1 != null && str2 != null)
                                {
                                    SearchPrice(temp3a1, temp3a2);
                                }
                                else if (str1 == null && str2 != null)
                                {
                                    SearchPriceLessThan(temp3a2);
                                }
                                else if(str1 != null && str2 == null)
                                {
                                    SearchPriceMoreThan(temp3a1);
                                }
                                    
                            }
                            break;
                        case "4":
                            Console.WriteLine("输入A修改订单，B修改条目");
                            myChoice = Console.ReadLine();
                            if ("A" == myChoice)
                            {
                                Console.WriteLine("输入想要修改的数据的前后值：");
                                string temp4a1 = Console.ReadLine();
                                string temp4a2 = Console.ReadLine();
                                if (ifExist(temp4a1))
                                {
                                    foreach (Order n in Search(temp4a1))
                                    {
                                        ReviseOrder(temp4a1, temp4a2, n);
                                        Console.WriteLine("修改成功！");
                                        break;
                                    }
                                }
                                else break;
                            }
                            else if ("B" == myChoice)
                            {
                                Console.WriteLine("输入你要修改明细的订单号或名称：");
                                string temp4b = Console.ReadLine();
                                if (ifExist(temp4b) == false) break;
                                Console.WriteLine("输入你要修改的条目的名称," +
                                    "要修改的明细类型（a.名称;b.数量;c.价格）," +
                                    "以及修改的数据改变后的值");
                                string temp4b1 = Console.ReadLine();
                                string temp4b2 = Console.ReadLine();
                               
                                if (temp4b2 == "a")
                                {
                                    string temp4b3 = Console.ReadLine();
                                    foreach (Order n in Search(temp4b))
                                    {
                                        ReviseItem(temp4b3, temp4b1, n);
                                        break;
                                    }
                                }
                                else if (temp4b2 == "b")
                                {
                                    uint temp4b4 = Convert.ToUInt32(Console.ReadLine());
                                    foreach (Order n in Search(temp4b))
                                    {
                                        ReviseNumber(temp4b4, temp4b1, n);
                                    }
                                }
                                else if (temp4b2 == "c")
                                {
                                    double temp4b4 = Convert.ToDouble(Console.ReadLine());
                                    foreach(Order n in Search(temp4b))
                                    {
                                        RevisePrice(temp4b4, temp4b1, n);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("请输入有效的明细类型范围！");
                                    break;
                                }
                            }
                            break;
                        case "5":
                            Console.WriteLine("以下是所有订单：");
                            Order ordertemp = new Order();
                            ordertemp.ToString();
                            break;
                        case "6":
                            Console.WriteLine("请输入生成路径及xml文件名" +
                                "（例：D:\\Git\mist\\learngit\\Homework7\\project1\\Order.xml）：");
                            string fileName = Console.ReadLine();
                            Export(fileName);
                            break;
                        case "7":
                            Console.WriteLine("请输入xml文件及所在路径：" +
                                "（例：D:\\Git\mist\\learngit\\Homework7\\project1\\Order.xml）");
                            string filename = Console.ReadLine();
                            Import(filename);
                            break;
                        default:
                            ifCircle = false;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("err：格式错误！");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("err:数据超出范围！");
                }
                catch(InvalidCastException)
                {
                    Console.WriteLine("err:数据转换失败！");
                }
                catch(ArgumentNullException)
                {
                    Console.WriteLine("err:参数错误！");
                }
                catch(FileNotFoundException)
                {
                    Console.WriteLine("路径错误！");
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("不允许输入空路径！");
                }
                catch(System.NotSupportedException)
                {
                    Console.WriteLine("路径格式错误！");
                }
            }
        }
    }
}
