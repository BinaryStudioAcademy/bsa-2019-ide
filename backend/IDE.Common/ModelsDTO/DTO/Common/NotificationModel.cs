using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.Common
{
    public class NotificationModel
    {
            public ICollection<int> Data { get; set; }
            public string Label { get; set; }

            public NotificationModel()
            {
                Data = new List<int>();
            }
    }
}
