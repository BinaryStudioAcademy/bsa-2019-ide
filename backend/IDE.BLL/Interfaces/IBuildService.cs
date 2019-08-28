﻿using IDE.Common.DTO.Common;
using IDE.Common.ModelsDTO.DTO.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IBuildService
    {
        Task BuildDotNetProject(int projectId);
        Task<IEnumerable<BuildDescriptionDTO>> GetBuildsByProjectId(int userId);
    }
}