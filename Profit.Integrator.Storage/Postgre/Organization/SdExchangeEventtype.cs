
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_exchange_eventtypes")]
    public partial class SdExchangeEventtype : IEquatable<SdExchangeEventtype>
    {
        [Column("id"  , DataType  = DataType.Int32, DbType   = "integer"        , IsPrimaryKey = true                                  )] public int    Id   { get; set; } // integer
        [Column("name", CanBeNull = false         , DataType = DataType.NVarChar, DbType       = "character varying(256)", Length = 256)] public string Name { get; set; } = null!; // character varying(256)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdExchangeEventtype> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdExchangeEventtype>(c => c.Id);

        public bool Equals(SdExchangeEventtype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdExchangeEventtype);
        }
        #endregion
    }
}
