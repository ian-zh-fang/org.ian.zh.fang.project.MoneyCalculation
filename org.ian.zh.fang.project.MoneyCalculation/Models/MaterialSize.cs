using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [SerializableAttribute]
    public class MaterialSize : EntityDataHandler<MaterialSize>
    {
        public MaterialSize() { }

        public MaterialSize(SerializationInfo info, StreamingContext context):base(info, context) { }
        
        [KeyAttribute, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SizeId { get; set; }

        [RequiredAttribute]
        public string SDesc { get; set; }

        protected override MaterialSize Instance
        {
            get
            {
                return this;
            }
        }
    }
}
