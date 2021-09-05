using System;
using System.Collections.Generic;

namespace _5Kyu_FindFirstAndOnlyLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new[] {-2, 0, 1, 2, 3, 4 };

            Console.WriteLine(Extract(arr));
            Console.ReadKey();
        }

        public static string Extract(int[] args)
        {
            if (args.Length < 3)
            {
                List<int> ls = new List<int>();
                foreach (int x in args)
                {
                    ls.Add(x);
                }
                return string.Join(",", ls.ToArray());
            }


            List<string> list = new List<string>();

            int temp1 = 0, temp2 = 0, counter = 0, helperZero = 0;

            for (int i = 0; i < args.Length; i++)
            {

                if (i + 1 != args.Length)
                    if (args[i] + 1 == args[i + 1])
                    {
                        counter++;
                        if (temp1 == 0 && (args[helperZero] != 0 || args[i - 1] == 0))
                        {
                            temp1 = args[i];
                            helperZero = i;
                        }
                        temp2 = args[i + 1];
                        continue;
                    }
                if (i > 0)
                    if (args[i - 1]+1 == args[i] && counter >= 2)
                    {
                        temp2 = args[i];
                        list.Add(temp1 + "-" + temp2);

                        counter = 0;
                        temp1 = 0;
                        temp2 = 0;
                        helperZero = i;
                        continue;
                    }
                if (counter == 1 && (temp1!=0 || temp2!=0))
                {
                    list.Add(temp1 + "");
                    list.Add(temp2 + "");
                    temp1 = 0;
                    temp2 = 0;
                    counter = 0;
                    helperZero = i;
                    continue;
                }
                if(temp1+1 != temp2)
                {
                    list.Add(args[i].ToString());
                    helperZero = i;
                }
            }

            return string.Join(",", list.ToArray());
        }
    }
}
