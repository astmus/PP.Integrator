
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_abonentdevices")]
    public partial class VoiceAbonentdevice : IEquatable<VoiceAbonentdevice>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("title", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string Title { get; set; } = null!; // character varying(255)
        [Column("capacity", DataType = DataType.Int32, DbType = "integer")] public int? Capacity { get; set; } // integer
        [Column("accountingtypeid", DataType = DataType.Guid, DbType = "uuid")] public Guid Accountingtypeid { get; set; } // uuid
        [Column("localityid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Localityid { get; set; } // uuid
        [Column("externalid", DataType = DataType.NVarChar, DbType = "character varying(64)", Length = 64)] public string? Externalid { get; set; } // character varying(64)
        [Column("devicetype", DataType = DataType.Int32, DbType = "integer")] public int? Devicetype { get; set; } // integer
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("unitid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Unitid { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceAbonentdevice> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceAbonentdevice>(c => c.Id);

        public bool Equals(VoiceAbonentdevice? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceAbonentdevice);
        }
        #endregion
    }
}
