
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("accruals")]
    public partial class Accrual : IEquatable<Accrual>
    {
        [Column("id"           , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id            { get; set; } // uuid
        [Column("date"         , DataType = DataType.Date     , DbType = "date"                                                )] public DateTime  Date          { get; set; } // date
        [Column("servicerateid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Servicerateid { get; set; } // uuid
        [Column("linktocheck"  , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Linktocheck   { get; set; } // text
        [Column("counter"      , DataType = DataType.Double   , DbType = "double precision"                                    )] public double    Counter       { get; set; } // double precision
        [Column("amount"       , DataType = DataType.Double   , DbType = "double precision"                                    )] public double    Amount        { get; set; } // double precision
        [Column("createddate"  , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createddate   { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"    , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted     { get; set; } // boolean
        [Column("updateddate"  , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate   { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Accrual> _equalityComparer = ComparerBuilder.GetEqualityComparer<Accrual>(c => c.Id);

        public bool Equals(Accrual? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Accrual);
        }
        #endregion
    }
}
