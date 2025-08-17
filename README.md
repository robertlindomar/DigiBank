# 🏦 DigiBank - Sistema Bancário Digital Completo

## 📋 Visão Geral

O **DigiBank** é um sistema bancário digital completo desenvolvido em **C# .NET Framework 4.8** com interface **Windows Forms** e banco de dados **MySQL**. O sistema simula um banco digital real com funcionalidades avançadas incluindo **cartões NFC virtuais**, **terminal POS (maquininha)**, **transferências automáticas** e **gestão completa de contas**.

## 🚀 Funcionalidades Principais

### 🔐 Sistema de Autenticação

- **Login seguro** com hash BCrypt para senhas
- **Dois tipos de usuário**: `cliente` e `admin`
- **Sistema consolidado**: Cliente e Usuário unificados em uma única entidade
- **Controle de acesso** baseado em tipo de usuário
- **Sessões seguras** com validação de credenciais

### 💳 Cartões NFC Virtuais

- **Cartões digitais** com UID único e verificável
- **Vinculação automática** a contas bancárias específicas
- **Status ativo/inativo** para controle de segurança
- **Apelidos personalizados** para identificação fácil
- **Histórico de vinculação** com data e hora

### 🏦 Gestão de Contas Bancárias

- **Conta Corrente** com funcionalidades completas
- **Conta Poupança** para investimentos
- **Saldo em tempo real** com atualizações automáticas
- **Status ativo/inativo** para controle operacional
- **Data de abertura** e histórico completo
- **Múltiplas contas** por cliente

### 💸 Sistema de Transações

- **Depósitos**: Entrada de dinheiro nas contas
- **Saques**: Retirada de dinheiro das contas
- **Transferências**: Entre contas próprias ou de terceiros
- **Histórico detalhado**: Data, hora, valor, descrição e status
- **Filtros avançados**: Por tipo, período e texto de busca
- **Estatísticas mensais**: Total de entradas, saídas e saldo líquido
- **Cores diferenciadas**: Verde (entradas) e Vermelho (saídas)

### 🎯 **Terminal POS (Maquininha) - Destaque Principal**

O **Terminal POS** é a funcionalidade mais inovadora do sistema, simulando perfeitamente uma maquininha de cartão real:

#### 🔧 Funcionamento

1. **Dono da Loja** acessa o Terminal POS
2. **Digita o valor** da transação
3. **Informa o UID** do cartão do cliente
4. **Clica em "💳 Aproximar Cartão"**
5. **Sistema processa** a transferência automaticamente

#### 💰 Processo de Pagamento

- **Validação de cartão**: Verifica se o cartão existe e está ativo
- **Verificação de saldo**: Confirma se o cliente tem fundos suficientes
- **Processamento da transação**: Debita da conta do cliente e credita na conta da loja
- **Registro completo**: Cria histórico detalhado da operação
- **Atualização de saldos**: Atualiza ambas as contas em tempo real

#### 🛡️ Segurança e Validações

- **Controle de acesso**: Usuário só acessa terminais próprios
- **Validação de propriedade**: Terminal deve pertencer ao usuário logado
- **Proteção contra fraudes**: Não permite pagamentos para a própria conta
- **Verificação de status**: Cartão e terminal devem estar ativos
- **Logs de auditoria**: Registra todas as operações para rastreabilidade

#### 📊 Interface Inteligente

- **Design realista**: Interface que simula maquininhas reais
- **Estados visuais**: Idle, Processando, Sucesso, Erro
- **Estatísticas em tempo real**: Total de pagamentos, aprovados, recusados
- **Histórico de pagamentos**: Lista dos últimos pagamentos processados
- **Feedback visual completo**: Cores e ícones para cada estado

## 🏗️ Arquitetura do Sistema

### 📁 Estrutura de Pastas

```
DigiBank/
├── controllers/     # Controladores da aplicação (MVC)
├── models/         # Modelos de dados (entidades)
├── repositories/   # Acesso ao banco de dados (Repository Pattern)
├── services/       # Lógica de negócio (Service Layer)
├── views/          # Interfaces gráficas (Windows Forms)
├── configs/        # Configurações e conexões
├── DB/            # Scripts e estrutura do banco de dados
└── Resources/     # Imagens, ícones e recursos visuais
```

### 🔄 Padrão Arquitetural

- **MVC (Model-View-Controller)**: Separação clara de responsabilidades
- **Repository Pattern**: Abstração do acesso a dados
- **Service Layer**: Lógica de negócio centralizada
- **Separation of Concerns**: Cada camada com responsabilidade específica
- **Dependency Injection**: Injeção de dependências nos controladores

### 🗄️ Estrutura do Banco de Dados

#### 📊 Tabelas Principais

- **`cliente`**: Dados dos clientes + informações de autenticação
- **`conta`**: Contas bancárias (corrente/poupança)
- **`cartao`**: Cartões NFC com UID único
- **`transacao`**: Histórico completo de transações
- **`terminal_pos`**: Terminais POS das lojas
- **`pagamento_pos`**: Registro de pagamentos via maquininha

#### 🔑 Relacionamentos

```
cliente (1) → conta (N) → cartao (N)
cliente (1) → conta (N) → terminal_pos (N)
conta (1) → transacao (N) [origem]
conta (1) → transacao (N) [destino]
terminal_pos (1) → pagamento_pos (N)
cartao (1) → pagamento_pos (N)
```

#### 🎯 Índices e Otimizações

- **Índice único** no UID dos cartões
- **Índice único** no CPF dos clientes
- **Índice único** no login dos clientes
- **Foreign Keys** com CASCADE para integridade referencial

## 🎨 Interface do Usuário

### 🖥️ Telas Principais

#### 🔐 Login

- **Interface moderna** com campos de usuário e senha
- **Validação em tempo real** dos campos
- **Mensagens de erro** claras e específicas
- **Redirecionamento automático** para o Dashboard após autenticação

#### 📊 Dashboard

- **Visão geral** das contas e saldos em tempo real
- **Transações recentes** (limitadas para performance)
- **Cartões NFC ativos** com status visual
- **Estatísticas resumidas** de movimentação
- **Navegação rápida** para todas as funcionalidades
- **Interface responsiva** com cores e ícones modernos

#### 💳 Gestão de Cartões NFC

- **Lista completa** de cartões vinculados
- **Status visual** (ativo/inativo) com cores
- **Informações detalhadas**: UID, apelido, data de vinculação
- **Estatísticas** de cartões ativos vs. inativos
- **Interface intuitiva** para gestão

#### 📈 Histórico de Transações

- **Lista completa** de todas as transações
- **Filtros avançados**:
  - Por tipo (Depósitos, Saques, Transferências)
  - Por texto de busca na descrição
  - Por período (mês atual)
- **Estatísticas mensais**:
  - Total de entradas
  - Total de saídas
  - Saldo líquido
- **Cores diferenciadas**: Verde (entradas), Vermelho (saídas)
- **Funcionalidade de transferência** direta entre contas próprias

#### 🏪 **Terminal POS (Maquininha)**

- **Interface realista** que simula maquininhas reais
- **Campo de valor** para a transação
- **Campo de UID** do cartão do cliente
- **Botão "💳 Aproximar Cartão"** para processar
- **Estados visuais** de processamento
- **Histórico de pagamentos** recentes
- **Estatísticas** de terminais e pagamentos
- **Criação automática** de terminal padrão se necessário

## 🚀 Como Executar

### 📋 Pré-requisitos

- **Visual Studio 2019+** ou **Visual Studio Code**
- **.NET Framework 4.8**
- **MySQL Server 8.0+**
- **MySQL Connector/NET 9.4.0**

### ⚙️ Configuração e Instalação

#### 1. **Clone o Repositório**

```bash
git clone [URL_DO_REPOSITORIO]
cd DigiBank
```

#### 2. **Configure o Banco de Dados**

```bash
# Execute o script principal
mysql -u root -p < DB/banco.sql
```

#### 3. **Configure a Conexão**

Edite `configs/Database.cs` com suas credenciais MySQL:

```csharp
private const string CONNECTION_STRING =
    "Server=localhost;Database=digibank;Uid=seu_usuario;Pwd=sua_senha;";
```

#### 4. **Compile e Execute**

- Abra `DigiBank.sln` no Visual Studio
- Restaure os pacotes NuGet
- Compile o projeto (Ctrl+Shift+B)
- Execute (F5)

### 🧪 Dados de Teste

O sistema já vem com dados de teste configurados:

#### 👥 Usuários de Teste

- **Loja Teste**: `loja` / `123456`
- **Cliente Teste**: `cliente` / `123456`

#### 💳 Cartões NFC de Teste

- **Cartão Loja**: UID `0848182788`
- **Cartão Cliente**: UID `0066581178`

#### 🏦 Contas de Teste

- **Loja**: Conta Corrente `0001-1` - Saldo: R$ 1.000,00
- **Cliente**: Conta Corrente `1234-5` - Saldo: R$ 2.500,00

#### 🏪 Terminal POS

- **Terminal Loja**: "Terminal Loja" - Ativo e configurado

## 🎯 Testando o Sistema

### 📱 **Teste da Maquininha POS (Recomendado)**

#### Passo a Passo:

1. **Login como Loja**: `loja` / `123456`
2. **Acesse**: Menu lateral → "Maquininha POS"
3. **Digite valor**: `50,00`
4. **Digite UID**: `0066581178` (cartão do cliente)
5. **Clique**: "💳 Aproximar Cartão"
6. **Aguarde**: Processamento automático
7. **Confirme**: Verifique o Dashboard

#### 🔍 **Verificações:**

- **Dashboard**: Saldo da loja aumentou para R$ 1.050,00
- **Transações**: Nova transação de transferência registrada
- **Maquininha**: Pagamento aparece no histórico
- **Cliente**: Saldo diminuiu para R$ 2.450,00

### 💸 **Teste de Transferências Internas**

#### Passo a Passo:

1. **Login como Cliente**: `cliente` / `123456`
2. **Acesse**: "Transações"
3. **Clique**: "Nova Transferência"
4. **Configure**: Origem (Conta Corrente) → Destino (Conta Poupança)
5. **Digite valor**: `100,00`
6. **Confirme**: Transferência

#### 🔍 **Verificações:**

- **Transação única**: Aparece apenas uma vez na lista
- **Filtros funcionando**: Aparece apenas em "Transferências"
- **Estatísticas corretas**: Entrada e saída contabilizadas

## 🛠️ Tecnologias e Dependências

### 💻 Backend

- **C# .NET Framework 4.8**
- **Windows Forms** para interface gráfica
- **MySQL Database** para persistência
- **BCrypt.Net-Next** para hash de senhas

### 🎨 Frontend

- **Windows Forms Designer**
- **Custom Controls** personalizados
- **Modern UI Design** com cores e ícones
- **Responsive Layout** adaptável

### 🗄️ Banco de Dados

- **MySQL 8.0+**
- **Foreign Keys** com integridade referencial
- **Índices otimizados** para performance
- **Charset UTF8MB4** para suporte completo a Unicode

### 📦 Pacotes NuGet

- **BCrypt.Net-Next 4.0.3**: Hash seguro de senhas
- **MySql.Data 9.4.0**: Conector MySQL
- **System.Configuration**: Gerenciamento de configurações

## 🔧 Funcionalidades Técnicas

### 🔐 Segurança

- **Hash BCrypt** com salt automático para senhas
- **Validação de entrada** em todos os campos
- **Controle de acesso** baseado em tipo de usuário
- **Logs de auditoria** para todas as transações
- **Proteção contra SQL Injection** via parâmetros

### ⚡ Performance

- **Queries otimizadas** com índices apropriados
- **Lazy loading** para dados pesados
- **Cache local** de dados frequentes
- **Transações de banco** para operações críticas

### 🎯 Usabilidade

- **Interface intuitiva** com navegação clara
- **Feedback visual** em todas as ações
- **Mensagens de erro** claras e específicas
- **Responsividade** em diferentes resoluções
- **Atalhos de teclado** para operações comuns

## 🐛 Correções Implementadas

### ✅ **Problemas Resolvidos**

#### 1. **Consolidação de Models**

- **Antes**: Models `Cliente` e `Usuario` separados (duplicação)
- **Depois**: Model `Cliente` consolidada com autenticação
- **Benefício**: Código mais limpo e manutenível

#### 2. **Duplicação de Transações**

- **Antes**: Transferências apareciam múltiplas vezes
- **Depois**: Deduplicação automática por ID
- **Benefício**: Interface mais clara e estatísticas corretas

#### 3. **Filtros de Transações**

- **Antes**: Transferências apareciam em "Depósitos" e "Transferências"
- **Depois**: Filtros baseados no tipo real da transação
- **Benefício**: Categorização correta das transações

#### 4. **Segurança do Terminal POS**

- **Antes**: Usuários podiam acessar terminais de outros
- **Depois**: Controle de acesso baseado em propriedade
- **Benefício**: Sistema mais seguro e controlado

## 📈 Roadmap e Melhorias Futuras

### 🚀 **Curto Prazo (1-3 meses)**

- **Relatórios em PDF**: Exportação de extratos
- **Notificações**: Alertas de transações importantes
- **Backup automático**: Sistema de backup do banco
- **Logs avançados**: Sistema de auditoria completo

### 🔮 **Médio Prazo (3-6 meses)**

- **API REST**: Integração com sistemas externos
- **App mobile**: Versão para smartphones
- **PIX**: Integração com sistema PIX brasileiro
- **Dashboard avançado**: Gráficos e métricas

### 🌟 **Longo Prazo (6+ meses)**

- **Machine Learning**: Detecção de fraudes
- **Blockchain**: Transações imutáveis
- **IoT**: Integração com terminais físicos
- **Multi-idioma**: Suporte a diferentes idiomas

## 🤝 Contribuição

### 📝 **Como Contribuir**

1. **Fork** o projeto no GitHub
2. **Crie uma branch** para sua feature: `git checkout -b feature/nova-funcionalidade`
3. **Commit** suas mudanças: `git commit -m 'Adiciona nova funcionalidade'`
4. **Push** para a branch: `git push origin feature/nova-funcionalidade`
5. **Abra um Pull Request** com descrição detalhada

### 📋 **Padrões de Código**

- **C# Coding Conventions** da Microsoft
- **Comentários** em português para documentação
- **Nomes descritivos** para variáveis e métodos
- **Tratamento de erros** adequado com try-catch
- **Validações** em todas as entradas do usuário

### 🧪 **Testes**

- **Teste manual** de todas as funcionalidades
- **Verificação** de integridade do banco
- **Validação** de segurança e permissões
- **Teste de performance** com dados reais

## 📞 Suporte e Troubleshooting

### 🆘 **Problemas Comuns**

#### **Erro de Conexão com MySQL**

```bash
# Verifique se o MySQL está rodando
sudo systemctl status mysql

# Teste a conexão
mysql -u root -p -h localhost
```

#### **Cartão não Encontrado**

- Confirme o UID no banco: `SELECT * FROM cartao WHERE uid = 'SEU_UID';`
- Verifique se o cartão está ativo: `ativo = 1`
- Confirme se está vinculado a uma conta válida

#### **Saldo Insuficiente**

- Verifique o saldo da conta: `SELECT saldo FROM conta WHERE id = X;`
- Confirme se a conta está ativa: `ativa = 1`
- Verifique se há bloqueios na conta

#### **Terminal Inativo**

- Ative o terminal: `UPDATE terminal_pos SET ativo = 1 WHERE id = X;`
- Verifique se pertence ao usuário logado
- Confirme se a conta vinculada está ativa

### 📧 **Canais de Suporte**

- **Issues**: Use o sistema de issues do GitHub
- **Documentação**: Consulte este README e comentários no código
- **Comunidade**: Participe das discussões e fóruns
- **Email**: [seu-email@exemplo.com]

## 📄 Licença

Este projeto está sob a licença **MIT**. Veja o arquivo `LICENSE` para mais detalhes.

### 📋 **Termos da Licença MIT**

- ✅ **Permitido**: Uso comercial, modificação, distribuição
- ✅ **Permitido**: Uso privado, patente, uso comercial
- ❌ **Requerido**: Inclusão da licença e copyright
- ❌ **Responsabilidade**: O autor não se responsabiliza por danos

---

## 🎉 Conclusão

O **DigiBank** representa um sistema bancário digital completo e inovador, com destaque especial para o **Terminal POS** que simula perfeitamente uma maquininha de cartão real. O sistema oferece uma experiência bancária moderna, segura e intuitiva, com funcionalidades avançadas que cobrem todas as necessidades de um banco digital.

### 🌟 **Destaques do Sistema**

- **Arquitetura robusta** com padrões de projeto estabelecidos
- **Interface moderna** e intuitiva para o usuário
- **Segurança avançada** com hash BCrypt e controle de acesso
- **Funcionalidades completas** de gestão bancária
- **Terminal POS inovador** que simula maquininhas reais
- **Código limpo** e bem documentado

### 🚀 **Próximos Passos**

1. **Teste o sistema** com os dados de exemplo
2. **Explore todas as funcionalidades** implementadas
3. **Contribua** com melhorias e novas features
4. **Compartilhe** o projeto com a comunidade

**🏦 Experimente agora e descubra o futuro do banking digital!**

---

_Desenvolvido com ❤️ em C# .NET Framework 4.8_
