using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpr
{
    public class DataType
    {
        public enum Type { my_integer, my_real, my_string, None};
        public Type type;
        public int demention
        {
            get;
            set;
        }
    }
}
