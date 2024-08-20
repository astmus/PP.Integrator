
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("dwh_metrics")]
    public partial class DwhMetric : IEquatable<DwhMetric>
    {
        [Column("id"                     , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                    )] public Guid      Id                      { get; set; } // uuid
        [Column("name"                   , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(256)" , Length = 256 )] public string    Name                    { get; set; } = null!; // character varying(256)
        [Column("description"            , DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Description             { get; set; } // text
        [Column("formula"                , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Formula                 { get; set; } = null!; // character varying(1024)
        [Column("aggregatetype"          , DataType  = DataType.NVarChar , DbType   = "character varying(4)"           , Length       = 4                                       )] public string?   Aggregatetype           { get; set; } // character varying(4)
        [Column("precision"              , DataType  = DataType.Int32    , DbType   = "integer"                                                                                 )] public int?      Precision               { get; set; } // integer
        [Column("metricgroupid"          , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Metricgroupid           { get; set; } // uuid
        [Column("formonitoring"          , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Formonitoring           { get; set; } // boolean
        [Column("foralert"               , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Foralert                { get; set; } // boolean
        [Column("alertfrequency"         , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                      )] public string?   Alertfrequency          { get; set; } // character varying(32)
        [Column("alertcalcinterval"      , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                      )] public string?   Alertcalcinterval       { get; set; } // character varying(32)
        [Column("alertcomparetype"       , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                      )] public string?   Alertcomparetype        { get; set; } // character varying(32)
        [Column("alertcompareoffset"     , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                      )] public string?   Alertcompareoffset      { get; set; } // character varying(32)
        [Column("alertcompareoperation"  , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                      )] public string?   Alertcompareoperation   { get; set; } // character varying(32)
        [Column("alertwarnuplimit"       , DataType  = DataType.Double   , DbType   = "double precision"                                                                        )] public double?   Alertwarnuplimit        { get; set; } // double precision
        [Column("alertwarnlolimit"       , DataType  = DataType.Double   , DbType   = "double precision"                                                                        )] public double?   Alertwarnlolimit        { get; set; } // double precision
        [Column("alerterroruplimit"      , DataType  = DataType.Double   , DbType   = "double precision"                                                                        )] public double?   Alerterroruplimit       { get; set; } // double precision
        [Column("alerterrorlolimit"      , DataType  = DataType.Double   , DbType   = "double precision"                                                                        )] public double?   Alerterrorlolimit       { get; set; } // double precision
        [Column("alertoutgoingruleid"    , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Alertoutgoingruleid     { get; set; } // uuid
        [Column("alertlastcompletedate"  , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Alertlastcompletedate   { get; set; } // timestamp (6) without time zone
        [Column("alertlastcompleteresult", DataType  = DataType.Double   , DbType   = "double precision"                                                                        )] public double?   Alertlastcompleteresult { get; set; } // double precision
        [Column("createdbyuserid"        , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid      Createdbyuserid         { get; set; } // uuid
        [Column("createddate"            , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime  Createddate             { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid"        , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Updatedbyuserid         { get; set; } // uuid
        [Column("updateddate"            , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Updateddate             { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"              , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool      Isdeleted               { get; set; } // boolean
        [Column("position"               , DataType  = DataType.Int32    , DbType   = "integer"                                                                                 )] public int?      Position                { get; set; } // integer

        #region IEquatable<T> support
        private static readonly IEqualityComparer<DwhMetric> _equalityComparer = ComparerBuilder.GetEqualityComparer<DwhMetric>(c => c.Id);

        public bool Equals(DwhMetric? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as DwhMetric);
        }
        #endregion
    }
}
