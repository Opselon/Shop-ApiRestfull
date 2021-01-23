using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopApi.Models;

namespace EshopApi.Contracts
{
    public interface ISalesPersonsRepository
    {

        #region Get all SalesPerson

        /// <summary>
        /// Get All SalesPerson to IEnumerable Command
        /// </summary>
        /// <returns></returns>
        IEnumerable<SalesPerson> GetAll();

        #endregion

        #region Add a new SalesPerson

        /// <summary>
        /// add a new SalesPerson into database Task Command
        /// </summary>
        /// <param name="sales">all of my SalesPerson filled fields</param>
        /// <returns></returns>
        Task<SalesPerson> Add(SalesPerson sales);

        #endregion

        #region Find a Sales Person

        /// <summary>
        /// Find SalesPerson with a ID Task Command
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SalesPerson> Find(int id);

        #endregion

        #region Update a SalesPerson

        /// <summary>
        /// Update specified SalesPerson with 'SalesPerson' fields Task Command
        /// </summary>
        /// <param name="Sales">my recivied SalesPerson</param>
        /// <returns></returns>
        Task<SalesPerson> Update(SalesPerson sales);

        #endregion

        #region Remove a SalesPerson

        /// <summary>
        /// Remove a specified SalesPersons with a ID Task Command
        /// </summary>
        /// <param name="id">my recived id</param>
        /// <returns></returns>
        Task<SalesPerson> Remove(int id);


        #endregion

        #region Check exists SalesPerson

        /// <summary>
        /// check if my specified customer is in my database or not [ True means yes and False means no ] Command
        /// </summary>
        /// <param name="id">my reviced id</param>
        /// <returns></returns>
        Task<bool> IsExists(int id);

        #endregion

    }
}
