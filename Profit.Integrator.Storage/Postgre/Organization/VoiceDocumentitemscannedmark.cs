
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_documentitemscannedmarks")]
    public partial class VoiceDocumentitemscannedmark : IEquatable<VoiceDocumentitemscannedmark>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("documentitemid", DataType = DataType.Guid, DbType = "uuid")] public Guid Documentitemid { get; set; } // uuid
        [Column("productmark", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Productmark { get; set; } // character varying(512)
        [Column("productmarkid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Productmarkid { get; set; } // uuid
        [Column("productboxid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Productboxid { get; set; } // uuid
        [Column("productboxtitle", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Productboxtitle { get; set; } // character varying(255)
        [Column("productseriesid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Productseriesid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceDocumentitemscannedmark> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceDocumentitemscannedmark>(c => c.Id);

        public bool Equals(VoiceDocumentitemscannedmark? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceDocumentitemscannedmark);
        }
        #endregion
    }
}
