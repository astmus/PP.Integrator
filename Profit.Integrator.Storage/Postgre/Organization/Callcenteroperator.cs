
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("callcenteroperators")]
    public partial class Callcenteroperator : IEquatable<Callcenteroperator>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id              { get; set; } // uuid
        [Column("name"           , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length       = 256 )] public string?   Name            { get; set; } // character varying(256)
        [Column("sip"            , DataType = DataType.NVarChar , DbType = "character varying(128)"         , Length       = 128 )] public string?   Sip             { get; set; } // character varying(128)
        [Column("telnumber"      , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length       = 256 )] public string?   Telnumber       { get; set; } // character varying(256)
        [Column("outgoinglineuri", DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length       = 256 )] public string?   Outgoinglineuri { get; set; } // character varying(256)
        [Column("createdate"     , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createdate      { get; set; } // timestamp (6) without time zone
        [Column("deletedate"     , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Deletedate      { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Callcenteroperator> _equalityComparer = ComparerBuilder.GetEqualityComparer<Callcenteroperator>(c => c.Id);

        public bool Equals(Callcenteroperator? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Callcenteroperator);
        }
        #endregion
    }
}
