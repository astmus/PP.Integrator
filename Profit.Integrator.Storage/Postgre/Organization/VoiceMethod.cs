
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_methods")]
    public partial class VoiceMethod : IEquatable<VoiceMethod>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("title", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Title { get; set; } // character varying(1024)
        [Column("version", DataType = DataType.Int32, DbType = "integer")] public int? Version { get; set; } // integer
        [Column("internalname", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Internalname { get; set; } // character varying(255)
        [Column("performerid", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Performerid { get; set; } // character varying(255)
        [Column("isasync", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isasync { get; set; } // boolean
        [Column("isguiapplicable", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isguiapplicable { get; set; } // boolean
        [Column("isabstract", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isabstract { get; set; } // boolean
        [Column("swopsystemid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Swopsystemid { get; set; } // uuid
        [Column("purpose", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Purpose { get; set; } // character varying(1024)
        [Column("description", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Description { get; set; } // character varying(1024)
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceMethod> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceMethod>(c => c.Id);

        public bool Equals(VoiceMethod? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceMethod);
        }
        #endregion
    }
}
