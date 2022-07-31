using Domain.Common;
using System;

namespace Domain.Models
{
    public class Agreement : ExtendedBaseModel
    {
        public string RecordNumber { get; set; }
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public DateTime StratDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProcessStatus { get; set; }
        public int AgreementType { get; set; }
        public string Description { get; set; }
        public string RequestNumber { get; set; }
        public DateTime IngoingDocumentDate { get; set; }
        public int IngoingDocumentNumber { get; set; }
        public DateTime HappensDateTime { get; set; }
        public int HappensCount { get; set; }
        public string FileUrl { get; set; }
    }
}
