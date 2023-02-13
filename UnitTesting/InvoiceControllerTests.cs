using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Entities;
using WebApplication1.Service.IService;

namespace UnitTesting
{
    public class InvoiceControllerTests
    {
        //[Fact]
        //public async void Task_Add_ValidData_Return_OkResult()
        //{
        //    //Arrange
        //    var controller = new PostController(repository);
        //    var post = new Post() { Title = "Test Title 3", Description = "Test Description 3", CategoryId = 2, CreatedDate = DateTime.Now };

        //    //Act
        //    var data = await controller.AddPost(post);

        //    //Assert
        //    Assert.IsType<OkObjectResult>(data);
        //}

        //[Fact]
        //public async void Task_Add_InvalidData_Return_BadRequest()
        //{
        //    //Arrange
        //    var controller = new PostController(repository);
        //    Post post = new Post() { Title = "Test Title More Than 20 Characteres", Description = "Test Description 3", CategoryId = 3, CreatedDate = DateTime.Now };

        //    //Act            
        //    var data = await controller.AddPost(post);

        //    //Assert
        //    Assert.IsType<BadRequestResult>(data);
        //}

        [Fact]
        public void Test_POST_AddReservation()
        {
            // Arrange
            InvoiceDTO inv = new InvoiceDTO()
            {
                Date = DateTime.Now,
                Description = "invoice 6",
                TotalAmount = 1000
            };
            var mockService = new Mock<IInvoiceService>();
            var logService = new Mock<ILogger<InvoicesController>>();
            mockService.Setup(t => t.AddInvoiceAsync(It.IsAny<InvoiceDTO>())).ReturnsAsync("");
            var controller = new InvoicesController(mockService.Object, logService.Object);

            // Act
            var result = controller.AddInvoice(inv);

            // Assert
            var invoice = Assert.IsType<Invoice>(result);
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void Test_PUT_UpdateReservation()
        {
            // Arrange
            int id = 1;
            InvoiceDTO inv = new InvoiceDTO()
            {
                Date = DateTime.Now,
                Description = "invoice 6",
                TotalAmount = 1000
            };
            var mockService = new Mock<IInvoiceService>();
            var logService = new Mock<ILogger<InvoicesController>>();
            mockService.Setup(t => t.AddInvoiceAsync(It.IsAny<InvoiceDTO>())).ReturnsAsync("");
            var controller = new InvoicesController(mockService.Object, logService.Object);

            // Act
            var result = controller.UpdateInvoice(id,inv);

            // Assert
            var reservation = Assert.IsType<string>(result);
            Assert.IsType<OkObjectResult>(result);
        }

    }
}