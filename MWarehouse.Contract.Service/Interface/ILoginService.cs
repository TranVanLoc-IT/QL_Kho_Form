﻿using MWarehouse.ModelViews.LoginModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Contract.Service.Interface
{
    public interface ILoginService
    {
        string HandleLoginRequest(LoginModel login);
        string GetCurrentuser();
    }
}
