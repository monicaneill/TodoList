CREATE PROCEDURE [dbo].[spToDoList_FilterByCompleted]
	@Completed bit
AS
Begin
	Select [Id], [ItemToDo], [Completed] 
	From dbo.ToDo
	Where Completed = @Completed;
End
