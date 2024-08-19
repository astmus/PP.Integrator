
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_scriptsteplinks")]
    public partial class VoiceScriptsteplink : IEquatable<VoiceScriptsteplink>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("scriptid", DataType = DataType.Guid, DbType = "uuid")] public Guid Scriptid { get; set; } // uuid
        [Column("stepid", DataType = DataType.Guid, DbType = "uuid")] public Guid Stepid { get; set; } // uuid
        [Column("nextstepid", DataType = DataType.Guid, DbType = "uuid")] public Guid Nextstepid { get; set; } // uuid
        [Column("version", DataType = DataType.Int32, DbType = "integer")] public int? Version { get; set; } // integer
        [Column("operand1", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Operand1 { get; set; } // character varying(255)
        [Column("operator", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Operator { get; set; } // character varying(255)
        [Column("operand2", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Operand2 { get; set; } // character varying(255)
        [Column("sourceconn", DataType = DataType.Int32, DbType = "integer")] public int? Sourceconn { get; set; } // integer
        [Column("targetconn", DataType = DataType.Int32, DbType = "integer")] public int? Targetconn { get; set; } // integer
        [Column("labeloffsetx", DataType = DataType.Double, DbType = "double precision")] public double? Labeloffsetx { get; set; } // double precision
        [Column("labeloffsety", DataType = DataType.Double, DbType = "double precision")] public double? Labeloffsety { get; set; } // double precision
        [Column("comment", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Comment { get; set; } // character varying(1024)
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceScriptsteplink> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceScriptsteplink>(c => c.Id);

        public bool Equals(VoiceScriptsteplink? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceScriptsteplink);
        }
        #endregion
    }
}
