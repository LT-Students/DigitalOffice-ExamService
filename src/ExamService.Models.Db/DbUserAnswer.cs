using System;

namespace ExamService.Models.Db
{
    public class DbUserAnswer
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid QuestionId { get; set; }
        public int Score { get; set; }
        public string Answer { get; set; }
    }
}
