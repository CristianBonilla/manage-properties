using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using RealEstate.Properties.Domain.Entities;
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

        /// <summary>
        /// Add a new property with the corresponding data
        /// </summary>
        /// <param name="propertyRequest">Property request</param>
        /// <returns>Property response</returns>
        /// <response code="201">Successfully for property created</response>
        /// <response code="500">Internal server error not creating property</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PropertyResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProperty([FromBody] PropertyRequest propertyRequest)
        {
            PropertyEntity property = _mapper.Map<PropertyEntity>(propertyRequest);
            PropertyEntity propertyAdded = await _service.AddProperty(property);

            return Ok(_mapper.Map<PropertyResponse>(propertyAdded));
        }

        /// <summary>
        /// Add the property image based on the received property identifier
        /// </summary>
        /// <param name="propertyId">Property identifier</param>
        /// <param name="image">Property image</param>
        /// <returns>Property image response</returns>
        /// <response code="201">Successfully to add the property image</response>
        /// <response code="500">Internal server error not creating property image</response>
        [HttpPost("image/{propertyId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddPropertyImage(Guid propertyId, IFormFile image)
        {
            if (image.Length <= 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "There is no image to process");
            using MemoryStream memoryStream = new();
            await image.CopyToAsync(memoryStream);
            byte[] imageBytes = memoryStream.ToArray();
            PropertyImageEntity propertyImage = await _service.AddPropertyImage(propertyId, imageBytes);

            return File(memoryStream, "application/octet-stream");
        }

        /// <summary>
        /// Edit the price of the property, based on the property identifier
        /// </summary>
        /// <param name="propertyId">Property identifier</param>
        /// <param name="price">Property price</param>
        /// <returns>Property edited</returns>
        /// <response code="200">Successfully updated property price</response>
        /// <response code="404">Property not found by identifier, to update the price</response>
        /// <response code="500">Internal server error not updating property price</response>
        [HttpPut("price/{propertyId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditPropertyPrice(Guid propertyId, [FromQuery] decimal price)
        {
            PropertyEntity property = await _service.EditPropertyPrice(propertyId, price);

            return Ok(_mapper.Map<PropertyResponse>(property));
        }
    }
}
