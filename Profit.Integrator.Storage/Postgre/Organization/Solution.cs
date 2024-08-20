
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("solutions")]
    public partial class Solution : IEquatable<Solution>
    {
        [Column("id"              , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id               { get; set; } // uuid
        [Column("operatorid"      , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Operatorid       { get; set; } // integer
        [Column("operatorname"    , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?   Operatorname     { get; set; } // character varying(50)
        [Column("registrationdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Registrationdate { get; set; } // timestamp (6) without time zone
        [Column("completedate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Completedate     { get; set; } // timestamp (6) without time zone
        [Column("deleted"         , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Deleted          { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Solution> _equalityComparer = ComparerBuilder.GetEqualityComparer<Solution>(c => c.Id);

        public bool Equals(Solution? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Solution);
        }
        #endregion
    }
}
