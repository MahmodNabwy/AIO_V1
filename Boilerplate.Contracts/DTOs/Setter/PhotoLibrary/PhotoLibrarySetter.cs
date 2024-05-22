﻿using Microsoft.AspNetCore.Http;

namespace Boilerplate.Contracts.DTOs.Setter.PhotoLibrary;

public class PhotoLibrarySetter
{
    public List<IFormFile> Files { get; set; }
    public int Directory { get; set; }
}