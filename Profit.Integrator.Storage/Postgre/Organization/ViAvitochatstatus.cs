
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_avitochatstatuses")]
    public partial class ViAvitochatstatus : IEquatable<ViAvitochatstatus>
    {
        [Column("id"         , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid     Id          { get; set; } // uuid
        [Column("accountid"  , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid     Accountid   { get; set; } // uuid
        [Column("chatid"     , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(512)", Length = 512)] public string   Chatid      { get; set; } = null!; // character varying(512)
        [Column("status"     , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(64)" , Length = 64 )] public string   Status      { get; set; } = null!; // character varying(64)
        [Column("updateddate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool     Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViAvitochatstatus> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViAvitochatstatus>(c => c.Id);

        public bool Equals(ViAvitochatstatus? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViAvitochatstatus);
        }
        #endregion
    }
}
