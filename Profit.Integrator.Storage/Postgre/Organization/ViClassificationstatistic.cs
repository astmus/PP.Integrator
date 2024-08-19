
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("vi_classificationstatistics")]
    public partial class ViClassificationstatistic : IEquatable<ViClassificationstatistic>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("stepid", DataType = DataType.Guid, DbType = "uuid")] public Guid Stepid { get; set; } // uuid
        [Column("phrase", DataType = DataType.Text, DbType = "text")] public string? Phrase { get; set; } // text
        [Column("resultstepid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Resultstepid { get; set; } // uuid
        [Column("resultsettingsname", DataType = DataType.NVarChar, DbType = "character varying(64)", Length = 64)] public string? Resultsettingsname { get; set; } // character varying(64)
        [Column("resultweight", DataType = DataType.Double, DbType = "double precision")] public double? Resultweight { get; set; } // double precision
        [Column("resultsourcetype", DataType = DataType.Int32, DbType = "integer")] public int? Resultsourcetype { get; set; } // integer
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViClassificationstatistic> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViClassificationstatistic>(c => c.Id);

        public bool Equals(ViClassificationstatistic? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViClassificationstatistic);
        }
        #endregion
    }
}
