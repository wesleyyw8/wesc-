using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace angulardemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestHahaController : ControllerBase
    {

        private readonly ILogger<TestHahaController> _logger;

        public TestHahaController(ILogger<TestHahaController> logger)
        {
            _logger = logger;
        }

        

        [HttpGet]
        public IEnumerable<String> Get()
        {
            var dbCon = DBConnect.Instance();
            dbCon.DatabaseName = "wes";
            System.Diagnostics.Debug.WriteLine("before is connect2!!");
            if (dbCon.IsConnect())
            {
                System.Diagnostics.Debug.WriteLine("connected!");
                //suppose col0 and col1 are defined as VARCHAR in the DB
                //string query = "SELECT col0,col1 FROM YourTable";
                //var cmd = new MySqlCommand(query, dbCon.Connection);
                //var reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    string someStringFromColumnZero = reader.GetString(0);
                //    string someStringFromColumnOne = reader.GetString(1);
                //    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                //}
                dbCon.Close();
            }
            string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
          return cars;
          //return cars;
        }
    }
}
