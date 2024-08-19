
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("guiincidentbuttonenabledattributes")]
    public partial class Guiincidentbuttonenabledattribute : IEquatable<Guiincidentbuttonenabledattribute>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("button", DataType = DataType.Guid, DbType = "uuid")] public Guid Button { get; set; } // uuid
        [Column("attribute", DataType = DataType.Guid, DbType = "uuid")] public Guid Attribute { get; set; } // uuid
        [Column("isrequired", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isrequired { get; set; } // boolean
        [Column("createdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createdate { get; set; } // timestamp (6) without time zone
        [Column("deletedate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Deletedate { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Guiincidentbuttonenabledattribute> _equalityComparer = ComparerBuilder.GetEqualityComparer<Guiincidentbuttonenabledattribute>(c => c.Id);

        public bool Equals(Guiincidentbuttonenabledattribute? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Guiincidentbuttonenabledattribute);
        }
        #endregion
    }
}
