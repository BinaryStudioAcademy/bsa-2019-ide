namespace IDE.DAL.Entities
{
    public class LastSuccessfulBuild
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int BuildId { get; set; }
        public string Link { get; set; }

        public Project Project { get; set; }
    }
}
