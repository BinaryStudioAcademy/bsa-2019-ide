using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.Common.ModelsDTO.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IRightsService
    {
        Task SetRightsToProject(UpdateUserRightDTO update, int userId);
        Task<ProjectRightsDTO> GetUserRightsForProject(int projectId, int userId);
        Task<UserAccess> GetUserRightById(int userId, int projectId);
        Task DeleteRights(int userId, int projectId, int currentUserId);
    }
}
