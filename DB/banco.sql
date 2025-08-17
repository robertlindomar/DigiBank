-- Criação do banco
CREATE DATABASE IF NOT EXISTS digibank DEFAULT CHARACTER SET utf8mb4 DEFAULT COLLATE utf8mb4_unicode_ci;

USE digibank;

-- Tabela de clientes (consolidada com informações de autenticação)
CREATE TABLE cliente (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    cpf VARCHAR(14) NOT NULL UNIQUE,
    login VARCHAR(50) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL,
    ativo BOOLEAN DEFAULT TRUE,
    data_criacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    tipo ENUM('cliente', 'admin') NOT NULL DEFAULT 'cliente'
) DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;

-- Tabela de contas bancárias
CREATE TABLE conta (
    id INT AUTO_INCREMENT PRIMARY KEY,
    numero_conta VARCHAR(20) NOT NULL UNIQUE,
    tipo ENUM('corrente', 'poupanca') NOT NULL,
    saldo DECIMAL(12, 2) DEFAULT 0.00,
    ativa BOOLEAN DEFAULT TRUE,
    cliente_id INT NOT NULL,
    data_abertura DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (cliente_id) REFERENCES cliente (id) ON DELETE CASCADE
) DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;

-- Tabela de cartão NFC
CREATE TABLE cartao (
    id INT AUTO_INCREMENT PRIMARY KEY,
    uid VARCHAR(50) NOT NULL UNIQUE,
    apelido VARCHAR(50),
    pin_hash VARCHAR(255),
    conta_id INT NOT NULL,
    ativo BOOLEAN DEFAULT TRUE,
    data_vinculacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (conta_id) REFERENCES conta (id) ON DELETE CASCADE
) DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;

CREATE INDEX idx_cartao_uid ON cartao (uid);

CREATE INDEX idx_cliente_cpf ON cliente (cpf);

CREATE INDEX idx_cliente_login ON cliente (login);

-- Tabela de transações
CREATE TABLE transacao (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tipo ENUM(
        'deposito',
        'saque',
        'transferencia'
    ) NOT NULL,
    valor DECIMAL(12, 2) NOT NULL,
    data_transacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    conta_origem_id INT,
    conta_destino_id INT,
    descricao VARCHAR(255),
    FOREIGN KEY (conta_origem_id) REFERENCES conta (id) ON DELETE SET NULL,
    FOREIGN KEY (conta_destino_id) REFERENCES conta (id) ON DELETE SET NULL
) DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;

-- Tabela de terminais POS
CREATE TABLE terminal_pos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    nome_loja VARCHAR(100),
    localizacao VARCHAR(100),
    uid VARCHAR(50) UNIQUE,
    conta_id INT NOT NULL,
    ativo BOOLEAN DEFAULT TRUE,
    FOREIGN KEY (conta_id) REFERENCES conta (id) ON DELETE CASCADE
) DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;

-- Tabela de pagamentos POS
CREATE TABLE pagamento_pos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    terminal_id INT,
    cartao_id INT,
    valor DECIMAL(12, 2) NOT NULL,
    data_hora DATETIME DEFAULT CURRENT_TIMESTAMP,
    data_pagamento DATETIME DEFAULT CURRENT_TIMESTAMP,
    status ENUM(
        'aprovado',
        'recusado',
        'pin_incorreto',
        'saldo_insuficiente'
    ) NOT NULL,
    descricao VARCHAR(255),
    FOREIGN KEY (terminal_id) REFERENCES terminal_pos (id) ON DELETE CASCADE,
    FOREIGN KEY (cartao_id) REFERENCES cartao (id) ON DELETE CASCADE
) DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_unicode_ci;

-- Clientes (consolidados com informações de autenticação)
-- senha: 123456 (hash bcrypt)
INSERT INTO
    cliente (
        id,
        nome,
        cpf,
        login,
        senha,
        ativo,
        tipo
    )
VALUES (
        1,
        'Loja Teste',
        '000.000.000-00',
        'loja',
        '$2a$11$9CaOWUQHHzwgDdsgvfKMZOnBRZRvbCtE55QkfudF83tHg3SR5aYEq',
        1,
        'cliente'
    ),
    (
        2,
        'Cliente Teste',
        '111.111.111-11',
        'cliente',
        '$2a$11$9CaOWUQHHzwgDdsgvfKMZOnBRZRvbCtE55QkfudF83tHg3SR5aYEq',
        1,
        'cliente'
    );

-- Contas (1 por cliente)
INSERT INTO
    conta (
        id,
        numero_conta,
        tipo,
        saldo,
        ativa,
        cliente_id
    )
VALUES (
        1,
        '0001-1',
        'corrente',
        1000.00,
        1,
        1
    ), -- Conta da LOJA (recebedora)
    (
        2,
        '1234-5',
        'corrente',
        2500.00,
        1,
        2
    );
-- Conta do CLIENTE (pagador)

-- Terminal POS (pertence à conta da LOJA)
INSERT INTO
    terminal_pos (
        id,
        nome,
        nome_loja,
        localizacao,
        conta_id,
        ativo
    )
VALUES (
        1,
        'Terminal Loja',
        'Loja Teste',
        'Centro',
        1,
        1
    );

-- Cartões NFC (um para cada cliente) com os UIDs solicitados
INSERT INTO
    cartao (
        id,
        uid,
        apelido,
        pin_hash,
        conta_id,
        ativo
    )
VALUES (
        1,
        '0848182788',
        'Cartão Loja',
        NULL,
        1,
        1
    ),
    (
        2,
        '0066581178',
        'Cartão Cliente',
        NULL,
        2,
        1
    );