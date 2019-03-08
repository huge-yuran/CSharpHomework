using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Prime
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("输入一个数：");
            int num = Convert.ToInt32(Console.ReadLine());
            for (int j = 2; j < num; j++)
                    {
                        while (num != j)
                        {
                            if (num % j == 0)
                            {
                                Console.Write(j + "*");
                                num /= j;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    Console.WriteLine(num);
         }
    }
}
