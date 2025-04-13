using GlamBeautyApi.Dtos.Category;
using GlamBeautyApi.Interfaces.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlamBeautyApi.Controllers;

[Route("api/category")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetCategories()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var res = await _categoryService.GetCategories();
        return Ok(res);
    }

    [HttpGet]
    [Authorize]
    [Route("{id}")]
    public async Task<IActionResult> GetCategory([FromRoute] string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var category = await _categoryService.GetCategory(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _categoryService.CreateCategory(dto);
        return Ok(result);
    }

    [HttpPut]
    [Authorize]
    [Route("{id}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] string id, [FromBody] CategoryUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _categoryService.UpdateCategory(id, dto);
        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _categoryService.DeleteCategory(id);
        if (result == null) return NotFound();
        return Ok(result);
    }
}