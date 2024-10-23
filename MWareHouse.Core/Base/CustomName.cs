using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Core.Base
{
    [AttributeUsage(AttributeTargets.All)]
    public class CustomName:Attribute
    {
        public string name {  get; set; }

        public CustomName(string name)
        {
            this.name = name;
        }
    }
}
