using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class SerializateBase : ISerializable
    {
        protected virtual Type CType
        {
            get { return GetType(); }
        }

        public SerializateBase() { }

        public SerializateBase(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            PropertyInfo[] properties = CType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField | BindingFlags.SetField);
            foreach(PropertyInfo p in properties)
            {
                object value = info.GetValue(p.Name, p.PropertyType);
                p.SetValue(this, value, null);
            }
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags =SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            PropertyInfo[] properties = CType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty);
            foreach(PropertyInfo p in properties)
            {
                object value = p.GetValue(this, null);
                info.AddValue(p.Name, value, p.PropertyType);
            }
        }

        /// <summary>
        /// 预留扩展函数
        /// </summary>
        /// <param name="args">传入的参数</param>
        /// <returns>返回一个 System.Object 类型的实例</returns>
        protected virtual object GetExtentionObj(params object[] args)
        {
            return null;
        }
    }
}
