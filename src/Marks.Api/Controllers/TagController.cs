using Marks.Application.Dto.Tag;
using Marks.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marks.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController(ITagService _tagService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagById(long id)
        {
            var tag = await _tagService.GetTagByIdAsync(id);
            if (tag == null)
                return NotFound();

            return Ok(tag);
        }

        [HttpGet]
        public async Task<IActionResult> GetTags(
            [FromQuery] int? page = 1,
            [FromQuery] int? pageSize = 10,
            [FromQuery] string? filter = null,
            [FromQuery] long? userId = null
        )
        {
            var result = await _tagService.GetTagsAsync(page, pageSize, filter, userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] TagCreateDto tag)
        {
            var createdTag = await _tagService.CreateTagAsync(tag);
            return CreatedAtAction(nameof(GetTagById), new { id = createdTag.Id }, createdTag);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(long id)
        {
            await _tagService.DeleteTagAsync(id);
            return NoContent();
        }
    }
}
