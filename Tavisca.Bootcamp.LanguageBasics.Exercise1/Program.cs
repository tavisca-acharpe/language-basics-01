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
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here  .
			
			int no1, no2, no3;
                char[] splitchars = { '=' };
                string[] numbers = equation.Split(splitchars);

                char[] splitcharsR = { '?' };
                string[] numbersR = numbers[1].Split(splitcharsR);

                int len = numbersR.Length;           

              if(len == 2)
                {
                    // Right side ? mark
                    char[] splitcharsR1 = { '*' };
                    string[] numbersR1 = numbers[0].Split(splitcharsR1);

                    no1 = int.Parse(numbersR1[0]);
                    no2 = int.Parse(numbersR1[1]); ;
                    no3 = no1 * no2;

                    int index = numbers[1].IndexOf('?');
                    index=index+1;

                    int[] n = new int[1000];
                    int c = 0;

                    while (no3 != 0)
                    {
                        n[c] = no3 % 10;
                        no3 = no3 / 10;
                        c++;
                    }
               
                    c=c-index;
                    return n[c];
                }
                else
                {
                    // For left side ?
                    char[] splitcharsR1 = { '*' };
                    string[] numbersL1 = numbers[0].Split(splitcharsR1);

                    int L0 = numbersL1[0].IndexOf('?');
                    int L1 = numbersL1[1].IndexOf('?');

                    no3 = int.Parse(numbers[1]);
                    
                    if (L0 == -1) // ? not avilable at 1st no 
                    {
                        // 2nd no contain ?
       
                        char[] splitcharsL2 = { '?' };
                        string[] numbersL2 = numbersL1[1].Split(splitcharsL2);

                        L1 = L1 + 1;
                        no1 = int.Parse(numbersL1[0]);                        

                        //for 2*2?=4
                        if (string.IsNullOrEmpty(numbersL2[0]))
                        {
                            int check = int.Parse(numbersL2[1]);
                            int i = check * no1;
                            if (i == no3)
                                return -1;
                        }
                        else
                        {
                            int check = int.Parse(numbersL2[0]);
                            int i = check * no1;
                            if (i == no3)
                                return -1;
                        }
                        
                            int[] n = new int[1000];
                            int c = 0;

                        //invalid division
                            decimal d = (decimal)no3 / no1;
                            if ((d % 1) > 0)
                            {
                                return -1;
                            }

                        //to find number
                            no2 = no3 / no1;    
                         
                            while (no2 != 0)
                            {
                                n[c] = no2 % 10;
                                no2 = no2 / 10;
                                c++;
                            }

                            int m = c;
                            c = c - L1;
                            if (c < 0 || c > m-1)
                                return -1;

                          return n[c];
                        
                    }
                    else  // ? not avilable at 2nd number
                    {
                       // 1st no contain ?

                       L0 = L0 + 1;
                       no2 = int.Parse(numbersL1[1]);

                       char[] splitcharsL2 = { '?' };
                       string[] numbersL2 = numbersL1[0].Split(splitcharsL2);
                      
                        
                       //for 2?*2=4
                       if (string.IsNullOrEmpty(numbersL2[0]))
                       {
                           int check = int.Parse(numbersL2[1]);
                           int i = check * no2;
                           if (i == no3)
                            return -1;

                       }
                       else
                       {
                           int check = int.Parse(numbersL2[0]);
                           int i = check * no2;
                           if (i == no3)
                               return -1;
                       }

                           int[] n = new int[1000];
                           int c = 0;
                        //invalid division
                           decimal d = (decimal)no3 / no2;
                           if ((d % 1) > 0)
                           {
                               return -1;
                           }
                           
                            no1 = no3 / no2;
                        //find no
                           while (no1 != 0)
                           {
                               n[c] = no1 % 10;
                               no1 = no1 / 10;
                               c++;
                           }

                           int m = c;
                           c = c - L0;
                           if (c < 0 || c > m - 1)
                               return -1;  
                        return n[c];
                   }
   
                }
              return -1;     
			
            throw new NotImplementedException();
        }
    }
}
