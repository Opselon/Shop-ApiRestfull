using EshopApi.Contracts;
using EShopApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region My Constructors
        /// <summary>
        /// My Constructors
        /// </summary>
        private EShopApi_DbContext _context;

        /// <summary>
        /// Gimme a repeted Context for using
        /// for dont repet open connecting
        /// </summary>
        /// <param name="context">My Context Parametr</param>
        public ProductRepository(EShopApi_DbContext context)
        {
            _context = context;
        }
        #endregion

        #region My Add | Update | Delete Tasks

        #region Add

        /// <summary>
        /// expecting to add a new Product into my database [RepositoryBase]
        /// </summary>
        /// <param name="Product">My received Product</param>
        /// <returns></returns>
        public async Task<Products> Add(Products Product)
        {
            //Add a new Product asyc
            await _context.Products.AddAsync(Product);

            //save new Product into database
            await _context.SaveChangesAsync();

            //fill the ID in database
            return Product;
        }


        #endregion

        #region Delete
        /// <summary>
        /// expecting to remove a specified Product from my database [RepositoryBase]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Products> Remove(int id)
        {
            //EF:fill the Product variable with specified Product where my ProductID is finded 
            var Product = await _context.Products.SingleAsync(c => c.ProductId == id);

            //Remove the Product with my variable "Product"
            _context.Products.Remove(Product);

            //save anychanges into database
            await _context.SaveChangesAsync();
            return Product;
        }


        #endregion

        #region Update

        /// <summary>
        /// expecting to update a specified Product in my database
        /// </summary>
        /// <param name="Product">my recvied Product</param>
        /// <returns></returns>
        public async Task<Products> Update(Products Product)
        {

            //update recivied Product
            _context.Update(Product);

            //save anychanges in database
            await _context.SaveChangesAsync();
            return Product;
        }

        #endregion

        #endregion

        #region My Find | GetAll | Count Product


        #region GetAll

        /// <summary>
        /// expecting to get all of Products method [RepositoryBase]
        /// </summary>
        /// <returns>list of Products</returns>
        public IEnumerable<Products> GetAll()
        {
            //EF: Get List Of Products
            return _context.Products.ToList();
        }


        #endregion

        #region Find

        /// <summary>
        /// expecting to find a Product in my database [RepositoryBase]
        /// </summary>
        /// <param name="id">My recevied ID </param>
        /// <returns></returns>
        public async Task<Products> Find(int id)
        {

            return await _context.Products.SingleOrDefaultAsync(c => c.ProductId == id);
        }


        #endregion

        #region Count

        /// <summary>
        /// expecting to Count all of Products from my database [RepositoryBase]
        /// </summary>
        /// <returns>number of count Products</returns>
        public async Task<int> CountProduct()
        {
            return await _context.Products.CountAsync();
        }

        #endregion


        #endregion

        #region Logic Parts

        /// <summary>
        /// expecting to find a Product by 'ProductID' [RepositoryBase]
        /// it will be true if any Product finded and it will be false if not
        /// </summary>
        /// <param name="id">my recvied ID</param>
        /// <returns></returns>
        public async Task<bool> IsExists(int id)
        {
            //check if my Product is in database? where ProductID = recivied ID
            return await _context.Products.AnyAsync(c => c.ProductId == id);
        }

        #endregion

    }
}
