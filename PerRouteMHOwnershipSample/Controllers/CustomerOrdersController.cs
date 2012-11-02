using _09_PerRouteMHOwnershipSample.Filters;
using _09_PerRouteMHOwnershipSample.Models;
using _09_PerRouteMHOwnershipSample.Models.Core;
using _09_PerRouteMHOwnershipSample.Models.Dtos;
using _09_PerRouteMHOwnershipSample.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace _09_PerRouteMHOwnershipSample.Controllers {

    //[CustomerOrdersAuthorize]
    public class CustomerOrdersController : ApiController {

        private readonly IEntityRepository<Order> _orderRepository;

        public CustomerOrdersController(IEntityRepository<Order> orderRepository) {

            _orderRepository = orderRepository;
        }

        public IEnumerable<OrderDto> GetOrders(int customerKey) {

            var orders = _orderRepository.GetAll(customerKey);
            return orders.Select(order => order.ToOrderDto());
        }

        //Ensure existance & ownership here.
        //[EnsureOrderOwnership]
        public OrderDto GetOrder(int customerKey, int key) {

            var order = _orderRepository.GetSingle(key);
            return order.ToOrderDto();
        }

        public HttpResponseMessage PostOrder( 
            int customerKey, OrderRequestModel requestModel,
            HttpRequestMessage request) {

            var order = requestModel.ToOrder(customerKey);
            _orderRepository.Add(order);
            _orderRepository.Save();

            var response = request.CreateResponse(HttpStatusCode.Created, order);
            response.Headers.Location = new Uri(
                Url.Link(
                    "CustomerOrdersHttpRoute", 
                    new { customerKey = customerKey, key = order.Key }
                )
            );

            return response;
        }

        //Ensure existance & ownership here.
        //[EnsureOrderOwnership]
        public HttpResponseMessage DeleteOrder(
            int customerKey, int key,
            HttpRequestMessage request) {

            var order = _orderRepository.GetSingle(key);
            _orderRepository.Delete(order);
            _orderRepository.Save();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}