﻿using Microsoft.EntityFrameworkCore;
using SGED.Context;
using SGED.Objects.Utilities;
using SGED.Objects.Models.Entities;
using SGED.Repositories.Interfaces;

namespace SGED.Repositories.Entities
{
    public class EtapaRepository : IEtapaRepository
	{
		private readonly AppDBContext _dbContext;
        private readonly RemoveContext _remove;

        public EtapaRepository(AppDBContext dbContext)
		{
			_dbContext = dbContext;
            _remove = new RemoveContext(dbContext);
        }

		public async Task<IEnumerable<Etapa>> GetAll()
		{
			return await _dbContext.Etapa.Include(objeto => objeto.TipoProcesso).AsNoTracking().ToListAsync();
		}

		public async Task<Etapa> GetById(int id)
		{
			return await _dbContext.Etapa.Include(objeto => objeto.TipoProcesso).AsNoTracking().FirstOrDefaultAsync(objeto => objeto.Id == id);
		}

		public async Task<Etapa> Create(Etapa etapa)
		{
			_dbContext.Add(etapa);
			await _dbContext.SaveChangesAsync();
			return etapa;
		}

		public async Task<Etapa> Update(Etapa etapa)
		{
			_dbContext.Entry(etapa).State = EntityState.Modified; 
			await _dbContext.SaveChangesAsync();
			return etapa;
		}

		public async Task<Etapa> Delete(int id)
		{
			var etapa = await GetById(id);
			_dbContext.Etapa.Remove(etapa);
			await _dbContext.SaveChangesAsync();
			return etapa;
		}


		public async Task<IEnumerable<Etapa>> GetStagesRelatedToTypeProcess(int idTipoProcesso)
		{
			return await _dbContext.Etapa.Where(objeto => objeto.IdTipoProcesso == idTipoProcesso).AsNoTracking().ToListAsync();
		}

	}
}
