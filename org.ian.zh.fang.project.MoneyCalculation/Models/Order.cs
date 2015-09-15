using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class Order : EntityDataHandler<Order>
    {
        public Order() { }

        public Order(SerializationInfo info, StreamingContext context) : base(info, context) { }

        [KeyAttribute, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [RequiredAttribute]
        public int CustomerId { get; set; }

        [RequiredAttribute]
        public string OCode { get; set; }

        private int _flag = 1;
        [RequiredAttribute]
        public int OFlag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        private DateTime _oAddTime = DateTime.Now;
        [RequiredAttribute]
        public DateTime OAddTime
        {
            get { return _oAddTime; }
            set { _oAddTime  = value; }
        }


        protected override Order Instance
        {
            get
            {
                return this;
            }
        }
    }
}