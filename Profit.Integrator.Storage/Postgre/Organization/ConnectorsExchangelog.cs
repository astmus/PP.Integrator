
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("connectors_exchangelog")]
    public partial class ConnectorsExchangelog : IEquatable<ConnectorsExchangelog>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("itemid", DataType = DataType.Guid, DbType = "uuid")] public Guid Itemid { get; set; } // uuid
        [Column("objectid", DataType = DataType.NVarChar, DbType = "character varying(64)", Length = 64)] public string? Objectid { get; set; } // character varying(64)
        [Column("objectbody", DataType = DataType.Text, DbType = "text")] public string? Objectbody { get; set; } // text
        [Column("exchangeresult", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(64)", Length = 64)] public string Exchangeresult { get; set; } = null!; // character varying(64)
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConnectorsExchangelog> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConnectorsExchangelog>(c => c.Id);

        public bool Equals(ConnectorsExchangelog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConnectorsExchangelog);
        }
        #endregion
    }
}
