
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_notificationsendedbysessions")]
    public partial class ViNotificationsendedbysession : IEquatable<ViNotificationsendedbysession>
    {
        [Column("id"            , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id             { get; set; } // uuid
        [Column("notificationid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Notificationid { get; set; } // uuid
        [Column("sessionid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?    Sessionid      { get; set; } // uuid
        [Column("stepid"        , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?    Stepid         { get; set; } // uuid
        [Column("sendeddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Sendeddate     { get; set; } // timestamp (6) without time zone
        [Column("messagetext"   , DataType = DataType.Text     , DbType = "text"                                                )] public string?  Messagetext    { get; set; } // text
        [Column("createddate"   , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Createddate    { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"     , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted      { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViNotificationsendedbysession> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViNotificationsendedbysession>(c => c.Id);

        public bool Equals(ViNotificationsendedbysession? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViNotificationsendedbysession);
        }
        #endregion
    }
}
