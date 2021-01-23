using EshopApi.Contracts;
using EShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace EShopApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {


        #region My Constructors

        private ICustomerRepository _customerRepository;

        private IMemoryCache _Cashe;

        public CustomersController(ICustomerRepository customerRepository )
        {
            _customerRepository = customerRepository;
        }


        /// <summary>
        /// its check if my specified customer is exists 
        /// </summary>
        /// <param name="id">this variable fill with customerID in database</param>
        /// <returns></returns>
        private Task<bool> CustomerExists(int id)
        {
            //returned the if my customer is exists my database then return true else return false
            return _customerRepository.IsExists(id);
        }


        #endregion

        #region Get Methods



        #region Get Customers

        /// <summary>
        /// expected get all of the customers
        /// </summary>
        /// <returns></returns>
        [HttpGet] // Read data from the cashe
        [ResponseCache(Duration = 60)] //this cashe method better to return images
        public IActionResult GetCustomer()
        {
            //Get all rows of my customer table and put it into resualt variable
            var result = new ObjectResult(_customerRepository.GetAll())
            {
                //An informational response indicates that the request was received and understood
                StatusCode = (int)HttpStatusCode.OK
            };

            //Count the number of customers to headers 
            Request.HttpContext.Response.Headers.Add("X-Count : ", _customerRepository.CountCustomer().ToString());


            //its returned resualt variable , mean make it done
            return result;
        }

        #endregion

        #region Get Customers By ID

        /// <summary>
        /// its return all of saved information the a row by CustomerID
        /// </summary>
        /// <param name="id">specified CustomerID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            //check if my Customer is exists in my database
            if (await CustomerExists(id))
            {
             
                //find specified where my Customer id and my int id is same
                var customer = await _customerRepository.Find(id);

                //The result has been successful
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }


        #endregion



        #endregion

        #region Post Methods


        #region Post Customer

        /// <summary>
        /// expecting to insert customer information to database
        /// </summary>
        /// <param name="customer">its a customer deatils as Customer</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {

            //If my adjectives that i make there in "Customer.Cs" like [Phone] & [Email] & Length
            //Are not is valid then...
            if (!ModelState.IsValid)
            {
                //return that error why its bad request
                return BadRequest("Error : " + ModelState);
            }



            //Add my customer to database with context
            await _customerRepository.Add(customer);


            //call the GetCustomer Action with ID push it to customer
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        #endregion


        #endregion

        #region Put Methods

        #region Put Customer | Update

        /// <summary>
        /// expecting to delete a customer from the database
        /// </summary>
        /// <param name="id">my specified person CustomerID Field</param>
        /// <param name="customer">its a customer deatils as Customer</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            //EF6:It mean i want change 'customer' state to new state that sended
            await _customerRepository.Update(customer);

           
            return Ok(customer);
        }

        #endregion


        #endregion

        #region Delete Methods

        #region Delete Customer

        /// <summary>
        /// expecting to delete a customer from the database
        /// </summary>
        /// <param name="id">my specified person CustomerID Field</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {

            //delete Customer from the database
            await _customerRepository.Remove(id);

            return Ok();
        }


        #endregion

        #endregion

    }
}
