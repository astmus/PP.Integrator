
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("hr_employments")]
    public partial class HrEmployment : IEquatable<HrEmployment>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Name { get; set; } // character varying(1024)
        [Column("departmentid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Departmentid { get; set; } // uuid
        [Column("position", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Position { get; set; } // character varying(1024)
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
        [Column("salaryfrom", DataType = DataType.Int32, DbType = "integer")] public int? Salaryfrom { get; set; } // integer
        [Column("salaryto", DataType = DataType.Int32, DbType = "integer")] public int? Salaryto { get; set; } // integer
        [Column("stagingemploymentid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Stagingemploymentid { get; set; } // uuid
        [Column("properties", DataType = DataType.Text, DbType = "text")] public string? Properties { get; set; } // text
        [Column("gender", DataType = DataType.Int32, DbType = "integer")] public int? Gender { get; set; } // integer
        [Column("agefrom", DataType = DataType.Int32, DbType = "integer")] public int? Agefrom { get; set; } // integer
        [Column("ageto", DataType = DataType.Int32, DbType = "integer")] public int? Ageto { get; set; } // integer
        [Column("expirienceyear", DataType = DataType.Int32, DbType = "integer")] public int? Expirienceyear { get; set; } // integer
        [Column("educationid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Educationid { get; set; } // uuid
        [Column("typeofworkid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Typeofworkid { get; set; } // uuid
        [Column("placeofworkid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Placeofworkid { get; set; } // uuid
        [Column("caninvalid", DataType = DataType.Boolean, DbType = "boolean")] public bool? Caninvalid { get; set; } // boolean
        [Column("needhealthbook", DataType = DataType.Boolean, DbType = "boolean")] public bool? Needhealthbook { get; set; } // boolean
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<HrEmployment> _equalityComparer = ComparerBuilder.GetEqualityComparer<HrEmployment>(c => c.Id);

        public bool Equals(HrEmployment? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as HrEmployment);
        }
        #endregion
    }
}
