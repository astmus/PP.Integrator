
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_swopsystems")]
    public partial class VoiceSwopsystem : IEquatable<VoiceSwopsystem>
    {
        [Column("id"                  , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id                   { get; set; } // uuid
        [Column("name"                , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string    Name                 { get; set; } = null!; // character varying(255)
        [Column("extensionid"         , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Extensionid          { get; set; } // uuid
        [Column("swopsystemtype"      , DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                    )] public string?   Swopsystemtype       { get; set; } // character varying(50)
        [Column("endpointaddr"        , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(512)", Length = 512)] public string    Endpointaddr         { get; set; } = null!; // character varying(512)
        [Column("username"            , DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                    )] public string?   Username             { get; set; } // character varying(50)
        [Column("password"            , DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                    )] public string?   Password             { get; set; } // character varying(50)
        [Column("swopmessageparamname", DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                    )] public string?   Swopmessageparamname { get; set; } // character varying(50)
        [Column("swopcalendar"        , DataType  = DataType.Text     , DbType   = "text"                                                                                  )] public string?   Swopcalendar         { get; set; } // text
        [Column("swopinterval"        , DataType  = DataType.Int32    , DbType   = "integer"                                                                               )] public int?      Swopinterval         { get; set; } // integer
        [Column("isreceivefirst"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isreceivefirst       { get; set; } // boolean
        [Column("requesttimeout"      , DataType  = DataType.Int32    , DbType   = "integer"                                                                               )] public int       Requesttimeout       { get; set; } // integer
        [Column("isactive"            , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isactive             { get; set; } // boolean
        [Column("createddate"         , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate          { get; set; } // timestamp (6) without time zone
        [Column("updateddate"         , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate          { get; set; } // timestamp (6) without time zone
        [Column("createdbyuserid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Createdbyuserid      { get; set; } // uuid
        [Column("updatedbyuserid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Updatedbyuserid      { get; set; } // uuid
        [Column("isdeleted"           , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted            { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceSwopsystem> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceSwopsystem>(c => c.Id);

        public bool Equals(VoiceSwopsystem? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceSwopsystem);
        }
        #endregion
    }
}
