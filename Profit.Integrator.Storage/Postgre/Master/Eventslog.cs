
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("eventslog")]
    public partial class Eventslog : IEquatable<Eventslog>
    {
        [Column("id"                , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                 { get; set; } // uuid
        [Column("entityid"          , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Entityid           { get; set; } // uuid
        [Column("pitserverid"       , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Pitserverid        { get; set; } // uuid
        [Column("sessionid"         , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Sessionid          { get; set; } // uuid
        [Column("externalresourceid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Externalresourceid { get; set; } // uuid
        [Column("eventtype"         , DataType = DataType.Int32    , DbType = "integer"                                             )] public int       Eventtype          { get; set; } // integer
        [Column("eventsubtype"      , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Eventsubtype       { get; set; } // integer
        [Column("eventtext"         , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Eventtext          { get; set; } // text
        [Column("eventproperties"   , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Eventproperties    { get; set; } // text
        [Column("comments"          , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Comments           { get; set; } // text
        [Column("createddate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createddate        { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"         , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted          { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Eventslog> _equalityComparer = ComparerBuilder.GetEqualityComparer<Eventslog>(c => c.Id);

        public bool Equals(Eventslog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Eventslog);
        }
        #endregion
    }
}
