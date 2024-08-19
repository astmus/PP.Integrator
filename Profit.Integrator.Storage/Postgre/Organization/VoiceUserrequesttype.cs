
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_userrequesttypes")]
    public partial class VoiceUserrequesttype : IEquatable<VoiceUserrequesttype>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("title", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string Title { get; set; } = null!; // character varying(1024)
        [Column("description", DataType = DataType.NVarChar, DbType = "character varying(2048)", Length = 2048)] public string? Description { get; set; } // character varying(2048)
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceUserrequesttype> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceUserrequesttype>(c => c.Id);

        public bool Equals(VoiceUserrequesttype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceUserrequesttype);
        }
        #endregion
    }
}
