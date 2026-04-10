using System.ComponentModel.DataAnnotations;

namespace EAZ.Chamados.Models;

public class Chamado
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe seu nome.")]
    [Display(Name = "Nome do Solicitante")]
    public string NomeSolicitante { get; set; } = string.Empty;

    [Required(ErrorMessage = "Selecione uma categoria.")]
    [Display(Name = "Categoria")]
    public string Categoria { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o título do problema.")]
    [Display(Name = "Título")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Descreva o problema.")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = string.Empty;

    public string Status { get; set; } = "Aberto";

    public string? Observacao { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.Now;

    public DateTime? AtualizadoEm { get; set; }
}
