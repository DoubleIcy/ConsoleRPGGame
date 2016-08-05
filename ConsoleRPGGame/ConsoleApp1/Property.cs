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
        public int hp, hp_, mp, mp_;

        public Property Add(Property a, Property[] bs)
        {
            foreach (Property b in bs)
            {
                a.attack += b.attack;
            }
            return a;
        }
    }
    public class PropertyE : Property
    { }
    public class PropertyS : Property
    { }
    public class PropertyM : Property
    { }
    public class Player
    {
        Property pro;
        string name;

        PropertyE weapon;
        PropertyE field;
        PropertyE cloth;
        PropertyE shipin;
    }

}
