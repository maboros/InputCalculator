using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOM_Seminarski_State
{
    public enum OperatorState
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
    public class InputCalculator
    {
        
        public InputCalculator(string input)
        {
            Operator = OperatorState.Add;
            ProcessString(input);
        }

        public float Calculate()
        {
            float result=0;
            bool haschanged = false;
            foreach (var item in input)
            {
                if (item == "+" || item == "*" || item == "-" || item == "/")
                {
                    ChangeState(item);
                    continue;
                }
                float number = 0;
                try
                {
                    number = float.Parse(item);
                }
                catch (Exception)
                {
                    Console.WriteLine("Input error, please try again, use spaces to separate and commas for decimal numbers.");
                }
                Console.WriteLine("My state is:" +result.ToString()+" "+Operator.ToString()+" "+number.ToString());
                result=Operate(number,result,haschanged);
                haschanged = true;
            }
            Console.WriteLine("My result is:"+result);
            return result;
        }

        private float Operate(float number, float result,bool haschanged)
        {
            switch (Operator)
            {
                case OperatorState.Add:
                    {
                        result += number;
                        break;
                    }
                case OperatorState.Subtract:
                    {
                        result -= number;
                        break;
                    }
                case OperatorState.Multiply:
                    {
                        if (haschanged == false)
                        {
                            result = number;
                            Console.WriteLine("No number beforehand so number is set to first given.");
                            break;
                        }
                        result *= number;
                        break;
                    }
                case OperatorState.Divide:
                    {
                        if (haschanged == false)
                        {
                            result = number;
                            Console.WriteLine("No number beforehand so number is set to first given.");
                            break;
                        }
                        if (result == 0)
                        {
                            Console.WriteLine("Division by 0 is not allowed!!!");
                            return 0;
                        }
                        result /= number;
                        break;
                    }
            }
            return result;
        }

        private void ChangeState(string item)
        {
            switch (item)
            {
                case "+":
                    Operator = OperatorState.Add;
                    break;
                case "-":
                    Operator = OperatorState.Subtract;
                    break;
                case "*":
                    Operator = OperatorState.Multiply;
                    break;
                case "/":
                    Operator = OperatorState.Divide;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        private void ProcessString(string input)
        {
            this.input=input.Split(' ');
            Console.WriteLine("Your input is:"+input);
        }

        public OperatorState Operator;
        private string[] input;
    }
}
