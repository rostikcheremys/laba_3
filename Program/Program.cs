using System;

namespace Program
{
    internal class Program
    {
        static void TaskFive(int signOfFirst, char[] firstOperand, string powerOfFirst, int signOfSecond, char[] secondOperand, string powerOfSecond)
        {
            int power = Convert.ToInt32(powerOfFirst, 2) - Convert.ToInt32(powerOfSecond, 2);
            string resultPower = "";
            
            if (power < 0)
            {
                Power(power, firstOperand,powerOfSecond, ref resultPower);
            }
            
            else if (power > 0)
            {
                Power(power, secondOperand,powerOfFirst, ref resultPower);
            }
            
            string convertOfFirst = "";
            string convertOfSecond = "";

            ConvertBinary(signOfFirst, firstOperand,ref convertOfFirst);
            ConvertBinary(signOfSecond, secondOperand,ref convertOfSecond);
            
            string sum = Convert.ToString(Convert.ToInt32(convertOfFirst, 2) + Convert.ToInt32(convertOfSecond, 2), 2);
            char[] straightSum = sum.ToCharArray();

            if (signOfFirst == 1 && signOfSecond == 1)
            {                        
                for (int i = sum.Length - 1; i > 0; i--)
                {
                    straightSum[i] = straightSum[i - 1];
                }
                
                straightSum[0] = '0';

                StraightSum(straightSum, resultPower);
                
                resultPower = Convert.ToString(Convert.ToInt32(resultPower, 2) + Convert.ToInt32("1", 2), 2);
                
                PrintArray(straightSum);
                Console.WriteLine($"{straightSum} 2^{resultPower}");
            }
            else
            {
                StraightSum(straightSum, resultPower);
                
                string resultSum = CharToString(straightSum);                
                string result = Math.Max(signOfFirst, signOfSecond) + resultSum;
                
                Console.WriteLine($"{result} 2^{resultPower}");
            }                        
        }
        static void Power(int power, char[] operand, string powerOfResult,ref string resultPower)
        {
            for (int i = operand.Length - 1; i >= 0; i--)
            {
                operand[i] = i >= power ? operand[i - power] : '0';
            }
            
            resultPower = powerOfResult;
        }
        static void StraightSum(char[] straightSum,string resultPower)
        {
            straightSum = Result(straightSum);
            
            if (straightSum[0] == '0')
            {
                Normalization(straightSum, resultPower);
            }  
        }
        static void ConvertBinary(int sing, char[] operand, ref string result)
        {
            if (sing == 1)
            {
                operand = Additional(operand);
                result = CharToString(operand).PadRight(15, '1');
            }
            else
            {
                result = CharToString(operand).PadRight(15, '0');
            }
        }
        static char[] Additional(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] == '1' ? '0' : '1';
            }
            
            bool isFlag = true;
            
            if (array[array.Length - 1] == '1')
            {
                for (int i = array.Length - 1; isFlag && i > 1; i--)
                {
                    if (array[i] == '0')
                    {
                        array[i] = '1';
                        isFlag = false;
                    }
                    else
                    {
                        array[i] = '0';
                    }
                }
            }
            else
            {
                array[array.Length - 1] = '1';
            }
 
            return array;
        }
        static void Normalization(char[] straightSum, string resultPower)
        {
            int count = 0;
            
            for (int i = 0; straightSum[i] != '1'; i++)
            {
                if (straightSum[i] == '0') count++;
            }
            for (int i = 0; i < straightSum.Length; i++)
            {
                if (i >= straightSum.Length - count)
                {
                    straightSum[i] = '0';
                }
                else
                {
                    straightSum[i] = straightSum[i + count];
                }
            }
            
            resultPower = Convert.ToString(Convert.ToInt32(resultPower, 2) - Convert.ToInt32(Convert.ToString(count, 2), 2), 2);
        }
        static char[] Result(char[] array)
        {
            if (array[array.Length - 1] == '1')
            {
                array[array.Length - 1] = '0';                
            }
            else
            {
                bool isFlag = true;
                
                for (int i = array.Length - 1; isFlag && i > 0; i--)
                {
                    if (array[i] == '1')
                    {
                        array[i] = '0';
                        array[i + 1] = '1';
                        isFlag = false;
                    }
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] == '1' ? '0' : '1';
            }
            return array;
        }
        static string CharToString(char[] array)
        {
            string result = "";
            
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }
            return result;
        }
        static void PrintArray(char[] array)
        {
            Console.Write("1");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
            Console.Write(" ");
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Введiть знаковий розряд, восьмирозрядне двiйкове число та його степiнь(через Enter):");
            
            string input = Console.ReadLine();
            string[] inputArray = input.Split(' ');
            int signOfFirst = Convert.ToInt32(inputArray[0]);
            char[] firstOperand = inputArray[1].ToCharArray();
            string powerOfFirst = inputArray[2];
            
            Console.WriteLine("Введiть знаковий розряд, шiстнадцятирозрядне двiйкове число та його степiнь(через Enter):");
            
            input = Console.ReadLine();
            inputArray = input.Split(' ');
            int signOfSecond = Convert.ToInt32(inputArray[0]);
            char[] secondOperand = inputArray[1].ToCharArray();
            string powerOfSecond = inputArray[2];

            Console.WriteLine("Результат:");
            TaskFive(signOfFirst, firstOperand, powerOfFirst, signOfSecond, secondOperand, powerOfSecond);    
        }
    }
}