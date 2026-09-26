using Microsoft.AspNetCore.Mvc;
using RideShare.Application.DTOs.Rides;
using RideShare.Application.Interfaces.Services;
using System;

namespace RideShare.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RideController:ControllerBase
{
    private readonly IRideService _rideService;
    public RideController(IRideService rideService)
    {
        _rideService = rideService;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var ride = await _rideService.GetByIdAsync(id, cancellationToken);
        if(ride is null)
        {
            return NotFound();
        }
        return Ok(ride);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRideRequest rideRequest, CancellationToken cancellationToken)
    {
        var ride = await _rideService.CreateAsync(rideRequest, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = ride.Id }, ride);
    }

}
