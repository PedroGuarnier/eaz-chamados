using EAZ.Chamados.Data;
using EAZ.Chamados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EAZ.Chamados.Pages.Chamados;

public class ListaModel : PageModel
{
    private readonly AppDbContext _db;

    public ListaModel(AppDbContext db) => _db = db;

    public List<Chamado> Chamados { get; set; } = new();

    public string FiltroStatus { get; set; } = "";
    public string FiltroCategoria { get; set; } = "";

    public int TotalChamados { get; set; }
    public int TotalAbertos { get; set; }
    public int TotalAndamento { get; set; }
    public int TotalResolvidos { get; set; }

    public async Task OnGetAsync(string? status, string? categoria)
    {
        FiltroStatus = status ?? "";
        FiltroCategoria = categoria ?? "";

        var query = _db.Chamados.AsQueryable();

        if (!string.IsNullOrEmpty(FiltroStatus))
            query = query.Where(c => c.Status == FiltroStatus);

        if (!string.IsNullOrEmpty(FiltroCategoria))
            query = query.Where(c => c.Categoria == FiltroCategoria);

        Chamados = await query.OrderByDescending(c => c.CriadoEm).ToListAsync();

        TotalChamados = await _db.Chamados.CountAsync();
        TotalAbertos = await _db.Chamados.CountAsync(c => c.Status == "Aberto");
        TotalAndamento = await _db.Chamados.CountAsync(c => c.Status == "Em Andamento");
        TotalResolvidos = await _db.Chamados.CountAsync(c => c.Status == "Resolvido");
    }

    public async Task<IActionResult> OnPostAtualizarAsync(int id, string status, string? observacao)
    {
        var chamado = await _db.Chamados.FindAsync(id);
        if (chamado == null)
            return NotFound();

        chamado.Status = status;
        chamado.Observacao = observacao;
        chamado.AtualizadoEm = DateTime.Now;

        await _db.SaveChangesAsync();

        return RedirectToPage();
    }
}
