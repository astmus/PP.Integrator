
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_notifications")]
    public partial class ViNotification : IEquatable<ViNotification>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id              { get; set; } // uuid
        [Column("starttime"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Starttime       { get; set; } // timestamp (6) without time zone
        [Column("endtime"        , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Endtime         { get; set; } // timestamp (6) without time zone
        [Column("calendarid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Calendarid      { get; set; } // uuid
        [Column("isactive"       , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isactive        { get; set; } // boolean
        [Column("allchannels"    , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Allchannels     { get; set; } // boolean
        [Column("allusers"       , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Allusers        { get; set; } // boolean
        [Column("title"          , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Title           { get; set; } // text
        [Column("messagetype"    , DataType = DataType.NVarChar , DbType = "character varying(16)"          , Length       = 16  )] public string?   Messagetype     { get; set; } // character varying(16)
        [Column("messagetext"    , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Messagetext     { get; set; } // text
        [Column("properties"     , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Properties      { get; set; } // text
        [Column("createdbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViNotification> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViNotification>(c => c.Id);

        public bool Equals(ViNotification? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViNotification);
        }
        #endregion
    }
}
