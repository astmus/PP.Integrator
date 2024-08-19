
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("console_userscontactsgroupsmembers")]
    public partial class ConsoleUserscontactsgroupsmember : IEquatable<ConsoleUserscontactsgroupsmember>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("groupid", DataType = DataType.Guid, DbType = "uuid")] public Guid Groupid { get; set; } // uuid
        [Column("contactid", DataType = DataType.Guid, DbType = "uuid")] public Guid Contactid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConsoleUserscontactsgroupsmember> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConsoleUserscontactsgroupsmember>(c => c.Id);

        public bool Equals(ConsoleUserscontactsgroupsmember? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConsoleUserscontactsgroupsmember);
        }
        #endregion
    }
}
