
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_exchangeout")]
    public partial class SdExchangeout : IEquatable<SdExchangeout>
    {
        [Column("id"          , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id           { get; set; } // uuid
        [Column("entityid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Entityid     { get; set; } // uuid
        [Column("entitytypeid", DataType = DataType.Int32    , DbType = "integer"                                             )] public int      Entitytypeid { get; set; } // integer
        [Column("completed"   , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Completed    { get; set; } // boolean
        [Column("timeadded"   , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Timeadded    { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"   , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted    { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdExchangeout> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdExchangeout>(c => c.Id);

        public bool Equals(SdExchangeout? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdExchangeout);
        }
        #endregion
    }
}
