using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class MaterialFrom : EntityDataHandler<MaterialFrom>
    {
        public MaterialFrom() { }
        public MaterialFrom(SerializationInfo info, StreamingContext context) : base(info, context) { }

        [KeyAttribute, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FromId { get; set; }

        [RequiredAttribute]
        public string FDesc { get; set; }

        protected override MaterialFrom Instance
        {
            get
            {
                return this;
            }
        }
    }
}
