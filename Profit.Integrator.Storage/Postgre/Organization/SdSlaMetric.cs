
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_sla_metrics")]
    public partial class SdSlaMetric : IEquatable<SdSlaMetric>
    {
        [Column("id"             , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                    )] public Guid      Id              { get; set; } // uuid
        [Column("name"           , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Name            { get; set; } = null!; // character varying(1024)
        [Column("startproperty"  , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Startproperty   { get; set; } = null!; // character varying(1024)
        [Column("finishproperty" , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Finishproperty  { get; set; } = null!; // character varying(1024)
        [Column("createdbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdSlaMetric> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdSlaMetric>(c => c.Id);

        public bool Equals(SdSlaMetric? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdSlaMetric);
        }
        #endregion
    }
}
