using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CopaMundial.Pages
{
    public class playerTeamsModel : PageModel
    {
        public string codigo { get; set; }
        public void OnGet(string parametroCod)
        {
            codigo = parametroCod;
        }
    }
}
