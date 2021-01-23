using EshopApi.Contracts;
using EShopApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopApi.Repositories
{
    public class SalesPersonsRepository : ISalesPersonsRepository
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
        public SalesPersonsRepository(EShopApi_DbContext context)
        {
            _context = context;
        }
        #endregion

        #region My Add | Update | Delete Tasks

        #region Add

        /// <summary>
        /// expecting to add a new SalesPerson into my database [RepositoryBase]
        /// </summary>
        /// <param name="SalesPerson">My received SalesPerson</param>
        /// <returns></returns>
        public async Task<SalesPerson> Add(SalesPerson SalesPerson)
        {
            //Add a new SalesPerson asyc
            await _context.SalesPerson.AddAsync(SalesPerson);

            //save new SalesPerson into database
            await _context.SaveChangesAsync();

            //fill the ID in database
            return SalesPerson;
        }


        #endregion

        #region Delete
        /// <summary>
        /// expecting to remove a specified SalesPerson from my database [RepositoryBase]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SalesPerson> Remove(int id)
        {
            //EF:fill the SalesPerson variable with specified SalesPerson where my SalesPersonID is finded 
            var SalesPerson = await _context.SalesPerson.SingleAsync(c => c.SalesPersonalid == id);

            //Remove the SalesPerson with my variable "SalesPerson"
            _context.SalesPerson.Remove(SalesPerson);

            //save anychanges into database
            await _context.SaveChangesAsync();
            return SalesPerson;
        }


        #endregion

        #region Update

        /// <summary>
        /// expecting to update a specified SalesPerson in my database
        /// </summary>
        /// <param name="SalesPerson">my recvied SalesPerson</param>
        /// <returns></returns>
        public async Task<SalesPerson> Update(SalesPerson SalesPerson)
        {

            //update recivied SalesPerson
            _context.Update(SalesPerson);

            //save anychanges in database
            await _context.SaveChangesAsync();
            return SalesPerson;
        }

        #endregion

        #endregion

        #region My Find | GetAll | Count SalesPerson


        #region GetAll

        /// <summary>
        /// expecting to get all of SalesPerson method [RepositoryBase]
        /// </summary>
        /// <returns>list of SalesPerson</returns>
        public IEnumerable<SalesPerson> GetAll()
        {
            //EF: Get List Of SalesPerson
            return _context.SalesPerson.ToList();
        }


        #endregion

        #region Find

        /// <summary>
        /// expecting to find a SalesPerson in my database [RepositoryBase]
        /// </summary>
        /// <param name="id">My recevied ID </param>
        /// <returns></returns>
        public async Task<SalesPerson> Find(int id)
        {
            //EF:Find SalesPerson by ID with him Orders
            return await _context.SalesPerson.SingleOrDefaultAsync(s => s.SalesPersonalid == id);
        }


        #endregion

        #region Count

        /// <summary>
        /// expecting to Count all of SalesPerson from my database [RepositoryBase]
        /// </summary>
        /// <returns>number of count SalesPerson</returns>
        public async Task<int> CountSalesPerson()
        {
            return await _context.SalesPerson.CountAsync();
        }

        #endregion


        #endregion

        #region Logic Parts

        /// <summary>
        /// expecting to find a SalesPerson by 'SalesPersonID' [RepositoryBase]
        /// it will be true if any SalesPerson finded and it will be false if not
        /// </summary>
        /// <param name="id">my recvied ID</param>
        /// <returns></returns>
        public async Task<bool> IsExists(int id)
        {
            //check if my SalesPerson is in database? where SalesPersonID = recivied ID
            return await _context.SalesPerson.AnyAsync(c => c.SalesPersonalid == id);
        }

        #endregion

    }
}
