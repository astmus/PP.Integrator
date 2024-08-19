
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("registrations")]
    public partial class Registration : IEquatable<Registration>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Name { get; set; } = null!; // character varying(256)
        [Column("email", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Email { get; set; } = null!; // character varying(256)
        [Column("password", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Password { get; set; } = null!; // character varying(256)
        [Column("phone", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Phone { get; set; } = null!; // character varying(256)
        [Column("organization", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Organization { get; set; } = null!; // character varying(256)
        [Column("pincode", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Pincode { get; set; } = null!; // character varying(256)
        [Column("status", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Status { get; set; } = null!; // character varying(256)
        [Column("createdat", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createdat { get; set; } // timestamp (6) without time zone
        [Column("modifiedat", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Modifiedat { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("agreewithterms", DataType = DataType.Boolean, DbType = "boolean")] public bool Agreewithterms { get; set; } // boolean
        [Column("pinisentered", DataType = DataType.Boolean, DbType = "boolean")] public bool? Pinisentered { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Registration> _equalityComparer = ComparerBuilder.GetEqualityComparer<Registration>(c => c.Id);

        public bool Equals(Registration? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Registration);
        }
        #endregion
    }
}
