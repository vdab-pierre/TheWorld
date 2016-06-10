using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using TheWorld.Models;
using TheWorld.ViewModel;

namespace TheWorld.Controllers.Api
{
    [Authorize]
    [Route("api/trips")]
    public class TripController:Controller
    {
        private IWorldRepository _repository;
        private ILogger<TripController> _logger;

        public TripController(IWorldRepository repository,ILogger<TripController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet("")]
        public JsonResult Get()
        {
            var trips = _repository.GetUserTripswithStops(User.Identity.Name);
            var results = Mapper.Map<IEnumerable<TripViewModel>>(trips);
            Thread.Sleep(1000);
            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]TripViewModel vm)
        {
            //we willen geen server errors etc, ook geen redirection, het is een api. Dus Try catch

            try
            {
                //voor een api kan ook validation in het model zitten
                //en het is veel interesanter om via een viewmodel te werken natuurlijk
                if (ModelState.IsValid)
                {
                    var newtrip = Mapper.Map<Trip>(vm);

                    newtrip.UserName = User.Identity.Name;

                    //save to the db
                    _logger.LogInformation("Attempting to save a new trip.");
                    _repository.AddTrip(newtrip);
                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int) HttpStatusCode.Created;
                        return Json(Mapper.Map<TripViewModel>(newtrip));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new trip",ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed",ModelState=ModelState });
        }
    }
}
