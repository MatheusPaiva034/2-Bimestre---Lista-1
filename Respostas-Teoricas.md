# Parte 1 — Respostas teóricas

## Exercício 1 — Autenticação e autorização

Autenticação é quando o sistema verifica quem é o usuário, por exemplo, conferindo seu nome de usuário e senha. Autorização é quando o sistema verifica o que esse usuário pode fazer depois de estar autenticado.

Um exemplo de autenticação é quando uma pessoa faz login em uma API informando usuário e senha para acessar seu perfil. Um exemplo de autorização é quando um funcionário faz login, mas somente o administrador tem permissão para excluir usuários.

## Exercício 2 — Funcionamento do JWT

O usuário envia seu nome de usuário e senha para a rota de login. A API verifica as credenciais e, se estiverem corretas, gera um token JWT e o devolve ao cliente.

Nas próximas requisições, o cliente envia o token no cabeçalho HTTP `Authorization`, no formato `Bearer`. A API valida o token e permite o acesso à rota protegida se ele for válido e os requisitos de autorização forem atendidos.

O JWT serve para representar informações sobre o usuário autenticado e permitir que a API valide as próximas requisições. Não devemos colocar senhas ou informações secretas no token porque seu conteúdo pode ser decodificado e visualizado. Ele deve conter apenas informações necessárias para a autenticação.

## Exercício 3 — Status HTTP 401 e 403

O código `401 Unauthorized` é retornado quando o usuário não está autenticado corretamente, por exemplo, quando tenta acessar uma rota protegida sem token ou com um token inválido.

O código `403 Forbidden` é retornado quando o usuário está autenticado, mas não tem permissão para realizar uma operação.

Exemplo de 401: uma pessoa tenta acessar o próprio perfil sem enviar um token. Exemplo de 403: um funcionário autenticado tenta acessar uma rota exclusiva para administradores.
