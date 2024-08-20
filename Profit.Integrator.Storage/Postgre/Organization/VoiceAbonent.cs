
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_abonents")]
    public partial class VoiceAbonent : IEquatable<VoiceAbonent>
    {
        [Column("id"                , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id                 { get; set; } // uuid
        [Column("externalid"        , DataType  = DataType.NVarChar , DbType   = "character varying(64)"          , Length       = 64                                    )] public string?   Externalid         { get; set; } // character varying(64)
        [Column("firstname"         , DataType  = DataType.NVarChar , DbType   = "character varying(255)"         , Length       = 255                                   )] public string?   Firstname          { get; set; } // character varying(255)
        [Column("middlename"        , DataType  = DataType.NVarChar , DbType   = "character varying(255)"         , Length       = 255                                   )] public string?   Middlename         { get; set; } // character varying(255)
        [Column("lastname"          , DataType  = DataType.NVarChar , DbType   = "character varying(255)"         , Length       = 255                                   )] public string?   Lastname           { get; set; } // character varying(255)
        [Column("displayname"       , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string    Displayname        { get; set; } = null!; // character varying(255)
        [Column("accountnumber"     , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string    Accountnumber      { get; set; } = null!; // character varying(255)
        [Column("clearaccountnumber", CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string    Clearaccountnumber { get; set; } = null!; // character varying(255)
        [Column("phonenumber"       , DataType  = DataType.NVarChar , DbType   = "character varying(255)"         , Length       = 255                                   )] public string?   Phonenumber        { get; set; } // character varying(255)
        [Column("createddate"       , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate        { get; set; } // timestamp (6) without time zone
        [Column("updateddate"       , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate        { get; set; } // timestamp (6) without time zone
        [Column("localityid"        , DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                    )] public string?   Localityid         { get; set; } // character varying(50)
        [Column("isdeleted"         , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted          { get; set; } // boolean
        [Column("customercode"      , DataType  = DataType.NVarChar , DbType   = "character varying(5)"           , Length       = 5                                     )] public string?   Customercode       { get; set; } // character varying(5)
        [Column("islegalentity"     , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Islegalentity      { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceAbonent> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceAbonent>(c => c.Id);

        public bool Equals(VoiceAbonent? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceAbonent);
        }
        #endregion
    }
}
