# Feedback - Avaliação Geral

## Front End

### Navegação
  * Pontos positivos:
    - Camada MVC com navegação bem definida.
    - Views para gerenciamento de categorias, produtos e autenticação.
    - Funcionalidades de CRUD disponíveis e funcionando.

  * Pontos negativos:
    - Nenhum ponto negativo identificado na navegação.

### Design
  - Interface administrativa clara e funcional, adequada ao propósito. Boa separação de layouts e organização de views.

### Funcionalidade
  * Pontos positivos:
    - CRUD completo para produtos e categorias em ambas as camadas (MVC e API).
    - Registro de usuários com associação ao vendedor implementado.
    - Autenticação via ASP.NET Identity com JWT (API) e cookies (MVC).
    - Proteção de ações por autenticação.
    - Exibição pública de produtos na home.

  * Pontos negativos:
    - Nenhum ponto funcional negativo.

## Back End

### Arquitetura
  * Pontos positivos:
    - Arquitetura enxuta e aderente à proposta com três camadas: MVC, API, e Core.
    - Implementações com boas práticas de configuração (ex: extensão para dependências, contextos, AutoMapper).

  * Pontos negativos:
    - Nenhum ponto negativo relevante.

### Funcionalidade
  * Pontos positivos:
    - Uso correto do EF Core com SQLite.
    - Migrations automáticas e seed de dados configurados no startup.
    - Identidade de usuário integrada com vendedor sem herança direta, conforme o escopo.
    - Controle de acesso a produtos por vendedor.

  * Pontos negativos:
    - Nenhum.

### Modelagem
  * Pontos positivos:
    - Modelagem anêmica, clara e condizente com o domínio do negócio.
    - Entidades bem definidas e com relacionamentos coerentes.

  * Pontos negativos:
    - Nenhum.

## Projeto

### Organização
  * Pontos positivos:
    - Uso correto da pasta `src` e arquivo `.sln` na raiz.
    - Separação clara entre os projetos de API, MVC e Core.
    - Estrutura de arquivos coesa e alinhada ao padrão.

  * Pontos negativos:
    - Nenhum ponto relevante.

### Documentação
  * Pontos positivos:
    - Presença dos arquivos `README.md` e `FEEDBACK.md`.
    - Swagger implementado e funcional para a API.

### Instalação
  * Pontos positivos:
    - Uso correto do SQLite.
    - Migrations e Seed executados no startup.

  * Pontos negativos:
    - Nenhum.

---

# 📊 Matriz de Avaliação de Projetos

| **Critério**                   | **Peso** | **Nota** | **Resultado Ponderado**                  |
|-------------------------------|----------|----------|------------------------------------------|
| **Funcionalidade**            | 30%      | 10       | 3,0                                      |
| **Qualidade do Código**       | 20%      | 10       | 2,0                                      |
| **Eficiência e Desempenho**   | 20%      | 10       | 2,0                                      |
| **Inovação e Diferenciais**   | 10%      | 10       | 1,0                                      |
| **Documentação e Organização**| 10%      | 10       | 1,0                                      |
| **Resolução de Feedbacks**    | 10%      | 10       | 1,0                                      |
| **Total**                     | 100%     | -        | **10,0**                                  |

## 🎯 **Nota Final: 10 / 10**
