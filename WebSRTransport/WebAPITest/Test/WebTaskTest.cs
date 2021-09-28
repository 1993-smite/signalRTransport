using NUnit.Framework;
using WebAPI.Models;

namespace WebAPITest.Test
{
    [TestFixture]
    class WebTaskTest
    {
        [Test]
        public void NewWebTaskValidationTest()
        {
            var webTask = new WebTask()
            {
                Id = 0
            };
            var validation = new WebTaskValidation();
            var result = validation.Validate(webTask);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(result.Errors.Count, 2);
        }

        [Test]
        public void WebTaskValidationTest()
        {
            var webTask = new WebTask()
            {
                Id = 1
            };
            var validation = new WebTaskValidation();
            var result = validation.Validate(webTask);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(result.Errors.Count, 1);
        }
    }
}
