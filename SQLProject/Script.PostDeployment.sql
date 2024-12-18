If Not Exists (Select 1 from dbo.ToDo)
Begin
    DBCC CHECKIDENT ('dbo.ToDo', RESEED, 0);

    Insert into dbo.ToDo (ItemToDo, Completed)
    Values 
    ('Kiss wife', 1),
    ('Wash dishes', 0),
    ('Teach dog trick', 0);
End