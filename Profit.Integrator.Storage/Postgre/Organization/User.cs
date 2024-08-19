
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("users")]
    public partial class User : IEquatable<User>
    {
        [Column("userid"                     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Userid                      { get; set; } // uuid
        [Column("name"                       , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(100)", Length = 100)] public string    Name                        { get; set; } = null!; // character varying(100)
        [Column("useratdomain"               , DataType  = DataType.NVarChar , DbType   = "character varying(100)"         , Length       = 100                                   )] public string?   Useratdomain                { get; set; } // character varying(100)
        [Column("senddate"                   , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Senddate                    { get; set; } // timestamp (6) without time zone
        [Column("dateuser"                   , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Dateuser                    { get; set; } // timestamp (6) without time zone
        [Column("department"                 , DataType  = DataType.Text     , DbType   = "text"                                                                                  )] public string?   Department                  { get; set; } // text
        [Column("workstarttime"              , DataType  = DataType.NVarChar , DbType   = "character varying(5)"           , Length       = 5                                     )] public string?   Workstarttime               { get; set; } // character varying(5)
        [Column("workendtime"                , DataType  = DataType.NVarChar , DbType   = "character varying(5)"           , Length       = 5                                     )] public string?   Workendtime                 { get; set; } // character varying(5)
        [Column("title"                      , DataType  = DataType.Text     , DbType   = "text"                                                                                  )] public string?   Title                       { get; set; } // text
        [Column("manager"                    , DataType  = DataType.Text     , DbType   = "text"                                                                                  )] public string?   Manager                     { get; set; } // text
        [Column("user"                       , DataType  = DataType.NVarChar , DbType   = "character varying(100)"         , Length       = 100                                   )] public string?   User1                       { get; set; } // character varying(100)
        [Column("timezoneoffset"             , DataType  = DataType.Int64    , DbType   = "bigint"                                                                                )] public long?     Timezoneoffset              { get; set; } // bigint
        [Column("schedule"                   , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                    )] public string?   Schedule                    { get; set; } // character varying(32)
        [Column("calendar"                   , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Calendar                    { get; set; } // uuid
        [Column("externaljob"                , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool?     Externaljob                 { get; set; } // boolean
        [Column("autoexplmode"               , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                    )] public string?   Autoexplmode                { get; set; } // character varying(32)
        [Column("classifier"                 , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                   )] public string?   Classifier                  { get; set; } // character varying(256)
        [Column("whenclassified"             , DataType  = DataType.NVarChar , DbType   = "character varying(255)"         , Length       = 255                                   )] public string?   Whenclassified              { get; set; } // character varying(255)
        [Column("city"                       , DataType  = DataType.NVarChar , DbType   = "character varying(100)"         , Length       = 100                                   )] public string?   City                        { get; set; } // character varying(100)
        [Column("phone"                      , DataType  = DataType.NVarChar , DbType   = "character varying(100)"         , Length       = 100                                   )] public string?   Phone                       { get; set; } // character varying(100)
        [Column("issrccalendarmeetingfilepst", DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool?     Issrccalendarmeetingfilepst { get; set; } // boolean
        [Column("networkaddress"             , DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                    )] public string?   Networkaddress              { get; set; } // character varying(50)
        [Column("sysdomainatuser"            , DataType  = DataType.NVarChar , DbType   = "character varying(100)"         , Length       = 100                                   )] public string?   Sysdomainatuser             { get; set; } // character varying(100)
        [Column("streetaddress"              , DataType  = DataType.NVarChar , DbType   = "character varying(500)"         , Length       = 500                                   )] public string?   Streetaddress               { get; set; } // character varying(500)
        [Column("mail"                       , DataType  = DataType.NVarChar , DbType   = "character varying(100)"         , Length       = 100                                   )] public string?   Mail                        { get; set; } // character varying(100)
        [Column("homephone"                  , DataType  = DataType.NVarChar , DbType   = "character varying(100)"         , Length       = 100                                   )] public string?   Homephone                   { get; set; } // character varying(100)
        [Column("officephone"                , DataType  = DataType.NVarChar , DbType   = "character varying(100)"         , Length       = 100                                   )] public string?   Officephone                 { get; set; } // character varying(100)
        [Column("inn"                        , DataType  = DataType.NVarChar , DbType   = "character varying(100)"         , Length       = 100                                   )] public string?   Inn                         { get; set; } // character varying(100)
        [Column("messagetypecontent"         , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool?     Messagetypecontent          { get; set; } // boolean
        [Column("mobilephone"                , DataType  = DataType.NVarChar , DbType   = "character varying(100)"         , Length       = 100                                   )] public string?   Mobilephone                 { get; set; } // character varying(100)
        [Column("id"                         , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id                          { get; set; } // uuid
        [Column("source"                     , DataType  = DataType.NVarChar , DbType   = "character varying(8)"           , Length       = 8                                     )] public string?   Source                      { get; set; } // character varying(8)
        [Column("externalid"                 , DataType  = DataType.NVarChar , DbType   = "character varying(64)"          , Length       = 64                                    )] public string?   Externalid                  { get; set; } // character varying(64)
        [Column("isdeleted"                  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool?     Isdeleted                   { get; set; } // boolean
        [Column("departmentid"               , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Departmentid                { get; set; } // uuid
        [Column("customproperties"           , DataType  = DataType.Text     , DbType   = "text"                                                                                  )] public string?   Customproperties            { get; set; } // text
        [Column("createddate"                , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate                 { get; set; } // timestamp (6) without time zone
        [Column("lastsourceid"               , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Lastsourceid                { get; set; } // uuid
        [Column("updateddate"                , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate                 { get; set; } // timestamp (6) without time zone
        [Column("clienttype"                 , DataType  = DataType.NVarChar , DbType   = "character varying(16)"          , Length       = 16                                    )] public string?   Clienttype                  { get; set; } // character varying(16)
        [Column("callcenteroperator"         , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Callcenteroperator          { get; set; } // uuid
        [Column("callcenteroperatorgroup"    , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Callcenteroperatorgroup     { get; set; } // uuid
        [Column("siplocator"                 , DataType  = DataType.NVarChar , DbType   = "character varying(100)"         , Length       = 100                                   )] public string?   Siplocator                  { get; set; } // character varying(100)
        [Column("skype_avatarurl"            , DataType  = DataType.NVarChar , DbType   = "character varying(1024)"        , Length       = 1024                                  )] public string?   SkypeAvatarurl              { get; set; } // character varying(1024)
        [Column("skype_persontype"           , DataType  = DataType.NVarChar , DbType   = "character varying(16)"          , Length       = 16                                    )] public string?   SkypePersontype             { get; set; } // character varying(16)
        [Column("skype_note"                 , DataType  = DataType.Text     , DbType   = "text"                                                                                  )] public string?   SkypeNote                   { get; set; } // text
        [Column("company"                    , DataType  = DataType.NVarChar , DbType   = "character varying(1024)"        , Length       = 1024                                  )] public string?   Company                     { get; set; } // character varying(1024)
        [Column("comments"                   , DataType  = DataType.Text     , DbType   = "text"                                                                                  )] public string?   Comments                    { get; set; } // text
        [Column("skype_lastlogindatetime"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? SkypeLastlogindatetime      { get; set; } // timestamp (6) without time zone
        [Column("skype_sip"                  , DataType  = DataType.NVarChar , DbType   = "character varying(128)"         , Length       = 128                                   )] public string?   SkypeSip                    { get; set; } // character varying(128)
        [Column("outgoinglineuri"            , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                   )] public string?   Outgoinglineuri             { get; set; } // character varying(256)
        [Column("operatorcontact"            , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                   )] public string?   Operatorcontact             { get; set; } // character varying(256)
        [Column("chatsessionchannelid"       , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Chatsessionchannelid        { get; set; } // uuid
        [Column("chatoperatoralias"          , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                   )] public string?   Chatoperatoralias           { get; set; } // character varying(256)
        [Column("chatmaxcount"               , DataType  = DataType.Int32    , DbType   = "integer"                                                                               )] public int?      Chatmaxcount                { get; set; } // integer

        #region IEquatable<T> support
        private static readonly IEqualityComparer<User> _equalityComparer = ComparerBuilder.GetEqualityComparer<User>(c => c.Id);

        public bool Equals(User? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as User);
        }
        #endregion
    }
}
