using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreAssignment01.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment01.Repositories
{
    /// This is a Simple Generic Repository that Do Simple CRUD Operations Select(All,Specifi(id))
    /// , Delete, insert, update. Without Services Module so it acts as a Repo + Services
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        #region CTOR + Private Field dbContext
        private readonly DbContext dbContext;
        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region Select
        public async Task<IEnumerable<TModel>> Select()
        {
            return await dbContext.Set<TModel>().ToListAsync();
        }

        public async Task<TModel?> Select(int id)
        {
            return await dbContext.Set<TModel>().FindAsync(id);
        }
        #endregion
        #region Insert & Update

        /// Insert only returns True of False or can return the Entry.Entity itself
        /// But can't return Primary key as There is no BaseEntity for the Models
        public async Task<bool> Insert(TModel E)
        {
            await dbContext.AddAsync(E);
            int result = await dbContext.SaveChangesAsync();
            return result > 0;
        }

        //  Not best practice to update without Service
        public async Task<int> Update(TModel E, int id)
        {
            var Entity = await dbContext.Set<TModel>().FindAsync(id);
            if (Entity == null) return 0;
            dbContext.Entry(Entity).CurrentValues.SetValues(E);
            return await dbContext.SaveChangesAsync();
        }
        #endregion
        public async Task<bool> Delete(int id)
        {
            var Entity = await dbContext.Set<TModel>().FindAsync(id);
            if (Entity == null) return false;
            dbContext.Set<TModel>().Remove(Entity);
            int result = await dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
