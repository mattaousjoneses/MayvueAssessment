using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web.Http.Cors;

namespace MayvueMotionPictures.Controllers
{
    //[EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class MotionPicturesController : ControllerBase
    {
        // GET: api/<MotionPicturesController>
        [HttpGet]
        public ActionResult Get()
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
                    toReturn = sqlDataToJson(reader);
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }

            return Ok(toReturn);
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
            var MotionPicture = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(value);

            string title = MotionPicture.Title;
            string desc = MotionPicture.Description;
            string rY = MotionPicture.ReleaseYear;

            string queryString = $"INSERT INTO MotionPictures VALUES ('{title}', '{desc}', '{rY}') GO";
            string connectionString = "Server=(local);Database=MotionPictureDB;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }

        }

        // PUT api/<MotionPicturesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            string title="", desc="", rY="";

            var MotionPicture = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(value);

            title = MotionPicture.Title;
            desc = MotionPicture.Description;
            rY = MotionPicture.ReleaseYear;

            string queryString = $"UPDATE MotionPictures SET Title='{title}', Description='{desc}', ReleaseYear='{rY}' WHERE id={id} GO" ;
            string connectionString = "Server=(local);Database=MotionPictureDB;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }

        // DELETE api/<MotionPicturesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string queryString = "DELETE FROM MotionPictures WHERE id="+id+" GO";
            string connectionString = "Server=(local);Database=MotionPictureDB;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
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
