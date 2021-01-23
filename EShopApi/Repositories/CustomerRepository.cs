using System;
using EshopApi.Contracts;
using EShopApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace EShopApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        #region My Constructors

        /// <summary>
        /// My Constructors
        /// </summary>
        private EShopApi_DbContext _context;

        /// <summary>
        /// Request the IMemoryCache instance in the constructor:
        /// </summary>
        private IMemoryCache _Cache;

        /// <summary>
        /// Gimme a repeted Context for using
        /// for dont repet open connecting
        /// </summary>
        /// <param name="context">My Context Parametr</param>
        /// <param name="cashe">My cashing parametr</param>
        public CustomerRepository(EShopApi_DbContext context, IMemoryCache Cache)
        {
            _context = context;
            _Cache = Cache;
        }



        #endregion

        #region My Add | Update | Delete Tasks

        #region Add

        /// <summary>
        /// expecting to add a new customer into my database [RepositoryBase]
        /// </summary>
        /// <param name="customer">My received customer</param>
        /// <returns></returns>
        public async Task<Customer> Add(Customer customer)
        {
            //Add a new customer asyc
            await _context.Customer.AddAsync(customer);

            //save new customer into database
            await _context.SaveChangesAsync();

            //fill the ID in database
            return customer;
        }


        #endregion

        #region Delete
        /// <summary>
        /// expecting to remove a specified customer from my database [RepositoryBase]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer> Remove(int id)
        {
            //EF:fill the customer variable with specified customer where my customerID is finded 
            var customer = await _context.Customer.SingleAsync(c => c.CustomerId == id);

            //Remove the customer with my variable "customer"
            _context.Customer.Remove(customer);

            //save anychanges into database
            await _context.SaveChangesAsync();
            return customer;
        }


        #endregion

        #region Update

        /// <summary>
        /// expecting to update a specified customer in my database
        /// </summary>
        /// <param name="customer">my recvied customer</param>
        /// <returns></returns>
        public async Task<Customer> Update(Customer customer)
        {

            //update recivied customer
            _context.Update(customer);

            //save anychanges in database
            await _context.SaveChangesAsync();
            return customer;
        }

        #endregion

        #endregion

        #region My Find | GetAll | Count Customer


        #region GetAll

        /// <summary>
        /// expecting to get all of customers method [RepositoryBase]
        /// </summary>
        /// <returns>list of customers</returns>
        public IEnumerable<Customer> GetAll()
        {
            //EF: Get List Of Customers
            return _context.Customer.ToList();
        }


        #endregion

        #region Find

        /// <summary>
        /// expecting to find a customer in my database [RepositoryBase]
        /// </summary>
        /// <param name="id">My recevied ID </param>
        /// <returns></returns>
        public async Task<Customer> Find(int id)
        {
            //make a variable and get Cache to fill it
            var CacheCustomer = _Cache.Get<Customer>(id);

            //check if my CacheCustomer is not null or is "fill"
            //in other option : check if CacheCustomer found my customer then
            if (CacheCustomer != null)
            {
                //then return the customer by id from the Cache
                return CacheCustomer;
            }
            //if not , then find customer from the database
            else
            {
                //EF:Find Customer by ID with him Orders | Query in the bank not Cache!
                var customer = await _context.Customer.Include(c => c.Orders).SingleOrDefaultAsync(c => c.CustomerId == id);

                //Keep in cache for this time, reset time if accessed.
                var CacheOption = new MemoryCacheEntryOptions().SetSlidingExpiration(new TimeSpan(60));

                // Save data in cache.
                _Cache.Set(customer.CustomerId,customer, CacheOption);
                return customer;
            }
        }


        #endregion

        #region Count

        /// <summary>
        /// expecting to Count all of Customers from my database [RepositoryBase]
        /// </summary>
        /// <returns>number of count customers</returns>
        public async Task<int> CountCustomer()
        {
            return await _context.Customer.CountAsync();
        }

        #endregion


        #endregion

        #region Logic Parts

        /// <summary>
        /// expecting to find a customer by 'CustomerID' [RepositoryBase]
        /// it will be true if any customer finded and it will be false if not
        /// </summary>
        /// <param name="id">my recvied ID</param>
        /// <returns></returns>
        public async Task<bool> IsExists(int id)
        {
            //check if my customer is in database? where customerID = recivied ID
            return await _context.Customer.AnyAsync(c => c.CustomerId == id);
        }

        #endregion

    }
}
