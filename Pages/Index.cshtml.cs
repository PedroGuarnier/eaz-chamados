using EAZ.Chamados.Data;
using EAZ.Chamados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EAZ.Chamados.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;

    public IndexModel(AppDbContext db) => _db = db;

    [BindProperty]
    public Chamado Input { get; set; } = new();

    public bool Sucesso { get; set; }
    public int ChamadoId { get; set; }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        _db.Chamados.Add(Input);
        await _db.SaveChangesAsync();

        Sucesso = true;
        ChamadoId = Input.Id;
        Input = new();
        ModelState.Clear();

        return Page();
    }
}
