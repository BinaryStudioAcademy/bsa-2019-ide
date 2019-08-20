using IDE.Common.ModelsDTO.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.Common
{
    public class DeleteCollaboratorRightDTO: CollaboratorDTO
    {
        public int ProjectId { get; set; }
    }
}
