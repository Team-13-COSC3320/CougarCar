using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Models;

namespace RazorPagesTutorial
{
    public class ReviewCreateModel : PageModel
    {
        private readonly RazorPagesTutorial.Data.RazorPagesTutorialContext _context;

        public ReviewCreateModel(RazorPagesTutorial.Data.RazorPagesTutorialContext context)
        {
            _context = context;
        }

      

        [BindProperty]
        public Review Review { get; set; }

        public IList<Product> Products { get; set; }

        public Product Product { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FindAsync(id);
            var rid = Review.R_ID;
            var pid = Product.ID;
            var content = Review.R_Content;
            var title = Review.R_Title;
            var star = Review.R_Star;
            var userid = Review.R_UID;

            string connection = "Data Source=sql5053.site4now.net;User ID=DB_A573D4_team13_admin;Password=Team13shop;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection sqlConnection = new SqlConnection(connection);

            string query = "Insert into dbo.REVIEW" +

                        " (R_UID, R_Title, R_Content, R_Star, ID)  " +

                        "VALUES(@R_UID, @R_Title, @R_Content, @R_Star, @ID)";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.Add("@R_UID", SqlDbType.Int).Value = userid;

            cmd.Parameters.Add("@R_Title", SqlDbType.Char).Value = title;

            cmd.Parameters.Add("@R_Content", SqlDbType.Char).Value = content;

            cmd.Parameters.Add("@R_Star", SqlDbType.Int).Value = star;

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = pid;

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();


            await _context.SaveChangesAsync();
            

            return RedirectToPage("./ReviewTable");
        }

    }
}