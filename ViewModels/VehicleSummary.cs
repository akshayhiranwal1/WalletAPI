using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletAPI.ViewModels
{
    public class VehicleSummary
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int? StatusId { get; set; }
        public string StatusName { get; set; }
        public string LocationName { get; set; }
        public int? MakeId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Mileage { get; set; }
        public string FileId { get; set; }
        public decimal? CAPRetail { get; set; }
        public decimal? GGRRetail { get; set; }
        public decimal? SalePrice { get; set; }
        public int? Monthly { get; set; }
        public decimal? MinMonthly { get; set; }
        public decimal? MinDeposit { get; set; }

        public int? NumberOfDoors { get; set; }
        public string FuelType { get; set; }
        public string BodyStyle { get; set; }
        public string ColourCurrent { get; set; }
        public int? Seats { get; set; }
        public string Transmission { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string SashImage { get; set; }
    }
}
