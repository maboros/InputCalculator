using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOM_Seminarski_State
{

    public class InputCalculator
    {
        public IOperate currentState;
        public InputCalculator(string input)
        {
            currentState = new Add();
            ProcessString(input);
        }
        private void setState(IOperate state)
        {
            currentState = state;
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
                    return 0;
                }
                Console.WriteLine("My state is:" +result.ToString()+" "+currentState.GetType().Name+" "+number.ToString());
                try
                {
                    result = currentState.Operate(number, result, haschanged);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Division by 0 is not allowed!!!");
                    return 0;
                }
                haschanged = true;
            }
            Console.WriteLine("My result is:"+result);
            return result;
        }

        private void ChangeState(string item)
        {
            switch (item)
            {
                case "+":
                    setState(new Add());
                    break;
                case "-":
                    setState(new Subtract());
                    break;
                case "*":
                    setState(new Multiply());
                    break;
                case "/":
                    setState(new Divide());
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
        private string[] input;
    }
}
