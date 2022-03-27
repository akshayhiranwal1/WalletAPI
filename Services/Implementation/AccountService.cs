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
using WalletAPI.Database;

namespace WalletAPI.Services.Implementation
{
    public class AccountService<T>
        : IAccountService<AccountViewModel>, IGenericService<AccountViewModel>
    {

        private IGenericRepository<Account> GenericRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        //private readonly IDeviceValidationService deviceValidationService;

        /// <inheritdoc />
        public AccountService(
            IUnitOfWork unitOfWork,
            //IDeviceValidationService deviceValidationService,
            IMapper mapper, IGenericRepository<Account> genericRepository)
        {
            this.unitOfWork = unitOfWork;
            //this.deviceValidationService = deviceValidationService;
            this.mapper = mapper;
            GenericRepository = genericRepository;
        }

        async Task<IEnumerable<AccountViewModel>> IGenericService<AccountViewModel>.GetAll()
        {
            IList<AccountViewModel> models = new List<AccountViewModel>();
            var getAllgs = await GenericRepository.GetAll();
            foreach (var getAll in getAllgs)
            {
                models.Add(mapper.Map<Account, AccountViewModel>(getAll));
            }
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<AccountViewModel>> GetAll(int page, int pageSize)
        {
            IList<AccountViewModel> models = new List<AccountViewModel>();
            var getAllByPages = await GenericRepository.GetAll(page, pageSize);
            foreach (var getAllByPage in getAllByPages)
            {
                models.Add(mapper.Map<Account, AccountViewModel>(getAllByPage));
            }
            return models.AsEnumerable();
        }

        public async Task<IEnumerable<AccountViewModel>> GetAll(string include)
        {
            IList<AccountViewModel> models = new List<AccountViewModel>();
            var getAllIncludes = await GenericRepository.GetAll();
            foreach (var getAllInclude in getAllIncludes)
            {
                models.Add(mapper.Map<Account, AccountViewModel>(getAllInclude));
            }
            return models.AsEnumerable();
        }

        public async Task<AccountViewModel> GetById(int id)
        {
            var getId = await GenericRepository.GetById(id);
            var model = mapper.Map<Account, AccountViewModel>(getId);
            return model;
        }

        public AccountViewModel Create(AccountViewModel model)
        {
            var insertModel = mapper.Map<AccountViewModel, Account>(model);
            var modelI = GenericRepository.Create(insertModel);
            return mapper.Map<Account, AccountViewModel>(modelI);
        }

        public void Update(int id, AccountViewModel model)
        {
            var updateModel = mapper.Map<AccountViewModel, Account>(model);
            GenericRepository.Update(id, updateModel);
        }

        public void Delete(int id)
        {
            var deleteModel = Task.Run(() => GenericRepository.GetById(id)).Result;
            GenericRepository.Update(deleteModel.Id, deleteModel);
        }

        public async Task<IEnumerable<AccountViewModel>> GetAllWithData(int LoggedInUserId)
        {
            IList<AccountViewModel> models = new List<AccountViewModel>();
            var dbEntities = await GenericRepository.GetAll("pleaseAddFk");
            var dbEntity = dbEntities.FirstOrDefault(x => x.Id == LoggedInUserId);
            if (dbEntity != null)
            {
                var approvalGetAll = mapper.Map<Account, AccountViewModel>(dbEntity);
                models.Add(approvalGetAll);
            }
            return models.AsEnumerable();
        }

        async Task<IEnumerable<AccountViewModel>> IGenericService<AccountViewModel>.GetByAny(int value)
        {
            IList<AccountViewModel> models = new List<AccountViewModel>();
            var getByAnyIds = await GenericRepository.FindBy(x => x.Id == value);

            foreach (var getByAnyId in getByAnyIds)
            {
                models.Add(mapper.Map<Account, AccountViewModel>(getByAnyId));
            }
            return models.AsEnumerable();
        }
    }
}
