# EAZ — Sistema de Chamados de TI

Sistema interno de gerenciamento de chamados de suporte para o Escritório de Advocacia Zveiter.

## Stack

- **ASP.NET Core 8** + Razor Pages
- **SQLite** + Entity Framework Core
- CSS puro (sem frameworks) — estética Art Deco preto/ouro

## Funcionalidades

- **Abertura de chamado** — qualquer usuário preenche nome, categoria, título e descrição
- **Painel do técnico** — lista todos os chamados com filtros por status e categoria
- **Estatísticas** — contadores de abertos, em andamento e resolvidos
- **Modal de atualização** — técnico altera o status e adiciona observações

## Como rodar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Setup

```bash
# Restaurar dependências
dotnet restore

# Rodar o projeto
dotnet run
```

Acesse: `https://localhost:5001` ou `http://localhost:5000`

O banco SQLite (`chamados.db`) é criado automaticamente na primeira execução.

## Estrutura do projeto

```
EAZ.Chamados/
├── Data/
│   └── AppDbContext.cs          # Contexto do EF Core
├── Models/
│   └── Chamado.cs               # Entidade principal
├── Pages/
│   ├── Index.cshtml             # Formulário de abertura
│   ├── Index.cshtml.cs
│   ├── Chamados/
│   │   ├── Lista.cshtml         # Painel do técnico
│   │   └── Lista.cshtml.cs
│   └── Shared/
│       ├── _Layout.cshtml       # Layout principal
│       └── _ValidationScriptsPartial.cshtml
├── wwwroot/
│   └── css/site.css             # Estilos Art Deco
├── Program.cs
├── appsettings.json
└── EAZ.Chamados.csproj
```

## Próximos passos sugeridos

- [ ] Autenticação simples (senha do técnico para acessar o painel)
- [ ] Notificação por e-mail ao abrir chamado
- [ ] Exportação de relatório em PDF/Excel
- [ ] Histórico de alterações por chamado
- [ ] Deploy na rede interna (IIS ou Linux + nginx)
