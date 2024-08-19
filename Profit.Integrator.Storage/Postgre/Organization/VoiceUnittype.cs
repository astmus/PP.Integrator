
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_unittypes")]
    public partial class VoiceUnittype : IEquatable<VoiceUnittype>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string Name { get; set; } = null!; // character varying(50)
        [Column("shortname", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Shortname { get; set; } // character varying(50)
        [Column("parentid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Parentid { get; set; } // uuid
        [Column("conversionfactor", DataType = DataType.Int32, DbType = "integer")] public int? Conversionfactor { get; set; } // integer
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceUnittype> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceUnittype>(c => c.Id);

        public bool Equals(VoiceUnittype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceUnittype);
        }
        #endregion
    }
}
