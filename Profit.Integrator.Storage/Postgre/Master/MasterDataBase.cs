using LinqToDB;
using LinqToDB.Data;
using Profit.Integrator.Storage.Postgre.Organization;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Profit.Integrator.Storage.MasterDataBase;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    /// <summary>
    /// Database       : PIT_M_883
    /// Data Source    : tcp://localhost:5432
    /// Server Version : 16.3
    /// 
    /// </summary>
    public partial class MasterDataBase : DataConnection
    {
        public MasterDataBase()
        {
            InitDataContext();
        }

        public MasterDataBase(string configuration)
            : base(configuration)
        {
            InitDataContext();
        }

        public MasterDataBase(DataOptions<MasterDataBase> options)
            : base(options.Options)
        {
            InitDataContext();
        }

        partial void InitDataContext();

        public ITable<Accesskey> Accesskeys => this.GetTable<Accesskey>();
        public ITable<Admin> Admins => this.GetTable<Admin>();
        public ITable<Allowipaddress> Allowipaddresses => this.GetTable<Allowipaddress>();
        public ITable<Authtoken> Authtokens => this.GetTable<Authtoken>();
        public ITable<Backgroundtaskbyentity> Backgroundtaskbyentities => this.GetTable<Backgroundtaskbyentity>();
        public ITable<Backgroundtaskbyserverpriority> Backgroundtaskbyserverpriorities => this.GetTable<Backgroundtaskbyserverpriority>();
        public ITable<Backgroundtaskbyserver> Backgroundtaskbyservers => this.GetTable<Backgroundtaskbyserver>();
        public ITable<Backgroundtask> Backgroundtasks => this.GetTable<Backgroundtask>();
        //public ITable<Cleartablessetting> Cleartablessettings => this.GetTable<Cleartablessetting>();
        public ITable<Crossentityassignedrole> Crossentityassignedroles => this.GetTable<Crossentityassignedrole>();
        public ITable<Crossentityrole> Crossentityroles => this.GetTable<Crossentityrole>();
        public ITable<Entity> Entities => this.GetTable<Entity>();
        public ITable<Entitiesadou> Entitiesadous => this.GetTable<Entitiesadou>();
        public ITable<Entityextension> Entityextensions => this.GetTable<Entityextension>();
        public ITable<Entitylicense> Entitylicenses => this.GetTable<Entitylicense>();
        public ITable<Eventslog> Eventslogs => this.GetTable<Eventslog>();
        public ITable<Externalresource> Externalresources => this.GetTable<Externalresource>();
        public ITable<Httpurlreference> Httpurlreferences => this.GetTable<Httpurlreference>();
        public ITable<Iamtoken> Iamtokens => this.GetTable<Iamtoken>();
        public ITable<License> Licenses => this.GetTable<License>();
        public ITable<Linescount> Linescounts => this.GetTable<Linescount>();
        public ITable<Masterbackgroundtaskbyserverpriority> Masterbackgroundtaskbyserverpriorities => this.GetTable<Masterbackgroundtaskbyserverpriority>();
        public ITable<Masterbackgroundtaskbyserver> Masterbackgroundtaskbyservers => this.GetTable<Masterbackgroundtaskbyserver>();
        public ITable<Masterbackgroundtask> Masterbackgroundtasks => this.GetTable<Masterbackgroundtask>();
        public ITable<Organizationscache> Organizationscaches => this.GetTable<Organizationscache>();
        public ITable<PitLog> PitLogs => this.GetTable<PitLog>();
        public ITable<Product> Products => this.GetTable<Product>();
        public ITable<Registration> Registrations => this.GetTable<Registration>();
        public ITable<Requestlog> Requestlogs => this.GetTable<Requestlog>();
        public ITable<Schemaversion> Schemaversions => this.GetTable<Schemaversion>();
        public ITable<Serverbyoperationpriority> Serverbyoperationpriorities => this.GetTable<Serverbyoperationpriority>();
        public ITable<Server> Servers => this.GetTable<Server>();
        public ITable<Servicerate> Servicerates => this.GetTable<Servicerate>();
        public ITable<Setting> Settings => this.GetTable<Setting>();
        public ITable<Trustedapp> Trustedapps => this.GetTable<Trustedapp>();
        public ITable<UiPage> UiPages => this.GetTable<UiPage>();
        public ITable<UiPagesLk> UiPagesLks => this.GetTable<UiPagesLk>();
        public ITable<Updatedatabasescript> Updatedatabasescripts => this.GetTable<Updatedatabasescript>();
        public ITable<Updatedatabaseslog> Updatedatabaseslogs => this.GetTable<Updatedatabaseslog>();
        public ITable<User> Users => this.GetTable<User>();
        public ITable<Websocketlog> Websocketlogs => this.GetTable<Websocketlog>();
        public ITable<UvwEventslog> UvwEventslogs => this.GetTable<UvwEventslog>();
    }

    public static partial class ExtensionMethods
    {
        #region Table Extensions
        public static Accesskey? Find(this ITable<Accesskey> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Accesskey?> FindAsync(this ITable<Accesskey> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Admin? Find(this ITable<Admin> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Admin?> FindAsync(this ITable<Admin> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Allowipaddress? Find(this ITable<Allowipaddress> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Allowipaddress?> FindAsync(this ITable<Allowipaddress> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Authtoken? Find(this ITable<Authtoken> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Authtoken?> FindAsync(this ITable<Authtoken> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Backgroundtaskbyentity? Find(this ITable<Backgroundtaskbyentity> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Backgroundtaskbyentity?> FindAsync(this ITable<Backgroundtaskbyentity> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Backgroundtaskbyserverpriority? Find(this ITable<Backgroundtaskbyserverpriority> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Backgroundtaskbyserverpriority?> FindAsync(this ITable<Backgroundtaskbyserverpriority> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Backgroundtaskbyserver? Find(this ITable<Backgroundtaskbyserver> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Backgroundtaskbyserver?> FindAsync(this ITable<Backgroundtaskbyserver> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Backgroundtask? Find(this ITable<Backgroundtask> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Backgroundtask?> FindAsync(this ITable<Backgroundtask> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        //public static Cleartablessetting? Find(this ITable<Cleartablessetting> table, Guid id)
        //{
        //    return table.FirstOrDefault(e => e.Id == id);
        //}

        //public static Task<Cleartablessetting?> FindAsync(this ITable<Cleartablessetting> table, Guid id, CancellationToken cancellationToken = default)
        //{
        //    return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        //}

        public static Crossentityassignedrole? Find(this ITable<Crossentityassignedrole> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Crossentityassignedrole?> FindAsync(this ITable<Crossentityassignedrole> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Crossentityrole? Find(this ITable<Crossentityrole> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Crossentityrole?> FindAsync(this ITable<Crossentityrole> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Entity? Find(this ITable<Entity> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Entity?> FindAsync(this ITable<Entity> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Entitiesadou? Find(this ITable<Entitiesadou> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Entitiesadou?> FindAsync(this ITable<Entitiesadou> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Entityextension? Find(this ITable<Entityextension> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Entityextension?> FindAsync(this ITable<Entityextension> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Entitylicense? Find(this ITable<Entitylicense> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Entitylicense?> FindAsync(this ITable<Entitylicense> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Eventslog? Find(this ITable<Eventslog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Eventslog?> FindAsync(this ITable<Eventslog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Externalresource? Find(this ITable<Externalresource> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Externalresource?> FindAsync(this ITable<Externalresource> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Httpurlreference? Find(this ITable<Httpurlreference> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Httpurlreference?> FindAsync(this ITable<Httpurlreference> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Iamtoken? Find(this ITable<Iamtoken> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Iamtoken?> FindAsync(this ITable<Iamtoken> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static License? Find(this ITable<License> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<License?> FindAsync(this ITable<License> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Linescount? Find(this ITable<Linescount> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Linescount?> FindAsync(this ITable<Linescount> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Masterbackgroundtaskbyserverpriority? Find(this ITable<Masterbackgroundtaskbyserverpriority> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Masterbackgroundtaskbyserverpriority?> FindAsync(this ITable<Masterbackgroundtaskbyserverpriority> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Masterbackgroundtaskbyserver? Find(this ITable<Masterbackgroundtaskbyserver> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Masterbackgroundtaskbyserver?> FindAsync(this ITable<Masterbackgroundtaskbyserver> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Masterbackgroundtask? Find(this ITable<Masterbackgroundtask> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Masterbackgroundtask?> FindAsync(this ITable<Masterbackgroundtask> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Organizationscache? Find(this ITable<Organizationscache> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Organizationscache?> FindAsync(this ITable<Organizationscache> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Registration? Find(this ITable<Registration> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Registration?> FindAsync(this ITable<Registration> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Requestlog? Find(this ITable<Requestlog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Requestlog?> FindAsync(this ITable<Requestlog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Schemaversion? Find(this ITable<Schemaversion> table, int schemaversionsid)
        {
            return table.FirstOrDefault(e => e.Schemaversionsid == schemaversionsid);
        }

        public static Task<Schemaversion?> FindAsync(this ITable<Schemaversion> table, int schemaversionsid, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Schemaversionsid == schemaversionsid, cancellationToken);
        }

        public static Serverbyoperationpriority? Find(this ITable<Serverbyoperationpriority> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Serverbyoperationpriority?> FindAsync(this ITable<Serverbyoperationpriority> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Server? Find(this ITable<Server> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Server?> FindAsync(this ITable<Server> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Setting? Find(this ITable<Setting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Setting?> FindAsync(this ITable<Setting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Trustedapp? Find(this ITable<Trustedapp> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Trustedapp?> FindAsync(this ITable<Trustedapp> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static UiPage? Find(this ITable<UiPage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<UiPage?> FindAsync(this ITable<UiPage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static UiPagesLk? Find(this ITable<UiPagesLk> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<UiPagesLk?> FindAsync(this ITable<UiPagesLk> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static User? Find(this ITable<User> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<User?> FindAsync(this ITable<User> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Websocketlog? Find(this ITable<Websocketlog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Websocketlog?> FindAsync(this ITable<Websocketlog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
        #endregion
    }
}
