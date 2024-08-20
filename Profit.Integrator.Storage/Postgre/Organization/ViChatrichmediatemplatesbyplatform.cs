
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_chatrichmediatemplatesbyplatforms")]
    public partial class ViChatrichmediatemplatesbyplatform : IEquatable<ViChatrichmediatemplatesbyplatform>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id              { get; set; } // uuid
        [Column("templateid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Templateid      { get; set; } // uuid
        [Column("platformid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Platformid      { get; set; } // uuid
        [Column("templatetext"   , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Templatetext    { get; set; } // text
        [Column("comments"       , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Comments        { get; set; } // character varying(1024)
        [Column("createdbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViChatrichmediatemplatesbyplatform> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViChatrichmediatemplatesbyplatform>(c => c.Id);

        public bool Equals(ViChatrichmediatemplatesbyplatform? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViChatrichmediatemplatesbyplatform);
        }
        #endregion
    }
}
