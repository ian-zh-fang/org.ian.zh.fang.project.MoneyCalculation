using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class OrderMaterial : EntityDataHandler<OrderMaterial>
    {
        public OrderMaterial() { }

        public OrderMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        [KeyAttribute, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaterialId { get; set; }

        [RequiredAttribute]
        public int OrderId { get; set; }

        [RequiredAttribute]
        public string MSize { get; set; }

        [RequiredAttribute]
        public int MQuantity { get; set; }

        [RequiredAttribute]
        public string MFrom { get; set; }

        [RequiredAttribute]
        public int MFlag { get; set; }

        private DateTime mAddTime = DateTime.Now;
        [RequiredAttribute]
        public DateTime MAddTime
        {
            get { return mAddTime; }
            set { mAddTime = value; }
        }

        protected override OrderMaterial Instance
        {
            get
            {
                return this;
            }
        }
    }
}
