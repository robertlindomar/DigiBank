    -- Criacao do banco
CREATE DATABASE IF NOT EXISTS digibank
  DEFAULT CHARACTER SET utf8mb4
  DEFAULT COLLATE utf8mb4_unicode_ci;
USE digibank;

-- Tabela de clientes
CREATE TABLE cliente (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    cpf VARCHAR(14) NOT NULL UNIQUE,
    data_criacao DATETIME DEFAULT CURRENT_TIMESTAMP
) DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabela de contas bancarias
CREATE TABLE conta (
    id INT AUTO_INCREMENT PRIMARY KEY,
    numero_conta VARCHAR(20) NOT NULL UNIQUE,
    tipo ENUM('corrente', 'poupanca') NOT NULL,
    saldo DECIMAL(12,2) DEFAULT 0.00,
    ativa BOOLEAN DEFAULT TRUE,
    cliente_id INT NOT NULL,
    data_abertura DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (cliente_id) REFERENCES cliente(id) ON DELETE CASCADE
) DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabela de login tradicional (usuario/senha)
CREATE TABLE usuario (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT NOT NULL,
    login VARCHAR(50) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL, -- armazenar hash seguro
    ativo BOOLEAN DEFAULT TRUE,
    data_criacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    tipo ENUM('cliente', 'admin') NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES cliente(id) ON DELETE CASCADE
) DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabela de cartao NFC
CREATE TABLE cartao (
    id INT AUTO_INCREMENT PRIMARY KEY,
    uid VARCHAR(50) NOT NULL UNIQUE, -- UID fisico do cartao NFC
    apelido VARCHAR(50),
    pin_hash VARCHAR(255), -- PIN criptografado
    conta_id INT NOT NULL,
    ativo BOOLEAN DEFAULT TRUE,
    data_vinculacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (conta_id) REFERENCES conta(id) ON DELETE CASCADE
) DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Indices para busca rapida
CREATE INDEX idx_cartao_uid ON cartao(uid);
CREATE INDEX idx_cliente_cpf ON cliente(cpf);

-- Tabela de transacoes
CREATE TABLE transacao (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tipo ENUM('deposito', 'saque', 'transferencia') NOT NULL,
    valor DECIMAL(12,2) NOT NULL,
    data_transacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    conta_origem_id INT,
    conta_destino_id INT,
    descricao VARCHAR(255),
    FOREIGN KEY (conta_origem_id) REFERENCES conta(id) ON DELETE SET NULL,
    FOREIGN KEY (conta_destino_id) REFERENCES conta(id) ON DELETE SET NULL
) DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabela de terminais POS
CREATE TABLE terminal_pos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome_loja VARCHAR(100),
    localizacao VARCHAR(100),
    uid VARCHAR(50) UNIQUE,
    conta_id INT NOT NULL,
    FOREIGN KEY (conta_id) REFERENCES conta(id) ON DELETE CASCADE
) DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabela de pagamentos via POS
CREATE TABLE pagamento_pos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    terminal_id INT,
    cartao_id INT,
    valor DECIMAL(12,2) NOT NULL,
    data_hora DATETIME DEFAULT CURRENT_TIMESTAMP,
    status ENUM('aprovado', 'recusado', 'pin_incorreto', 'saldo_insuficiente') NOT NULL,
    descricao VARCHAR(255),
    FOREIGN KEY (terminal_id) REFERENCES terminal_pos(id) ON DELETE CASCADE,
    FOREIGN KEY (cartao_id) REFERENCES cartao(id) ON DELETE CASCADE
) DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;



-- Inserir clientes
INSERT INTO cliente (nome, cpf) VALUES
('Administrador do Sistema', '000.000.000-00'),
('Joao da Silva', '111.111.111-11');

-- Inserir contas
INSERT INTO conta (numero_conta, tipo, saldo, ativa, cliente_id, data_abertura) VALUES
(1, '1001', 'corrente', 5000.00, TRUE, 1, '2025-08-12 00:56:37'),
(2, '2001', 'poupanca', 1500.00, TRUE, 2, '2025-08-12 00:56:37'),
(3, '2002', 'corrente', 500.00, TRUE, 2, '2025-08-12 00:56:37');

-- Inserir usuarios (senha simulada com hash bcrypt ficticio)
-- Senha real: admin123 / usuario123
INSERT INTO usuario (cliente_id, login, senha, ativo, data_criacao, tipo) VALUES
(1, 1, 'admin', '$2a$11$9CaOWUQHHzwgDdsgvfKMZOnBRZRvbCtE55QkfudF83tHg3SR5aYEq', 1, '2025-08-12 00:56:42', 'admin'),
(2, 2, 'usuario', '$2a$11$QOBgl2F6TpFBsMpNLdU8AeLA5fNMWJmoxZAl/UzIv.zoHslzig5ke', 1, '2025-08-12 00:56:42', 'cliente');

-- Inserir cartoes NFC
-- UID ficticio para testes: '0848182788' (admin) e '0066581178' (Joao)
INSERT INTO cartao (uid, apelido, pin_hash, conta_id, ativo) VALUES
('0848182788', 'Cartao Admin', NULL, 1, TRUE),
('0066581178', 'Cartao Joao', NULL, 2, TRUE);

-- Inserir um terminal POS de teste
INSERT INTO terminal_pos (nome_loja, localizacao, uid, conta_id) VALUES
('Loja Teste', 'Centro', 'POS123456', 1);

-- Inserir uma transacao de teste
INSERT INTO transacao (tipo, valor, conta_origem_id, conta_destino_id, descricao) VALUES
('deposito', 500.00, NULL, 2, 'Deposito inicial para Joao');