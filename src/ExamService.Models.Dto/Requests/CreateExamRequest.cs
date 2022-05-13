namespace LT.DigitalOffice.ExamService.Models.Dto.Requests
{
  public record CreateExamRequest
  {
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
