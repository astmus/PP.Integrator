
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_workitems_factsla")]
    public partial class SdWorkitemsFactsla : IEquatable<SdWorkitemsFactsla>
    {
        [Column("id"                       , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                    )] public Guid      Id                        { get; set; } // uuid
        [Column("workitemid"               , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid      Workitemid                { get; set; } // uuid
        [Column("slaname"                  , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Slaname                   { get; set; } = null!; // character varying(1024)
        [Column("metricname"               , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Metricname                { get; set; } = null!; // character varying(1024)
        [Column("startpropertydisplayname" , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Startpropertydisplayname  { get; set; } = null!; // character varying(1024)
        [Column("finishpropertydisplayname", CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Finishpropertydisplayname { get; set; } = null!; // character varying(1024)
        [Column("startpropertyvalue"       , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Startpropertyvalue        { get; set; } // timestamp (6) without time zone
        [Column("finishplanpropertyvalue"  , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Finishplanpropertyvalue   { get; set; } // timestamp (6) without time zone
        [Column("finishfactpropertyvalue"  , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Finishfactpropertyvalue   { get; set; } // timestamp (6) without time zone
        [Column("warningpropertyvalue"     , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Warningpropertyvalue      { get; set; } // timestamp (6) without time zone
        [Column("currentstate"             , DataType  = DataType.NVarChar , DbType   = "character varying(64)"          , Length       = 64                                      )] public string?   Currentstate              { get; set; } // character varying(64)
        [Column("source"                   , DataType  = DataType.NVarChar , DbType   = "character varying(8)"           , Length       = 8                                       )] public string?   Source                    { get; set; } // character varying(8)
        [Column("externalid"               , DataType  = DataType.NVarChar , DbType   = "character varying(64)"          , Length       = 64                                      )] public string?   Externalid                { get; set; } // character varying(64)
        [Column("createdbyuserid"          , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid      Createdbyuserid           { get; set; } // uuid
        [Column("createddate"              , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime  Createddate               { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid"          , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Updatedbyuserid           { get; set; } // uuid
        [Column("updateddate"              , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Updateddate               { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"                , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool      Isdeleted                 { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdWorkitemsFactsla> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdWorkitemsFactsla>(c => c.Id);

        public bool Equals(SdWorkitemsFactsla? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdWorkitemsFactsla);
        }
        #endregion
    }
}
