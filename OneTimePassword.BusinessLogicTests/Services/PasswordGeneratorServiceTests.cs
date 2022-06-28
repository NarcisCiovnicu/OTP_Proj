using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneTimePassword.BusinessLogic.Models;
using OneTimePassword.BusinessLogic.Services;
using OneTimePassword.BusinessLogic.Validators;
using System;

namespace OneTimePassword.BusinessLogicTests.Services
{
    [TestClass]
    public class PasswordGeneratorServiceTests
    {
        [TestMethod]
        public void GetGeneratedPassword_Should_Return_Same_Password_for_the_same_user_requesting_in_less_then_30_seconds()
        {
            var validator = new UserOtpRequestValidator();
            var request1 = new UserOtpRequestModel
            {
                UserId = "user1",
                CurrentTime = DateTime.Now
            };
            var request2 = new UserOtpRequestModel
            {
                UserId = "user1",
                CurrentTime = DateTime.Now.AddSeconds(10)
            };

            var service = new PasswordGeneratorService(null, validator);

            var password1 = service.GetGeneratedPassword(request1);
            var password2 = service.GetGeneratedPassword(request2);

            Assert.AreEqual(password1.Password, password2.Password);
        }

        [TestMethod]
        public void GetGeneratedPassword_Should_Return_Different_Password_for_the_same_user_requesting_after_30_seconds()
        {
            var validator = new UserOtpRequestValidator();
            var request1 = new UserOtpRequestModel
            {
                UserId = "user1",
                CurrentTime = DateTime.Now
            };
            var request2 = new UserOtpRequestModel
            {
                UserId = "user1",
                CurrentTime = DateTime.Now.AddSeconds(40)
            };

            var service = new PasswordGeneratorService(null, validator);

            var password1 = service.GetGeneratedPassword(request1);
            var password2 = service.GetGeneratedPassword(request2);

            Assert.AreNotEqual(password1.Password, password2.Password);
        }

        [TestMethod]
        public void GetGeneratedPassword_Should_Return_Different_Password_for_different_users_requesting_in_less_than_30_seconds()
        {
            var validator = new UserOtpRequestValidator();
            var request1 = new UserOtpRequestModel
            {
                UserId = "user1",
                CurrentTime = DateTime.Now
            };
            var request2 = new UserOtpRequestModel
            {
                UserId = "user2",
                CurrentTime = DateTime.Now.AddSeconds(10)
            };

            var service = new PasswordGeneratorService(null, validator);

            var password1 = service.GetGeneratedPassword(request1);
            var password2 = service.GetGeneratedPassword(request2);

            Assert.AreNotEqual(password1.Password, password2.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetGeneratedPassword_Should_Throw_an_Exception_if_user_id_is_not_valid()
        {
            var validator = new UserOtpRequestValidator();
            var request1 = new UserOtpRequestModel
            {
                UserId = "",
                CurrentTime = DateTime.Now
            };

            var service = new PasswordGeneratorService(null, validator);

            var password1 = service.GetGeneratedPassword(request1);
        }
    }
}
