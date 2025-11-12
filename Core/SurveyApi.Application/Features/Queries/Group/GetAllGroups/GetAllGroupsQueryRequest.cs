using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Group.GetAllGroups
{
    public class GetAllGroupsQueryRequest : IRequest<GetAllGroupsQueryResponse>
    {
    }
}
