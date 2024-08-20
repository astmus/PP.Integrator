
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("absenceclassificationcandidates")]
    public partial class Absenceclassificationcandidate : IEquatable<Absenceclassificationcandidate>
    {
        [Column("id"                  , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                   { get; set; } // uuid
        [Column("usersip"             , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length       = 256 )] public string?   Usersip              { get; set; } // character varying(256)
        [Column("managersip"          , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length       = 256 )] public string?   Managersip           { get; set; } // character varying(256)
        [Column("beginabsencetime"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Beginabsencetime     { get; set; } // timestamp (6) without time zone
        [Column("endabsencetime"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Endabsencetime       { get; set; } // timestamp (6) without time zone
        [Column("subject"             , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Subject              { get; set; } // character varying(1024)
        [Column("postto"              , DataType = DataType.NVarChar , DbType = "character varying(16)"          , Length       = 16  )] public string?   Postto               { get; set; } // character varying(16)
        [Column("requestsubjectcount" , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Requestsubjectcount  { get; set; } // integer
        [Column("requestclasscount"   , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Requestclasscount    { get; set; } // integer
        [Column("classstate"          , DataType = DataType.NVarChar , DbType = "character varying(16)"          , Length       = 16  )] public string?   Classstate           { get; set; } // character varying(16)
        [Column("absencetype"         , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Absencetype          { get; set; } // integer
        [Column("classificationresult", DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Classificationresult { get; set; } // integer
        [Column("createddate"         , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate          { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"           , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted            { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Absenceclassificationcandidate> _equalityComparer = ComparerBuilder.GetEqualityComparer<Absenceclassificationcandidate>(c => c.Id);

        public bool Equals(Absenceclassificationcandidate? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Absenceclassificationcandidate);
        }
        #endregion
    }
}
