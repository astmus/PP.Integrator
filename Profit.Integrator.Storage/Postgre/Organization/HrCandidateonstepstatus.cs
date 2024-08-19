
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("hr_candidateonstepstatuses")]
    public partial class HrCandidateonstepstatus : IEquatable<HrCandidateonstepstatus>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Name { get; set; } // character varying(1024)
        [Column("cod", DataType = DataType.Int32, DbType = "integer")] public int? Cod { get; set; } // integer
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<HrCandidateonstepstatus> _equalityComparer = ComparerBuilder.GetEqualityComparer<HrCandidateonstepstatus>(c => c.Id);

        public bool Equals(HrCandidateonstepstatus? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as HrCandidateonstepstatus);
        }
        #endregion
    }
}
