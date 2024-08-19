
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_productmarks")]
    public partial class VoiceProductmark : IEquatable<VoiceProductmark>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("title", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string Title { get; set; } = null!; // character varying(255)
        [Column("productseriesid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Productseriesid { get; set; } // uuid
        [Column("productboxid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Productboxid { get; set; } // uuid
        [Column("productboxtitle", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Productboxtitle { get; set; } // character varying(255)
        [Column("productmarkstatusid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Productmarkstatusid { get; set; } // uuid
        [Column("productid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Productid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Createdbyuserid { get; set; } // uuid
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceProductmark> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceProductmark>(c => c.Id);

        public bool Equals(VoiceProductmark? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceProductmark);
        }
        #endregion
    }
}
