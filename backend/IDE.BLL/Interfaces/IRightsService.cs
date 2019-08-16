using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IRightsService
    {
        Task SetRightsToProject(int projectId, UserAccess access, int userId);
        ProjectRightsDTO GetUserRightsForProject(int projectId, int userId);
    }
}
