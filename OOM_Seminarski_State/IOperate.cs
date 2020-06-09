using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOM_Seminarski_State
{
    public interface IOperate
    {
        float Operate(float number, float result, bool haschanged);
    }
}
