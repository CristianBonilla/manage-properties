using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using RealEstate.Properties.Contracts.Services;
using RealEstate.Properties.Contracts.DTO.Property;

namespace RealEstate.Properties.API.Controllers
{
    /// <summary>
    /// Controller who is responsible for offering property services
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class PropertiesController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly IPropertiesService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesController"/> class
        /// </summary>
        /// <param name="mapper">Auto mapper</param>
        /// <param name="service">Properties service</param>
        public PropertiesController(IMapper mapper, IPropertiesService service) => (_mapper, _service) = (mapper, service);

        /// <summary>
        /// Get the list of properties with the necessary data
        /// </summary>
        /// <returns>Properties filter</returns>
        /// <response code="200">Successful to get all available properties</response>
        /// <response code="500">Internal server error not getting properties list</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<PropertiesFilter>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IAsyncEnumerable<PropertiesFilter> GetProperties()
        {
            var properties = _service.GetProperties();

            return _mapper.Map<IAsyncEnumerable<PropertiesFilter>>(properties);
        }

        /// <summary>
        /// Get the list of filtered properties with the necessary data
        /// </summary>
        /// <param name="text">Text to match</param>
        /// <returns>Properties filter</returns>
        /// <response code="200">Successfully to get all available properties filtered</response>
        /// <response code="500">Internal server error not getting list of filtered properties</response>
        [HttpGet("{text}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<PropertiesFilter>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IAsyncEnumerable<PropertiesFilter> GetProperties(string text)
        {
            var properties = _service.GetProperties(text);

            return _mapper.Map<IAsyncEnumerable<PropertiesFilter>>(properties);
        }
    }
}
