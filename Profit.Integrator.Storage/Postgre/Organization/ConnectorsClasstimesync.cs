
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("connectors_classtimesync")]
    public partial class ConnectorsClasstimesync : IEquatable<ConnectorsClasstimesync>
    {
        [Column("id"            , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id             { get; set; } // uuid
        [Column("productid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Productid      { get; set; } // uuid
        [Column("objectclass"   , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(250)", Length = 250)] public string    Objectclass    { get; set; } = null!; // character varying(250)
        [Column("lastsyncronize", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Lastsyncronize { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConnectorsClasstimesync> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConnectorsClasstimesync>(c => c.Id);

        public bool Equals(ConnectorsClasstimesync? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConnectorsClasstimesync);
        }
        #endregion
    }
}
