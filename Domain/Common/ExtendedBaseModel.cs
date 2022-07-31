using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common
{
    public class ExtendedBaseModel
    {
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Key]
        public int AgreementID { get; set; }
        [Column(TypeName = "datetime"), DefaultValue("getDate()")]
        public DateTime InsertionDate { get; set; }
        [Column(TypeName = "datetime"), DefaultValue("getDate()")]
        public DateTime UpdateDate { get; set; }
        [DefaultValue("1")]
        public int Status { get; set; }
    }
}
