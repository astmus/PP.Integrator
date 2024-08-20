
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_exchangelog")]
    public partial class SdExchangelog : IEquatable<SdExchangelog>
    {
        [Column("id"              , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                )] public Guid     Id               { get; set; } // uuid
        [Column("entityid"        , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                )] public Guid?    Entityid         { get; set; } // uuid
        [Column("entitytypeid"    , DataType  = DataType.Int32    , DbType   = "integer"                                                                             )] public int?     Entitytypeid     { get; set; } // integer
        [Column("eventtime"       , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                     )] public DateTime Eventtime        { get; set; } // timestamp (6) without time zone
        [Column("eventtypeid"     , DataType  = DataType.Int32    , DbType   = "integer"                                                                             )] public int      Eventtypeid      { get; set; } // integer
        [Column("exchangesourceid", CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(64)", Length = 64)] public string   Exchangesourceid { get; set; } = null!; // character varying(64)
        [Column("source"          , DataType  = DataType.NVarChar , DbType   = "character varying(8)"           , Length       = 8                                   )] public string?  Source           { get; set; } // character varying(8)
        [Column("externalid"      , DataType  = DataType.NVarChar , DbType   = "character varying(64)"          , Length       = 64                                  )] public string?  Externalid       { get; set; } // character varying(64)
        [Column("description"     , DataType  = DataType.Text     , DbType   = "text"                                                                                )] public string?  Description      { get; set; } // text
        [Column("isdeleted"       , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                             )] public bool     Isdeleted        { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdExchangelog> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdExchangelog>(c => c.Id);

        public bool Equals(SdExchangelog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdExchangelog);
        }
        #endregion
    }
}
