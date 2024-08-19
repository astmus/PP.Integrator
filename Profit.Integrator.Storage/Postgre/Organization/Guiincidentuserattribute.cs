
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("guiincidentuserattributes")]
    public partial class Guiincidentuserattribute : IEquatable<Guiincidentuserattribute>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string Name { get; set; } = null!; // character varying(512)
        [Column("title", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Title { get; set; } // character varying(1024)
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
        [Column("attrtype", DataType = DataType.Guid, DbType = "uuid")] public Guid Attrtype { get; set; } // uuid
        [Column("isrequired", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isrequired { get; set; } // boolean
        [Column("isreadonly", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isreadonly { get; set; } // boolean
        [Column("controltype", DataType = DataType.Guid, DbType = "uuid")] public Guid Controltype { get; set; } // uuid
        [Column("sourcetype", DataType = DataType.Guid, DbType = "uuid")] public Guid? Sourcetype { get; set; } // uuid
        [Column("sourceparams", DataType = DataType.Text, DbType = "text")] public string? Sourceparams { get; set; } // text
        [Column("createdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createdate { get; set; } // timestamp (6) without time zone
        [Column("deletedate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Deletedate { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Guiincidentuserattribute> _equalityComparer = ComparerBuilder.GetEqualityComparer<Guiincidentuserattribute>(c => c.Id);

        public bool Equals(Guiincidentuserattribute? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Guiincidentuserattribute);
        }
        #endregion
    }
}
