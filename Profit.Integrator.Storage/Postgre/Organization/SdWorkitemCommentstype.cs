
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("sd_workitem_commentstypes")]
    public partial class SdWorkitemCommentstype : IEquatable<SdWorkitemCommentstype>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("connectorproductid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Connectorproductid { get; set; } // uuid
        [Column("connectoraccountid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Connectoraccountid { get; set; } // uuid
        [Column("authortypeid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Authortypeid { get; set; } // uuid
        [Column("hasdialog", DataType = DataType.Boolean, DbType = "boolean")] public bool Hasdialog { get; set; } // boolean
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Name { get; set; } // character varying(1024)
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdWorkitemCommentstype> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdWorkitemCommentstype>(c => c.Id);

        public bool Equals(SdWorkitemCommentstype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdWorkitemCommentstype);
        }
        #endregion
    }
}
