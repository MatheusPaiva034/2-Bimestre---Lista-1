# 2º Bimestre — Lista 1: API com JWT

Atividade acadêmica de autenticação e autorização usando C#, ASP.NET Core .NET 10 e JSON Web Token (JWT).

## Requisitos
- .NET 10 SDK
- Postman (para os testes)

## Como executar
1. Clone o repositório.
2. Abra a pasta `ApiJwt` no terminal.
3. Execute `dotnet restore`.
4. Execute `dotnet run`.
5. Use o endereço mostrado no terminal para fazer as requisições no Postman.

## Credenciais didáticas
- Usuário: `admin`
- Senha: `123456`

## Rotas
- `POST /api/auth/login`: recebe `usuario` e `senha` em JSON e retorna JWT quando as credenciais estão corretas.
- `GET /api/usuario/perfil`: rota protegida; exige `Authorization: Bearer <token>`.

## Testes esperados
1. Login válido: `200 OK` e token.
2. Login inválido: `401 Unauthorized`.
3. Perfil sem token: `401 Unauthorized`.
4. Perfil com token válido: `200 OK`.

## Segurança
Este projeto é exclusivamente didático. A chave de assinatura é de demonstração. Em produção, armazene segredos em variáveis de ambiente ou em um gerenciador de segredos e nunca publique chaves reais.

## Evidências
Adicione nesta seção as capturas de tela dos quatro testes realizados no Postman, após executá-los localmente.