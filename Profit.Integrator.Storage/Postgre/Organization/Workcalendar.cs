
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("workcalendars")]
    public partial class Workcalendar : IEquatable<Workcalendar>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Name { get; set; } // character varying(1024)
        [Column("is24x7", DataType = DataType.Boolean, DbType = "boolean")] public bool Is24X7 { get; set; } // boolean
        [Column("ismonday24", DataType = DataType.Boolean, DbType = "boolean")] public bool Ismonday24 { get; set; } // boolean
        [Column("istuesday24", DataType = DataType.Boolean, DbType = "boolean")] public bool Istuesday24 { get; set; } // boolean
        [Column("iswednesday24", DataType = DataType.Boolean, DbType = "boolean")] public bool Iswednesday24 { get; set; } // boolean
        [Column("isthursday24", DataType = DataType.Boolean, DbType = "boolean")] public bool Isthursday24 { get; set; } // boolean
        [Column("isfriday24", DataType = DataType.Boolean, DbType = "boolean")] public bool Isfriday24 { get; set; } // boolean
        [Column("issaturday24", DataType = DataType.Boolean, DbType = "boolean")] public bool Issaturday24 { get; set; } // boolean
        [Column("issunday24", DataType = DataType.Boolean, DbType = "boolean")] public bool Issunday24 { get; set; } // boolean
        [Column("description", DataType = DataType.NVarChar, DbType = "character varying(2048)", Length = 2048)] public string? Description { get; set; } // character varying(2048)
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Workcalendar> _equalityComparer = ComparerBuilder.GetEqualityComparer<Workcalendar>(c => c.Id);

        public bool Equals(Workcalendar? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Workcalendar);
        }
        #endregion
    }
}
