
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("discounts")]
    public partial class Discount : IEquatable<Discount>
    {
        [Column("id"           , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id            { get; set; } // uuid
        [Column("title"        , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?  Title         { get; set; } // character varying(50)
        [Column("servicerateid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?    Servicerateid { get; set; } // uuid
        [Column("value"        , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?  Value         { get; set; } // character varying(50)
        [Column("createddate"  , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Createddate   { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"    , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted     { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Discount> _equalityComparer = ComparerBuilder.GetEqualityComparer<Discount>(c => c.Id);

        public bool Equals(Discount? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Discount);
        }
        #endregion
    }
}
