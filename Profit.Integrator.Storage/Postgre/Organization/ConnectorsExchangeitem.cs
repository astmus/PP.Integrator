
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("connectors_exchangeitems")]
    public partial class ConnectorsExchangeitem : IEquatable<ConnectorsExchangeitem>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("directionid", DataType = DataType.Guid, DbType = "uuid")] public Guid Directionid { get; set; } // uuid
        [Column("conditions", DataType = DataType.Text, DbType = "text")] public string? Conditions { get; set; } // text
        [Column("itembody", DataType = DataType.Text, DbType = "text")] public string? Itembody { get; set; } // text
        [Column("itemstate", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(16)", Length = 16)] public string Itemstate { get; set; } = null!; // character varying(16)
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("itemid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Itemid { get; set; } // uuid
        [Column("itemtype", DataType = DataType.NVarChar, DbType = "character varying(250)", Length = 250)] public string? Itemtype { get; set; } // character varying(250)
        [Column("issync", DataType = DataType.Boolean, DbType = "boolean")] public bool Issync { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConnectorsExchangeitem> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConnectorsExchangeitem>(c => c.Id);

        public bool Equals(ConnectorsExchangeitem? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConnectorsExchangeitem);
        }
        #endregion
    }
}
