
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("console_contactsgroupsmembers")]
    public partial class ConsoleContactsgroupsmember : IEquatable<ConsoleContactsgroupsmember>
    {
        [Column("id"         , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id          { get; set; } // uuid
        [Column("groupid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Groupid     { get; set; } // uuid
        [Column("userid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Userid      { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConsoleContactsgroupsmember> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConsoleContactsgroupsmember>(c => c.Id);

        public bool Equals(ConsoleContactsgroupsmember? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConsoleContactsgroupsmember);
        }
        #endregion
    }
}
