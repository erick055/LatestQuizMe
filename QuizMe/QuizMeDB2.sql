CREATE TABLE Flashcards (
    FlashcardId INT PRIMARY KEY IDENTITY(1,1),
    Question NVARCHAR(MAX) NOT NULL,
    Answer NVARCHAR(MAX) NOT NULL,
    
    -- This is the new column that links to the Users table
    UserId INT NOT NULL, 
    
    -- This line creates the official link (foreign key)
    CONSTRAINT FK_Flashcards_Users 
        FOREIGN KEY (UserId) REFERENCES Users(UserId)
);