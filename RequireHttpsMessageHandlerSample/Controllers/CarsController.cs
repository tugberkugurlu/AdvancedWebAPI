using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RequireHttpsMessageHandlerSample.Controllers {

    public class CarsController : ApiController {

        public string[] GetCars() {

            return new[] { 
                "Car 1",
                "Car 2",
                "Car 3"
            };
        }

        public string[] GetCar(string id) {

            return new[] { 
                string.Format("Car {0}", id)
            };
        }
    }
}