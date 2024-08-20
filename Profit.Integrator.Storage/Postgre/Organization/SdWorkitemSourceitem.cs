
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_workitem_sourceitems")]
    public partial class SdWorkitemSourceitem : IEquatable<SdWorkitemSourceitem>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id              { get; set; } // uuid
        [Column("workitemid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Workitemid      { get; set; } // uuid
        [Column("sourceid"       , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?    Sourceid        { get; set; } // uuid
        [Column("createdbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Createddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdWorkitemSourceitem> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdWorkitemSourceitem>(c => c.Id);

        public bool Equals(SdWorkitemSourceitem? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdWorkitemSourceitem);
        }
        #endregion
    }
}
