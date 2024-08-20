
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_calls")]
    public partial class ViCall : IEquatable<ViCall>
    {
        [Column("id"                , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                 { get; set; } // uuid
        [Column("sessionid"         , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Sessionid          { get; set; } // uuid
        [Column("callcentercallid"  , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Callcentercallid   { get; set; } // uuid
        [Column("iscallinconference", DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Iscallinconference { get; set; } // boolean
        [Column("createddate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate        { get; set; } // timestamp (6) without time zone
        [Column("updateddate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate        { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"         , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted          { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViCall> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViCall>(c => c.Id);

        public bool Equals(ViCall? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViCall);
        }
        #endregion
    }
}
