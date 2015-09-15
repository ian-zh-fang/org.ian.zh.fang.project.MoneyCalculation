using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class UnitContent : EntityDataHandler<UnitContent>
    {
        public UnitContent() { }

        public UnitContent(SerializationInfo info, StreamingContext context) : base(info, context) { }

        [KeyAttribute, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnitId { get; set; }

        [RequiredAttribute]
        public string UName { get; set; }

        [RequiredAttribute]
        public double UPrice { get; set; }

        protected override UnitContent Instance
        {
            get
            {
                return this;
            }
        }
    }
}