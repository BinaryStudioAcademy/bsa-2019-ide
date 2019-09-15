using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.ExceptionsCustom
{
    public class NonAuthorRightsChange: Exception
    {
        public NonAuthorRightsChange() : base("Only project author can set and change rights for project") { }
    }
}
