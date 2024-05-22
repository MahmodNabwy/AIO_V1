﻿using Boilerplate.Contracts.DTOs.Setter.Elements.Element;
using Boilerplate.Contracts.Filters;
using Boilerplate.Contracts.Interfaces.Custom;

namespace Boilerplate.Contracts.IServices.Services.Elements
{
    public interface IElementService
    {
        Task<IHolderOfDTO> GetAllAsync(List<string> keys);
        Task<IHolderOfDTO> GetAllAdminAsync(List<string> keys);
        IHolderOfDTO SearchAdminAsync(ElementFilter filter);
        Task<IHolderOfDTO> GetByIdAdminAsync(long id);
        Task<IHolderOfDTO> GetByKeyAdminAsync(string key);
        Task<IHolderOfDTO> GetByKeyAsync(string key);
        Task<IHolderOfDTO> SaveAsync(ElementSetterDTO setterDTO);
        Task<IHolderOfDTO> Update(ElementUpdateSetterDTO updateDTO);
        Task<IHolderOfDTO> DeleteSoftAsync(long id);
        Task<IHolderOfDTO> CancelDeleteSoftAsync(long id);
    }
}
