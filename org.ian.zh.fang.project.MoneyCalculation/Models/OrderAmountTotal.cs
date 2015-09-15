using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class OrderAmountTotal : EntityQueryHandler<OrderAmountTotal>
    {
        public OrderAmountTotal() { }

        public OrderAmountTotal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        [KeyAttribute]
        public int OrderId { get; set; }

        public double Amount { get; set; }
    }
}