namespace PetStore.ConsoleClient
{
    using System;
    using PetStore.Data;
    using PetStore.Importer;

    public class Startup
    {
        private const int CountriesSeedCount = 20;
        private const int SpeciesSeedCount = 100;
        private const int PetsSeedCount = 5000;
        private const int CategoriesSeedCount = 50;
        private const int ProductsSeedCount = 20000;
        

        public static void Main()
        {
            //ResetDatabase(); // only for testing, but the management studio app needs to be closed entirely

            SeedDatabase();
        }

        private static void SeedDatabase()
        {
            var rand = new RandomGenerator();
            var seeder = new PetStoreSeeder(rand);

            // SeedColors() is not needed since i saved the database with preliminary included data for colors, 
            // please load it from the provided sequel script or bak file from task 1 (You should have it loaded)
            // In case there are no colors in the Colors table, uncomment next line to seed them, otherwise the app will throw
            // this is because I don`t have task 2 StoredProcedure for inserting colors done. The seeder needs to have data for
            // colors preliminary inserted.

            //seeder.SeedColors();  

            seeder.SeedCountries(CountriesSeedCount);
            seeder.SeedSpecies(SpeciesSeedCount);
            seeder.SeedPets(PetsSeedCount);
            seeder.SeedCategories(CategoriesSeedCount);
            seeder.SeedProducts(ProductsSeedCount);
        }

        private static void ResetDatabase()
        {
            var db = new PetStoreEntities();
            db.Database.Delete();
            db.Database.Create();
        }
    }
}
