using AutoMapper;
using CoreWebApp.Business.Interfaces;
using CoreWebApp.Core.Common;
using CoreWebApp.Data.EntityModels;
using CoreWebApp.Model.Customer;
using CoreWebApp.Repository.BaseRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CoreWebApp.Business.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CoreWebApp.Business.Interfaces.ICustomerService" />
    public class CustomerService : ICustomerService
    {

        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;


        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Registers the customer.
        /// </summary>
        /// <param name="customerModel">The customer model.</param>
        /// <returns></returns>
        public ResponseModel RegisterCustomer(CustomerModel customerModel)
        {

            var model = new ResponseModel();
            var _temp = IsCustomerRegistered(customerModel.Email);
            if (_temp)
            {
                model.Messsage = "Customer already registered.";
                model.IsSuccess = false;
            }
            else
            {
                var customer = mapper.Map<Customer>(customerModel);
                unitOfWork.GetRepository<Customer>().Insert(customer);
                model.IsSuccess = true;
                model.Messsage = "Customer registration completed.";
            }
            unitOfWork.SaveChanges();

            return model;
        }


        /// <summary>
        /// Determines whether [is vehicle registered] [the specified identifier].
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns>
        ///   <c>true</c> if [is vehicle registered] [the specified identifier]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsCustomerRegistered(string Email)
        {
            var isExist = unitOfWork.GetRepository<Customer>().Get(x => x.Email.Contains(Email)).Any();

            if (isExist)
                return true;
            return false;
        }


        /// <summary>
        /// Gets the customer list.
        /// </summary>
        /// <returns></returns>
        public List<CustomerId> GetCustomerList()
        {
            return unitOfWork.GetRepository<Customer>().Get().Select(v => new CustomerId
            {
                Id = (int)v.CustomerId,
                Name = v.Name
            }).ToList(); ;
        }
    }
}
