using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShopApi.Models
{
    public partial class Customer
    {
        #region My Constructors
        /// <summary>
        ///My Constructors
        /// </summary>
        public Customer()
        {
            Orders = new HashSet<Orders>();
        }

        #endregion

        #region Row of table Customer

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
        /// its field of "City" in my database table 'Customer'
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// its field of "ZipCode" in my database table 'Customer'
        /// </summary>
        public string ZipCode { get; set; }

        #endregion

        #region Rel-Connectings

        /// <summary>
        /// my relentshieps
        /// </summary>
        public ICollection<Orders> Orders { get; set; }

        #endregion

    }
}
