using GBSApi.Dtos.Course;
using GBSApi.ErrorHandler;
using GBSApi.Errors;
using GBSApi.Interfaces.Course;
using GBSApi.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GBSApi.Controllers;

[Route("api/courses")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetCourses([FromQuery] QueryCourse queryCourse)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var courses = await _courseService.GetAllCourses(queryCourse);
        return Ok(courses);
    }

    [HttpGet]
    [Route("{id}")] // <- validation with string not allowed
    public async Task<IActionResult> GetCourse(string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var course = await _courseService.GetCourse(id);
        if (course == null) return NotFound();
        return Ok(course);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> CreateCourse(
        [FromRoute] string id,
        [FromBody] CourseCreateDto dto
    )
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var exists = await _courseService.CategoryExists(id);

        if (!exists) return BadRequest("Category does not exist");

        var course = await _courseService.CreateCourse(id, dto);
        return CreatedAtAction("CreateCourse", new { name = course.CourseName }, course);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateCourse([FromRoute] string id, [FromBody] CourseUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var course = await _courseService.UpdateCourse(id, dto);


        if (course == null) return BadRequest("Course or Category does not exist");
        return Ok(course);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var res = await _courseService.DeleteAsync(id);
        if (string.IsNullOrEmpty(res)) return NotFound();
        return Ok(res);
    }

    [HttpGet]
    [Route("/std/{id}")]
    public async Task<Result<CourseDto>> GetCourseNew(string id)
    {
        if (!ModelState.IsValid)
            return Result<CourseDto>.Failure(StatusErrors.DtoError);

        var course = await _courseService.GetCourse(id);
        return course == null ? Result<CourseDto>.Failure(StatusErrors.NotFound) : Result<CourseDto>.Success(course!);
    }
}