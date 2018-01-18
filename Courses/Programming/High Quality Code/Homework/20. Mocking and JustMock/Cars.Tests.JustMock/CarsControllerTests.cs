namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using Cars.Models;
    
    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            //: this(new JustMockCarsRepository())
            : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            //var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());
            var model = (ICollection<Car>)this.controller.Index().Model;

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        // this method also tests the Detail() functionality to full extent
        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "dummy",
                Model = "dummy",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        // We don`t need this method, we can simply call Model property
        // on the mocked CarsController methods` returned IView values.
        // Each Model property of IView object will be of type Object and will
        // wrap the actual returned type to which we can cast.
        // See the change I`ve made from line 39 to line 40 for refrence.
        // What I do is to skip the calling of GetModel with a Func delegate
        // and simply just call the Model property on the returned result.
        // KISS - Keep it simple stupid
        private object GetModel(Func<IView> funcView)
        {
            IView view = funcView();
            return view.Model;
        }

        // Added missing methods to cover all cases for CarsController

        [TestMethod]
        public void SearchShouldReturnCarsRepositorySearchMethodResult()
        {
            var result = (ICollection<Car>)this.controller.Search("dummyKey").Model;

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void SortByMakeShouldReturnCarsRepositorySortByMakeMethodResult()
        {
            var result = (IList<Car>)this.controller.Sort("make").Model;

            Assert.AreEqual("Opel", result[0].Make);
        }

        [TestMethod]
        public void SortByYearShouldReturnCarsRepositorySortByYearMethodResult()
        {
            var result = (IList<Car>)this.controller.Sort("year").Model;

            Assert.AreEqual("Audi", result[0].Make);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortByYearShouldThrowOnInvalidArguement()
        {
            var result = (IList<Car>)this.controller.Sort("wrong argument").Model;
        }
    }
}
