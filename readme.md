![banner](./docs/banner.png)

# Canal DEPLOY

# Demonstração do `dotnet run app.cs` - .NET 10 Preview 6

Este repositório demonstra a nova funcionalidade `dotnet run app.cs` introduzida no .NET 10 Preview 4, que permite executar arquivos C# diretamente sem precisar criar um projeto.

## 🚀 O que é `dotnet run app.cs`?

Uma nova forma mais simples de começar com C# e .NET 10! Agora você pode executar um arquivo `.cs` diretamente, similar a linguagens de script como Python ou JavaScript.

### ✨ Principais benefícios:
- **Início rápido, sem arquivo de projeto** - Perfeito para aprendizado, experimentação e scripts pequenos
- **Integração nativa com CLI** - Sem ferramentas extras, apenas `dotnet` e seu arquivo `.cs`
- **Escalabilidade** - Quando seu script crescer, pode evoluir para um projeto completo

## 📂 Arquivos de demonstração

- `api.cs` - Exemplo de API web simples para Linux
- `app.cs` - Exemplo de API web simples para Windows
- `canalDEPLOY.cs` - Exemplo de script simples escrever Canal Deploy

## 🔧 Comandos básicos

```bash
# Executar um arquivo C# diretamente
dotnet run <app>.cs

# Converter para projeto completo
dotnet project convert app.cs
```

## 🪟 Instalação do .NET 10 Preview no Windows

```powershell
winget install --id Microsoft.DotNet.SDK.Preview --version 10.0.100-preview.6.25358.103 --source winget
```

## 🐧 Instalação do .NET 10 Preview no Linux

```bash
curl -sSL https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh

chmod +x dotnet-install.sh

./dotnet-install.sh -Channel 10.0.1xx -Quality preview
```
# Configurar variáveis de ambiente
```bash
echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.bashrc
echo 'export PATH=$DOTNET_ROOT:$PATH:$DOTNET_ROOT/tools' >> ~/.bashrc
```
# Recarregar as variáveis de ambiente
```bash
source ~/.bashrc
```
# Verificar instalação

```bash
dotnet --version
dotnet --list-sdks
```
## 📝 Diretivas de arquivo para apps baseados em arquivo

O .NET 10 introduz diretivas especiais que podem ser usadas diretamente nos arquivos `.cs`:

### 📦 Referenciando pacotes NuGet com `#:package`

```csharp
#:package Humanizer@2.14.1

using Humanizer;

var dotNet10Released = DateTimeOffset.Parse("2025-11-14");
var since = DateTimeOffset.Now - dotNet10Released;

Console.WriteLine($"Faz {since.Humanize()} que o .NET 10 foi lançado.");
```

### 🌐 Especificando SDK com `#:sdk`

```csharp
#:sdk Microsoft.NET.Sdk.Web

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapGet("/", () => "Olá, mundo!");
app.Run();
```

### ⚙️ Configurando propriedades MSBuild com `#:property`

```csharp
#:property LangVersion preview

// Seu código aqui pode usar recursos de linguagem preview
```

### 🐧 Usando shebang para scripts shell

```csharp
#!/usr/bin/dotnet run
Console.WriteLine("Olá de um script C#!");
```

```bash
# Tornar executável e rodar diretamente
chmod +x app.cs
./app.cs
```

## 🔄 Convertendo para projeto

Quando seu arquivo crescer em complexidade, você pode convertê-lo facilmente:

```bash
dotnet project convert app.cs
```

Isso irá:
- Criar um novo diretório com o nome do arquivo
- Gerar um arquivo `.csproj`
- Mover seu código para `Program.cs`
- Traduzir todas as diretivas `#:` para propriedades MSBuild

## 📚 Exemplos práticos

### Exemplo 1: API Web Simples

```csharp
#:sdk Microsoft.NET.Sdk.Web
#:package Microsoft.AspNetCore.OpenApi@10.*-*

var builder = WebApplication.CreateBuilder();
builder.Services.AddOpenApi();

var app = builder.Build();
app.MapGet("/", () => "Hello, world!");
app.Run();
```

### Exemplo 2: Script com pacote externo

```csharp
#:package Newtonsoft.Json@13.0.3

using Newtonsoft.Json;

var pessoa = new { Nome = "João", Idade = 30 };
var json = JsonConvert.SerializeObject(pessoa, Formatting.Indented);
Console.WriteLine(json);
```

## 🆚 Comparação com projetos tradicionais

| Característica | `dotnet run app.cs` | Projeto tradicional |
|----------------|---------------------|-------------------|
| Setup inicial | Zero configuração | Requer `dotnet new` |
| Estrutura | Um arquivo | Múltiplos arquivos |
| Dependências | Diretivas `#:` | Arquivo `.csproj` |
| Ideal para | Scripts, prototipagem | Aplicações completas |

## 🎯 Casos de uso ideais

- 📖 **Aprendizado e ensino** - Sem barreiras para iniciantes
- 🧪 **Prototipagem rápida** - Teste ideias rapidamente
- 🤖 **Scripts de automação** - Substitua PowerShell/Bash por C#
- 🔧 **Ferramentas CLI simples** - Scripts utilitários
- 📊 **Análise de dados** - Scripts para processamento rápido

## 🔗 Links úteis

- [Blog post oficial](https://devblogs.microsoft.com/dotnet/announcing-dotnet-run-app/)
- [Vídeo demonstração Microsoft Build](https://www.youtube.com/watch?v=98MizuB7i-w)
- [Documentação completa](https://github.com/dotnet/sdk/blob/main/documentation/general/dotnet-run-file.md)

## 🏃‍♂️ Começando agora

1. **Execute os comandos de instalação acima**
2. **Crie um arquivo `hello.cs`:**
   ```csharp
   Console.WriteLine("Olá, .NET 10!");
   ```
3. **Execute:** `dotnet run hello.cs`
4. **Experimente as diretivas** nos exemplos acima!

---

> **Nota:** Esta funcionalidade está disponível a partir do .NET 10 Preview 4. Para suporte completo no VS Code, instale a versão pré-lançamento da extensão C# (versão 2.79.8+).
