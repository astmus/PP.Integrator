
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_entitytypes")]
    public partial class SdEntitytype : IEquatable<SdEntitytype>
    {
        [Column("id"  , DataType  = DataType.Int32, DbType   = "integer"        , IsPrimaryKey = true                    , IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public int    Id   { get; set; } // integer
        [Column("name", CanBeNull = false         , DataType = DataType.NVarChar, DbType       = "character varying(256)", Length     = 256                                           )] public string Name { get; set; } = null!; // character varying(256)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdEntitytype> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdEntitytype>(c => c.Id);

        public bool Equals(SdEntitytype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdEntitytype);
        }
        #endregion
    }
}
