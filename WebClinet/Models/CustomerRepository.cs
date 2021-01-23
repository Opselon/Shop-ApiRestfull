using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace WebClinet.Models
{
    public class CustomerRepository
    {
        #region My Constractur

        //My Api Url in my string to use
#warning localhost:44363 should the domain name in reality project
        private string ApiUrl = "https://localhost:44363/api/customers";

        //make http clinet to
        private HttpClient _client;


        /// <summary>
        /// customerRepository to a new one 
        /// </summary>
        public CustomerRepository()
        {
            _client = new HttpClient();
        }


        #endregion


        public List<Customer> GetAllCustomer()
        {
            //Get customers list in JSON string
            var result = _client.GetStringAsync(ApiUrl).Result;
            List<Customer> list = JsonConvert.DeserializeObject<List<Customer>>(result);
            return list;
        }

        public Customer GetCustomerByID(int customerID)
        {
            var result = _client.GetStringAsync(ApiUrl + "/" + customerID).Result;
            Customer customer = JsonConvert.DeserializeObject<Customer>(result);
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            string JsonCustomer = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(JsonCustomer, Encoding.UTF8, "application/json");
            var res = _client.PostAsync(ApiUrl, content).Result;
        }

        public void UpdateCustomer(Customer customer)
        {
            string JsonCustomer = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(JsonCustomer, Encoding.UTF8, "application/json");
            var res = _client.PutAsync(ApiUrl, content).Result;
        }

        public void DeleteCustomer(int CustomerID)
        {
            var res = _client.DeleteAsync(ApiUrl + "/" + CustomerID).Result;
        }

        #region Row of table Customer

        public class Customer
        {
            /// <summary>
            /// its field of "CustomerID" in my database table 'Customer'
            /// </summary>
            public int CustomerId { get; set; }
            /// <summary>
            /// its field of "FirstName" in my database table 'Customer'
            /// </summary>
            [Required(ErrorMessage = "Enter FirstName")] // The Error Massege
            [StringLength(50)] // set Length to 50
            public string FirstName { get; set; }
            /// <summary>
            /// its field of "LastNameName" in my database table 'Customer'
            /// </summary>
            [Required] // The Error Massege
            [StringLength(50)] // set Length to 50
            public string LastName { get; set; }
            /// <summary>
            /// its field of "Email" in my database table 'Customer'
            /// </summary>
            [EmailAddress]
            public string Email { get; set; }
            /// <summary>
            /// its field of "Phone" in my database table 'Customer'
            /// </summary>
            [Phone]
            public string Phone { get; set; }
            /// <summary>
            /// its field of "Address" in my database table 'Customer'
            /// </summary>
            public string Address { get; set; }
            /// <summary>
            /// its field of "City" in my database table 'Customer'
            /// </summary>
            public string City { get; set; }
            /// <summary>
            /// its field of "State" in my database table 'Customer'
            /// </summary>
            public string State { get; set; }
            /// <summary>
            /// its field of "ZipCode" in my database table 'Customer'
            /// </summary>
            public string ZipCode { get; set; }

            #endregion

        }


    }
}
