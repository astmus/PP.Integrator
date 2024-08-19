
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("dwh_metricsoperands")]
    public partial class DwhMetricsoperand : IEquatable<DwhMetricsoperand>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Name { get; set; } = null!; // character varying(256)
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
        [Column("cod", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(16)", Length = 16)] public string Cod { get; set; } = null!; // character varying(16)
        [Column("operandtype", DataType = DataType.NVarChar, DbType = "character varying(32)", Length = 32)] public string? Operandtype { get; set; } // character varying(32)
        [Column("phrasesclusterid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Phrasesclusterid { get; set; } // uuid
        [Column("checkpointname", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Checkpointname { get; set; } // character varying(256)
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<DwhMetricsoperand> _equalityComparer = ComparerBuilder.GetEqualityComparer<DwhMetricsoperand>(c => c.Id);

        public bool Equals(DwhMetricsoperand? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as DwhMetricsoperand);
        }
        #endregion
    }
}
