
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("backgroundtaskbyentities")]
    public partial class Backgroundtaskbyentity : IEquatable<Backgroundtaskbyentity>
    {
        [Column("id"                        , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                         { get; set; } // uuid
        [Column("entity"                    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Entity                     { get; set; } // uuid
        [Column("backgroundtask"            , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Backgroundtask             { get; set; } // uuid
        [Column("rangeparams"               , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length       = 256 )] public string?   Rangeparams                { get; set; } // character varying(256)
        [Column("weight"                    , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Weight                     { get; set; } // integer
        [Column("duetime"                   , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Duetime                    { get; set; } // integer
        [Column("period"                    , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Period                     { get; set; } // integer
        [Column("isdeleted"                 , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted                  { get; set; } // boolean
        [Column("parameters"                , DataType = DataType.NVarChar , DbType = "character varying"                                   )] public string?   Parameters                 { get; set; } // character varying
        [Column("description"               , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Description                { get; set; } // text
        [Column("executorscount"            , DataType = DataType.Int32    , DbType = "integer"                                             )] public int       Executorscount             { get; set; } // integer
        [Column("updatetime"                , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updatetime                 { get; set; } // timestamp (6) without time zone
        [Column("laststarttime"             , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Laststarttime              { get; set; } // timestamp (6) without time zone
        [Column("lastsaccessfulcompletetime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Lastsaccessfulcompletetime { get; set; } // timestamp (6) without time zone
        [Column("nextstarttime"             , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Nextstarttime              { get; set; } // timestamp (6) without time zone
        [Column("startfromtime"             , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Startfromtime              { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Backgroundtaskbyentity> _equalityComparer = ComparerBuilder.GetEqualityComparer<Backgroundtaskbyentity>(c => c.Id);

        public bool Equals(Backgroundtaskbyentity? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Backgroundtaskbyentity);
        }
        #endregion
    }
}
