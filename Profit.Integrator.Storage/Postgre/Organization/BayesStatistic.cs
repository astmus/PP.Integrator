
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("bayes_statistic")]
    public partial class BayesStatistic : IEquatable<BayesStatistic>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("areaid", DataType = DataType.Guid, DbType = "uuid")] public Guid Areaid { get; set; } // uuid
        [Column("category", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Category { get; set; } // character varying(512)
        [Column("word", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Word { get; set; } // character varying(128)
        [Column("quantity", DataType = DataType.Int32, DbType = "integer")] public int? Quantity { get; set; } // integer
        [Column("dispersion", DataType = DataType.Decimal, DbType = "numeric(10,2)")] public decimal? Dispersion { get; set; } // numeric(10,2)
        [Column("wordcount", DataType = DataType.Int32, DbType = "integer")] public int? Wordcount { get; set; } // integer
        [Column("weight", DataType = DataType.Decimal, DbType = "numeric(5,2)")] public decimal? Weight { get; set; } // numeric(5,2)
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<BayesStatistic> _equalityComparer = ComparerBuilder.GetEqualityComparer<BayesStatistic>(c => c.Id);

        public bool Equals(BayesStatistic? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BayesStatistic);
        }
        #endregion
    }
}
