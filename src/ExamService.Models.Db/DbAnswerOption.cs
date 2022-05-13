using System;

namespace ExamService.Models.Db
{
    public class DbAnswerOption
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }
    }
}
