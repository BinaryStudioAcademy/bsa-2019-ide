using IDE.Common.ModelsDTO.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IInfoService
    {
        Task<WebSiteInfo> GetInfo();
    }
}
