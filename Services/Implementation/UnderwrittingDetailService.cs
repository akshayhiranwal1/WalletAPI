using AutoMapper;
using WalletAPI.Data.Management;
using WalletAPI.Repository;
using WalletAPI.Services.Generic;
using WalletAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WalletAPI.Services.Implementation
{
    public class UnderwrittingDetailService
        //: IUnderwrittingDetailService<UnderwrittingDetailViewModel>, IGenericService<UnderwrittingDetailViewModel>
    {

        //private IGenericRepository<UnderwrittingDetail> GenericRepository;
        //private readonly IUnitOfWork unitOfWork;
        //private readonly IMapper mapper;
        ////private readonly IDeviceValidationService deviceValidationService;

        ///// <inheritdoc />
        //public UnderwrittingDetailService(
        //    IUnitOfWork unitOfWork,
        //    //IDeviceValidationService deviceValidationService,
        //    IMapper mapper, IGenericRepository<UnderwrittingDetail> genericRepository)
        //{
        //    this.unitOfWork = unitOfWork;
        //    //this.deviceValidationService = deviceValidationService;
        //    this.mapper = mapper;
        //    GenericRepository = genericRepository;
        //}

        //async Task<IEnumerable<UnderwrittingDetailViewModel>> IGenericService<UnderwrittingDetailViewModel>.GetAll()
        //{
        //    IList<UnderwrittingDetailViewModel> models = new List<UnderwrittingDetailViewModel>();
        //    var getAllgs = await GenericRepository.GetAll();
        //    foreach (var getAll in getAllgs)
        //    {
        //        models.Add(mapper.Map<UnderwrittingDetail, UnderwrittingDetailViewModel>(getAll));
        //    }
        //    return models.AsEnumerable();
        //}

        //public async Task<IEnumerable<UnderwrittingDetailViewModel>> GetAll(int page, int pageSize)
        //{
        //    IList<UnderwrittingDetailViewModel> models = new List<UnderwrittingDetailViewModel>();
        //    var getAllByPages = await GenericRepository.GetAll(page, pageSize);
        //    foreach (var getAllByPage in getAllByPages)
        //    {
        //        models.Add(mapper.Map<UnderwrittingDetail, UnderwrittingDetailViewModel>(getAllByPage));
        //    }
        //    return models.AsEnumerable();
        //}

        //public async Task<IEnumerable<UnderwrittingDetailViewModel>> GetAll(string include)
        //{
        //    IList<UnderwrittingDetailViewModel> models = new List<UnderwrittingDetailViewModel>();
        //    var getAllIncludes = await GenericRepository.GetAll();
        //    foreach (var getAllInclude in getAllIncludes)
        //    {
        //        models.Add(mapper.Map<UnderwrittingDetail, UnderwrittingDetailViewModel>(getAllInclude));
        //    }
        //    return models.AsEnumerable();
        //}

        //public async Task<UnderwrittingDetailViewModel> GetById(int id)
        //{
        //    var getId = await GenericRepository.GetById(id);
        //    var model = mapper.Map<UnderwrittingDetail, UnderwrittingDetailViewModel>(getId);
        //    return model;
        //}

        //public UnderwrittingDetailViewModel Create(UnderwrittingDetailViewModel model)
        //{
        //    var insertModel = mapper.Map<UnderwrittingDetailViewModel, UnderwrittingDetail>(model);
        //    var modelI = GenericRepository.Create(insertModel);
        //    return mapper.Map<UnderwrittingDetail, UnderwrittingDetailViewModel>(modelI);
        //}

        //public void Update(int id, UnderwrittingDetailViewModel model)
        //{
        //    var updateModel = mapper.Map<UnderwrittingDetailViewModel, UnderwrittingDetail>(model);
        //    GenericRepository.Update(id, updateModel);
        //}

        //public void Delete(int id)
        //{
        //    var deleteModel = Task.Run(() => GenericRepository.GetById(id)).Result;
        //    deleteModel.IsActive = false;
        //    deleteModel.IsDeleted = true;
        //    GenericRepository.Update(deleteModel.Id, deleteModel);
        //}

        //public async Task<IEnumerable<UnderwrittingDetailViewModel>> GetAllWithData(int LoggedInUserId)
        //{
        //    IList<UnderwrittingDetailViewModel> models = new List<UnderwrittingDetailViewModel>();
        //    var dbEntities = await GenericRepository.GetAll("pleaseAddFk");
        //    var dbEntity = dbEntities.FirstOrDefault(x => x.Id == LoggedInUserId);
        //    if (dbEntity != null)
        //    {
        //        var approvalGetAll = mapper.Map<UnderwrittingDetail, UnderwrittingDetailViewModel>(dbEntity);
        //        models.Add(approvalGetAll);
        //    }
        //    return models.AsEnumerable();
        //}

        //async Task<IEnumerable<UnderwrittingDetailViewModel>> IGenericService<UnderwrittingDetailViewModel>.GetByAny(int value)
        //{
        //    IList<UnderwrittingDetailViewModel> models = new List<UnderwrittingDetailViewModel>();
        //    var getByAnyIds = await GenericRepository.FindBy(x => x.FkLeadId == value);

        //    foreach (var getByAnyId in getByAnyIds)
        //    {
        //        models.Add(mapper.Map<UnderwrittingDetail, UnderwrittingDetailViewModel>(getByAnyId));
        //    }
        //    return models.AsEnumerable();
        //}
    }
}
