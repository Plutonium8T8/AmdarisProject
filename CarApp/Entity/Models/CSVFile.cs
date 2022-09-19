namespace Entity.Models
{
    public class CSVFile : EntityBaseClass
    {
        public string FileName { get; set; }
        public string Content { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
