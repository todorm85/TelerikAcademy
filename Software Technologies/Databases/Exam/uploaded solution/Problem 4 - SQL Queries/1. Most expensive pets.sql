USE PetStore

SELECT TOP 5 p.Price, p.Breed, p.BirthDate
FROM Pets p
WHERE YEAR(p.BirthDate) >= 2012
ORDER BY p.Price DESC
