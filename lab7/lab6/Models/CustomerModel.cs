using cross_lab5.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace cross_lab5.Models
{
    public class CustomerModel
    {
        public int CustomerIdToSearch { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
