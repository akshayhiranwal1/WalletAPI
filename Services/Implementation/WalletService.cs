using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletAPI.Data.Management;
using WalletAPI.Database;
using WalletAPI.Repository;
using WalletAPI.Services.Generic;
using WalletAPI.Services.Interfaces;
using WalletAPI.ViewModels;

namespace WalletAPI.Services.Implementation
{
    public class WalletService<T>
        : IWalletService<WalletViewModel>, IGenericService<WalletViewModel>
    {

        private IGenericRepository<Wallet> GenericRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        //private readonly IDeviceValidationService deviceValidationService;

        /// <inheritdoc />
        public WalletService(
            IUnitOfWork unitOfWork,
            //IDeviceValidationService deviceValidationService,
            IMapper mapper, IGenericRepository<Wallet> genericRepository)
        {
            this.unitOfWork = unitOfWork;
            //this.deviceValidationService = deviceValidationService;
            this.mapper = mapper;
            GenericRepository = genericRepository;
        }

        async Task<IEnumerable<WalletViewModel>> IGenericService<WalletViewModel>.GetAll()
        {
            IList<WalletViewModel> models = new List<WalletViewModel>();
            var getAllgs = await GenericRepository.GetAll();
            foreach (var getAll in getAllgs)
            {
                models.Add(mapper.Map<Wallet, WalletViewModel>(getAll));
            }
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<WalletViewModel>> GetAll(int page, int pageSize)
        {
            IList<WalletViewModel> models = new List<WalletViewModel>();
            var getAllByPages = await GenericRepository.GetAll(page, pageSize);
            foreach (var getAllByPage in getAllByPages)
            {
                models.Add(mapper.Map<Wallet, WalletViewModel>(getAllByPage));
            }
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<WalletViewModel>> GetAll(string include)
        {
            IList<WalletViewModel> models = new List<WalletViewModel>();
            var getAllIncludes = await GenericRepository.GetAll();
            foreach (var getAllInclude in getAllIncludes)
            {
                models.Add(mapper.Map<Wallet, WalletViewModel>(getAllInclude));
            }
            return models.AsEnumerable();
        }

        public async Task<WalletViewModel> GetById(int id)
        {
            var getId = await GenericRepository.GetById(id);
            var model = mapper.Map<Wallet, WalletViewModel>(getId);
            return model;
        }

        public WalletViewModel Create(WalletViewModel model)
        {
            var insertModel = mapper.Map<WalletViewModel, Wallet>(model);
            var modelI = GenericRepository.Create(insertModel);
            return mapper.Map<Wallet, WalletViewModel>(modelI);
        }

        public void Update(int id, WalletViewModel model)
        {
            var updateModel = mapper.Map<WalletViewModel, Wallet>(model);
            GenericRepository.Update(id, updateModel);
        }

        public void Delete(int id)
        {
            var deleteModel = Task.Run(() => GenericRepository.GetById(id)).Result;
            GenericRepository.Update(deleteModel.Id, deleteModel);
        }

        public async Task<IEnumerable<WalletViewModel>> GetAllWithData(int LoggedInUserId)
        {
            IList<WalletViewModel> models = new List<WalletViewModel>();
            var dbEntities = await GenericRepository.GetAll("pleaseAddFk");
            var dbEntity = dbEntities.FirstOrDefault(x => x.Id == LoggedInUserId);
            if (dbEntity != null)
            {
                var approvalGetAll = mapper.Map<Wallet, WalletViewModel>(dbEntity);
                models.Add(approvalGetAll);
            }
            return models.AsEnumerable();
        }

        async Task<IEnumerable<WalletViewModel>> IGenericService<WalletViewModel>.GetByAny(int value)
        {
            IList<WalletViewModel> models = new List<WalletViewModel>();
            var getByAnyIds = await GenericRepository.FindBy(x => x.Id == value);

            foreach (var getByAnyId in getByAnyIds)
            {
                models.Add(mapper.Map<Wallet, WalletViewModel>(getByAnyId));
            }
            return models.AsEnumerable();
        }
    }
}