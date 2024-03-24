using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebAppDB.Entities;

namespace WebApp.Test
{
    public class ProductControllerTests
    {
        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int quantity, int id)
        {
            // Arrange
            var controller = new ProductController();

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
