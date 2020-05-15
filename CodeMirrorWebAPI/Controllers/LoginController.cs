using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodeMirrorWebAPI.Controllers
{
    [ApiController]
    [Route("loginController")]
    public class LoginController : ControllerBase
    {
        [HttpGet("Login/{username}/{password}")]
        public ActionResult<string> Login(string username, string password)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                SqlCommand command = new SqlCommand("usp_Login", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FirstName", username));
                command.Parameters.Add(new SqlParameter("@LastName", password));

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(table);
                connection.Close();
            }


            if (table.Rows.Count == 0)
            {
                return NoContent();
            }

            var accID = (int)table.Rows[0]["AccountID"];
            var currLevel = (int)table.Rows[0]["CurrentLevel"];
            
            if (accID == -1)
            {
                return StatusCode((int)HttpStatusCode.Conflict, $"{accID}");
            }
            return Ok($"{accID}, {currLevel}"); 
        }
    }
}
