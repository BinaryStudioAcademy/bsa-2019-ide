using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.ExceptionsCustom
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string name):base($"{name} not found")
        {

        }
    }
}
