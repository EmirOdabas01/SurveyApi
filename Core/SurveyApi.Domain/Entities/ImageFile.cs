using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class ImageFile : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Survey Survey { get; set; }
    }
}
