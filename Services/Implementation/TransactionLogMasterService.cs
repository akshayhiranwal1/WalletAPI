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
    public class TransactionLogMasterService<T>
        : ITransactionLogMasterService<TransactionLogMasterViewModel>, IGenericService<TransactionLogMasterViewModel>
    {

        private IGenericRepository<TransactionLogMaster> GenericRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private IGenericRepository<Wallet> WalletRepository;
        //private readonly IDeviceValidationService deviceValidationService;

        /// <inheritdoc />
        public TransactionLogMasterService(
            IUnitOfWork unitOfWork, IGenericRepository<Wallet> walletRepository,
        IMapper mapper, IGenericRepository<TransactionLogMaster> genericRepository)
        {
            this.unitOfWork = unitOfWork;
            //this.deviceValidationService = deviceValidationService;
            this.mapper = mapper;
            GenericRepository = genericRepository;
            WalletRepository = walletRepository;
        }

        async Task<IEnumerable<TransactionLogMasterViewModel>> IGenericService<TransactionLogMasterViewModel>.GetAll()
        {
            IList<TransactionLogMasterViewModel> models = new List<TransactionLogMasterViewModel>();
            var getAllgs = await GenericRepository.GetAll();
            foreach (var getAll in getAllgs)
            {
                models.Add(mapper.Map<TransactionLogMaster, TransactionLogMasterViewModel>(getAll));
            }
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<TransactionLogMasterViewModel>> GetAll(int page, int pageSize)
        {
            IList<TransactionLogMasterViewModel> models = new List<TransactionLogMasterViewModel>();
            var getAllByPages = await GenericRepository.GetAll(page, pageSize);
            foreach (var getAllByPage in getAllByPages)
            {
                models.Add(mapper.Map<TransactionLogMaster, TransactionLogMasterViewModel>(getAllByPage));
            }
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<TransactionLogMasterViewModel>> GetAll(string include)
        {
            IList<TransactionLogMasterViewModel> models = new List<TransactionLogMasterViewModel>();
            var getAllIncludes = await GenericRepository.GetAll();
            foreach (var getAllInclude in getAllIncludes)
            {
                models.Add(mapper.Map<TransactionLogMaster, TransactionLogMasterViewModel>(getAllInclude));
            }
            return models.AsEnumerable();
        }

        public async Task<TransactionLogMasterViewModel> GetById(int id)
        {
            var getId = await GenericRepository.GetById(id);
            var model = mapper.Map<TransactionLogMaster, TransactionLogMasterViewModel>(getId);
            return model;
        }

        public TransactionLogMasterViewModel Create(TransactionLogMasterViewModel model)
        {
            var walletDetails = WalletRepository.GetById(model.WalletId.Value).Result;
            if (walletDetails == null)
                return new TransactionLogMasterViewModel() { Description = "Invalid Wallet" };

            if (walletDetails.Amount < model.Amount)
                return new TransactionLogMasterViewModel() { Description = "Wallet does not have sufficient balance." };

            var insertModel = mapper.Map<TransactionLogMasterViewModel, TransactionLogMaster>(model);
            var modelI = GenericRepository.Create(insertModel);
            walletDetails.Amount = walletDetails.Amount - modelI.Amount;
            WalletRepository.Update(walletDetails.Id, walletDetails);
            return mapper.Map<TransactionLogMaster, TransactionLogMasterViewModel>(modelI);
        }

        public void Update(int id, TransactionLogMasterViewModel model)
        {
            var updateModel = mapper.Map<TransactionLogMasterViewModel, TransactionLogMaster>(model);
            GenericRepository.Update(id, updateModel);
        }

        public void Delete(int id)
        {
            var deleteModel = Task.Run(() => GenericRepository.GetById(id)).Result;
            GenericRepository.Update(deleteModel.Id, deleteModel);
        }

        public async Task<IEnumerable<TransactionLogMasterViewModel>> GetAllWithData(int LoggedInUserId)
        {
            IList<TransactionLogMasterViewModel> models = new List<TransactionLogMasterViewModel>();
            var dbEntities = await GenericRepository.GetAll("pleaseAddFk");
            var dbEntity = dbEntities.FirstOrDefault(x => x.Id == LoggedInUserId);
            if (dbEntity != null)
            {
                var approvalGetAll = mapper.Map<TransactionLogMaster, TransactionLogMasterViewModel>(dbEntity);
                models.Add(approvalGetAll);
            }
            return models.AsEnumerable();
        }

        async Task<IEnumerable<TransactionLogMasterViewModel>> IGenericService<TransactionLogMasterViewModel>.GetByAny(int value)
        {
            IList<TransactionLogMasterViewModel> models = new List<TransactionLogMasterViewModel>();
            var getByAnyIds = await GenericRepository.FindBy(x => x.Id == value);

            foreach (var getByAnyId in getByAnyIds)
            {
                models.Add(mapper.Map<TransactionLogMaster, TransactionLogMasterViewModel>(getByAnyId));
            }
            return models.AsEnumerable();
        }
    }
}