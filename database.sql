CREATE DATABASE ExamAdvSoftware;
USE ExamAdvSoftware;

CREATE TABLE tblArtist (
    ArtistID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Genre VARCHAR(100),
    Country VARCHAR(100),
    ActiveYears VARCHAR(50),
    Popularity INT
);

INSERT INTO tblArtist (Name, Genre, Country, ActiveYears, Popularity)
VALUES 
('The Beatles', 'Rock', 'United Kingdom', '1960–1970', 10),
('Madonna', 'Pop', 'United States', '1979–present', 9),
('Bob Marley', 'Reggae', 'Jamaica', '1962–1981', 8),
('Taylor Swift', 'Pop', 'United States', '2006–present', 9),
('Daft Punk', 'Electronic', 'France', '1993–2021', 7),
('Charlotte de Witte', 'Techno', 'Belgium', '2010–present', 6),
('Lenny Kravitz', 'Rock', 'United States', '1988–present', 8),
('Black Pumas', 'Psychedelic Soul', 'United States', '2017–present', 5);

CREATE TABLE tblPerformance (
    PerformanceId INT AUTO_INCREMENT PRIMARY KEY,
    ArtistId INT,
    Location VARCHAR(255),
    Date VARCHAR(100),
    Time VARCHAR(100),
    FOREIGN KEY (ArtistId) REFERENCES tblArtist(ArtistID)
);