using AutoMapper.Configuration;
using WalletAPI.ViewModels;

namespace WalletAPI.Mappings
{
    /// <summary>
    /// Contains objects mapping
    /// </summary>
    /// <seealso cref="MapperConfigurationExpression" />
    public class MapsProfile : MapperConfigurationExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapsProfile"/> class
        /// </summary>
        public MapsProfile()
        {
            // DeviceViewModel To Device and its reverse from Device To DeviceViewModel
            //CreateMap<DeviceViewModel, Device>()
            //    .ForMember(dest => dest.DeviceTitle, opt => opt.MapFrom(src => src.Title))
            //    .ForMember(dest => dest.DeviceId, opt => opt.MapFrom(src => Guid.NewGuid()))
            //    .ForMember(x => x.DeviceDetails, opt => opt.Ignore()).ReverseMap();


            // DeviceViewModel To Device and its reverse from Device To DeviceViewModel
            //CreateMap<ComplianceDetailViewModel, ComplianceDetail>().ReverseMap();
        }
    }
}
