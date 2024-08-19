
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("console_eventtypes")]
    public partial class ConsoleEventtype : IEquatable<ConsoleEventtype>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("cod", DataType = DataType.Int32, DbType = "integer")] public int Cod { get; set; } // integer
        [Column("title", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Title { get; set; } = null!; // character varying(256)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConsoleEventtype> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConsoleEventtype>(c => c.Id);

        public bool Equals(ConsoleEventtype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConsoleEventtype);
        }
        #endregion
    }
}
