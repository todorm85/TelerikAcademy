USE PetStore

SELECT s.Name AS SpeciesName, COUNT(p.ProductId) AS ProductsCount
FROM Species s
	INNER JOIN ProductsSpecies ps
		ON s.SpeciesId = ps.SpeciesId
	INNER JOIN Products p
		ON p.ProductId = ps.ProductId
GROUP BY s.Name
ORDER BY ProductsCount ASC