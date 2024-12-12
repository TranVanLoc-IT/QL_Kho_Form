using System;
using System.Collections.Generic;

namespace MWarehouse.Repository.Models;

public partial class AuthCode
{
    public int Id { get; set; }

    public string KeyValue { get; set; }
}
