
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("sd_knowledgearticles")]
    public partial class SdKnowledgearticle : IEquatable<SdKnowledgearticle>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("number", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Number { get; set; } = null!; // character varying(256)
        [Column("keywords", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Keywords { get; set; } = null!; // character varying(256)
        [Column("phrases", DataType = DataType.Text, DbType = "text")] public string? Phrases { get; set; } // text
        [Column("title", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(200)", Length = 200)] public string Title { get; set; } = null!; // character varying(200)
        [Column("description", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Description { get; set; } // character varying(256)
        [Column("internalcontent", DataType = DataType.Text, DbType = "text")] public string? Internalcontent { get; set; } // text
        [Column("externalcontenturl", DataType = DataType.NVarChar, DbType = "character varying(2048)", Length = 2048)] public string? Externalcontenturl { get; set; } // character varying(2048)
        [Column("folderid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Folderid { get; set; } // uuid
        [Column("categoryid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Categoryid { get; set; } // uuid
        [Column("statusid", DataType = DataType.Guid, DbType = "uuid")] public Guid Statusid { get; set; } // uuid
        [Column("tagid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Tagid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("externalid", DataType = DataType.NVarChar, DbType = "character varying(64)", Length = 64)] public string? Externalid { get; set; } // character varying(64)
        [Column("source", DataType = DataType.NVarChar, DbType = "character varying(8)", Length = 8)] public string? Source { get; set; } // character varying(8)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("lastsourceid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Lastsourceid { get; set; } // uuid
        [Column("displaycount", DataType = DataType.Int32, DbType = "integer")] public int Displaycount { get; set; } // integer

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdKnowledgearticle> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdKnowledgearticle>(c => c.Id);

        public bool Equals(SdKnowledgearticle? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdKnowledgearticle);
        }
        #endregion
    }
}
