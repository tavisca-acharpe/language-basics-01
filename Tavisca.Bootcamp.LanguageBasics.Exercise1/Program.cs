using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
            
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine("{0} : {1}",args,result);
        }

        public static int FindDigit(string equation)
        {
         	   int no1, no2, no3;
                string qMark = "?";
                
                string[] LHSRHS = equation.Split('=');
                string LHS =LHSRHS[0];
                string RHS =LHSRHS[1];

                string[] Split_LHS = LHS.Split('*');
                string[] LHS_Split_LHS = Split_LHS[0].Split('?');    
                string[] RHS_Split_LHS = Split_LHS[1].Split('?');

                if (RHS.Contains(qMark))
                {
                    // Right side ? mark
                    no1 = int.Parse(Split_LHS[0]);
                    no2 = int.Parse(Split_LHS[1]); ;
                    no3 = no1 * no2;
                    int number = getMissingDigit(no3, LHSRHS[1]);
                    return number;
                }
                else
                {
                    no3 = int.Parse(LHSRHS[1]);
                    if (Split_LHS[0].Contains(qMark)) // ? not avilable at 1st no 
                    {
                        // 2nd no contain ?
                        no1 = int.Parse(Split_LHS[1]);
                        no2 = no3 / no1;
                        if (checkConditions(no1, no3, Split_LHS[0]) == -1)
                            return -1;
                        else
                          return  getMissingDigit(no2, Split_LHS[0]);
                     }
                    else  // ? not avilable at 2nd number
                    {
                        // 1st no contain ?
                        no1 = int.Parse(Split_LHS[0]);
                        no2 = no3 / no1;
                        if (checkConditions(no1, no3, Split_LHS[1]) == -1)
                            return -1;
                        else
                            return getMissingDigit(no2, Split_LHS[1]);
                    }

                }

            throw new NotImplementedException();
        }

        public static int checkConditions(int no1, int no2, string Split_LHS)
        {
            string[] FindQmark = Split_LHS.Split('?');
            int no3=0;  

            if (string.IsNullOrEmpty(FindQmark[0]))
               no3 = int.Parse(FindQmark[1]);         

            if (string.IsNullOrEmpty(FindQmark[1]))
             no3 = int.Parse(FindQmark[0]);
            
            int CalculatedValue = no1 * no3;
            if (CalculatedValue == no2)
              return -1;

            decimal d = (decimal)no2 / no1;
            if ((d % 1) > 0)
                return -1;
            
            return 0;
        }
        
        public static int getMissingDigit(int no3,string String)
        {
            int index = String.IndexOf('?');
            index = index + 1;

            int[] n = new int[1000];
            int temp = 0;

            while (no3 != 0)
            {
                n[temp] = no3 % 10;
                no3 = no3 / 10;
                temp++;
            }

            temp = temp - index;
            return n[temp];
        }
    }
}
