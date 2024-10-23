using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWarehouse.Core.Base;

namespace MWarehouse.Core.Constant
{
    public class ErrorCode
    {
        public enum Code
        {
            [CustomName("Not found entity")]
            NOT_FOUND = 404,

            [CustomName("Entity is not valid")]
            BAD_REQUEST = 400,

            [CustomName("SQL error")]
            SQL_ERROR = 402,

            [CustomName("Fail")]
            FAIL = 500,

            [CustomName("Success")]
            SUCCESS = 200
        }
    }
}
