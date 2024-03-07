﻿using SGED.DTO.Entities;

namespace SGED.Services.Interfaces
{
    public interface ITipoDocumentoEtapaService
    {
        Task<IEnumerable<TipoDocumentoEtapaDTO>> GetAll();
        Task<TipoDocumentoEtapaDTO> GetById(int id);
        Task Create(TipoDocumentoEtapaDTO TipoDocumentoEtapaDTO);
        Task Update(TipoDocumentoEtapaDTO TipoDocumentoEtapaDTO);
        Task Remove(int id);
    }
}
