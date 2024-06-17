using BookstoreManagemant.Communication.Requests;
using BookstoreManagemant.Communication.Responses;
using BookstoreManagemant.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreManagemant.Controllers;
[Route("BookStore/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredBook), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] ResquestRegisterBook request)
    {
        var response = new ResponseRegisteredBook
        {
            Id = 1,
            Title = request.Title,
            Author = request.Author,
            Gender = request.BookType.ToString()
        };

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var response = new List<Book>
        {
            new Book { Id = 1, Title = "Game of Thrones", Author = "George R. R. Martin", Gender = "Fiction" },
            new Book { Id = 2, Title = "The Lord of the Rings", Author = "J. R. R. Tolkien", Gender = "Fiction" }
        };

        if (response.Count == 0)
            return NotFound("Nenhum registro encontrado!");

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update(int id, [FromBody] RequestUpdateBook request)
    {
        if (request == null)
            return NoContent();

        return Ok($"Registro N° {id} alterado com sucesso!");
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        if (id == 0)
            return NoContent();

        return Ok($"Registro N° {id} excluído com sucesso!");
    }
}
