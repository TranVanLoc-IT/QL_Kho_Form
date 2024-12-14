using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.ModelViews.LoginModelView
{
    public class EditUserModel
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Pass { get; set; }
        public int Status { get; set; }
    }
}
