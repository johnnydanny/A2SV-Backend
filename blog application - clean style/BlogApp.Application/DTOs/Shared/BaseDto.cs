﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DTOs.Shared
{
    public abstract class BaseDto
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
    }
}
