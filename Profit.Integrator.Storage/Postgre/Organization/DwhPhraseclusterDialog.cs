
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("dwh_phrasecluster_dialogs")]
    public partial class DwhPhraseclusterDialog : IEquatable<DwhPhraseclusterDialog>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id              { get; set; } // uuid
        [Column("completetime"   , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Completetime    { get; set; } // timestamp (6) without time zone
        [Column("phraseclusterid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Phraseclusterid { get; set; } // uuid
        [Column("passcount"      , DataType = DataType.Int32    , DbType = "integer"                                             )] public int      Passcount       { get; set; } // integer
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Createddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<DwhPhraseclusterDialog> _equalityComparer = ComparerBuilder.GetEqualityComparer<DwhPhraseclusterDialog>(c => c.Id);

        public bool Equals(DwhPhraseclusterDialog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as DwhPhraseclusterDialog);
        }
        #endregion
    }
}
