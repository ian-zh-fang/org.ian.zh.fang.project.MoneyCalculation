using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class EntityQueryHandler<T> : SerializateBase
        where T : class, new()
    {
        public EntityQueryHandler() { }
        public EntityQueryHandler(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// 获取所有的数据记录
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> AllAsync()
        {
            IEnumerable<T> data = null;
            using (MCDBContext<T> db = new MCDBContext<T>())
            {
                data = await db.Result.ToArrayAsync();
            }

            return data;
        }

        /// <summary>
        /// 查找指定记录标识的数据记录
        /// </summary>
        /// <param name="keyvalue">指定的记录标识</param>
        /// <returns></returns>
        public static async Task<T> FindAsync(object keyvalue)
        {
            T data = null;
            using (var db = new MCDBContext<T>())
            {
                data = await db.Result.FindAsync(keyvalue);
            }
            return data;
        }

        /// <summary>
        /// 查找指定条件的数据记录
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public static async Task<T[]> FindAsync(Expression<Func<T, bool>> predicate)
        {
            T[] data = null;
            using (var db = new MCDBContext<T>())
            {
                data = await db.Result.Where(predicate).ToArrayAsync();
            }
            return data;
        }

        protected override Type CType
        {
            get
            {
                return typeof(T);
            }
        }
    }

    [SerializableAttribute]
    public class EntityDataHandler<T> : EntityQueryHandler<T>
        where T : class, new()
    {
        public EntityDataHandler() { }

        public EntityDataHandler(SerializationInfo info, StreamingContext context) : base(info, context) { }
        
        /// <summary>
        /// 保存当前记录
        /// </summary>
        /// <returns></returns>
        public async Task<T> InsertAsync()
        {
            return await InsertAsync(Instance);
        }

        /// <summary>
        /// 删除指定的数据记录
        /// </summary>
        /// <param name="t">指定的数据记录</param>
        /// <returns></returns>
        public static async Task<T> InsertAsync(T t)
        {
            T result = null;
            using (MCDBContext<T> db = new MCDBContext<T>())
            {
                result = db.Result.Add(t);
                if (0 >= await db.SaveChangesAsync())
                {
                    result = null;
                }
            }

            return result;
        }

        /// <summary>
        /// 更新当前记录的全部字段信息
        /// </summary>
        /// <returns></returns>
        public async Task<T> UpdateAsync()
        {
            T result = null;
            using (var db = new MCDBContext<T>())
            {
                result = db.Result.Attach(Instance);
                DbEntityEntry<T> entry = db.Entry(Instance);
                entry.State = EntityState.Modified;

                if (0 >= await db.SaveChangesAsync())
                {
                    result = null;
                }
            }

            return result;
        }

        /// <summary>
        /// 更新当前记录的指定字段信息
        /// </summary>
        /// <param name="properties">指定的字段组</param>
        /// <returns></returns>
        public async Task<T> UpdateAsync(Expression<Func<T, object>>[] properties)
        {
            return await UpdateAsync(Instance, properties);
        }

        /// <summary>
        /// 更新指定数据记录的指定字段的信息
        /// </summary>
        /// <param name="t">指定的数据记录</param>
        /// <param name="properties">指定的字段组</param>
        /// <returns></returns>
        public static async Task<T> UpdateAsync(T t, params Expression<Func<T, object>>[] properties)
        {
            T result = null;
            using (MCDBContext<T> db = new MCDBContext<T>())
            {
                result = db.Result.Attach(t);
                DbEntityEntry<T> entry = db.Entry(t);
                foreach (var property in properties)
                {
                    entry.Property(property).IsModified = true;
                }

                if (0 >= await db.SaveChangesAsync())
                {
                    result = null;
                }
            }

            return result;
        }

        /// <summary>
        /// 删除当前记录
        /// </summary>
        /// <returns></returns>
        public async Task<T> DeleteAsync()
        {
            T result = null;
            using (MCDBContext<T> db = new MCDBContext<T>())
            {
                db.Result.Attach(Instance);
                result = db.Result.Remove(Instance);
                if (0 >= await db.SaveChangesAsync())
                {
                    result = null;
                }
            }

            return result;
        }

        /// <summary>
        /// 删除指定标识的数据记录
        /// </summary>
        /// <param name="keyValues">指定的记录标识</param>
        /// <returns></returns>
        public static async Task<T> DeleteAsync(object keyValues)
        {
            T data = await FindAsync(keyValues);
            T result = await DeleteAsync(data);
            return result;
        }

        /// <summary>
        /// 删除指定的数据记录
        /// </summary>
        /// <param name="t">指定的数据记录</param>
        /// <returns></returns>
        public static async Task<T> DeleteAsync(T t)
        {
            if (t == null) return null;

            T result = null;
            using (MCDBContext<T> db = new MCDBContext<T>())
            {
                db.Result.Attach(t);
                result = db.Result.Remove(t);
                if (0 >= await db.SaveChangesAsync())
                {
                    result = null;
                }
            }

            return result;
        }

        /// <summary>
        /// 批量删除指定的数据记录
        /// </summary>
        /// <param name="items">指定数据记录集</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> DeleteAsync(IEnumerable<T> items)
        {
            IEnumerable<T> result = null;
            using (MCDBContext<T> db = new MCDBContext<T>())
            {
                foreach (T t in items)
                {
                    db.Result.Attach(t);
                }
                result = db.Result.RemoveRange(items);
                if (0 >= await db.SaveChangesAsync())
                {
                    result = new T[0];
                }
            }

            return result;
        }

        /// <summary>
        /// 删除指定条件的数据记录
        /// </summary>
        /// <param name="predicate">指定的条件</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> data = await FindAsync(predicate);
            IEnumerable<T> result = await DeleteAsync(data);
            return result;
        }

        //获取当前实例的主键的值
        protected override object GetExtentionObj(params object[] args)
        {
            PropertyInfo property = CType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty)
                .FirstOrDefault(t => t.GetCustomAttribute<KeyAttribute>(false) != null);

            object result = (property == null) ? null : property.GetValue(Instance, null);
            return result;
        }

        protected virtual T Instance
        {
            get { return null; }
        }
    }
}
