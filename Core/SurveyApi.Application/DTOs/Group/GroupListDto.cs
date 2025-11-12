using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.DTOs.Group
{
    public class GroupListDto
    {
        public int Count { get; set; }
        public Object Groups { get; set; }
    }
}
