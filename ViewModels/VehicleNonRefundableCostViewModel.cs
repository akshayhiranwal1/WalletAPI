using System;
using System.Collections.Generic;

namespace WalletAPI.ViewModels
{
    public partial class VehicleNonRefundableCostViewModel
    {
        public int Id { get; set; }
        public int FkVehicleMasterId { get; set; }
        public int? FkStatusId { get; set; }
        public int? AccountCode { get; set; }
        public string Subject { get; set; }
        public string CostType { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public bool? IncludeVat { get; set; }
        public decimal? Vat { get; set; }
        public decimal? Total { get; set; }        
        public string InvoiceNumber { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public partial class NonRefundableCostViewModel
    {
        public List<VehicleNonRefundableCostViewModel> NonRefundalbeCosts { get; set; }
        public decimal TotalAmount { get; set;}
        public decimal TotalVAT { get; set; }
    }
}
