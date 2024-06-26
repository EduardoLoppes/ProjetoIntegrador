﻿using Microsoft.EntityFrameworkCore;
using SGED.Context;
using SGED.Objects.Models.Entities;
using SGED.Repositories.Interfaces;

namespace SGED.Repositories.Entities
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
	{
		private readonly AppDBContext _dbContext;

		public TipoUsuarioRepository(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<TipoUsuario>> GetAll()
		{
			return await _dbContext.TipoUsuario.Where(objeto => objeto.NomeTipoUsuario != "Desenvolvedor").ToListAsync();
		}

		public async Task<TipoUsuario> GetById(int id)
		{
			return await _dbContext.TipoUsuario.Where(objeto => objeto.Id == id).FirstOrDefaultAsync();
		}

		public async Task<TipoUsuario> Create(TipoUsuario tipousuario)
		{
			_dbContext.TipoUsuario.Add(tipousuario);
			await _dbContext.SaveChangesAsync();
			return tipousuario;
		}

		public async Task<TipoUsuario> Update(TipoUsuario tipousuario)
		{
			_dbContext.Entry(tipousuario).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return tipousuario;
		}

		public async Task<TipoUsuario> Delete(int id)
		{
			var tipoUsuario = await GetById(id);
			_dbContext.TipoUsuario.Remove(tipoUsuario);
			await _dbContext.SaveChangesAsync();
			return tipoUsuario;
		}
	}
}
