using System;

namespace OOM_Seminarski_State
{
    public class Divide : IOperate
    {
        public float Operate(float number, float result, bool haschanged)
        {
            if (haschanged == false)
            {
                result = number;
                Console.WriteLine("No number beforehand so number is set to first given.");
                return result;
            }
            if (result == 0)
            {
                throw new DivideByZeroException();
            }
            result /= number;
            return result;
        }
    }
}