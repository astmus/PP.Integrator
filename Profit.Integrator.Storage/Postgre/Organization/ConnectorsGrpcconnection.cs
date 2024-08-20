
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("connectors_grpcconnections")]
    public partial class ConnectorsGrpcconnection : IEquatable<ConnectorsGrpcconnection>
    {
        [Column("id"           , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id            { get; set; } // uuid
        [Column("accountid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Accountid     { get; set; } // uuid
        [Column("pitserverid"  , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Pitserverid   { get; set; } // uuid
        [Column("lastalivetime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Lastalivetime { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConnectorsGrpcconnection> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConnectorsGrpcconnection>(c => c.Id);

        public bool Equals(ConnectorsGrpcconnection? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConnectorsGrpcconnection);
        }
        #endregion
    }
}
