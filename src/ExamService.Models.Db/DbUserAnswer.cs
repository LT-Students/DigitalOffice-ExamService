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
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedAtUtc { get; set; }
  }
}
