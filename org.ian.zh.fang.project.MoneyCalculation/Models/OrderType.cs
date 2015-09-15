using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class OrderType : EntityDataHandler<OrderType>
    {
        public OrderType() { }

        public OrderType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        [KeyAttribute, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CId { get; set; }

        [RequiredAttribute]
        public string CName { get; set; }

        [RequiredAttribute]
        public string UName { get; set; }

        [RequiredAttribute]
        public int UQuantity { get; set; }

        [RequiredAttribute]
        public double UPrice { get; set; }

        protected override OrderType Instance
        {
            get
            {
                return this;
            }
        }
    }
}