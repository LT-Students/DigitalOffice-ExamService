using ExamService.Models.Db;
using LT.DigitalOffice.ExamService.Business.Exam.Interfaces;
using LT.DigitalOffice.ExamService.Data.Interfaces;
using LT.DigitalOffice.ExamService.Mappers.Models.Interfaces;
using LT.DigitalOffice.ExamService.Models.Dto.Models;
using LT.DigitalOffice.ExamService.Models.Dto.Requests.Exam.Filters;
using LT.DigitalOffice.Kernel.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ExamService.Business.Exam
{
  public class FindExamCommand : IFindExamCommand
  {
    private readonly IExamRepository _repository;
    private readonly IExamInfoMapper _mapper;

    public FindExamCommand(
      IExamRepository repository,
      IExamInfoMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<FindResultResponse<ExamInfo>> ExecuteAsync(FindExamsFilter filter)
    {
      (List<DbExam> exams, int totalCount) = await _repository.FindAsync(filter);

      return new(body: exams.Select(_mapper.Map).ToList(), totalCount: totalCount);
    }
  }
}
