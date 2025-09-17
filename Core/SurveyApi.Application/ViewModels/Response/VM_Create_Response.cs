using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.ViewModels.Response
{
    public class VM_Create_Response
    {
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string SurveyId { get; set; }
    }
}
