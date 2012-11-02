using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ActionSelectionLogic.Models;
using System.Linq;

namespace ActionSelectionLogic.APIs {

    public class CarsController : ApiController {

        private readonly CarsContext _carsCtx = new CarsContext();
        
        // GET /api/cars
        public IEnumerable<Car> Get() {

            return _carsCtx.All;
        }

        // GET /api/cars?make={make}
        public IEnumerable<Car> Get(string make) {

            return _carsCtx.All.Where(
                x => x.Make.Equals(
                    make, 
                    StringComparison.InvariantCultureIgnoreCase));
        }

        // GET /api/cars?make={make}&year={year}
        public IEnumerable<Car> Get(string make, int year) {

            return _carsCtx.All.Where(
                x => x.Make.Equals(make, StringComparison.InvariantCultureIgnoreCase) && 
                     x.Year == year);
        }

        // GET /api/cars/{id}
        public Car GetCar(int id) {

            var carTuple = _carsCtx.GetSingle(id);

            if (!carTuple.Item1) {

                var response = Request.CreateResponse(HttpStatusCode.NotFound);
                throw new HttpResponseException(response);
            }

            return carTuple.Item2;
        }
    }
}