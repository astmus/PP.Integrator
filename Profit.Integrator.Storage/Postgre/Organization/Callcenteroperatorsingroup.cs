
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("callcenteroperatorsingroups")]
    public partial class Callcenteroperatorsingroup : IEquatable<Callcenteroperatorsingroup>
    {
        [Column("id"              , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id               { get; set; } // uuid
        [Column("operatorsgroup"  , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Operatorsgroup   { get; set; } // uuid
        [Column("operator"        , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Operator         { get; set; } // uuid
        [Column("operatorposition", DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Operatorposition { get; set; } // integer
        [Column("createdate"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createdate       { get; set; } // timestamp (6) without time zone
        [Column("deletedate"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Deletedate       { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Callcenteroperatorsingroup> _equalityComparer = ComparerBuilder.GetEqualityComparer<Callcenteroperatorsingroup>(c => c.Id);

        public bool Equals(Callcenteroperatorsingroup? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Callcenteroperatorsingroup);
        }
        #endregion
    }
}
