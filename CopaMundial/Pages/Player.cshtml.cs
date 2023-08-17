using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CopaMundial.Pages
{
    public class PlayerModel : PageModel
    {
        public int Id { get; set; }
        public void OnGet(int parametroId)
        {
            Id = parametroId;
        }
    }
}
