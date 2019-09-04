using System;

namespace IDE.Common.ModelsDTO.DTO.Project
{
    public class LikedProjectDTO
    {
        public int ProjectId { get; set; }
        public int LikesCount { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string AuthorNickName { get; set; }
        public DateTime? LastChangedDate { get; set; }
    }
}
