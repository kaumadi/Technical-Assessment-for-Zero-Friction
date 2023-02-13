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
        
        [Fact]
        public async void Test_Add_InvalidData_Return_BadRequest()
        {
            InvoiceDTO inv = new InvoiceDTO()
            {
                Date = DateTime.Now,
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
            Assert.IsType<BadRequestResult>(result);
        }

    }
}
