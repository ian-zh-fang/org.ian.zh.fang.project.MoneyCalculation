using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class OrderContent : EntityDataHandler<OrderContent>
    {
        public OrderContent() { }

        public OrderContent(SerializationInfo info, StreamingContext context) : base(info, context) { }

        [KeyAttribute, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContentId { get; set; }

        [RequiredAttribute]
        public int OrderId { get; set; }

        private DateTime _cAddTime = DateTime.Now;
        [RequiredAttribute]
        public DateTime CAddTime
        {
            get { return _cAddTime; }
            set { _cAddTime = value; }
        }

        [RequiredAttribute]
        public string CName { get; set; }

        [RequiredAttribute]
        public int CQuantity { get; set; }

        [RequiredAttribute]
        public string TName { get; set; }

        [RequiredAttribute]
        public string UName { get; set; }

        [RequiredAttribute]
        public int UQuantity { get; set; }

        [RequiredAttribute]
        public double UPrice { get; set; }

        protected override OrderContent Instance
        {
            get
            {
                return this;
            }
        }
    }
}