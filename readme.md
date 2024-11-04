
# Janos Enterprise

## Descrição

Janos Enterprise é um projeto desenvolvido para gerenciar informações relacionadas a clientes, endereços, lojas e notas. O sistema utiliza o ASP.NET Core para o backend e implementa boas práticas de programação que garantem um código limpo, modular e de fácil manutenção.

## Estrutura do Projeto

- **Pasta Janos**: Contém a aplicação principal, incluindo:
  - **Controllers**: Gerenciam a lógica de negócios e as interações entre as requisições e os dados.
  - **Repositórios**: Abstraem a lógica de acesso a dados, permitindo operações CRUD em entidades.
  - **Modelos**: Definem as estruturas de dados utilizadas na aplicação.

- **Pasta Janos.Tests**: Contém os testes unitários da aplicação, assegurando que a funcionalidade do sistema esteja correta e que novas mudanças não quebrem funcionalidades existentes.

## Práticas de Clean Code e Princípios SOLID

O projeto segue práticas de **Clean Code** e os princípios **SOLID**, fundamentais para a criação de um código de qualidade. Aqui estão as principais práticas adotadas:

### Clean Code

1. **Nomenclatura significativa**: Nomes claros e descritivos para variáveis, métodos e classes.
2. **Métodos pequenos**: Cada método tem uma única responsabilidade, facilitando a compreensão.
3. **Evitar duplicação**: Centralização da lógica de código nos repositórios, evitando redundâncias.
4. **Tratamento de erros**: Uso adequado de respostas HTTP para lidar com diferentes estados do sistema.

### SOLID

1. **Single Responsibility Principle (SRP)**: Cada controller e repositório tem uma única responsabilidade, facilitando a manutenção.
2. **Open/Closed Principle (OCP)**: O código é aberto para extensão e fechado para modificação, permitindo a injeção de dependência nos controllers.
3. **Liskov Substitution Principle (LSP)**: As subclasses podem ser usadas de forma intercambiável, mantendo a integridade do sistema.
4. **Interface Segregation Principle (ISP)**: Interfaces são mantidas enxutas e específicas, evitando implementações desnecessárias.
5. **Dependency Inversion Principle (DIP)**: Uso de injeção de dependências para desacoplar classes e melhorar a testabilidade.

### Benefícios das Práticas

- **Facilidade de manutenção**: O código é mais fácil de entender e alterar, reduzindo o risco de bugs.
- **Flexibilidade**: O uso de interfaces e desacoplamento permite a extensão de funcionalidades sem impacto no código existente.
- **Testabilidade**: A injeção de dependências facilita a criação de testes automatizados, garantindo a funcionalidade do sistema.

## Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/gutodidonato/SP4-dotnet

2. Navegue até o diretório do projeto:
   ```bash
   cd Janos

3. Restaure os pacotes do NuGet:
   ```bash
   dotnet restore

4. Execute a aplicação:
   ```bash
   dotnet run


## Testes

1. Clone o repositório:
   ```bash
   git clone https://github.com/gutodidonato/SP4-dotnet

2. Navegue até o diretório do projeto:
   ```bash
   cd Janos.Tests

3. Restaure os pacotes do NuGet:
   ```bash
   dotnet restore

4. Install da build:
   ```bash
   dotnet restore

5. Execute os testes:
   ```bash
   dotnet test


RESTful APIs utilizadas:

1. Sendgrid
2. viacep