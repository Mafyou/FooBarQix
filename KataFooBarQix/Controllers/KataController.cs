namespace KataFooBarQix.Controllers;

[ApiController]
[Route("[controller]")]
public class KataController : ControllerBase
{
    private readonly IMediator _mediator;

    public KataController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost(Name="Compute")]
    public async Task<ActionResult<string>> Index(string rawInput)
    {
        var query = new GetCompute(rawInput);
        return Ok(await _mediator.Send(query));
    }
}