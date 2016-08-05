using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleRPGGame
{
    interface IRPG
    {
        
    }
    interface IProperty
    {
        IProperty EquipItem();
        bool Attack(IProperty sender,IProperty recie);
    }

}
