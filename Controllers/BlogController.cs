using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace test_dev_moovency.Controllers;

[ApiController]
[Route("api/blog")]
public class BlogController : ControllerBase
{
    private readonly DbContext context;

    private readonly ILogger<BlogController> _logger;

    public BlogController(ILogger<BlogController> logger, DbContext context)
    {
        _logger = logger;
        this.context = context;
    }

    /// GET api/blog/step3
    /// to do use this api now the old one is obsolete
    [HttpGet("step3")]
    public async Task<IEnumerable<Blog>> Get()
    {
        IIncludableQueryable<Blog, List<Post>> blogs = context.Blogs.Include(x => x.Posts);
        List<Blog> results = await blogs.ToListAsync();

        // DO NOT REMOVE
        foreach (Blog r in results)
            foreach (Post p in r.Posts)
                p.Blog = null;

        return results;
    }

    /// GET api/blog/:blogId
    /// Get a blog by its database ID
    [HttpGet("{blogId}")]
    public async Task<IEnumerable<Blog>> GetOne(int blogId)
    {
        List<Blog> results = new();

        // TODO: query for single blog
        // use linq and entity framework
        // we will need to "Include the posts too"
        // https://docs.microsoft.com/fr-fr/ef/core/querying/

        // var blog = context.Blogs ...

        // DO NOT REMOVE
        foreach (Blog r in results)
            foreach (Post p in r.Posts)
                p.Blog = null;

        return results;
    }
}
