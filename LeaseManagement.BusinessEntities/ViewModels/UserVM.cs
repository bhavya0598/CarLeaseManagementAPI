namespace LeaseManagement.BusinessEntities.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserVM
    {
        [Key]
        public Guid UserId { get; set; }

        [EmailAddress(ErrorMessage ="Invalid Email!")]
        [MaxLength(50, ErrorMessage = "Characters must be less than 50")]
        public string Email { get; set; }

        //[RegularExpression("^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{7,15}$", ErrorMessage = "Atleast 1 special character, 1 number and length 7-15")]
        public string Password { get; set; }
        
        [MaxLength(50, ErrorMessage = "Characters must be less than 50")]
        public string Username { get; set; }
        public string ActivationCode { get; set; }
        public bool IsVerified { get; set; }
    }
}
