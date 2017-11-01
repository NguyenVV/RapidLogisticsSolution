#region Using Namespaces...

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

#endregion

namespace DataModel.GenericRepository
{
    /// <summary>
    /// Generic Repository class for Entity Operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> where TEntity : class
    {
        #region Private member variables...
        internal DbContext Context;
        internal DbSet<TEntity> DbSet;
        #endregion

        #region Public Constructor...
        /// <summary>
        /// Public Constructor,initializes privately declared local variables.
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(DbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }
        #endregion

        #region Public member methods...
        public void RefreshConnection()
        {
            DbContext context = new DbContext(ConfigurationManager.ConnectionStrings["RapidSolutionEntities"].ConnectionString);
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
            Context.Configuration.LazyLoadingEnabled = true;
            Context.Configuration.ProxyCreationEnabled = true;
        }
        public bool isConnectSql()
        {
            EntityConnectionStringBuilder b = new EntityConnectionStringBuilder();
            ConnectionStringSettings entityConString = ConfigurationManager.ConnectionStrings["RapidSolutionEntities"];
            b.ConnectionString = entityConString.ConnectionString;
            string providerConnectionString = b.ProviderConnectionString;

            SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder();
            conStringBuilder.ConnectionString = providerConnectionString;
            conStringBuilder.ConnectTimeout = 1;
            string constr = conStringBuilder.ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public void DisposeContext()
        {
            if (Context == null)
                return;
            Context.Dispose();
        }
        public int ExecuteUpdateQuery(string _query)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbConnectionStringRapidSolution"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                if (connection.State == ConnectionState.Closed || connection.State ==
                        ConnectionState.Broken)
                {
                    connection.Open();
                }

                using (var myAdapter = new SqlDataAdapter(_query, connection))
                {
                    try
                    {
                        SqlCommand myCommand = new SqlCommand();
                        myCommand.Connection = connection;
                        myCommand.CommandText = _query;
                        myAdapter.UpdateCommand = myCommand;

                        return myCommand.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.Write("Error - Connection.executeUpdateQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                        return 0;
                    }
                }
            }
        }

        public DataTable ExecuteSelectQueryFromECUS5VNACCS(string _query)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbConnectionStringECUS5VNACCS"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                if (connection.State == ConnectionState.Closed || connection.State ==
                        ConnectionState.Broken)
                {
                    connection.Open();
                }
                using (var myAdapter = new SqlDataAdapter(_query, connection))
                {
                    try
                    {
                        SqlCommand myCommand = new SqlCommand();
                        myCommand.Connection = connection;
                        myCommand.CommandText = _query;
                        myAdapter.SelectCommand = myCommand;
                        DataTable result = new DataTable();
                        myAdapter.Fill(result);
                        return result;
                    }
                    catch (SqlException e)
                    {
                        Console.Write("Error - Connection.executeUpdateQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                        return null;
                    }
                    finally
                    {
                        //CloseConnection();
                    }
                }
            }
        }

        /// <summary>
        /// generic Get method for Entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = DbSet;
            return query.AsEnumerable();
        }

        /// <summary>
        /// Generic get method on the basis of id for Entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// generic Insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// generic Insert method for the the list entities
        /// </summary>
        /// <param name="entityList"></param>
        public virtual int Insert(List<TEntity> entityList)
        {
            int numberInsert = 0;
            if (entityList != null && entityList.Count() > 0)
            {
                foreach (TEntity entity in entityList)
                {
                    try
                    {   
                        DbSet.Add(entity);
                        numberInsert++;
                    }
                    catch (Exception ex)

                    { Ultilities.FileHelper.WriteLog(Ultilities.ExceptionLevel.Function, "public virtual void Insert(List<TEntity> entityList)", ex); }
                }
            }

            return numberInsert;
        }

        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>
        /// <param name="updatedProperties"></param>
        public virtual void Update(TEntity entityOriginal, TEntity entityToUpdate, params Expression<Func<TEntity, object>>[] updatedProperties)
        {
            //Ensure only modified fields are updated.
            var dbEntityEntry = Context.Entry(entityOriginal);
            dbEntityEntry.OriginalValues.SetValues(entityOriginal);
            dbEntityEntry.CurrentValues.SetValues(entityToUpdate);

            if (updatedProperties.Any())
            {
                //update explicitly mentioned properties
                foreach (var property in updatedProperties)
                {
                    dbEntityEntry.Property(property).IsModified = true;
                }
            }
            else
            {
                //no items mentioned, so find out the updated entries
                foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
                {
                    var original = dbEntityEntry.OriginalValues.GetValue<object>(property);
                    var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
                    if (original != null && !original.Equals(current))
                        dbEntityEntry.Property(property).IsModified = true;
                }
            }
        }
        /// <summary>
        /// generic method to get many record on the basis of a condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return DbSet.Where(where).ToList();
        }

        /// <summary>
        /// generic method to get many record on the basis of a condition but query able.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where)
        {
            return DbSet.Where(where).AsQueryable();
        }

        /// <summary>
        /// generic get method , fetches data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public TEntity Get(Func<TEntity, Boolean> where)
        {
            return DbSet.Where(where).FirstOrDefault<TEntity>();
        }

        /// <summary>
        /// generic delete method , deletes data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public void Delete(Func<TEntity, Boolean> where)
        {
            IQueryable<TEntity> objects = DbSet.Where<TEntity>(where).AsQueryable();
            foreach (TEntity obj in objects)
                DbSet.Remove(obj);
        }

        /// <summary>
        /// generic method to fetch all the records from db
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsEnumerable();
        }

        /// <summary>
        /// Inclue multiple
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetWithInclude(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = this.DbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        /// <summary>
        /// Generic method to check if entity exists
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public bool Exists(object primaryKey)
        {
            return DbSet.Find(primaryKey) != null;
        }
        public bool Exists(Func<TEntity, bool> predicate)
        {
            return DbSet.Any(predicate);
        }

        /// <summary>
        /// Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return DbSet.Single<TEntity>(predicate);
        }

        /// <summary>
        /// The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return DbSet.First<TEntity>(predicate);
        }


        #endregion
    }
}