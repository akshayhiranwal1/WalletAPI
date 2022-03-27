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
    public class PaymentMasterService<T> : IPaymentMasterService<PaymentMasterViewModel>, IGenericService<PaymentMasterViewModel>
    {

        private IGenericRepository<PaymentMaster> GenericRepository;
        private IGenericRepository<TransactionLogMaster> TransactionRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        /// <inheritdoc />
        public PaymentMasterService(
            IUnitOfWork unitOfWork,
             IGenericRepository<TransactionLogMaster> transactionRepository,
            IMapper mapper, IGenericRepository<PaymentMaster> genericRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            GenericRepository = genericRepository;
            TransactionRepository = transactionRepository;
        }

        async Task<IEnumerable<PaymentMasterViewModel>> IGenericService<PaymentMasterViewModel>.GetAll()
        {
            IList<PaymentMasterViewModel> models = new List<PaymentMasterViewModel>();
            var getAllgs = await GenericRepository.GetAll();
            foreach (var getAll in getAllgs)
            {
                models.Add(mapper.Map<PaymentMaster, PaymentMasterViewModel>(getAll));
            }
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<PaymentMasterViewModel>> GetAll(int page, int pageSize)
        {
            IList<PaymentMasterViewModel> models = new List<PaymentMasterViewModel>();
            var getAllByPages = await GenericRepository.GetAll(page, pageSize);
            foreach (var getAllByPage in getAllByPages)
            {
                models.Add(mapper.Map<PaymentMaster, PaymentMasterViewModel>(getAllByPage));
            }
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<PaymentMasterViewModel>> GetAll(string include)
        {
            IList<PaymentMasterViewModel> models = new List<PaymentMasterViewModel>();
            var getAllIncludes = await GenericRepository.GetAll();
            foreach (var getAllInclude in getAllIncludes)
            {
                models.Add(mapper.Map<PaymentMaster, PaymentMasterViewModel>(getAllInclude));
            }
            return models.AsEnumerable();
        }

        public async Task<PaymentMasterViewModel> GetById(int id)
        {
            var getId = await GenericRepository.GetById(id);
            var model = mapper.Map<PaymentMaster, PaymentMasterViewModel>(getId);
            return model;
        }

        public PaymentMasterViewModel Create(PaymentMasterViewModel model)
        {
            var insertModel = mapper.Map<PaymentMasterViewModel, PaymentMaster>(model);
            var modelI = GenericRepository.Create(insertModel);
            return mapper.Map<PaymentMaster, PaymentMasterViewModel>(modelI);
        }

        public void Update(int id, PaymentMasterViewModel model)
        {
            var updateModel = mapper.Map<PaymentMasterViewModel, PaymentMaster>(model);
            GenericRepository.Update(id, updateModel);
        }

        public void Delete(int id)
        {
            var deleteModel = Task.Run(() => GenericRepository.GetById(id)).Result;
            GenericRepository.Update(deleteModel.Id, deleteModel);
        }

        public async Task<IEnumerable<PaymentMasterViewModel>> GetAllWithData(int LoggedInUserId)
        {
            IList<PaymentMasterViewModel> models = new List<PaymentMasterViewModel>();
            var dbEntities = await GenericRepository.GetAll("pleaseAddFk");
            var dbEntity = dbEntities.FirstOrDefault(x => x.Id == LoggedInUserId);
            if (dbEntity != null)
            {
                var approvalGetAll = mapper.Map<PaymentMaster, PaymentMasterViewModel>(dbEntity);
                models.Add(approvalGetAll);
            }
            return models.AsEnumerable();
        }

        async Task<IEnumerable<PaymentMasterViewModel>> IGenericService<PaymentMasterViewModel>.GetByAny(int value)
        {
            IList<PaymentMasterViewModel> models = new List<PaymentMasterViewModel>();
            var getByAnyIds = await GenericRepository.FindBy(x => x.Id == value);

            foreach (var getByAnyId in getByAnyIds)
            {
                models.Add(mapper.Map<PaymentMaster, PaymentMasterViewModel>(getByAnyId));
            }
            return models.AsEnumerable();
        }
    }
}