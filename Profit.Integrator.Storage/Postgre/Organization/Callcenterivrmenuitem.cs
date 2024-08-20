
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("callcenterivrmenuitems")]
    public partial class Callcenterivrmenuitem : IEquatable<Callcenterivrmenuitem>
    {
        [Column("id"                           , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                    )] public Guid      Id                            { get; set; } // uuid
        [Column("title"                        , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Title                         { get; set; } = null!; // character varying(1024)
        [Column("ivrmenu"                      , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid      Ivrmenu                       { get; set; } // uuid
        [Column("positionnumber"               , DataType  = DataType.Int32    , DbType   = "integer"                                                                                 )] public int?      Positionnumber                { get; set; } // integer
        [Column("workcalendarid"               , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Workcalendarid                { get; set; } // uuid
        [Column("mondayisworkday"              , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Mondayisworkday               { get; set; } // boolean
        [Column("mondayis24horsworkday"        , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Mondayis24Horsworkday         { get; set; } // boolean
        [Column("mondaystarttime"              , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Mondaystarttime               { get; set; } // timestamp (6) without time zone
        [Column("mondayendtime"                , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Mondayendtime                 { get; set; } // timestamp (6) without time zone
        [Column("tuesdayisworkday"             , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Tuesdayisworkday              { get; set; } // boolean
        [Column("tuesdayis24horsworkday"       , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Tuesdayis24Horsworkday        { get; set; } // boolean
        [Column("tuesdaystarttime"             , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Tuesdaystarttime              { get; set; } // timestamp (6) without time zone
        [Column("tuesdayendtime"               , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Tuesdayendtime                { get; set; } // timestamp (6) without time zone
        [Column("wednesdayisworkday"           , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Wednesdayisworkday            { get; set; } // boolean
        [Column("wednesdayis24horsworkday"     , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Wednesdayis24Horsworkday      { get; set; } // boolean
        [Column("wednesdaystarttime"           , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Wednesdaystarttime            { get; set; } // timestamp (6) without time zone
        [Column("wednesdayendtime"             , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Wednesdayendtime              { get; set; } // timestamp (6) without time zone
        [Column("thursdayisworkday"            , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Thursdayisworkday             { get; set; } // boolean
        [Column("thursdayis24horsworkday"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Thursdayis24Horsworkday       { get; set; } // boolean
        [Column("thursdaystarttime"            , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Thursdaystarttime             { get; set; } // timestamp (6) without time zone
        [Column("thursdayendtime"              , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Thursdayendtime               { get; set; } // timestamp (6) without time zone
        [Column("fridayisworkday"              , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Fridayisworkday               { get; set; } // boolean
        [Column("fridayis24horsworkday"        , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Fridayis24Horsworkday         { get; set; } // boolean
        [Column("fridaystarttime"              , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Fridaystarttime               { get; set; } // timestamp (6) without time zone
        [Column("fridayendtime"                , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Fridayendtime                 { get; set; } // timestamp (6) without time zone
        [Column("saturdayisworkday"            , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Saturdayisworkday             { get; set; } // boolean
        [Column("saturdayis24horsworkday"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Saturdayis24Horsworkday       { get; set; } // boolean
        [Column("saturdaystarttime"            , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Saturdaystarttime             { get; set; } // timestamp (6) without time zone
        [Column("saturdayendtime"              , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Saturdayendtime               { get; set; } // timestamp (6) without time zone
        [Column("sundayisworkday"              , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Sundayisworkday               { get; set; } // boolean
        [Column("sundayis24horsworkday"        , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Sundayis24Horsworkday         { get; set; } // boolean
        [Column("sundaystarttime"              , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Sundaystarttime               { get; set; } // timestamp (6) without time zone
        [Column("sundayendtime"                , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Sundayendtime                 { get; set; } // timestamp (6) without time zone
        [Column("canactivationvoice"           , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Canactivationvoice            { get; set; } // boolean
        [Column("activationvoicespeech"        , DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Activationvoicespeech         { get; set; } // text
        [Column("canactivationbutton"          , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Canactivationbutton           { get; set; } // boolean
        [Column("activationbutton"             , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Activationbutton              { get; set; } // uuid
        [Column("startplaytype"                , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                      )] public string?   Startplaytype                 { get; set; } // character varying(32)
        [Column("texttospeech"                 , DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Texttospeech                  { get; set; } // text
        [Column("actiontypeonselect"           , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                      )] public string?   Actiontypeonselect            { get; set; } // character varying(32)
        [Column("tooperatoronselect"           , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Tooperatoronselect            { get; set; } // uuid
        [Column("togrouponselect"              , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Togrouponselect               { get; set; } // uuid
        [Column("calltypetogrouponselect"      , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Calltypetogrouponselect       { get; set; } // uuid
        [Column("declarecalcwaittimeonselect"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Declarecalcwaittimeonselect   { get; set; } // boolean
        [Column("tomenuonselect"               , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Tomenuonselect                { get; set; } // uuid
        [Column("timeout"                      , DataType  = DataType.Int32    , DbType   = "integer"                                                                                 )] public int?      Timeout                       { get; set; } // integer
        [Column("actiontypeontimeout"          , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                      )] public string?   Actiontypeontimeout           { get; set; } // character varying(32)
        [Column("tooperatorontimeout"          , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Tooperatorontimeout           { get; set; } // uuid
        [Column("togroupontimeout"             , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Togroupontimeout              { get; set; } // uuid
        [Column("calltypetogroupontimeout"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Calltypetogroupontimeout      { get; set; } // uuid
        [Column("declarecalcwaittimeontimeout" , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Declarecalcwaittimeontimeout  { get; set; } // boolean
        [Column("tomenuontimeout"              , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Tomenuontimeout               { get; set; } // uuid
        [Column("immediatelyifbusy"            , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Immediatelyifbusy             { get; set; } // boolean
        [Column("createdate"                   , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Createdate                    { get; set; } // timestamp (6) without time zone
        [Column("deletedate"                   , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Deletedate                    { get; set; } // timestamp (6) without time zone
        [Column("transfersipontimeout"         , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                     )] public string?   Transfersipontimeout          { get; set; } // character varying(256)
        [Column("transfersiponselect"          , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                     )] public string?   Transfersiponselect           { get; set; } // character varying(256)
        [Column("toexternalcontrolleronselect" , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Toexternalcontrolleronselect  { get; set; } // uuid
        [Column("toexternalcontrollerontimeout", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Toexternalcontrollerontimeout { get; set; } // uuid
        [Column("calltitle"                    , DataType  = DataType.NVarChar , DbType   = "character varying(128)"         , Length       = 128                                     )] public string?   Calltitle                     { get; set; } // character varying(128)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Callcenterivrmenuitem> _equalityComparer = ComparerBuilder.GetEqualityComparer<Callcenterivrmenuitem>(c => c.Id);

        public bool Equals(Callcenterivrmenuitem? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Callcenterivrmenuitem);
        }
        #endregion
    }
}
