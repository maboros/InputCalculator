namespace OOM_Seminarski_State
{
    public class Add : IOperate
    {
        public float Operate(float number, float result, bool haschanged)
        {
            result += number;
            return result;
        }
    }
}