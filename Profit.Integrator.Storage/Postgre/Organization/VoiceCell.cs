
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_cells")]
    public partial class VoiceCell : IEquatable<VoiceCell>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("title", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string Title { get; set; } = null!; // character varying(255)
        [Column("hall", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Hall { get; set; } // character varying(255)
        [Column("rack", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Rack { get; set; } // character varying(50)
        [Column("section", DataType = DataType.Int32, DbType = "integer")] public int? Section { get; set; } // integer
        [Column("floor", DataType = DataType.Int32, DbType = "integer")] public int? Floor { get; set; } // integer
        [Column("ticket", DataType = DataType.Int32, DbType = "integer")] public int? Ticket { get; set; } // integer
        [Column("barcode", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Barcode { get; set; } // character varying(255)
        [Column("reserved", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Reserved { get; set; } // character varying(255)
        [Column("isvoice", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isvoice { get; set; } // boolean
        [Column("celltypeid", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Celltypeid { get; set; } // character varying(255)
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceCell> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceCell>(c => c.Id);

        public bool Equals(VoiceCell? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceCell);
        }
        #endregion
    }
}
