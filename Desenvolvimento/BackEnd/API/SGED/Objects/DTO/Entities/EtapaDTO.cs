﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SGED.Objects.Interfaces;
using SGED.Objects.Utilities;

namespace SGED.Objects.DTO.Entities
{
	public class EtapaDTO : IStatus, IPosicao
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "O nome da etapa é requerido!")]
		[MinLength(3)]
		[MaxLength(50)]
		public string NomeEtapa { get; set; }

		[Required(ErrorMessage = "A descrição da etapa é requerida!")]
		[MinLength(5)]
		[MaxLength(250)]
		public string DescricaoEtapa { get; set; }

		[Required(ErrorMessage = "A posição é requerida!")]
		public int Posicao { get; set; }

		[Required(ErrorMessage = "O status é requerido!")]
		public bool Status { get; set; }

		[JsonIgnore]
		public TipoProcessoDTO? TipoProcessoDTO { get; set; }

		[Required(ErrorMessage = "O TipoProcesso é requerido!")]
		public int IdTipoProcesso { get; set; }

		[JsonIgnore]
		public ICollection<TipoDocumentoDTO>? TipoDocumentoDTO { get; set; }

		public void DisableAllOperations() => IStatusExtensions.DisableAllOperations(this);
		public void EnableAllOperations() => IStatusExtensions.EnableAllOperations(this);
	}
}
