CREATE PROCEDURE [dbo].[spToDo_Insert]
	@ItemToDo nvarchar(50),
	@Completed bit

AS
Begin
	Insert into dbo.ToDo (ItemToDo, Completed)
	Values (@ItemToDo, @Completed);
End