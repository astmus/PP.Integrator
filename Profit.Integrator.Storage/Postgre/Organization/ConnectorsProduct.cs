
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("connectors_products")]
    public partial class ConnectorsProduct : IEquatable<ConnectorsProduct>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("productname", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Productname { get; set; } = null!; // character varying(256)
        [Column("productversion", DataType = DataType.NVarChar, DbType = "character varying(16)", Length = 16)] public string? Productversion { get; set; } // character varying(16)
        [Column("productbranch", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Productbranch { get; set; } // character varying(256)
        [Column("isinwork", DataType = DataType.Boolean, DbType = "boolean")] public bool Isinwork { get; set; } // boolean
        [Column("ismain", DataType = DataType.Boolean, DbType = "boolean")] public bool Ismain { get; set; } // boolean
        [Column("hasmultiaccount", DataType = DataType.Boolean, DbType = "boolean")] public bool? Hasmultiaccount { get; set; } // boolean
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("chatplatformid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Chatplatformid { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConnectorsProduct> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConnectorsProduct>(c => c.Id);

        public bool Equals(ConnectorsProduct? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConnectorsProduct);
        }
        #endregion
    }
}
