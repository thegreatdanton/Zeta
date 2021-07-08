using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta.Models
{
    public class Menu
    {
        public Dictionary<string, MenuItem> MenuItems{ get; set; }

        public Menu() 
        {
            MenuItems = new();
        }
    }
}
