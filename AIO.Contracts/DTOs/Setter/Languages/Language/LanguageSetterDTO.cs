﻿using AIO.Contracts.Features.Languages.DTOs.Setter.LanguageTranslation;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace AIO.Contracts.DTOs.Setter.Languages.Language
{
    public class LanguageSetterDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Locale is required")]
        public string Locale { get; set; }
        public string Flag { get; set; }
        public string Direction { get; set; }
        public bool IsDefault { get; set; }

        [Required(ErrorMessage = "Translation is required")]
        public List<LanguageTranslationSetterDTO> LanguageTranslations { get; set; }
    }
}