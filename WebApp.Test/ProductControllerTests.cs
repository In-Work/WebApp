using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebAppDB.Entities;
using Moq;

namespace WebApp.Test
{
    public class ProductControllerTests
    {
        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int quantity, int id)
        {  
            // Arrange
            var controllerContext = new ControllerContext();
            var moqHttpContext = new Mock<HttpContext>();

            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;

            var controller = new ProductController()
            { 
                ControllerContext = controllerContext 
            };

            controller._dishes = TestData.GetDishesList();

            // Act
            var result = controller.Index(pageNo: page, group: null) as ViewResult;
            var model = result?.Model as List<Dish>;

            // Assert
            Assert.NotNull(model);
            Assert.Equal(quantity, model.Count);
            Assert.Equal(id, model[0].DishId);
        }
    }
}
