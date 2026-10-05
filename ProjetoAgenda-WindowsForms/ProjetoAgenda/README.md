# Projeto Agenda - Windows Forms

Projeto acadêmico de gerenciamento de contatos pessoais desenvolvido em **C# com Windows Forms**.

## Funcionalidades

- Adicionar contatos
- Pesquisar contatos
- Alterar contatos
- Remover contatos
- Listar contatos
- Cadastrar múltiplos telefones por contato
- Definir telefone principal
- Calcular idade automaticamente
- Exibir data no formato `dd/mm/aaaa`

## Estrutura de classes

### Data
- `dia: int`
- `mes: int`
- `ano: int`
- `setData(int dia, int mes, int ano)`
- `ToString()`

### Telefone
- `tipo: string`
- `numero: string`
- `principal: bool`

### Contato
- `email: string`
- `nome: string`
- `dtNasc: Data`
- `telefones: List<Telefone>`
- `getIdade()`
- `adicionarTelefone(Telefone t)`
- `getTelefonePrincipal()`
- `ToString()`
- `Equals(object obj)`

### Contatos
- `agenda: List<Contato>` somente leitura externamente
- `adicionar(Contato c)`
- `pesquisar(Contato c)`
- `alterar(Contato c)`
- `remover(Contato c)`

## Requisitos

- Windows 10 ou 11
- Visual Studio 2022
- .NET 8 SDK
- Carga de trabalho **Desenvolvimento para desktop com .NET** instalada

## Como executar

1. Baixe ou clone este repositório.
2. Abra `ProjetoAgenda.sln` no Visual Studio 2022.
3. Aguarde a restauração do projeto.
4. Pressione `F5` para executar.

## Observação acadêmica

A interface Windows Forms apenas coleta e apresenta os dados. A lógica principal da agenda permanece nas classes de domínio, seguindo o diagrama proposto no exercício.
