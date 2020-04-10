using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;

namespace RazorPagesTutorial.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTutorial.Data.RazorPagesTutorialContext _context;

        public DetailsModel(RazorPagesTutorial.Data.RazorPagesTutorialContext context)
        {
            _context = context;
        }


        public List<Product> Products { get; set; }

        public Product Product { get; set; }

        public int SelectedId { get; set; }


        //public void OnGet(int? Id) {
        //    RedirectToPage("/Product/Details?ID=" + Id);        
        //}

        //public IActionResult Index()
        //{


        //}

        //public IActionResult OnPost()
        //{
        //    return new RedirectToPageResult("/Product/Details?ID=1" + SelectedId);
        //}


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            

            Product = await _context.Product.AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);
            Products = await _context.Product.ToListAsync();

            
            return Page();
        }
    }
}
