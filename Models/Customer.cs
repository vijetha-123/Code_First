using System.ComponentModel.DataAnnotations;

namespace codefirst.Models
{
    public class Customer
    {
        [Key]
        public int cust_ID{  get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [RegularExpression(@"^([A-Za-z]+)$")]
        public string cust_name{ get; set; }

        [Range(18, 25, ErrorMessage = "Enter age between 18 to 25")]
        public int cust_age{ get; set; }

        public DateTime d_order{ get; set; }

        public DateTime cust_dob{ get; set; }

        [DataType(DataType.PhoneNumber)]
        public string cust_mob { get; set; }

        [DataType(DataType.EmailAddress)]
        public string cust_mail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter the Password")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,12}$")]
        public string cust_pswd { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter the Confirm Password")]
        [Compare("cust_pswd", ErrorMessage = "Password does not match")]
        public string cust_confirmpswd { get; set; }

    }
}
