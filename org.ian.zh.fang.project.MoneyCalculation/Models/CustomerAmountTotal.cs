using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class CustomerAmountTotal : EntityQueryHandler<CustomerAmountTotal>
    {
        public CustomerAmountTotal() { }

        public CustomerAmountTotal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        [KeyAttribute]
        public int CustomerId { get; set; }

        public double Amount { get; set; }
    }
}