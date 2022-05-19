using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enum
{
    public class Status
    {
        public enum StatusEnum
        {
            NotSet,
            Ok,
            Validation,
            Alert,
            Existence,
            Error
        }
    }
}
