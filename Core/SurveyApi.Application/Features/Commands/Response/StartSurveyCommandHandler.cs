using MediatR;
using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Exceptions;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Response
{
    public class StartSurveyCommandHandler : IRequestHandler<StartSurveyCommandRequest, StartSurveyCommandResponse>
    {
        private readonly IResponseWriteRepository _responseWriteRepository;
        private readonly IResponseReadRepository _responseReadRepository;
        private readonly ISurveyReadRepository _surveyReadRepository;
        public StartSurveyCommandHandler(IResponseWriteRepository responseWriteRepository, 
            ISurveyReadRepository surveyReadRepository,
            IResponseReadRepository responseReadRepository)
        {
            _responseWriteRepository = responseWriteRepository;
            _surveyReadRepository = surveyReadRepository;
            _responseReadRepository = responseReadRepository;
        }

        public async Task<StartSurveyCommandResponse> Handle(StartSurveyCommandRequest request, CancellationToken cancellationToken)
        {
            var survey = await _surveyReadRepository
                .GetWhere(s => s.SurveyId == Guid.Parse(request.SurveyId))
                .Include(s => s.Responses)
                .FirstOrDefaultAsync();

            if (survey == null)
                throw new SurveyNotFoundException();
            else if (survey.Responses.Count >= survey.MaxResponse)
                throw new SurveyNotAccessibleException("The Survey reached max response limit");

            DateTime date = DateTime.UtcNow;
            await _responseWriteRepository.AddAsync(new Domain.Entities.Response
            {
                SurveyId = Guid.Parse(request.SurveyId),
                BeginDate = date,
            });

            await _responseWriteRepository.SaveAsync();

            var response = await _responseReadRepository.GetSingleAsync(r => r.BeginDate == date);

            return new()
            {
                ResponseId = response.Id
            };
        }
    }
}
