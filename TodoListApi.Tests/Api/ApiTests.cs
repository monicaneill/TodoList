using ApiClass = TodoList.WebApi.Api;
using DataAccessLibrary.Data;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace TodoListApi.Tests.Api;

public class ApiTests
{
    [Fact]
    public async Task GetToDoListItems_ReturnsOkResult_WithMultipleToDoListItems()
    {
        // Arrange
        var mockData = new Mock<IToDoListData>();
        mockData.Setup(data => data.GetToDoListItems())
            .ReturnsAsync(new List<ToDoListModel>
            {
                new ToDoListModel { Id = 1, ItemToDo = "Test Task 1", Completed = false },
                new ToDoListModel { Id = 2, ItemToDo = "Test Task 2", Completed = true },
                new ToDoListModel { Id = 3, ItemToDo = "Test Task 3", Completed = false }
            });

        // Act
        var result = await ApiClass.GetToDoListItems(mockData.Object);

        // Assert
        var okResult = Assert.IsType<Ok<IEnumerable<ToDoListModel>>>(result);
        var returnValue = Assert.IsAssignableFrom<IEnumerable<ToDoListModel>>(okResult.Value);

        Assert.Equal(3, returnValue.Count());
        Assert.Equal("Test Task 1", returnValue.ElementAt(0).ItemToDo);
        Assert.Equal("Test Task 2", returnValue.ElementAt(1).ItemToDo);
        Assert.Equal("Test Task 3", returnValue.ElementAt(2).ItemToDo);
    }

    [Fact]
    public async Task GetToDoListItem_ReturnsOkResult_WithToDoListItem()
    {
        // Arrange
        int testId = 1;
        var mockData = new Mock<IToDoListData>();
        mockData.Setup(data => data.GetToDoListItem(testId))
            .ReturnsAsync(new ToDoListModel { Id = testId, ItemToDo = "Test Task", Completed = false });

        // Act
        var result = await ApiClass.GetToDoListItem(testId, mockData.Object);

        // Assert
        var okResult = Assert.IsType<Ok<ToDoListModel>>(result);
        var returnValue = Assert.IsType<ToDoListModel>(okResult.Value);
        Assert.Equal(testId, returnValue.Id);
        Assert.Equal("Test Task", returnValue.ItemToDo);
    }

    [Fact]
    public async Task GetToDoListItems_ReturnsNotFoundWithMessage_WhenNoItemsPresent()
    {
        // Arrange
        var mockData = new Mock<IToDoListData>();
        mockData.Setup(data => data.GetToDoListItems())
            .ReturnsAsync(new List<ToDoListModel>()); // Return an empty list

        // Act
        var result = await ApiClass.GetToDoListItems(mockData.Object);

        // Assert
        var notFoundResult = Assert.IsType<NotFound<string>>(result);
        Assert.Equal("No to-do list items are present, try adding some!", notFoundResult.Value);
    }

    [Fact]
    public async Task GetToDoListItem_ReturnsNotFound_WhenItemDoesNotExist()
    {
        // Arrange
        int testId = 1;
        var mockData = new Mock<IToDoListData>();
        mockData.Setup(data => data.GetToDoListItem(testId))
            .ReturnsAsync((ToDoListModel)null);

        // Act
        var result = await ApiClass.GetToDoListItem(testId, mockData.Object);

        // Assert
        Assert.IsType<NotFound>(result);
    }

    [Fact]
    public async Task FilterToDoListItem_ReturnsNotFound_WhenItemDoesNotExist()
    {
        // Arrange
        bool completed = true;
        var mockData = new Mock<IToDoListData>();
        mockData.Setup(data => data.FilterToDoListItem(completed))
            .ReturnsAsync((IEnumerable<ToDoListModel>)null);

        // Act
        var result = await ApiClass.FilterToDoListItem(completed, mockData.Object);

        // Assert
        Assert.IsType<NotFound>(result);
    }

    [Fact]
    public async Task InsertToDoItem_ReturnsOkResult_WhenItemIsInsertedSuccessfully()
    {
        // Arrange
        var mockData = new Mock<IToDoListData>();
        var newToDoItem = new ToDoListModel { Id = 0, ItemToDo = "New Task", Completed = false };

        mockData.Setup(data => data.InsertToDoItem(newToDoItem))
            .Returns(Task.CompletedTask) // Simulate successful insert
            .Verifiable();

        // Act
        var result = await ApiClass.InsertToDoItem(newToDoItem, mockData.Object);

        // Assert
        Assert.IsType<Ok<string>>(result);

        // Verify that the InsertToDoItem method was called exactly once with the correct parameter
        mockData.Verify(data => data.InsertToDoItem(newToDoItem), Times.Once);
    }

    [Fact]
    public async Task InsertToDoItem_ReturnsProblemResult_WhenExceptionIsThrown()
    {
        // Arrange
        var mockData = new Mock<IToDoListData>();
        var newToDoItem = new ToDoListModel { Id = 0, ItemToDo = "New Task", Completed = false };

        mockData.Setup(data => data.InsertToDoItem(newToDoItem))
            .ThrowsAsync(new System.Exception("Database error"));

        // Act
        var result = await ApiClass.InsertToDoItem(newToDoItem, mockData.Object);

        // Assert
        Assert.IsType<ProblemHttpResult>(result);
    }
}