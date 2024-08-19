
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("connectors_settings")]
    public partial class ConnectorsSetting : IEquatable<ConnectorsSetting>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("productid", DataType = DataType.Guid, DbType = "uuid")] public Guid Productid { get; set; } // uuid
        [Column("isextended", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isextended { get; set; } // boolean
        [Column("displayname", CanBeNull = false, DataType = DataType.Text, DbType = "text")] public string Displayname { get; set; } = null!; // text
        [Column("key", CanBeNull = false, DataType = DataType.Text, DbType = "text")] public string Key { get; set; } = null!; // text
        [Column("value", DataType = DataType.Text, DbType = "text")] public string? Value { get; set; } // text
        [Column("accountid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Accountid { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConnectorsSetting> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConnectorsSetting>(c => c.Id);

        public bool Equals(ConnectorsSetting? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConnectorsSetting);
        }
        #endregion
    }
}
