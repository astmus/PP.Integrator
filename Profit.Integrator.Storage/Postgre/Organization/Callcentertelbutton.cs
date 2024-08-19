
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("callcentertelbuttons")]
    public partial class Callcentertelbutton : IEquatable<Callcentertelbutton>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("button", DataType = DataType.NVarChar, DbType = "character varying(8)", Length = 8)] public string? Button { get; set; } // character varying(8)
        [Column("positionnumber", DataType = DataType.Int32, DbType = "integer")] public int? Positionnumber { get; set; } // integer
        [Column("visible", DataType = DataType.Boolean, DbType = "boolean")] public bool? Visible { get; set; } // boolean
        [Column("createdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createdate { get; set; } // timestamp (6) without time zone
        [Column("deletedate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Deletedate { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Callcentertelbutton> _equalityComparer = ComparerBuilder.GetEqualityComparer<Callcentertelbutton>(c => c.Id);

        public bool Equals(Callcentertelbutton? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Callcentertelbutton);
        }
        #endregion
    }
}
