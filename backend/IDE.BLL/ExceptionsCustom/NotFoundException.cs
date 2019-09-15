using System;

namespace IDE.BLL.ExceptionsCustom
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string name):base($"{name} not found")
        {
        }

        public NotFoundException(string name, int id)
            : base($"Entity {name} with id ({id}) was not found.")
        {
        }

        public NotFoundException(string name, string id)
            : base($"Entity {name} with id ({id}) was not found.")
        {
        }
    }
}
