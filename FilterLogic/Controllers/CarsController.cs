using FilterLogic.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FilterLogic.Controllers {

    public class CarsController : ApiController {

        [MyAuthFilter]
        [MyActionFilter]
        [MyExceptionFilter]
        //[MySecondActionFilter]
        public string[] GetCars() {

            //throw new NotImplementedException();

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