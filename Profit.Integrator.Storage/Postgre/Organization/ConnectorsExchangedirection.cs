
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("connectors_exchangedirections")]
    public partial class ConnectorsExchangedirection : IEquatable<ConnectorsExchangedirection>
    {
        [Column("id"           , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id            { get; set; } // uuid
        [Column("sourceid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Sourceid      { get; set; } // uuid
        [Column("destinationid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Destinationid { get; set; } // uuid
        [Column("isactive"     , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Isactive      { get; set; } // boolean
        [Column("lastsync"     , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Lastsync      { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConnectorsExchangedirection> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConnectorsExchangedirection>(c => c.Id);

        public bool Equals(ConnectorsExchangedirection? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConnectorsExchangedirection);
        }
        #endregion
    }
}
