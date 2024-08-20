
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("dwh_metricsgroups")]
    public partial class DwhMetricsgroup : IEquatable<DwhMetricsgroup>
    {
        [Column("id"             , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id              { get; set; } // uuid
        [Column("name"           , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(256)", Length = 256)] public string    Name            { get; set; } = null!; // character varying(256)
        [Column("description"    , DataType  = DataType.Text     , DbType   = "text"                                                                                  )] public string?   Description     { get; set; } // text
        [Column("createdbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted       { get; set; } // boolean
        [Column("position"       , DataType  = DataType.Int32    , DbType   = "integer"                                                                               )] public int?      Position        { get; set; } // integer

        #region IEquatable<T> support
        private static readonly IEqualityComparer<DwhMetricsgroup> _equalityComparer = ComparerBuilder.GetEqualityComparer<DwhMetricsgroup>(c => c.Id);

        public bool Equals(DwhMetricsgroup? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as DwhMetricsgroup);
        }
        #endregion
    }
}
