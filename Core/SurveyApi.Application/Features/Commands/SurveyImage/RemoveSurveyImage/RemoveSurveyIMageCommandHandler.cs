using MediatR;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.SurveyImage.RemoveSurveyImage
{
    public class RemoveSurveyIMageCommandHandler : IRequestHandler<RemoveSurveyIMageCommandRequest, RemoveSurveyIMageCommandResponse>
    {
        private readonly IImageFileWriteRepository _ımageFileWriteRepository;
        private readonly IImageFileReadRepository _ımageFileReadRepository;
        public RemoveSurveyIMageCommandHandler(IImageFileWriteRepository ımageFileWriteRepository, IImageFileReadRepository ımageFileReadRepository)
        {
            _ımageFileWriteRepository = ımageFileWriteRepository;
            _ımageFileReadRepository = ımageFileReadRepository;
        }

        public async Task<RemoveSurveyIMageCommandResponse> Handle(RemoveSurveyIMageCommandRequest request, CancellationToken cancellationToken)
        {
            var imageFile = await _ımageFileReadRepository.GetByIdAsync(request.Id);
            
            if(imageFile != null)
            await _ımageFileWriteRepository.RemoveAsync(request.Id);

            return new();
        }
    }
}
