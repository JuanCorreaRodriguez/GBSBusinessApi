﻿using GBSApi.Dtos.Brand;
using GBSApi.Interfaces.Brand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GBSApi.Controllers;

[Route("api/brand")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    // [Authorize]
    public async Task<IActionResult> GetBrands()
    {
        var brands = await _brandService.GetBrands();
        if (!brands.Any()) return NoContent();
        return Ok(brands);
    }

    [HttpGet]
    // [Authorize]
    [Route("{id}")]
    public async Task<IActionResult> GetBrand([FromRoute] string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var brand = await _brandService.GetBrand(id);
        if (brand == null) return NotFound("Brand not found");
        return Ok(brand);
    }

    [HttpPost]
    [Authorize]
    [Consumes("application/json")]
    public async Task<IActionResult> AddBrand([FromBody] BrandCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var brand = await _brandService.CreateBrand(dto);
        return Ok(brand);
    }

    [HttpPut]
    [Authorize]
    [Route("{id}")]
    public async Task<IActionResult> UpdateBrand([FromRoute] string id, [FromBody] BrandUpdateDto dto)
    {
        if (id == "") return BadRequest("Id is required");
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var brand = await _brandService.UpdateBrand(id, dto);
        if (brand == null) return NotFound("Brand not found");
        return Ok(brand);
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteBrand([FromRoute] string id)
    {
        if (id == "") return BadRequest("Id is required");
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _brandService.DeleteBrand(id);
        if (!result) return NotFound("Something went wrong");
        return Ok(result);
    }
}