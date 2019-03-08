using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Arrays
{
    public static void Main(string [] args)
    {
        Console.WriteLine(2);
        for (int n = 3; n < 101; n++)
        {
            int c = 2;
            int x = 0;
            while (n > c)
            {
                if (n % c == 0)
                {
                    x++;
                    break;
                }
                else
                {
                    c++;
                }
            }
            if(x == 0)
                Console.WriteLine(n);
        }



        Console.ReadKey();
    }
}
