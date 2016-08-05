using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleRPGGame
{
    public class Property
    {  
        public int g, f;
        public int l, m; 
    }
    public class intz
    {
        private int _a = 0;
        public int a
        {
            get { return _a; }
            set { _a = value > 0 ? value : 0; }
        }
    }
    public class intq
    {
        public intz ah;
        public intz a
        {
            get { return ah; }
            set { ah.a = value.a > ah.a ? ah.a : value.a; }
        }
    }
}
