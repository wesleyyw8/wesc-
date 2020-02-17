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
    public class ApiNewsLetterController : ControllerBase
    {

        private readonly ILogger<ApiNewsLetterController> _logger;

        public ApiNewsLetterController(ILogger<ApiNewsLetterController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost]
        public Boolean Post([FromBody]NewsLetterModel value)
        {
            var dbCon = DBConnect.Instance();
            if (dbCon.IsConnect())
            {
                if (!isEmailAlreadyExist(value.email, dbCon))
                {
                    string query =
                    "INSERT INTO NEWSLETTER values (null, '"
                    + value.email + "','"
                    + value.heardAbout + "','"
                    + value.reasonSingup + "')";
                    try
                    {
                        insertIntoDatabase(query, dbCon);
                        return true;
                    } catch(Exception ex)
                    {
                        throw (ex);
                    }
                } else
                {
                    System.Diagnostics.Debug.WriteLine("email already exists: " + value.email);
                }
            }
            return false;
        }

        private Boolean isEmailAlreadyExist(string email, DBConnect dbCon)
        {
            string query = "select * from NEWSLETTER where emailAddress = '"+ email + "';";
            var cmd = new MySqlCommand(query, dbCon.Connection);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        private void insertIntoDatabase(string query, DBConnect dbCon)
        {
            System.Diagnostics.Debug.WriteLine("query: " + query);
            var cmd = new MySqlCommand(query, dbCon.Connection);
            int rowsAffected = cmd.ExecuteNonQuery();
            System.Diagnostics.Debug.WriteLine("rows affected" + rowsAffected);
        }

        //[HttpGet]
        //public IEnumerable<String> Get()
        //{
        //    var dbCon = DBConnect.Instance();
        //    if (dbCon.IsConnect())
        //    {
        //        //suppose col0 and col1 are defined as VARCHAR in the DB
        //        //string query = "SELECT col0,col1 FROM YourTable";
        //        //var cmd = new MySqlCommand(query, dbCon.Connection);
        //        //var reader = cmd.ExecuteReader();
        //        //while (reader.Read())
        //        //{
        //        //    string someStringFromColumnZero = reader.GetString(0);
        //        //    string someStringFromColumnOne = reader.GetString(1);
        //        //    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
        //        //}
        //        dbCon.Close();
        //    }
        //    string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
        //    return cars;
        //}
    }
}
