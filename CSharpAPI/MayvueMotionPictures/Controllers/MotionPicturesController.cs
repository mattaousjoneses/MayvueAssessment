using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace MayvueMotionPictures.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotionPicturesController : ControllerBase
    {
        // GET: api/<MotionPicturesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string toReturn = string.Empty;
            
            string queryString = "SELECT *  FROM  MotionPictures";
            string connectionString = "Server=(local);Database=MotionPictureDB;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Object> dataReturn = new System.Collections.Generic.List<Object>();
                try
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("ID = {0}, Title = {1}",
                        reader["ID"], reader["Title"]));// etc
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/<MotionPicturesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MotionPicturesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MotionPicturesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MotionPicturesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private String sqlDataToJson(SqlDataReader dataReader)
        {
            var dataTable = new DataTable();
            dataTable.Load(dataReader);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dataTable);
            return JSONString;
        }
    }
}

/*
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MayvueMotionPictures.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotionPicturesController : ControllerBase
    {
        // GET: api/<MotionPicturesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/<MotionPicturesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MotionPicturesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MotionPicturesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MotionPicturesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
*/