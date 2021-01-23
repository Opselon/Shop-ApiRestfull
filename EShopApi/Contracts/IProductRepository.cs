using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopApi.Models;

namespace EshopApi.Contracts
{
    public interface IProductRepository
    {
        #region Get All Products

        /// <summary>
        /// Get All Product to IEnumerable Command
        /// </summary>
        /// <returns></returns>
        IEnumerable<Products> GetAll();

        #endregion

        #region Add a new product

        /// <summary>
        /// add a new product into database Task Command
        /// </summary>
        /// <param name="product">all of my product filled fields</param>
        /// <returns></returns>
        Task<Products> Add(Products product);


        #endregion

        #region Find a product

        /// <summary>
        /// Find product with a ID Task Command
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Products> Find(int id);

        #endregion

        #region Update a product

        /// <summary>
        /// Update specified product with 'product' fields Task Command
        /// </summary>
        /// <param name="product">my recivied product</param>
        /// <returns></returns>
        Task<Products> Update(Products product);

        #endregion

        #region Remove a product

        /// <summary>
        /// Remove a specified Products with a ID Task Command
        /// </summary>
        /// <param name="id">my recived id</param>
        /// <returns></returns>
        Task<Products> Remove(int id);

        #endregion

        #region Check exists product

        /// <summary>
        /// check if my specified customer is in my database or not [ True means yes and False means no ] Command
        /// </summary>
        /// <param name="id">my reviced id</param>
        /// <returns></returns>
        Task<bool> IsExists(int id);

        #endregion

    }
}
