using SurveyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Repositories
{
    public interface IResponseReadRepository : IReadRepository<Response>
    {
    }
}
