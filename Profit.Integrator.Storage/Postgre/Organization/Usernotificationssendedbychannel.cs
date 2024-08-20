
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("usernotificationssendedbychannels")]
    public partial class Usernotificationssendedbychannel : IEquatable<Usernotificationssendedbychannel>
    {
        [Column("id"                , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                 { get; set; } // uuid
        [Column("usernotificationid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Usernotificationid { get; set; } // uuid
        [Column("notifychannelid"   , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Notifychannelid    { get; set; } // uuid
        [Column("sendeddate"        , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Sendeddate         { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"         , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted          { get; set; } // boolean
        [Column("plansendeddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Plansendeddate     { get; set; } // timestamp (6) without time zone
        [Column("countunsuccess"    , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Countunsuccess     { get; set; } // integer

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Usernotificationssendedbychannel> _equalityComparer = ComparerBuilder.GetEqualityComparer<Usernotificationssendedbychannel>(c => c.Id);

        public bool Equals(Usernotificationssendedbychannel? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Usernotificationssendedbychannel);
        }
        #endregion
    }
}
