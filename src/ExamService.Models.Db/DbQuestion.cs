using System;

namespace ExamService.Models.Db
{
    public class DbQuestion
    {
        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public string Subject { get; set; }
        public int Score { get; set; }
    }
}
