using System;
using Xunit;
using EmployeeLog;
using EmployeeLog.Controllers;
using EmployeeLog.Data;

namespace Xunit_testing
{
    public class GivenUserWhenSettingAPassword
    {
        [Fact]
        public void ThenThePasswordMustBe8OrMoreCharacters()
        {
            //Setup // Arrange  -  initializes objects and set values
            string passwordLength = "qwefggthbdfb";

            //Subject // Act - this is the class youre testing and calling method
            var actValidate = new PasswordValidator();
            var result = actValidate.IsValid(passwordLength);

            //Assert - Check the thing!
            Assert.True(result);
        }
        [Fact]
        public void ThenThePasswordIsLessThane8OrMoreCharacters()
        {
            // Arrange  
            string passwordLength = "qwefgg";

            // Act 
            var actValidate = new PasswordValidator();
            var result = actValidate.IsValid(passwordLength);

            //Assert
            Assert.False(result);
        }

        //Do another test for this method.
        [Fact]
        public void ThenPasswordMustHaveUpper()
        {
            //Act
            string UpperCase = "Uyhfeesd";

            //Arrange
            var actUpper = new PasswordValidator();
            var result = actUpper.IsUpperCase(UpperCase);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ThenPasswordDoesNotHaveUpper()
        {
            //Act
            string UpperCase = "jyhfeesd";

            //Arrange
            var actUpper = new PasswordValidator();
            var result = actUpper.IsUpperCase(UpperCase);

            //Assert
            Assert.False(result);
        }
    }
}
