using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Oct11_Task1
{
    static void Main()
    {
        string input = Console.ReadLine();

        int num = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '-' || input[i] == '0' || input[i] == '.')
            {
                continue;
            }
            num += int.Parse(input[i].ToString());
        }

        do
        {
            if (num <= 9)
            {
                Console.WriteLine(num);
                break;
            }
            else
            {
                input = num.ToString();
                num = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '0')
                    {
                        continue;
                    }
                    num += int.Parse(input[i].ToString());
                }
            }

        } while (true);
    }
}

