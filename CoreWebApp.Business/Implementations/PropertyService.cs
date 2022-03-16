using AutoMapper;
using CoreWebApp.Business.Interfaces;
using CoreWebApp.Core.Common;
using CoreWebApp.Data.EntityModels;
using CoreWebApp.Model.Property;
using CoreWebApp.Repository.BaseRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CoreWebApp.Business.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CoreWebApp.Business.Interfaces.IPropertyService" />
    public class PropertyService : IPropertyService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;


        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public PropertyService(
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this._unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Registers the vehicle.
        /// </summary>
        /// <param name="vehicleModel">The vehicle model.</param>
        /// <returns></returns>
        public ResponseModel RegisterProperty(PropertyModel propertyModel)
        {
            var model = new ResponseModel();
            var _temp = IsPropertyRegistered(propertyModel.PropertyNo);
            if (_temp)
            {
                model.Messsage = "Property already registered.";
                model.IsSuccess = false;
            }
            else
            {
                var property = mapper.Map<Property>(propertyModel);
                _unitOfWork.GetRepository<Property>().Insert(property);
                model.IsSuccess = true;
                model.Messsage = "Property registration completed.";
            }
            _unitOfWork.SaveChanges();
            return model;
        }

        /// <summary>
        /// Determines whether [is vehicle registered] [the specified identifier].
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="propertyNo">The vehicle identifier.</param>
        /// <returns>
        ///   <c>true</c> if [is vehicle registered] [the specified identifier]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPropertyRegistered(string propertyNo)
        {
            var isExist = _unitOfWork.GetRepository<Property>().Get()
           .Where(b => b.PropertyNo == propertyNo)
           .Any();

            if (isExist)
                return true;
            return false;
        }

        /// <summary>
        /// Gets the available custom domains.
        /// </summary>
        /// <param name="webstoreId">The webstore identifier.</param>
        /// <returns>Domain list.</returns>
        public List<Property> GetAvailablePropertyByCustomerId(int customerId)
        {
            var list = _unitOfWork.GetRepository<Property>().Get(x => x.CustomerId != customerId).ToList();
            return list;
        }
    }
}
