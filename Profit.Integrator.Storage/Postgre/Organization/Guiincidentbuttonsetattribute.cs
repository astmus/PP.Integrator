
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("guiincidentbuttonsetattributes")]
    public partial class Guiincidentbuttonsetattribute : IEquatable<Guiincidentbuttonsetattribute>
    {
        [Column("id"              , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id               { get; set; } // uuid
        [Column("button"          , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Button           { get; set; } // uuid
        [Column("attribute"       , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Attribute        { get; set; } // uuid
        [Column("setattributetype", DataType = DataType.NVarChar , DbType = "character varying(128)"         , Length       = 128 )] public string?   Setattributetype { get; set; } // character varying(128)
        [Column("staticvalue"     , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Staticvalue      { get; set; } // text
        [Column("functionvalue"   , DataType = DataType.NVarChar , DbType = "character varying(128)"         , Length       = 128 )] public string?   Functionvalue    { get; set; } // character varying(128)
        [Column("createdate"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createdate       { get; set; } // timestamp (6) without time zone
        [Column("deletedate"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Deletedate       { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Guiincidentbuttonsetattribute> _equalityComparer = ComparerBuilder.GetEqualityComparer<Guiincidentbuttonsetattribute>(c => c.Id);

        public bool Equals(Guiincidentbuttonsetattribute? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Guiincidentbuttonsetattribute);
        }
        #endregion
    }
}
