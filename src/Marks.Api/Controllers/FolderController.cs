namespace Marks.Api.Controllers
{
    using Application.Dto.Folder;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class FolderController(IFolderService folderService) : ControllerBase
    {
        private readonly IFolderService _folderService = folderService;
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFolderById(long id)
        {
            var folder = await _folderService.GetFolderByIdAsync(id);

            return Ok(folder);
        }

        [HttpGet]
        public async Task<IActionResult> GetFolders(
            [FromQuery] int? page = 1,
            [FromQuery] int? pageSize = 10,
            [FromQuery] string? filter = null,
            [FromQuery] long? userId = null
        )
        {
            var result = await _folderService.GetFoldersAsync(page, pageSize, filter, userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFolder([FromBody] FolderCreateDto folder)
        {
            var createdFolder = await _folderService.CreateFolderAsync(folder);
            return CreatedAtAction(
                nameof(GetFolderById),
                new { id = createdFolder.Id },
                createdFolder
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFolder(long id)
        {
            await _folderService.DeleteFolderAsync(id);
            return NoContent();
        }
    }
}
