using MediatR;
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
        private readonly IImageFileReadRepository _ımageFileReadRepository;

        public GetSurveyImageQueryHandler(IImageFileReadRepository ımageFileReadRepository)
        {
            _ımageFileReadRepository = ımageFileReadRepository;
        }

        public async Task<GetSurveyImageQueryResponse> Handle(GetSurveyImageQueryRequest request, CancellationToken cancellationToken)
        {
            var surveyImage = await _ımageFileReadRepository.GetByIdAsync(request.Id);

            if (surveyImage == null)
                throw new Exception();
            return null;
        }
    }
}
