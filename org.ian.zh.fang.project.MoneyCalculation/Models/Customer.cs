using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class Customer : EntityDataHandler<Customer>
    {
        public Customer() { }

        public Customer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        [KeyAttribute, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [RequiredAttribute]
        public string CuName { get; set; }

        [RequiredAttribute]
        public string CuTel { get; set; }

        [RequiredAttribute]
        public string CuAddr { get; set; }

        [RequiredAttribute]
        public string CuDesc { get; set; }

        private int _flag = 1;
        [RequiredAttribute]
        public int CuFlag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        private DateTime _addtime = DateTime.Now;
        [RequiredAttribute]
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        protected override Customer Instance
        {
            get
            {
                return this;
            }
        }
    }
}