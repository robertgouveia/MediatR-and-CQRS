using System.Security.Cryptography;
using CqrsMediatr.Commands;
using CqrsMediatr.Models;
using CqrsMediatr.Notifications;
using CqrsMediatr.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatr.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : Controller
{
    // Must have a reference to the mediator
    //ISender holds the send method
    //IPublisher holds the publish method
    //private readonly IMediator _mediator; IMediator Holds functionality of ISender and IPublisher -- you can be more strict and reference on of the other
    private readonly ISender _sender;
    
    //To publish notification you have to use the IPublisher
    private readonly IPublisher _publisher;

    public ProductsController(ISender sender, IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        // Send expects a query
        var products = await _sender.Send(new GetProductsQuery());
        
        // Controller is completely seperated by the data layer, instead the MediatR pattern handles this for the controller
        return Ok(products);
    }

    [HttpGet("{id:int}", Name = "GetProductById")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _sender.Send(new GetProductByIdQuery(id));

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
        var productResponse = await _sender.Send(new AddProductCommand(product));
        
        // Call the notification for the listeners
        // This can also be done directly in the handler (ISender - Command)
        await _publisher.Publish(new ProductAddedNotification(productResponse)); 
        
        return CreatedAtAction("GetProductById", new { id = productResponse.Id }, productResponse);
    }
}