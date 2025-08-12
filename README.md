# 🏦 DigiBank - Sistema Bancário Completo

## 📋 Visão Geral

O **DigiBank** é um sistema bancário completo desenvolvido em **C# .NET Framework 4.8** com interface **Windows Forms** e banco de dados **MySQL**. O sistema simula um banco digital com funcionalidades avançadas incluindo **cartões NFC**, **maquininha POS real** e **transferências automáticas**.

## 🚀 Funcionalidades Principais

### 👤 Sistema de Usuários
- **Login seguro** com hash BCrypt
- **Dois tipos de usuário**: Cliente e Administrador
- **Perfis personalizados** com informações completas

### 💳 Cartões NFC
- **Cartões virtuais** com UID único
- **Vinculação automática** a contas bancárias
- **Status ativo/inativo** para controle de segurança
- **Apelidos personalizados** para identificação

### 🏦 Contas Bancárias
- **Conta Corrente** e **Conta Poupança**
- **Saldo em tempo real**
- **Histórico completo** de transações
- **Status ativo/inativo**

### 💸 Transações
- **Depósitos** (entrada de dinheiro)
- **Saques** (retirada de dinheiro)
- **Transferências** entre contas (próprias ou de terceiros)
- **Histórico detalhado** com data, hora e descrição
- **Filtros avançados** por tipo e período
- **Estatísticas** de entradas e saídas

### 🎯 **MAQUININHA POS (Destaque)**

A **Maquininha POS** é a funcionalidade mais inovadora do sistema, funcionando como uma **maquininha de cartão real**:

#### 🔧 Como Funciona
1. **Dono da Loja** acessa a Maquininha POS
2. **Digita o valor** da transação
3. **Informa o UID** do cartão do cliente
4. **Clica em "Aproximar Cartão"**
5. **Sistema processa** a transferência automaticamente

#### 💰 Transferência Real
- **Debita** o valor da conta do cliente
- **Credita** o valor na conta da loja
- **Cria registro** de pagamento no banco
- **Atualiza saldos** em tempo real
- **Gera histórico** completo da transação

#### 🛡️ Validações de Segurança
- **Verificação de saldo** do cliente
- **Validação de cartão ativo**
- **Confirmação de terminal ativo**
- **Logs detalhados** de todas as operações

#### 📊 Interface da Maquininha
- **Design moderno** inspirado em maquininhas reais
- **Estados visuais**: Idle, Processando, Sucesso, Erro
- **Estatísticas em tempo real**: Total de pagamentos, aprovados, etc.
- **Histórico de pagamentos** recentes
- **Feedback visual** completo para o usuário

## 🏗️ Arquitetura do Sistema

### 📁 Estrutura de Pastas
```
DigiBank/
├── controllers/     # Controladores da aplicação
├── models/         # Modelos de dados
├── repositories/   # Acesso ao banco de dados
├── services/       # Lógica de negócio
├── views/          # Interfaces gráficas
├── configs/        # Configurações
├── DB/            # Scripts do banco de dados
└── Resources/     # Imagens e recursos
```

### 🔄 Padrão Arquitetural
- **MVC (Model-View-Controller)**
- **Repository Pattern** para acesso a dados
- **Service Layer** para lógica de negócio
- **Separation of Concerns** bem definida

## 🗄️ Banco de Dados

### 📊 Tabelas Principais
- **`cliente`**: Dados dos clientes
- **`usuario`**: Credenciais de login
- **`conta`**: Contas bancárias
- **`cartao`**: Cartões NFC
- **`transacao`**: Histórico de transações
- **`terminal_pos`**: Terminais POS
- **`pagamento_pos`**: Pagamentos via maquininha

### 🔑 Relacionamentos
- Cliente → Contas (1:N)
- Conta → Cartões (1:N)
- Conta → Transações (1:N)
- Terminal → Pagamentos (1:N)

## 🎨 Interface do Usuário

### 🖥️ Telas Principais

#### 📊 Dashboard
- **Visão geral** das contas e saldos
- **Transações recentes** (limitadas a 2)
- **Cartões NFC** ativos (limitados a 2)
- **Estatísticas** em tempo real
- **Navegação rápida** para outras telas

#### 💳 Cartões NFC
- **Lista completa** de cartões
- **Status visual** (ativo/inativo)
- **Informações detalhadas**: UID, apelido, data de vinculação
- **Estatísticas** de cartões ativos/inativos

#### 📈 Transações
- **Histórico completo** de transações
- **Filtros avançados** por tipo e texto
- **Estatísticas** de entradas e saídas
- **Cores diferenciadas**: Verde (entrada), Vermelho (saída)
- **Funcionalidade de transferência** direta

#### 🏪 **Maquininha POS**
- **Interface realista** de maquininha
- **Campo de valor** para transação
- **Campo de UID** do cartão do cliente
- **Estados visuais** de processamento
- **Histórico de pagamentos** recentes
- **Estatísticas** de terminais e pagamentos

## 🚀 Como Executar

### 📋 Pré-requisitos
- **Visual Studio 2019+** ou **Visual Studio Code**
- **.NET Framework 4.8**
- **MySQL Server 8.0+**
- **MySQL Connector/NET**

### ⚙️ Configuração
1. **Clone o repositório**
2. **Execute o script** `DB/banco.sql` no MySQL
3. **Configure a conexão** em `configs/Database.cs`
4. **Compile e execute** o projeto

### 🧪 Dados de Teste
Execute `DB/dados_teste.sql` para criar:
- **2 usuários**: Loja Teste e Cliente Teste
- **2 cartões NFC**: UIDs `0848182788` e `0066581178`
- **1 terminal POS** ativo
- **Contas com saldo** para testes

## 🎯 Testando a Maquininha POS

### 📝 Passo a Passo
1. **Faça login** como "loja" (senha: 123456)
2. **Acesse** "Maquininha POS" no menu lateral
3. **Digite um valor**: ex. `50,00`
4. **Digite o UID**: `0066581178` (cartão do cliente)
5. **Clique** em "💳 Aproximar Cartão"
6. **Aguarde** o processamento
7. **Confirme** a transferência no Dashboard

### 🔍 Verificação
- **Dashboard**: Saldo da loja aumentou
- **Transações**: Nova transação registrada
- **Maquininha**: Pagamento aparece no histórico

## 🛠️ Tecnologias Utilizadas

### 💻 Backend
- **C# .NET Framework 4.8**
- **Windows Forms**
- **MySQL Database**
- **BCrypt** para hash de senhas

### 🎨 Frontend
- **Windows Forms Designer**
- **Custom Controls**
- **Modern UI Design**
- **Responsive Layout**

### 🗄️ Banco de Dados
- **MySQL 8.0**
- **Stored Procedures**
- **Foreign Keys**
- **Indexes otimizados**

## 🔧 Funcionalidades Técnicas

### 🔐 Segurança
- **Hash BCrypt** para senhas
- **Validação de entrada** em todos os campos
- **Controle de acesso** por tipo de usuário
- **Logs de auditoria** para transações

### ⚡ Performance
- **Queries otimizadas** com índices
- **Lazy loading** para dados pesados
- **Cache local** de dados frequentes
- **Async/await** para operações longas

### 🎯 Usabilidade
- **Interface intuitiva** e moderna
- **Feedback visual** em todas as ações
- **Navegação clara** entre telas
- **Responsividade** em diferentes resoluções

## 📈 Roadmap Futuro

### 🚀 Melhorias Planejadas
- **API REST** para integração externa
- **App mobile** para clientes
- **Notificações push** em tempo real
- **Relatórios avançados** e gráficos
- **Integração com PIX**
- **Autenticação biométrica**

### 🔮 Funcionalidades Avançadas
- **Machine Learning** para detecção de fraudes
- **Blockchain** para transações
- **Inteligência artificial** para atendimento
- **Integração com IoT** para terminais físicos

## 🤝 Contribuição

### 📝 Como Contribuir
1. **Fork** o projeto
2. **Crie uma branch** para sua feature
3. **Commit** suas mudanças
4. **Push** para a branch
5. **Abra um Pull Request**

### 📋 Padrões de Código
- **C# Coding Conventions**
- **Comentários** em português
- **Nomes descritivos** para variáveis
- **Tratamento de erros** adequado

## 📞 Suporte

### 🆘 Problemas Comuns
- **Erro de conexão**: Verifique configurações do MySQL
- **Cartão não encontrado**: Confirme o UID no banco
- **Saldo insuficiente**: Verifique saldo da conta do cliente
- **Terminal inativo**: Ative o terminal no banco

### 📧 Contato
- **Issues**: Use o sistema de issues do GitHub
- **Documentação**: Consulte este README
- **Comunidade**: Participe das discussões

## 📄 Licença

Este projeto está sob a licença **MIT**. Veja o arquivo `LICENSE` para mais detalhes.

---

## 🎉 Conclusão

O **DigiBank** é um sistema bancário completo e inovador, com destaque especial para a **Maquininha POS** que simula perfeitamente uma maquininha de cartão real. O sistema oferece uma experiência bancária moderna e segura, com interface intuitiva e funcionalidades avançadas.

**🚀 Experimente agora e descubra o futuro do banking digital!**
