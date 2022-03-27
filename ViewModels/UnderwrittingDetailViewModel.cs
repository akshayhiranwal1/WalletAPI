using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletAPI.ViewModels
{
    public class UnderwrittingDetailViewModel
    {
        public int Id { get; set; }
        public int? FkCustomerId { get; set; }
        public int? FkLeadId { get; set; }
        public bool? CIfas { get; set; }
        public bool? OnVoterRoll { get; set; }
        public string CreditScore { get; set; }
        public bool? HpiClear { get; set; }
        public bool? AmlCheck { get; set; }
        public int? NumberOfCcjs { get; set; }
        public int? NumberOfDefaults { get; set; }
        public int? NumberOfArrears { get; set; }
        public bool? Iva { get; set; }
        public bool? Bko { get; set; }
        public bool? Vt { get; set; }
        public string CompanyName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
