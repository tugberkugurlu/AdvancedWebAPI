using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AsyncDatabaseCall.Models;

namespace AsyncDatabaseCall.APIs {

    public class SPCarsAsyncController : ApiController {

        readonly GalleryContext galleryContext = new GalleryContext();

        public Task<IEnumerable<Car>> Get() {

            return galleryContext.GetCarsViaSPAsync();
        }
    }
}