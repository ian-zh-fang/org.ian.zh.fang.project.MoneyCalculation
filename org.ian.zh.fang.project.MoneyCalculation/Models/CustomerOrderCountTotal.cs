using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class CustomerOrderCountTotal : EntityQueryHandler<CustomerOrderCountTotal>
    {
        public CustomerOrderCountTotal() { }

        public CustomerOrderCountTotal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        [KeyAttribute]
        public int CustomerId { get; set; }

        public int Count { get; set; }
    }
}