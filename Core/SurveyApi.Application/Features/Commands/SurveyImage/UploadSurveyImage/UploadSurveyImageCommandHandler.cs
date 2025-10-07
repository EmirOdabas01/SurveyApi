using MediatR;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.SurveyImage.UploadSurveyImage
{
    public class UploadSurveyImageCommandHandler : IRequestHandler<UploadSurveyImageCommandRequest, UploadSurveyImageCommandResponse>
    {
        private readonly IFileService _fileService;
        private readonly IImageFileWriteRepository _ımageFileWriteRepository;
        private readonly ISurveyReadRepository _surveyReadRepository;
        public UploadSurveyImageCommandHandler(IFileService fileService, 
            IImageFileWriteRepository ımageFileWriteRepository,
            ISurveyReadRepository surveyReadRepository)
        {
            _fileService = fileService;
            _ımageFileWriteRepository = ımageFileWriteRepository;
            _surveyReadRepository = surveyReadRepository;
        }

        public async Task<UploadSurveyImageCommandResponse> Handle(UploadSurveyImageCommandRequest request, CancellationToken cancellationToken)
        {
            var survey = await _surveyReadRepository.GetByIdAsync(request.Id, false);

            if (survey == null)
                throw new Exception();

            var result = await _fileService.UploadAsync("resources\\images", request.Files, request.Id);

            await _ımageFileWriteRepository.AddAsync(new Domain.Entities.ImageFile
            {
                SurveyId = Guid.Parse(request.Id),
                Path = result.path,
                FileName = result.fileName
            });

            await _ımageFileWriteRepository.SaveAsync();
            return new();
        }
    }
}
