﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.DTOs.User
{
    public class CreateUserResponseDto
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
