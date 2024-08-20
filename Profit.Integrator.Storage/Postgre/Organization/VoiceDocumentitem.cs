
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_documentitems")]
    public partial class VoiceDocumentitem : IEquatable<VoiceDocumentitem>
    {
        [Column("id"            , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id             { get; set; } // uuid
        [Column("documentid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Documentid     { get; set; } // uuid
        [Column("number"        , DataType = DataType.Int32    , DbType = "integer"                                             )] public int       Number         { get; set; } // integer
        [Column("cargoid"       , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Cargoid        { get; set; } // character varying(255)
        [Column("productid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Productid      { get; set; } // uuid
        [Column("fromcellid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Fromcellid     { get; set; } // uuid
        [Column("fromsubcell"   , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Fromsubcell    { get; set; } // character varying(255)
        [Column("tocellid"      , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Tocellid       { get; set; } // uuid
        [Column("tosubcell"     , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Tosubcell      { get; set; } // character varying(255)
        [Column("qty"           , DataType = DataType.Double   , DbType = "double precision"                                    )] public double?   Qty            { get; set; } // double precision
        [Column("unitid"        , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Unitid         { get; set; } // uuid
        [Column("factqty"       , DataType = DataType.Double   , DbType = "double precision"                                    )] public double?   Factqty        { get; set; } // double precision
        [Column("boxnum"        , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Boxnum         { get; set; } // integer
        [Column("expirationdate", DataType = DataType.Date     , DbType = "date"                                                )] public DateTime? Expirationdate { get; set; } // date
        [Column("volume"        , DataType = DataType.Double   , DbType = "double precision"                                    )] public double?   Volume         { get; set; } // double precision
        [Column("weight"        , DataType = DataType.Double   , DbType = "double precision"                                    )] public double?   Weight         { get; set; } // double precision
        [Column("seriescode"    , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?   Seriescode     { get; set; } // character varying(50)
        [Column("pickarea"      , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?   Pickarea       { get; set; } // character varying(50)
        [Column("employeeid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Employeeid     { get; set; } // uuid
        [Column("starttime"     , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Starttime      { get; set; } // timestamp (6) without time zone
        [Column("endtime"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Endtime        { get; set; } // timestamp (6) without time zone
        [Column("extendedfields", DataType = DataType.Text     , DbType = "text"                                                )] public string?   Extendedfields { get; set; } // text
        [Column("status"        , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Status         { get; set; } // integer
        [Column("completed"     , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Completed      { get; set; } // boolean
        [Column("createddate"   , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createddate    { get; set; } // timestamp (6) without time zone
        [Column("updateddate"   , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate    { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"     , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted      { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceDocumentitem> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceDocumentitem>(c => c.Id);

        public bool Equals(VoiceDocumentitem? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceDocumentitem);
        }
        #endregion
    }
}
