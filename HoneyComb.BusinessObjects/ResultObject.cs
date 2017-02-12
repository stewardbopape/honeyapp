using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.BusinessObjects
{
    public class ResultObj<T>
    {
        public ResultObj()
        {
            Data = default(T);
            isSuccessful = false;
            Error = string.Empty;
        }
        public T Data { get; set; }
        public string Error { get; set; }
        public bool isSuccessful { get; set; }
    }

    public class GetAction
    {
        public ActionCode Code { get; set; }
        public string Url { get; set; }
    }
}
