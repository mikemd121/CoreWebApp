using AutoMapper;
using CoreWebApp.Business.Interfaces;
using CoreWebApp.Core.Common;
using CoreWebApp.Data.BaseOperation;
using CoreWebApp.Data.EntityModels;
using CoreWebApp.Model.Property;
using CoreWebApp.Model.SalesViewModel;
using CoreWebApp.Repository.BaseRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Business.Implementations
{
    public class SalesService : ISalesService
    {

        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public SalesService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Sells the property.
        /// </summary>
        /// <param name="salesModel">The sales model.</param>
        /// <returns></returns>
        public ResponseModel SellProperty(SalesModel salesModel)
        {
            var model = new ResponseModel();
            var _temp = IsPropertySold(salesModel);
            if (_temp)
            {
                model.Messsage = "Property already sold.";
                model.IsSuccess = false;
            }
            else {
                var sale = mapper.Map<Sale>(salesModel);
                unitOfWork.GetRepository<Sale>().Insert(sale);
                model.IsSuccess = true;
                model.Messsage = "Property sold.";
            }
            unitOfWork.SaveChanges();
            return model;
        }

        /// <summary>
        /// Gets the sold property list.
        /// </summary>
        /// <returns></returns>
        public List<PropertyModel> GetSoldPropertyList()
        {
            const string includedEntities =
               "Customer,Property";
            var saleList = unitOfWork.GetRepository<Sale>().Get(includeProperties: includedEntities).ToList();

            var salesPropertyList = mapper.Map<List<PropertyModel>>(saleList);
            return salesPropertyList;
        }

        /// <summary>
        /// Determines whether [is property sold] [the specified sales model].
        /// </summary>
        /// <param name="salesModel">The sales model.</param>
        /// <returns>
        ///   <c>true</c> if [is property sold] [the specified sales model]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPropertySold(SalesModel salesModel)
        {
            var isExist = unitOfWork.GetRepository<Sale>().Get(x => x.Property.PropertyId==salesModel.PropertyId).Any();
            if (isExist)
                return true;
            return false;
        }
    }
}
