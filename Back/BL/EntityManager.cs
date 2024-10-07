using BL.Interfaces;
using ENTITIES;
using ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BL
{
    public class EntityManager<T> : IEntityManager<T> where T : EntityBase
    {
        protected ContextHandler<T> _contextHandler;

        public EntityManager(Context context,WriteContext wContext) { 
            _contextHandler = new ContextHandler<T>(context,wContext);
        }
        public async Task<int> Add(T entity) {
            _contextHandler.Write().Add(entity);
            return await _contextHandler.Save();
        }
        public async Task<List<T>> GetList()
        {
            List<T> entities = await _contextHandler.Read().ToListAsync();
            return entities;
        }
        public async Task<T?> Get(int id)
        {
            T? entity = await _contextHandler.Read().Where(x => x.Id == id).FirstOrDefaultAsync();
            return entity;
        }
        public async Task<int> Update(T updatedEntity)
        {
            T? entity = await this.Get(updatedEntity.Id);
            UpdateInstance(updatedEntity, entity);
            _contextHandler?.Write().Update(entity);
            return await _contextHandler.Save();
        }
        public async Task<int> Delete(int id) {
            T? entity = await this.Get(id);
            if(entity == null)
            {
                return 0;
            }
            _contextHandler.Write().Remove(entity);
            int result = await _contextHandler.Save();
            return result;
        }

        private void UpdateInstance(T source, T target)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(source, null);
                try
                {
                    if (value != null && !(value is string && string.IsNullOrEmpty((string)value)) &&
                    !(value.GetType().IsValueType && Convert.ToInt32(value) == 0))
                    {
                        property.SetValue(target, value);
                    }
                }
                catch (Exception ex) { }
            };
        }
    }
}