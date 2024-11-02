# Sprint 3 Dotnet Go&GetIt

## Visão Geral

Este projeto é uma aplicação monolítica desenvolvida com ASP.NET Core, utilizando o padrão Repository para isolar a lógica de acesso a dados da lógica de negócios. A aplicação inclui endpoints REST para diversas operações e é projetada para ser simples de desenvolver e implantar.

## Arquitetura
### Justificativa do uso da arquitetura monolítica no projeto
Para um projeto em seu estágio inicial, a arquitetura monolítica apresenta vantagens significativas. A simplicidade de manutenção é um dos principais atrativos, pois todo o código reside em um único lugar, facilitando a compreensão e as alterações. A curva de aprendizado para novos desenvolvedores também é menor, já que não há a complexidade de lidar com múltiplos serviços.
Além disso, a rápida implantação em diferentes ambientes é outro benefício. A aplicação pode ser facilmente replicada em máquinas distintas, agilizando o processo de desenvolvimento e testes.
No entanto, é importante ressaltar que essa arquitetura apresenta limitações à medida que o projeto cresce. A manutenção pode se tornar mais desafiadora à medida que a base de código aumenta, e a escalabilidade pode ser comprometida. Por isso, é fundamental avaliar a evolução do projeto e estar preparado para migrar para uma arquitetura de microsserviços quando necessário.


### Arquitetura Monolítica

A arquitetura monolítica é caracterizada pela implementação de todos os componentes da aplicação em uma única unidade. Isso inclui:

- **Endpoints REST**: Todos os endpoints da API estão centralizados na mesma aplicação.
- **Regras de Negócio**: Toda a lógica de negócios é implementada dentro da mesma aplicação.
- **Lógica de Acesso a Dados**: Utiliza o padrão Repository para abstrair a camada de dados e manter a separação entre a lógica de negócios e a persistência.

**Vantagens:**
- **Simplicidade:** Menos complexidade inicial devido à centralização de todos os componentes.
- **Desenvolvimento Rápido:** Inicialmente mais rápido devido a menos sobrecarga de configuração e comunicação entre serviços.
- **Desdobramento:** O processo de implantação é direto, com apenas um artefato para gerenciar.

**Desvantagens:**
- **Escalabilidade Limitada:** A aplicação é escalada como um todo, o que pode ser menos eficiente e mais caro.
- **Flexibilidade Reduzida:** Mudanças na aplicação podem impactar a totalidade do sistema, tornando as atualizações mais complexas.
- **Manutenção:** À medida que a aplicação cresce, pode se tornar difícil de manter e entender devido à alta coesão.

### Padrão Repository

O padrão Repository é utilizado para criar uma camada de abstração entre a lógica de negócios e o acesso a dados. Isso é feito através de:

- **Interface Repository:** Define métodos para operações de dados, como `Add`, `Update`, `Delete`, e `Find`.
- **Implementação Repository:** Contém a lógica específica para interagir com o banco de dados ou outras fontes de dados.

**Benefícios:**
- **Abstração:** Separa a lógica de acesso a dados da lógica de negócios.
- **Facilidade de Testes:** Permite a teste da lógica de negócios sem depender diretamente da camada de persistência.
- **Centralização:** Facilita a manutenção e alteração das operações de dados.

## Comparação com Arquitetura de Microservices

### Arquitetura de Microservices

A arquitetura de microservices divide a aplicação em serviços independentes, cada um responsável por uma funcionalidade específica.

**Vantagens:**
- **Escalabilidade:** Permite escalar serviços individuais conforme necessário.
- **Desenvolvimento Independente:** Equipes podem trabalhar em diferentes serviços sem conflitos.
- **Resiliência:** Falhas em um microservice não afetam diretamente os outros serviços.
- **Tecnologias Diversas:** Permite o uso de tecnologias e bancos de dados variados para diferentes serviços.

**Desvantagens:**
- **Complexidade:** A comunicação entre microservices e a gestão de dados distribuídos adicionam complexidade.
- **Sobrehead Operacional:** Exige mais ferramentas e práticas para monitoramento, logging e gerenciamento.
- **Deploy e Testes:** O processo de deploy e testes é mais complexo devido à independência dos serviços.


## Utilização

```bash
     dotnet run
```

```txt 
    substituir no appsettings.json, o "OracleConnection" pelo enviado em txt
```
