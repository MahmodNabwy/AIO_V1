﻿using AIO.Contracts.Bases;
#nullable disable

namespace AIO.Contracts.Features.Languages.DTOs.Getter.LanguageTranslation
{
    public class LanguageTranslationGetterDTO : BaseGetterUpdateTranslationDTO
    {
        public string Name { get; set; }
    }
}