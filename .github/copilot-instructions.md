# Instruções para Agentes AI - Projeto copilotdemo

## Arquitetura e Estrutura

Este é um projeto ASP.NET Core Web API que segue uma arquitetura em camadas:

- **Controllers/** - Controladores da API REST
- **Models/** - Modelos de domínio
- **Repositories/** - Camada de acesso a dados
- **Tests/** - Testes unitários

### Padrões Principais

1. **Injeção de Dependência**
   - Interfaces são injetadas via construtor
   - Exemplo: `ProdutosController` recebe `IProdutoRepository`
   ```csharp
   public ProdutosController(IProdutoRepository repository)
   {
       _repository = repository;
   }
   ```

2. **Padrão Repository**
   - Abstração do acesso a dados através de interfaces
   - Exemplo: `IProdutoRepository` define operações CRUD

3. **Tratamento de Erros**
   - Try/catch em todos os métodos do controller
   - Retornos padronizados:
     - 200 OK: Sucesso
     - 404 NotFound: Recurso não encontrado
     - 400 BadRequest: Dados inválidos
     - 500 Internal Server Error: Erros não tratados

## Fluxos de Desenvolvimento

### Testes Unitários

- Utiliza xUnit e Moq para testes
- Nomenclatura: `[Metodo]_[Cenario]_[ResultadoEsperado]`
- Padrão AAA (Arrange, Act, Assert)
- Exemplo:
```csharp
[Fact]
public void GetProdutos_QuandoExistemProdutos_RetornaOkComListaDeProdutos()
{
    // Arrange
    var produtosMock = new List<Produto>();
    _mockRepository.Setup(repo => repo.GetAll()).Returns(produtosMock);
    
    // Act
    var resultado = _controller.GetProdutos();
    
    // Assert
    var okResult = Assert.IsType<OkObjectResult>(resultado.Result);
}
```

### Convenções de Código

1. **Controllers**
   - Sufixo "Controller" para todas as classes controller
   - Atributo [Route("api/[controller]")] para definir rotas
   - Retornos tipo ActionResult<T> para endpoints

2. **Modelos**
   - Classes POCO sem lógica de negócio
   - Validações via DataAnnotations quando necessário

3. **Repositórios**
   - Interface I[Nome]Repository define contrato
   - Implementação concreta em [Nome]Repository

## Workflows Críticos

### Build e Testes
```powershell
# Restaurar pacotes
dotnet restore

# Build
dotnet build

# Executar testes
dotnet test
```

### Debugging
- Configurado para usar o ambiente de desenvolvimento por padrão
- Utilize o arquivo `launchSettings.json` para configurações específicas

## Integrações

- Banco de dados (implementação do repositório pendente)
- Sistema de logs (pendente de implementação)

## Pontos de Atenção

1. **Validações**
   - Sempre validar IDs > 0
   - Verificar nulidade dos objetos recebidos
   - Validar ModelState antes de processar requisições

2. **Respostas HTTP**
   - Usar tipos corretos de retorno HTTP
   - Incluir mensagens descritivas nos erros
