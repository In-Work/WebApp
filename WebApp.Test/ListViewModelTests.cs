using WebApp.Models;
using WebAppDB.Entities;

namespace WebApp.Test
{
    public class ListViewModelTests
    {
        [Fact]
        public void ListViewModelCountsPages()
        {
            // Act
            var model = ListViewModel<Dish>.GetModel(TestData.GetDishesList(), 1, 3);

            // Assert
            Assert.Equal(2, model.TotalPages);
        }

        [Theory]
        [MemberData(memberName: nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ListViewModelSelectsCorrectQty(int page, int quantity, int id)
        {
            // Act
            var model = ListViewModel<Dish>.GetModel(TestData.GetDishesList(), page, 3);
            
            // Assert
            Assert.Equal(quantity, model.Count);
        }

        [Theory]
        [MemberData(memberName: nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ListViewModelHasCorrectData(int page, int quantity, int id)
        {
            // Act
            var model = ListViewModel<Dish>.GetModel(TestData.GetDishesList(), page, 3);

            // Assert
            Assert.Equal(id, model[0].DishId);
        }
    }
}
