CREATE PROCEDURE [dbo].[spToDoList_GetAll]
AS
Begin
	SELECT [Id], [ItemToDo], [Completed] 
	From dbo.ToDo;
End
