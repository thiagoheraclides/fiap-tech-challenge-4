# Fiap-Tech-Challenge-4

Instruções de build.

## Banco de dados

Este projeto foi criado usando banco de dados MS-SQL Server.
A solução está configurada para criar e gerar o banco de dados ao iniciar a aplicação. Para isto basta apenas alterar no arquivo appsettings.json, a propriedade ConnectionStrings, item Default, com as configurações relativas ao seu ambiente.

"ConnectionStrings": {
  "Default": "Data Source=**servidor ms sql**;Initial Catalog=**banco de dados**;User ID=**usuário**;Password=**senha**;TrustServerCertificate=true;" 
}

## API

Projeto criado utilizando .NET 8.

## Testes
Os testes estão disponibilizados na Solution do projeto, em parte apartada aos binários da API.

## Observações Complementares

Utilizamos swagger para documentação dos métodos disponibilizados na API.

## Critérios de aceite

- Criar a API de cadastro de usuário para validar as documentações e confirmar via e-mail processo finalizado.
- **Criar a API para acompanhar consórcios em andamentos e novos grupos**.
A API será composta de:
  - Pesquisar: Apresentar todos os **consórcios** em andamentos ou contratados pelo usuário;
  - Contratar: Usuário enviar proposta para o sistema confirmar os dados e realizar a contratação.
  - Ofertar lances: O sistema disponibilizará uma funcionalidade para ofertar lances e acompanhar os sorteios mensais dos contemplados;
  - Contemplação: O sistema tramitará a contemplação do consórcio até aquisição do ativo desejado.
- Pagamento: O Sistema permitirá acompanhar os pagamentos, tais como realizar adiantamento de cobranças futuras ou em atraso;
- **Criar a API para acompanhar ativos de previdência**
A API será composta de:
  - Pesquisar: Apresentar todos os ativos de **previdência** disponíveis ou contratados;
  - Contratar: Usuário enviar proposta para o sistema confirmar os dados e realizar a contratação.
  - Portabilidade: O sistema disponibilizará uma funcionalidade para realizar a portabilidade da previdência de outras instituições. 
  - Contemplação: O sistema tramitará a contemplação da previdência até o pagamento do ativo contratado.
  - Pagamentos: O Sistema permitirá acompanhar os pagamentos, tais como realizar alterações no contrato;
