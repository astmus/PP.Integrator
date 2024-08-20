
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("guiincidentscripts")]
    public partial class Guiincidentscript : IEquatable<Guiincidentscript>
    {
        [Column("id"             , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id              { get; set; } // uuid
        [Column("parentid"       , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Parentid        { get; set; } // uuid
        [Column("title"          , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(512)", Length = 512)] public string    Title           { get; set; } = null!; // character varying(512)
        [Column("position"       , DataType  = DataType.Int32    , DbType   = "integer"                                                                               )] public int?      Position        { get; set; } // integer
        [Column("description"    , DataType  = DataType.Text     , DbType   = "text"                                                                                  )] public string?   Description     { get; set; } // text
        [Column("needextrainfo"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool?     Needextrainfo   { get; set; } // boolean
        [Column("categoryid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Categoryid      { get; set; } // uuid
        [Column("statusid"       , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Statusid        { get; set; } // uuid
        [Column("createdbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Guiincidentscript> _equalityComparer = ComparerBuilder.GetEqualityComparer<Guiincidentscript>(c => c.Id);

        public bool Equals(Guiincidentscript? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Guiincidentscript);
        }
        #endregion
    }
}
