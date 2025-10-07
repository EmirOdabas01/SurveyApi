using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.SurveyImage.GetSurveyImage
{
    public class GetSurveyImageQueryHandler : IRequestHandler<GetSurveyImageQueryRequest, GetSurveyImageQueryResponse>
    {
        private readonly ISurveyReadRepository _surveyReadRepository;
        private readonly IConfiguration _configuration;
        public GetSurveyImageQueryHandler(ISurveyReadRepository surveyReadRepository, IConfiguration configuration)
        {
            _surveyReadRepository = surveyReadRepository;
            _configuration = configuration;
        }

        public async Task<GetSurveyImageQueryResponse> Handle(GetSurveyImageQueryRequest request, CancellationToken cancellationToken)
        {
            var survey = await _surveyReadRepository.Table.Include(s => s.ImageFile).FirstOrDefaultAsync(p => p.SurveyId == Guid.Parse(request.Id));

            if (survey == null)
                throw new Exception();

            return new()
            {
                Id = survey.SurveyId.ToString(),
                Path = $"{_configuration["BaseStorageUrl"]}/{survey.ImageFile.Path}",
            };
        }
    }
}
