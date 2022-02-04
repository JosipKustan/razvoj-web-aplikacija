Use AdventureWorksOBP
GO
----------------------------------------------
--- USER TABLES ------------------------------
----------------------------------------------
IF OBJECT_ID('UserData') IS NULL
BEGIN
    CREATE TABLE UserData (
    IDLoginData INT IDENTITY PRIMARY KEY,
    Username NVARCHAR(64),
    Password NVARCHAR(64)
)
END
GO
----------------------------------------------
----------------------------------------------
---SELECT PROCEDURES---------------------------------
----------------------------------------------
----------------------------------------------

----------------------------------------------
---DRZAVA-------------------------------------
----------------------------------------------
IF OBJECT_ID('selectDrzava') IS NOT NULL
BEGIN
    DROP PROCEDURE selectDrzava
END
GO
CREATE PROCEDURE selectDrzava
    @IDDrzava INT
AS
BEGIN
    SELECT * FROM Drzava WHERE IDDrzava = @IDDrzava
END
GO

IF OBJECT_ID('selectDrzavaAll') IS NOT NULL
BEGIN
    DROP PROCEDURE selectDrzavaAll
END
GO
CREATE PROCEDURE selectDrzavaAll
AS
BEGIN
    SELECT * FROM Drzava
END
GO

----------------------------------------------
--- Grad -------------------------------------
----------------------------------------------
IF OBJECT_ID('selectGrad') IS NOT NULL
BEGIN
    DROP PROCEDURE selectGrad
END
GO
CREATE PROCEDURE selectGrad
    @IDGrad INT
AS
BEGIN
    SELECT * FROM Grad WHERE IDGrad = @IDGrad
END
GO

IF OBJECT_ID('selectGradAll') IS NOT NULL
BEGIN
    DROP PROCEDURE selectGradAll
END
GO
CREATE PROCEDURE selectGradAll
AS
BEGIN
    SELECT * FROM Grad
END
GO

IF OBJECT_ID('selectGradAllDrzava') IS NOT NULL
BEGIN
    DROP PROCEDURE selectGradAllDrzava
END
GO
CREATE PROCEDURE selectGradAllDrzava
    @IDDrzava INT
AS
BEGIN
    SELECT * FROM Grad WHERE DrzavaID=@IDDrzava
END
GO

----------------------------------------------
--- Kategorija -------------------------------------
----------------------------------------------

IF OBJECT_ID('selectKategorija') IS NOT NULL
BEGIN
    DROP PROCEDURE selectKategorija
END
GO
CREATE PROCEDURE selectKategorija
    @IDKategorija INT
AS
BEGIN
    SELECT * FROM Kategorija WHERE IDKategorija = @IDKategorija
END
GO

IF OBJECT_ID('selectKategorijaAll') IS NOT NULL
BEGIN
    DROP PROCEDURE selectKategorijaAll
END
GO
CREATE PROCEDURE selectKategorijaAll
AS
BEGIN
    SELECT * FROM Kategorija
END
GO

---CRUD-------------------------------------------
IF OBJECT_ID('updateKategorija') IS NOT NULL
BEGIN
    DROP PROCEDURE updateKategorija
END
GO
CREATE PROCEDURE updateKategorija
    @IDKategorija int,
    @Naziv nvarchar(50)
AS
BEGIN
    UPDATE Kategorija SET Naziv = @Naziv WHERE IDKategorija = @IDKategorija
END
GO


IF OBJECT_ID('deleteKategorija') IS NOT NULL
BEGIN
    DROP PROCEDURE deleteKategorija
END
GO
CREATE PROCEDURE deleteKategorija
    @IDKategorija INT
AS
BEGIN
    DELETE FROM Potkategorija WHERE KategorijaID = @IDKategorija
    DELETE FROM KATEGORIJA WHERE IDKategorija = @IDKategorija
END
GO

----------------------------------------------
---KOMERCIALIST---------------------------------
----------------------------------------------

IF OBJECT_ID('selectKomercijalist') IS NOT NULL
BEGIN
    DROP PROCEDURE selectKomercijalist
END
GO
CREATE PROCEDURE selectKomercijalist
    @IDKomercijalist INT
AS
BEGIN
    SELECT * FROM Komercijalist WHERE IDKomercijalist = @IDKomercijalist
END
GO
IF OBJECT_ID('selectKomercijalistAll') IS NOT NULL
BEGIN
    DROP PROCEDURE selectKomercijalistAll
END
GO
CREATE PROCEDURE selectKomercijalistAll
AS
BEGIN
    SELECT * FROM Komercijalist
END
GO

----------------------------------------------
---KREDITNA KARTICA---------------------------------
----------------------------------------------

IF OBJECT_ID('selectKreditnaKarticaBroj') IS NOT NULL
BEGIN
    DROP PROCEDURE selectKreditnaKarticaBroj
END
GO
CREATE PROCEDURE selectKreditnaKarticaBroj
    @Broj nvarchar(25)
AS
BEGIN
    SELECT * FROM KreditnaKartica WHERE Broj = @Broj
END
GO

IF OBJECT_ID('selectKreditnaKartica') IS NOT NULL
BEGIN
    DROP PROCEDURE selectKreditnaKartica
END
GO
CREATE PROCEDURE selectKreditnaKartica
    @IDKreditnaKartica INT
AS
BEGIN
    SELECT * FROM KreditnaKartica WHERE IDKreditnaKartica = @IDKreditnaKartica
END
GO

IF OBJECT_ID('selectKreditnaKarticaAll') IS NOT NULL
BEGIN
    DROP PROCEDURE selectKreditnaKarticaAll
END
GO
CREATE PROCEDURE selectKreditnaKarticaAll
AS
BEGIN
    SELECT * FROM KreditnaKartica
END
GO

----------------------------------------------
---KUPAC---------------------------------
----------------------------------------------

IF OBJECT_ID('selectKupac') IS NOT NULL
BEGIN
    DROP PROCEDURE selectKupac
END
GO
CREATE PROCEDURE selectKupac
    @IDKupac INT
AS
BEGIN
    SELECT * FROM Kupac WHERE IDKupac = @IDKupac
END
GO

IF OBJECT_ID('selectKupacAll') IS NOT NULL
BEGIN
    DROP PROCEDURE selectKupacAll
END
GO
CREATE PROCEDURE selectKupacAll
AS
BEGIN
    SELECT TOP 200 * FROM Kupac
END
GO

IF OBJECT_ID('selectKupacAllGrad') IS NOT NULL
BEGIN
    DROP PROCEDURE selectKupacAllGrad
END
GO
CREATE PROCEDURE selectKupacAllGrad
    @GradID INT
AS
BEGIN
    SELECT TOP 200 * FROM Kupac WHERE GradID=@GradID
END
GO

---KUPAC CRUD---------------------------------

IF OBJECT_ID('updateKupac') IS NOT NULL
BEGIN
    DROP PROCEDURE updateKupac
END
GO
CREATE PROCEDURE updateKupac
    @IDKupac int,
    @Ime nvarchar(50),
	@Prezime nvarchar(50),
	@Email nvarchar(50),
	@Telefon nvarchar(25)
AS
BEGIN
    UPDATE Kupac SET Ime = @Ime, Prezime = @Prezime, Email = @Email, Telefon = @Telefon WHERE IDKupac = @IDKupac
END
GO

----------------------------------------------
---POTKATEGORIJA---------------------------------
----------------------------------------------

IF OBJECT_ID('selectPotkategorija') IS NOT NULL
BEGIN
    DROP PROCEDURE selectPotkategorija
END
GO
CREATE PROCEDURE selectPotkategorija
    @IDPotkategorija INT
AS
BEGIN
    SELECT * FROM Potkategorija WHERE IDPotkategorija = @IDPotkategorija
END
GO

IF OBJECT_ID('selectPotkategorijaAll') IS NOT NULL
BEGIN
    DROP PROCEDURE selectPotkategorijaAll
END
GO
CREATE PROCEDURE selectPotkategorijaAll
AS
BEGIN
    SELECT * FROM Potkategorija
END
GO

IF OBJECT_ID('updatePotkategorija') IS NOT NULL
BEGIN
    DROP PROCEDURE updatePotkategorija
END
GO
CREATE PROCEDURE updatePotkategorija
    @IDPotkategorija int,
	@KategorijaID int,
	@Naziv nvarchar(50)
AS
BEGIN
    UPDATE Potkategorija SET KategorijaID = @KategorijaID, Naziv = @Naziv WHERE IDPotkategorija = @IDPotkategorija
END
GO

IF OBJECT_ID('deletePotkategorija') IS NOT NULL
BEGIN
    DROP PROCEDURE deletePotkategorija
END
GO
CREATE PROCEDURE deletePotkategorija
    @IDPotkategorija int
AS
BEGIN
    DELETE FROM Potkategorija WHERE IDPotkategorija = @IDPotkategorija
END
GO

----------------------------------------------
---PROIZVOD---------------------------------
----------------------------------------------

IF OBJECT_ID('selectProizvod') IS NOT NULL
BEGIN
    DROP PROCEDURE selectProizvod
END
GO
CREATE PROCEDURE selectProizvod
    @IDProizvod INT
AS
BEGIN
    SELECT * FROM Proizvod WHERE IDProizvod = @IDProizvod
END
GO

IF OBJECT_ID('selectProizvodAll') IS NOT NULL
BEGIN
    DROP PROCEDURE selectProizvodAll
END
GO
CREATE PROCEDURE selectProizvodAll
AS
BEGIN
    BEGIN
        SELECT * FROM Proizvod
    END
END
GO

IF OBJECT_ID('updateProizvod') IS NOT NULL
BEGIN
    DROP PROCEDURE updateProizvod
END
GO
CREATE PROCEDURE updateProizvod
    @IDProizvod INT,
	@Naziv NVARCHAR(50),
	@BrojProizvoda NVARCHAR(25),
	@Boja NVARCHAR(15),
	@MinimalnaKolicinaNaSkladistu INT,
	@CijenaBezPDV MONEY,
	@PotkategorijaID INT
AS
BEGIN
    UPDATE Proizvod SET Naziv = @Naziv, BrojProizvoda = @BrojProizvoda, Boja = @Boja, MinimalnaKolicinaNaSkladistu = @MinimalnaKolicinaNaSkladistu, CijenaBezPDV = @CijenaBezPDV, PotkategorijaID = @PotkategorijaID WHERE IDProizvod = @IDProizvod
END
GO

IF OBJECT_ID('deleteProizvod') IS NOT NULL
BEGIN
    DROP PROCEDURE deleteProizvod
END
GO
CREATE PROCEDURE deleteProizvod
    @IDProizvod INT
AS
BEGIN
   DELETE FROM Proizvod WHERE IDProizvod = @IDProizvod
END
GO