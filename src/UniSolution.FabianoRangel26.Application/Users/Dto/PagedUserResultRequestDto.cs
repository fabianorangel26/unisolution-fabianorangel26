﻿using Abp.Application.Services.Dto;
using System;

namespace UniSolution.FabianoRangel26.Users.Dto
{
    //custom PagedResultRequestDto
    public class PagedUserResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
