using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.Project
{
    public class LikedProjectDTO
    {
        public int ProjectId { get; set; }
        public int LikesCount { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string AuthorNickName { get; set; }
    }
}
