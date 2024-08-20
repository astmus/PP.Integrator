
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_scriptsteps")]
    public partial class VoiceScriptstep : IEquatable<VoiceScriptstep>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id              { get; set; } // uuid
        [Column("number"         , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Number          { get; set; } // integer
        [Column("title"          , DataType = DataType.NVarChar , DbType = "character varying"                                   )] public string?   Title           { get; set; } // character varying
        [Column("scriptid"       , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Scriptid        { get; set; } // uuid
        [Column("stepperformer"  , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Stepperformer   { get; set; } // character varying(255)
        [Column("steptype"       , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Steptype        { get; set; } // character varying(255)
        [Column("comment"        , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Comment         { get; set; } // character varying(1024)
        [Column("checkpointname" , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Checkpointname  { get; set; } // character varying(255)
        [Column("checkpointvalue", DataType = DataType.NVarChar , DbType = "character varying(512)"         , Length       = 512 )] public string?   Checkpointvalue { get; set; } // character varying(512)
        [Column("data"           , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Data            { get; set; } // text
        [Column("version"        , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Version         { get; set; } // integer
        [Column("x"              , DataType = DataType.Double   , DbType = "double precision"                                    )] public double?   X               { get; set; } // double precision
        [Column("y"              , DataType = DataType.Double   , DbType = "double precision"                                    )] public double?   Y               { get; set; } // double precision
        [Column("createdbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceScriptstep> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceScriptstep>(c => c.Id);

        public bool Equals(VoiceScriptstep? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceScriptstep);
        }
        #endregion
    }
}
