using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Data.Entity;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class EntityQueryHandler<T> : SerializateBase
        where T : class, new()
    {
        public EntityQueryHandler() { }
        public EntityQueryHandler(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public static async Task<IEnumerable<T>> AllAsync()
        {
            IEnumerable<T> data = null;
            using (MCDBContext<T> db = new MCDBContext<T>())
            {
                data = await db.Result.ToArrayAsync();
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
        
        public async Task<T> AddAsync()
        {
            T result = null;
            using (MCDBContext<T> db = new MCDBContext<T>())
            {
                result = db.Result.Add(Instance);
                if (0 >= await db.SaveChangesAsync())
                {
                    result = null;
                }
            }

            return result;
        }

        protected virtual T Instance
        {
            get { return null; }
        }
    }
}
