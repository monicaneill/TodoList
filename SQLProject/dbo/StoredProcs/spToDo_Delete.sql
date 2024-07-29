CREATE PROCEDURE [dbo].[spToDoList_Delete]
	@Id int
AS
Begin
	Delete
	From dbo.ToDo
	Where Id = @Id;
End