using System.Data;

public static class DbInitializer
{
    public static void Initialize(DbContext context)
    {
        try
        {

            // Look for any students.
            if (context.Posts.Any())
            {
                context.Posts.RemoveRange(context.Posts);
                context.SaveChanges();
            }

            // Look for any students.
            if (context.Blogs.Any())
            {
                context.Blogs.RemoveRange(context.Blogs);
                context.SaveChanges();
            }

            var blogs = new Blog[]
            {
                new Blog{BlogId=1, Url="/blog1"},
                new Blog{BlogId=2, Url="/blog2"},
                new Blog{BlogId=3, Url="/step-4"},
                new Blog{BlogId=4, Url="/secret-blog"},
            };

            context.Blogs.AddRange(blogs);
            context.SaveChanges();

            var posts = new Post[]
            {
                new Post{BlogId=1, Title="My first post",Content="Hello world"},
                new Post{BlogId=2, Title="My second post",Content="Hello world"},
                new Post{BlogId=3, Title="Step 4",Content="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdGU0IjoiVG8gY29tcGxldGUgdGhlIGxhc3Qgc3RlcCwgeW91IHdpbGwgbmVlZCB0byBidWlsZCB0aGUgZG9ja2VyIGltYWdlIHByZXNlbnQgaW4gdGhlIHByb2plY3QuIFRoaXMgd2lsbCBzaG93IHRoZSByZXN1bHQgcGFnZSBhdCBodHRwOi8vbG9jYWxob3N0OjgwODAvaW5kZXguaHRtbC4gTWFrZSBhIHNjcmVlbnNob3QgYW5kIHNlbmQgaXQgdG8gbWUuIn0.DXYt8_Xrtnq9MdphZP74WtXNdWZY6Epwwg0QJMppyiE"},
                new Post{BlogId=4, Title="Old",Content="assets/img.png"}
            };

            context.Posts.AddRange(posts);
            context.SaveChanges();

        }
        catch (Exception ex)
        {
            // database file is missing
            throw new DataException("database file is missing,run db creation command ");
        }
    }
}