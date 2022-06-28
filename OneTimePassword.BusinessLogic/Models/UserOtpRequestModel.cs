using System;

namespace OneTimePassword.BusinessLogic.Models
{
    public class UserOtpRequestModel
    {
        public String UserId { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}
