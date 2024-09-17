﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace TechnologyKeeda.Repositories.Interfaces
{
    public interface IUtilityRepo
    {
        Task<string> SaveImage(string ContainerName, IFormFile file);
        Task<string> EditImage(string ContainerName, IFormFile file, string dbPath);
        Task DeleteImage(string ContainerName, string dbPath);
    }
}
