using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class OrderMaterialTotal : EntityQueryHandler<OrderMaterialTotal>
    {
        public OrderMaterialTotal() { }

        public OrderMaterialTotal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        [KeyAttribute]
        public int OrderId { get; set; }

        public string MSize { get; set; }

        public string MFrom { get; set; }

        public int Quantity { get; set; }
    }
}