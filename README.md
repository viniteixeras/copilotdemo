# API de Gerenciamento de Produtos

Este projeto é uma API RESTful desenvolvida em ASP.NET Core para gerenciamento de produtos, implementando operações CRUD (Create, Read, Update, Delete) com boas práticas de desenvolvimento e documentação.

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 9.0
- xUnit para testes unitários
- Moq para mocking em testes
- Swagger/OpenAPI para documentação

## 📁 Estrutura do Projeto

```
copilotdemo/
├── Controllers/
│   └── ProdutosController.cs    # Controlador REST para produtos
├── Models/
│   └── Produto.cs               # Modelo de domínio
├── Repositories/
│   ├── IProdutoRepository.cs    # Interface do repositório
│   └── ProdutoRepository.cs     # Implementação do repositório
└── Tests/
    └── ProdutosControllerTests.cs # Testes unitários
```

## 🔄 Endpoints da API

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | /api/produtos | Lista todos os produtos |
| GET | /api/produtos/{id} | Obtém um produto específico |
| POST | /api/produtos | Cria um novo produto |
| PUT | /api/produtos/{id} | Atualiza um produto existente |
| DELETE | /api/produtos/{id} | Remove um produto |

### Exemplos de Respostas

#### GET /api/produtos
```json
[
  {
    "id": 1,
    "nome": "Produto 1",
    "preco": 10.0
  },
  {
    "id": 2,
    "nome": "Produto 2",
    "preco": 20.0
  }
]
```

## 🛠️ Como Executar

1. Clone o repositório
```powershell
git clone [url-do-repositorio]
```

2. Restaure os pacotes
```powershell
dotnet restore
```

3. Execute o projeto
```powershell
dotnet run
```

4. Acesse a API em `https://localhost:7000` (ou a porta configurada)

## 🧪 Executando os Testes

```powershell
dotnet test
```

## 📝 Padrões e Práticas

### Tratamento de Erros
- Padronização de respostas de erro
- Mensagens descritivas
- Logging de exceções (em implementação)

### Validações
- Verificação de IDs válidos
- Validação de modelo via DataAnnotations
- Verificação de existência de recursos

### Documentação
- Comentários XML para documentação da API
- Swagger/OpenAPI para documentação interativa
- Atributos para descrição de respostas HTTP

## 🔒 Boas Práticas Implementadas

1. **Arquitetura em Camadas**
   - Separação clara de responsabilidades
   - Injeção de dependência
   - Padrão Repository

2. **Testes**
   - Testes unitários com xUnit
   - Mocking com Moq
   - Nomenclatura descritiva dos testes

3. **Convenções**
   - Padrões de nomenclatura consistentes
   - Rotas RESTful
   - Respostas HTTP padronizadas

## 🚧 Melhorias Futuras

- [ ] Implementação de logging
- [ ] Persistência de dados em banco
- [ ] Autenticação e autorização
- [ ] Paginação de resultados
- [ ] Cache de dados
- [ ] Documentação Swagger completa

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
