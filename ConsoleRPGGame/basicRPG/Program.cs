using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace basicRPG
{
    public class Program
    {
        static void Main(string[] args)
        {
            object objtest = new Prop(1,2,3,4,5,9);


            Prop a = new Prop();
            Prop b = new Prop(1,2,3,4,5,6);

            Prop c = new Prop(11, 21, 31, 41, 51, 61);
            Prop d = (Prop)Add(b,c);
            d = (Prop)Add(a, b);
            object obj = Add(d, b);
        }
        public static object Add(object a, object b)
        {
            object abak = a;
            PropertyInfo[] _a = GetPropertyInfoArray(a);
            PropertyInfo[] _b = GetPropertyInfoArray(b);
            foreach (PropertyInfo __a in _a)
            {
                foreach (PropertyInfo __b in _b)
                {
                    if (__a.Name == __b.Name)
                    {
                        int x = (int)__a.GetValue(a, null);
                        int y = (int)__b.GetValue(b, null);
                        __a.SetValue(abak, x+y,null);
                    }
                }
            }

            return abak;
        }
        public static PropertyInfo[] GetPropertyInfoArray(object _a)
        { 
            PropertyInfo[] props = null;
            try
            {
                Type type = _a.GetType();//typeof();
                object obj = Activator.CreateInstance(type);
                props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
            catch (Exception ex)  { }
            return props;
        }
    }
    public class Prop
    {
        public int g { get; set; }
        public int f { get; set; }
        public int hp { get; set; }
        public int mp { get; set; }
        public int hp_ { get; set; }
        public int mp_ { get; set; }
        public Prop() { }
        public Prop(int _g, int _f, int _hp, int _mp, int _hp_, int _mp_)
        {
            g = _g;
            f = _f;
            hp = _hp;
            mp = _mp;
            hp_ = _hp_;
            mp_ = _mp_;
        }

        public Prop Add(Prop a,Prop b)
        { 
            a.g += b.g;
            a.f += b.f;
            a.hp += b.hp;
            a.mp += b.mp;
            a.hp_ += b.hp_;
            a.mp_ += b.mp_;
            return a;
        }
        public Prop Add(Prop b)
        {
            Prop a = this;
            a = Add(a, b);
            return a;
        }
    }
}
