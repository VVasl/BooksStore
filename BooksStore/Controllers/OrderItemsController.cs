using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BooksStore.Data;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using BooksStore.Data.Entities;
using BooksStore.Models;

namespace BooksStore.Controllers
{
    [Route("/api/orders/{orderId}/items")]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderItemsController : Controller
    {
        private readonly IBooksStoreRepository _repository;
        private readonly Logger _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(IBooksStoreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _logger = LogManager.GetCurrentClassLogger();
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int orderId)
        {
            try
            {
                // var order = _repository.GetOrderById(User.Identity.Name, orderId);
                var order = _repository.GetOrderById(orderId);

                if (order != null)
                {
                    return Ok(_mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemsDto>>(order.Items));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to get order items: {ex}");
                return BadRequest("Failed to get order items");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            try
            {
                //var order = _repository.GetOrderById(User.Identity.Name, orderId);
                var order = _repository.GetOrderById(orderId);

                if (order != null)
                {
                    var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
                    if (item != null)
                    {
                        return Ok(_mapper.Map<OrderItem, OrderItemsDto>(item));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
                /// too much NotFound 
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to get order item:{ex}");
                return BadRequest("Failed to get order item");
            }
        }
    }
}
