using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.BusinessObjects
{
    public class PostObject<T>
    {
        public PostObject()
        {
            Data = default(T);
            PostAction = new PostAction();
        }
        public T Data { get; set; }

        public PostAction PostAction { get; set; }
    }
    public class PostAction
    {
        public ActionCodeType Code { get; set; }
        public string Url { get; set; }
    }
}
