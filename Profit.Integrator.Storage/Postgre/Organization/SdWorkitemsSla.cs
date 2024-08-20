
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_workitems_sla")]
    public partial class SdWorkitemsSla : IEquatable<SdWorkitemsSla>
    {
        [Column("id"                  , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                              )] public Guid      Id                   { get; set; } // uuid
        [Column("workitemid"          , DataType  = DataType.Guid     , DbType   = "uuid"                                                                              )] public Guid      Workitemid           { get; set; } // uuid
        [Column("slaid"               , DataType  = DataType.Guid     , DbType   = "uuid"                                                                              )] public Guid?     Slaid                { get; set; } // uuid
        [Column("metricid"            , DataType  = DataType.Guid     , DbType   = "uuid"                                                                              )] public Guid      Metricid             { get; set; } // uuid
        [Column("warningoffsetminutes", DataType  = DataType.Int32    , DbType   = "integer"                                                                           )] public int?      Warningoffsetminutes { get; set; } // integer
        [Column("limitminutes"        , DataType  = DataType.Int32    , DbType   = "integer"                                                                           )] public int?      Limitminutes         { get; set; } // integer
        [Column("sourcetype"          , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(8)", Length = 8)] public string    Sourcetype           { get; set; } = null!; // character varying(8)
        [Column("createdbyuserid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                              )] public Guid      Createdbyuserid      { get; set; } // uuid
        [Column("createddate"         , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                   )] public DateTime  Createddate          { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                              )] public Guid?     Updatedbyuserid      { get; set; } // uuid
        [Column("updateddate"         , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                   )] public DateTime? Updateddate          { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"           , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                           )] public bool      Isdeleted            { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdWorkitemsSla> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdWorkitemsSla>(c => c.Id);

        public bool Equals(SdWorkitemsSla? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdWorkitemsSla);
        }
        #endregion
    }
}
