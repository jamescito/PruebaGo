using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Controllers;
using TaskApi.Interfaces;
using TaskApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskApi.Test;

public class TareaControllerTests
{
    [Fact]
    public async Task GetTareas_DebeRetornarOkConLista()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(uow => uow.Tareas.GetAllAsync())
                      .ReturnsAsync(new List<Tarea> { new Tarea { Id = 1, Title = "Test" } });

        var controller = new TareaController(mockUnitOfWork.Object);

        // Act
        var result = await controller.GetTareas();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.NotNull(okResult.Value);
    }
}