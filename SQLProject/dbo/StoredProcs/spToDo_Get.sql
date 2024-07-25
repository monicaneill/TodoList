CREATE PROCEDURE [dbo].[spToDoList_Get]
	@Id int
AS
Begin
	SELECT [Id], [ItemToDo], [Completed] 
	From dbo.ToDo
	Where Id = @Id;
End