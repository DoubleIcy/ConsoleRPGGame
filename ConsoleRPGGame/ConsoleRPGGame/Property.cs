using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleRPGGame
{
    public class Property
    {
        private bool _live = true;
        public bool live
        {
            get { return _live; }
            set { if (value == false) _live = false; }
        }
        public int attack, defense, hit, miss, critical;
        public int hp, mp, tp;

        public int test = -1; 
        //public int stamina, intelligence,strength;

        public intz g, f;
        public intq l, m=new intq();
        void test()
        {
            
        }
        
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
            set { ah =Dayu(value ,ah) ? ah : value; }
        }
        public bool Dayu(intz a, intz b)
        {
            if (a.a > b.a)
                return true;
            else
                return false; 
        }
    }
}
