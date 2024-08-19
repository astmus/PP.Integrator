
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_contextparameters")]
    public partial class VoiceContextparameter : IEquatable<VoiceContextparameter>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("title", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string Title { get; set; } = null!; // character varying(1024)
        [Column("internalname", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Internalname { get; set; } // character varying(1024)
        [Column("objecttypeid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Objecttypeid { get; set; } // uuid
        [Column("contexttype", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string Contexttype { get; set; } = null!; // character varying(255)
        [Column("defaultvalue", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Defaultvalue { get; set; } // character varying(1024)
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceContextparameter> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceContextparameter>(c => c.Id);

        public bool Equals(VoiceContextparameter? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceContextparameter);
        }
        #endregion
    }
}
