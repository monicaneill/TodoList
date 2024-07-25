CREATE PROCEDURE [dbo].[spToDo_Update]
	@Id int,
	@ItemToDo nvarchar(50),
	@Completed bit

AS
Begin
	update dbo.ToDo
	Set ItemToDo = @ItemToDo, Completed = @Completed
	Where Id = @Id;
End