namespace PetStore.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using PetStore.Data;

    public class PetStoreSeeder
    {
        private PetStoreEntities db = new PetStoreEntities();
        private IRandomGenerator randomGenerator;

        public PetStoreSeeder(IRandomGenerator rand)
        {
            this.randomGenerator = rand;
        }

        public void SeedCountries(int countriesCount)
        {
            Console.WriteLine("Seeding Countries");

            var randomCountryName = randomGenerator.GetRandomString(5, 50);
            var countriesNames = db.Countries.Select(d => d.Name).ToList();

            for (int i = 0; i < countriesCount; i++)
            {
                while (countriesNames.Contains(randomCountryName))
                {
                    randomCountryName = randomGenerator.GetRandomString(10, 50);
                }

                countriesNames.Add(randomCountryName);

                var country = new Country()
                {
                    Name = randomCountryName
                };

                db.Countries.Add(country);

                OptimizedDbSave();
            }

            db.SaveChanges();
        }

        private void OptimizedDbSave()
        {
            if (db.ChangeTracker.Entries().Count() > 100)
            {
                db.SaveChanges();
                db = new PetStoreEntities();
                Console.Write(".");
            }
        }


        public void SeedSpecies(int SpeciesSeedCount)
        {
            Console.WriteLine("Seeding Species");

            var randomSpeciesName = randomGenerator.GetRandomString(5, 50);
            var speciesNames = db.Species.Select(d => d.Name).ToList();

            var countriesIds = db.Countries.Select(d => d.CountryId).ToArray();
            var countryIdsCount = countriesIds.Count();

            for (int i = 0; i < SpeciesSeedCount; i++)
            {
                while (speciesNames.Contains(randomSpeciesName))
                {
                    randomSpeciesName = randomGenerator.GetRandomString(10, 50);
                }

                speciesNames.Add(randomSpeciesName);
                
                var randomCountryIdIndex = randomGenerator.GetRandomInteger(0, countryIdsCount);
                var randomCountryId = countriesIds[randomCountryIdIndex];

                var species = new Species()
                {
                    Name = randomSpeciesName,
                    CountryId = randomCountryId
                };

                db.Species.Add(species);

                OptimizedDbSave();
            }

            db.SaveChanges();
        }

        public void SeedPets(int PetsSeedCount)
        {
            Console.WriteLine("Seeding Pets");

            var colorIds = db.Colors.Select(d => d.ColorId).ToArray();
            var colorIdsCount = colorIds.Count();

            var speciesIds = db.Species.Select(d => d.SpeciesId).ToArray();
            var speciesIdsCount = speciesIds.Count();

            var minDate = new DateTime(2010, 1, 1);
            var timeBeforeNow = new TimeSpan(60, 0, 0, 0);
            var maxDate = DateTime.Now - timeBeforeNow;

            for (int i = 0; i < PetsSeedCount; i++)
            {
                var randomBreedName = randomGenerator.GetRandomString(5, 30);
                var randomColorIdIndex = randomGenerator.GetRandomInteger(0, colorIdsCount);
                var randomSpeciesIdIndex = randomGenerator.GetRandomInteger(0, speciesIdsCount);
                var pet = new Pet()
                {
                    Breed = randomBreedName,
                    BirthDate = randomGenerator.GetRandomDate(minDate, maxDate),
                    ColorId = colorIds[randomColorIdIndex],
                    Price = randomGenerator.GetRandomInteger(5, 2500),
                    SpeciesId = speciesIds[randomSpeciesIdIndex],
                };

                db.Pets.Add(pet);

                OptimizedDbSave();
            }

            db.SaveChanges();
        }

        public void SeedCategories(int CategoriesSeedCount)
        {
            Console.WriteLine("Seeding Categories");

            for (int i = 0; i < CategoriesSeedCount; i++)
            {
                var randomCategoryName = randomGenerator.GetRandomString(5, 20);

                var category = new Category()
                {
                    Name = randomCategoryName
                };

                db.Categories.Add(category);

                OptimizedDbSave();
            }

            db.SaveChanges();
        }

        public void SeedSpeciesToProducts(int minSpeciesCount, int maxSpeciesCount)
        {
            Console.WriteLine("Seeding Species to Products");
            var products = db.Products.ToArray();
            var speciesIds = db.Species.Select(s => s.SpeciesId).ToArray();

            foreach (var product in products)
            {
                var randomSpeciesPerCategoryCount = randomGenerator.GetRandomInteger(minSpeciesCount, maxSpeciesCount);

                var randomSpeciesId = speciesIds[randomGenerator.GetRandomInteger(0, speciesIds.Count())];
                var addedSpeciesIds = new List<int>();

                for (int i = 0; i < randomSpeciesPerCategoryCount; i++)
                {
                    while (addedSpeciesIds.Contains(randomSpeciesId))
                    {
                        randomSpeciesId = speciesIds[randomGenerator.GetRandomInteger(0, speciesIds.Count())];
                    }

                    addedSpeciesIds.Add(randomSpeciesId);

                    var species = db.Species.First(s => s.SpeciesId == randomSpeciesId);

                    product.Species.Add(species);
                }
            }

            db.SaveChanges();
        }

        public void SeedProducts(int ProductsSeedCount)
        {
            Console.WriteLine("Seeding Products");

            var categoryIds = db.Categories.Select(c => c.CategoryId).ToArray();
            var categoryIdsCount = categoryIds.Count();

            var speciesIds = db.Species.Select(s => s.SpeciesId).ToArray();

            for (int i = 0; i < ProductsSeedCount; i++)
            {
                var randomProductName = randomGenerator.GetRandomString(5, 20);
                var randomCategoryId = categoryIds[randomGenerator.GetRandomInteger(0, categoryIdsCount)];

                var product = new Product()
                {
                    Name = randomProductName,
                    Price = randomGenerator.GetRandomInteger(10, 1000),
                    CategoryId = randomCategoryId
                };


                var randomSpeciesPerCategoryCount = randomGenerator.GetRandomInteger(2, 10);
                var randomSpeciesId = speciesIds[randomGenerator.GetRandomInteger(0, speciesIds.Count())];
                var addedSpeciesIds = new List<int>();

                for (int j = 0; j < randomSpeciesPerCategoryCount; j++)
                {
                    while (addedSpeciesIds.Contains(randomSpeciesId))
                    {
                        randomSpeciesId = speciesIds[randomGenerator.GetRandomInteger(0, speciesIds.Count())];
                    }

                    addedSpeciesIds.Add(randomSpeciesId);

                    var species = db.Species.First(s => s.SpeciesId == randomSpeciesId);

                    product.Species.Add(species);
                }


                db.Products.Add(product);

                OptimizedDbSave();
            }

            db.SaveChanges();
        }

        public void SeedColors()
        {
            for (int i = 0; i < 4; i++)
            {
                var color = new Color()
                {
                    ColorIndex = i
                };

                db.Colors.Add(color);
            }

            db.SaveChanges();
        }
    }
}
