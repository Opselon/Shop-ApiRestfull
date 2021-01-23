using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopApi.Models;

namespace EshopApi.Contracts
{
    public interface ICustomerRepository
    {

        #region My Task's 

        /// <summary>
        /// Get All Customers to IEnumerable Command
        /// </summary>
        /// <returns>Get All Customers information</returns>
        IEnumerable<Customer> GetAll();

        /// <summary>
        /// add a new customer into database Task Command
        /// </summary>
        /// <param name="customer">all of my customer filled fields</param>
        /// <returns></returns>
        Task<Customer> Add(Customer customer);

        /// <summary>
        /// Find Customer with a ID Task Command
        /// </summary>
        /// <param name="id">find specified customer by CustomerID</param>
        Task<Customer> Find(int id);

        /// <summary>
        /// Update specified Customer with 'customer' fields Task Command
        /// </summary>
        /// <param name="customer">its all of my customer information</param>
        /// <returns></returns>
        Task<Customer> Update(Customer customer);

        /// <summary>
        /// Remove a specified Customer with a ID Task Command
        /// </summary>
        /// <param name="id">find specified customer by CustomerID</param>
        Task<Customer> Remove(int id);

        /// <summary>
        /// check if my specified customer is in my database or not [ True means yes and False means no ] Command
        /// </summary>
        /// <param name="id">my specified customerID</param>
        /// <returns></returns>
        Task<bool> IsExists(int id);

        /// <summary>
        /// Count all the customers Task int Command
        /// </summary>
        /// <returns></returns>
        Task<int> CountCustomer();

        #endregion

    }
}