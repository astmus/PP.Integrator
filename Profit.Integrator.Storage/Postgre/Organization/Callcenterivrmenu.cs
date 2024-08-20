
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("callcenterivrmenus")]
    public partial class Callcenterivrmenu : IEquatable<Callcenterivrmenu>
    {
        [Column("id"                           , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                    )] public Guid      Id                            { get; set; } // uuid
        [Column("title"                        , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Title                         { get; set; } = null!; // character varying(1024)
        [Column("startplaytype"                , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                      )] public string?   Startplaytype                 { get; set; } // character varying(32)
        [Column("texttospeech"                 , DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Texttospeech                  { get; set; } // text
        [Column("canextensionnumber"           , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Canextensionnumber            { get; set; } // boolean
        [Column("conversationrecordingmode"    , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                      )] public string?   Conversationrecordingmode     { get; set; } // character varying(32)
        [Column("createdate"                   , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Createdate                    { get; set; } // timestamp (6) without time zone
        [Column("deletedate"                   , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Deletedate                    { get; set; } // timestamp (6) without time zone
        [Column("incomeline"                   , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Incomeline                    { get; set; } // uuid
        [Column("isspeechrecvoice"             , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Isspeechrecvoice              { get; set; } // boolean
        [Column("isidleactive"                 , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool      Isidleactive                  { get; set; } // boolean
        [Column("idle"                         , DataType  = DataType.Int32    , DbType   = "integer"                                                                                 )] public int?      Idle                          { get; set; } // integer
        [Column("actiontypeonidle"             , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                      )] public string?   Actiontypeonidle              { get; set; } // character varying(32)
        [Column("tooperatoronidle"             , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Tooperatoronidle              { get; set; } // uuid
        [Column("togrouponidle"                , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Togrouponidle                 { get; set; } // uuid
        [Column("calltypetogrouponidle"        , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Calltypetogrouponidle         { get; set; } // uuid
        [Column("tomenuonidle"                 , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Tomenuonidle                  { get; set; } // uuid
        [Column("transfersiponidle"            , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                     )] public string?   Transfersiponidle             { get; set; } // character varying(256)
        [Column("toexternalcontrolleronidle"   , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Toexternalcontrolleronidle    { get; set; } // uuid
        [Column("timeout"                      , DataType  = DataType.Int32    , DbType   = "integer"                                                                                 )] public int?      Timeout                       { get; set; } // integer
        [Column("actiontypeontimeout"          , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                      )] public string?   Actiontypeontimeout           { get; set; } // character varying(32)
        [Column("tooperatorontimeout"          , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Tooperatorontimeout           { get; set; } // uuid
        [Column("togroupontimeout"             , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Togroupontimeout              { get; set; } // uuid
        [Column("calltypetogroupontimeout"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Calltypetogroupontimeout      { get; set; } // uuid
        [Column("tomenuontimeout"              , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Tomenuontimeout               { get; set; } // uuid
        [Column("transfersipontimeout"         , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                     )] public string?   Transfersipontimeout          { get; set; } // character varying(256)
        [Column("toexternalcontrollerontimeout", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Toexternalcontrollerontimeout { get; set; } // uuid
        [Column("immediatelyifbusy"            , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Immediatelyifbusy             { get; set; } // boolean
        [Column("synthsettings"                , DataType  = DataType.NVarChar , DbType   = "character varying(1024)"        , Length       = 1024                                    )] public string?   Synthsettings                 { get; set; } // character varying(1024)
        [Column("issystem"                     , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Issystem                      { get; set; } // boolean
        [Column("calltitle"                    , DataType  = DataType.NVarChar , DbType   = "character varying(128)"         , Length       = 128                                     )] public string?   Calltitle                     { get; set; } // character varying(128)
        [Column("declarecalcwaittimeontimeout" , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Declarecalcwaittimeontimeout  { get; set; } // boolean
        [Column("skipitemsprompt"              , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool      Skipitemsprompt               { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Callcenterivrmenu> _equalityComparer = ComparerBuilder.GetEqualityComparer<Callcenterivrmenu>(c => c.Id);

        public bool Equals(Callcenterivrmenu? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Callcenterivrmenu);
        }
        #endregion
    }
}
