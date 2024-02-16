﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SGED.Models.Entities
{
    [Table("TipoDocumento")]
    public class TipoDocumento
    {
        [Column("idTipoDocumento")]
        public int Id { get; set; }

        [Column("nomeTipoDocumento")]
        public string NomeTipoDocumento { get; set; }

        [Column("descricaoTipoDocumento")]
        public string DescricaoTipoDocumento { get; set; }
    }
}