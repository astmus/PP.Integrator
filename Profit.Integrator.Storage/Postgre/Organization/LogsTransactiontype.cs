
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("logs_transactiontypes")]
    public partial class LogsTransactiontype : IEquatable<LogsTransactiontype>
    {
        [Column("id"             , DataType  = DataType.Guid, DbType   = "uuid"           , IsPrimaryKey = true                                  )] public Guid   Id              { get; set; } // uuid
        [Column("transactionname", CanBeNull = false        , DataType = DataType.NVarChar, DbType       = "character varying(128)", Length = 128)] public string Transactionname { get; set; } = null!; // character varying(128)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<LogsTransactiontype> _equalityComparer = ComparerBuilder.GetEqualityComparer<LogsTransactiontype>(c => c.Id);

        public bool Equals(LogsTransactiontype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as LogsTransactiontype);
        }
        #endregion
    }
}
