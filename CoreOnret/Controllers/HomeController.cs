using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreOnret.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;



namespace CoreOnret.Controllers
{

    
   
    public class HomeController : Controller
    {

        private readonly IConfiguration configuration;

       

        public List<Product> productList = new List<Product>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IConfiguration config)
        {
            this.configuration = config;
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EDIT()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EDIT(string title)
        {

            string connectionString = configuration.GetConnectionString("DefaultConnectionString");
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            Product pr = new Product();
            if (pr.Content.Exists(p => p.title == title))
            {
                ViewData["Message"] = "The product was already exist";
                
            }
            else
            {
                string id=string.Empty, tit= string.Empty, description= string.Empty, langcode= string.Empty;

                for(int i = 0; i <= pr.Content.Count-1; i++)
                {
                    id = pr.Content[i].ToString();
                    tit = pr.Content[i].ToString();
                    description = pr.Content[i].ToString();
                    langcode = pr.Content[i].ToString();

                }
                SqlCommand add = new SqlCommand("insert into Products(title,description,LangCode,BuyPrice,ListPrice,SellPrice,currentType,CategoryName,Image,BrandName) values(@title,@description,@LangCode,@BuyPrice,@ListPrice,@SellPrice,@currentType,@CategoryName,@Image,@BrandName)",con);
                add.Parameters.AddWithValue("@title", title);
                add.Parameters.AddWithValue("@description", description);
                add.Parameters.AddWithValue("@LangCode", langcode);
                add.Parameters.AddWithValue("@BuyPrice", Convert.ToDecimal(pr.Currency.BuyPrice));
                add.Parameters.AddWithValue("@ListPrice", Convert.ToDecimal(pr.Currency.ListPrice));
                add.Parameters.AddWithValue("@currentType", Convert.ToDecimal(pr.Currency.SellPrice));                       
                add.Parameters.AddWithValue("@CategoryName", pr.Currency.currentcyType);
                add.Parameters.AddWithValue("@Image", pr.CategoryName);
                add.Parameters.AddWithValue("@BrandName", pr.Images);
                add.Parameters.AddWithValue("@description", pr.BrandName);

                add.ExecuteNonQuery();
                con.Close();

                return RedirectToAction("ProductList", "Home");
            }
            return View();
        }

        public IActionResult ProductList()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
