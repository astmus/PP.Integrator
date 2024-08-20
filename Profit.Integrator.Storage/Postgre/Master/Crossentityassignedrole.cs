
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("crossentityassignedroles")]
    public partial class Crossentityassignedrole : IEquatable<Crossentityassignedrole>
    {
        [Column("id"         , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id          { get; set; } // uuid
        [Column("userid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Userid      { get; set; } // uuid
        [Column("entityid"   , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Entityid    { get; set; } // uuid
        [Column("roleid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Roleid      { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createddate { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Crossentityassignedrole> _equalityComparer = ComparerBuilder.GetEqualityComparer<Crossentityassignedrole>(c => c.Id);

        public bool Equals(Crossentityassignedrole? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Crossentityassignedrole);
        }
        #endregion
    }
}
