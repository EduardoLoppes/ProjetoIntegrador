﻿using System.ComponentModel.DataAnnotations;
using SGED.Objects.Interfaces;
using SGED.Objects.Interfaces.Pessoa;
using SGED.Objects.Utilities;

namespace SGED.Objects.DTO.Entities
{
    public class TipoProcessoDTO : IStatus
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do TipoProcesso é requerido!")]
        [MinLength(3)]
        [MaxLength(100)]
        public string NomeTipoProcesso { get; set; }

        [Required(ErrorMessage = "A descrição do TipoProcesso é requerida!")]
        [MinLength(3)]
        [MaxLength(100)]
        public string DescricaoTipoProcesso { get; set; }

        [Required(ErrorMessage = "O status é requerido!")]
        public bool Status { get; set; }


        public void DisableAllOperations() => IStatusExtensions.DisableAllOperations(this);
        public void EnableAllOperations() => IStatusExtensions.EnableAllOperations(this);
    }
}
