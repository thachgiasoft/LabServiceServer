using System;
using System.ComponentModel;
using System.Threading;
using System.Web;
using SubSonic;

// <auto-generated />

namespace Vietbait.Lablink.Model
{
    /// <summary>
    ///     Controller class for tbl_RolesForUsers
    /// </summary>
    [DataObject]
    public class TblRolesForUserController
    {
        // Preload our schema..
        private TblRolesForUser thisSchemaLoad = new TblRolesForUser();
        private string userName = String.Empty;

        protected string UserName
        {
            get
            {
                if (userName.Length == 0)
                {
                    if (HttpContext.Current != null)
                    {
                        userName = HttpContext.Current.User.Identity.Name;
                    }
                    else
                    {
                        userName = Thread.CurrentPrincipal.Identity.Name;
                    }
                }
                return userName;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TblRolesForUserCollection FetchAll()
        {
            var coll = new TblRolesForUserCollection();
            var qry = new Query(TblRolesForUser.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TblRolesForUserCollection FetchByID(object SUID)
        {
            TblRolesForUserCollection coll = new TblRolesForUserCollection().Where("sUID", SUID).Load();
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TblRolesForUserCollection FetchByQuery(Query qry)
        {
            var coll = new TblRolesForUserCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SUID)
        {
            return (TblRolesForUser.Delete(SUID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SUID)
        {
            return (TblRolesForUser.Destroy(SUID) == 1);
        }


        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(string SUID, long IRoleID, long IParentRoleID, string FpSBranchID)
        {
            var qry = new Query(TblRolesForUser.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("SUID", SUID)
                .AND("IRoleID", IRoleID)
                .AND("IParentRoleID", IParentRoleID)
                .AND("FpSBranchID", FpSBranchID);
            qry.Execute();
            return (true);
        }


        /// <summary>
        ///     Inserts a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void Insert(string SUID, long IRoleID, long IParentRoleID, string FpSBranchID)
        {
            var item = new TblRolesForUser();

            item.SUID = SUID;

            item.IRoleID = IRoleID;

            item.IParentRoleID = IParentRoleID;

            item.FpSBranchID = FpSBranchID;


            item.Save(UserName);
        }

        /// <summary>
        ///     Updates a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(string SUID, long IRoleID, long IParentRoleID, string FpSBranchID)
        {
            var item = new TblRolesForUser();
            item.MarkOld();
            item.IsLoaded = true;

            item.SUID = SUID;

            item.IRoleID = IRoleID;

            item.IParentRoleID = IParentRoleID;

            item.FpSBranchID = FpSBranchID;

            item.Save(UserName);
        }
    }
}