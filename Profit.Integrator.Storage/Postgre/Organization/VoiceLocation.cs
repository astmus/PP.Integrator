
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_locations")]
    public partial class VoiceLocation : IEquatable<VoiceLocation>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("title", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string Title { get; set; } = null!; // character varying(255)
        [Column("code", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string Code { get; set; } = null!; // character varying(50)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceLocation> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceLocation>(c => c.Id);

        public bool Equals(VoiceLocation? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceLocation);
        }
        #endregion
    }
}
