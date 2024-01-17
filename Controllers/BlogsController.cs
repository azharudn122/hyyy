using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly string connectionString = "Data Source=DESKTOP-8R5DP8G\\MSSQLSERVER02;Initial Catalog=YourDatabaseName;Integrated Security=True";

        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            return dbConnection.Query<Blog>("SELECT * FROM Blogs");
        }
    }

    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // Add other properties as needed
    }
}
