using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace WebApplication1.Controllers
{
    // Route API access between url htt://myaddress:5127/api....
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public ProductController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // Method GET for capture data in sql server. select all fields and data.

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select ID, PRODUTO_PUBLI, PRODUTO_FINAL,DIVISOR,
                    convert(varchar(10),DT_INICIAL,120) as DT_INICIAL,
                    convert(varchar(10),DT_FINAL,120) as DT_FINAL,GRUPO,
                    PERCENTUAL_RATEIO,CCUSTO_CLI,ORDEM_INTERNA
                    from 
                    dbo.ims_investimento_produto
                    ";

            DataTable table = new DataTable();
            // connection string
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {

                    // Execute script sql for show data in screem
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }

        // Method POST for insert data in sql server. insert with script bellow.
        [HttpPost]
        public JsonResult Post(Product prod)
        {
            string query = @"
                    insert into dbo.ims_investimento_produto
                    (PRODUTO_PUBLI,PRODUTO_FINAL,DIVISOR,DT_INICIAL,DT_FINAL,GRUPO,PERCENTUAL_RATEIO,CCUSTO_CLI,ORDEM_INTERNA)
                    values (@PRODUTO_PUBLI,@PRODUTO_FINAL,@DIVISOR,@DT_INICIAL,@DT_FINAL,@GRUPO,@PERCENTUAL_RATEIO,@CCUSTO_CLI,@ORDEM_INTERNA)
                    ";

            DataTable table = new DataTable();
            // connection string
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@PRODUTO_PUBLI", prod.PRODUTO_PUBLI);
                    myCommand.Parameters.AddWithValue("@PRODUTO_FINAL", prod.PRODUTO_FINAL);
                    myCommand.Parameters.AddWithValue("@DIVISOR", prod.DIVISOR);
                    myCommand.Parameters.AddWithValue("@DT_INICIAL", prod.DT_INICIAL);
                    myCommand.Parameters.AddWithValue("@DT_FINAL", prod.DT_FINAL);
                    myCommand.Parameters.AddWithValue("@GRUPO", prod.GRUPO);
                    myCommand.Parameters.AddWithValue("@PERCENTUAL_RATEIO", prod.PERCENTUAL_RATEIO ?? (object)DBNull.Value);
                    myCommand.Parameters.AddWithValue("@CCUSTO_CLI", prod.CCUSTO_CLI);
                    myCommand.Parameters.AddWithValue("@ORDEM_INTERNA", prod.ORDEM_INTERNA);
                    // Execute script sql for show data in screem
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }

        // Method PUT for update data in sql server. update by ID with script bellow.
        [HttpPut]
        public JsonResult Put(Product prod)
        {
            string query = @"
                    update dbo.ims_investimento_produto 
                    set PRODUTO_PUBLI=@PRODUTO_PUBLI,
                    PRODUTO_FINAL=@PRODUTO_FINAL,
                    DIVISOR=@DIVISOR,
                    DT_INICIAL=@DT_INICIAL,
                    DT_FINAL=@DT_FINAL,
                    GRUPO=@GRUPO,
                    PERCENTUAL_RATEIO=@PERCENTUAL_RATEIO,
                    CCUSTO_CLI=@CCUSTO_CLI,
                    ORDEM_INTERNA=@ORDEM_INTERNA
                    where ID=@ID
                    ";

            DataTable table = new DataTable();
            // connection string
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID", prod.ID);
                    myCommand.Parameters.AddWithValue("@PRODUTO_PUBLI", prod.PRODUTO_PUBLI);
                    myCommand.Parameters.AddWithValue("@PRODUTO_FINAL", prod.PRODUTO_FINAL);
                    myCommand.Parameters.AddWithValue("@DIVISOR", prod.DIVISOR);
                    myCommand.Parameters.AddWithValue("@DT_INICIAL", prod.DT_INICIAL);
                    myCommand.Parameters.AddWithValue("@DT_FINAL", prod.DT_FINAL);
                    myCommand.Parameters.AddWithValue("@GRUPO", prod.GRUPO);
                    myCommand.Parameters.AddWithValue("@PERCENTUAL_RATEIO", prod.PERCENTUAL_RATEIO ?? (object)DBNull.Value);
                    myCommand.Parameters.AddWithValue("@CCUSTO_CLI", prod.CCUSTO_CLI);
                    myCommand.Parameters.AddWithValue("@ORDEM_INTERNA", prod.ORDEM_INTERNA);
                    // Execute script sql for show data in screem
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }

        // Method DELET for delete data in sql server. delete by ID with script bellow.
        [HttpDelete("{ID}")]
        public JsonResult Delete(int ID)
        {
            string query = @"
                    delete from dbo.ims_investimento_produto 
                    where ID=@ID
                    ";

            DataTable table = new DataTable();
            // connection string
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID", ID);
                    // Execute script sql for show data in screem
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Deleted Successfully");
        }


    }
}
