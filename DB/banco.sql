-- Criação do banco
CREATE DATABASE IF NOT EXISTS digibank DEFAULT CHARACTER SET utf8mb4 DEFAULT COLLATE utf8mb4_unicode_ci;

USE digibank;

-- Tabela de clientes
CREATE TABLE cliente (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    cpf VARCHAR(14) NOT NULL UNIQUE,
    data_criacao DATETIME DEFAULT CURRENT_TIMESTAMP
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

-- Tabela de login
CREATE TABLE usuario (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT NOT NULL,
    login VARCHAR(50) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL,
    ativo BOOLEAN DEFAULT TRUE,
    data_criacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    tipo ENUM('cliente', 'admin') NOT NULL,
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

-- Inserir clientes (apenas uma vez)
INSERT INTO
    cliente (nome, cpf)
VALUES (
        'Administrador do Sistema',
        '000.000.000-00'
    ),
    (
        'João da Silva',
        '111.111.111-11'
    ),
    (
        'Maria Oliveira',
        '222.222.222-22'
    ),
    (
        'Carlos Pereira',
        '333.333.333-33'
    ),
    ('Ana Souza', '444.444.444-44');

-- Usuários com senha hash BCrypt
INSERT INTO
    usuario (
        cliente_id,
        login,
        senha,
        ativo,
        tipo
    )
VALUES (
        1,
        'admin',
        '$2a$11$9CaOWUQHHzwgDdsgvfKMZOnBRZRvbCtE55QkfudF83tHg3SR5aYEq',
        1,
        'admin'
    ),
    (
        2,
        'joao',
        '$2a$11$Cjz8OGQmpwG4G8O6Zytl/OuZr9MTUk5cdOw1hxRYYA3Y5GcE7MSWe',
        1,
        'cliente'
    ),
    (
        3,
        'maria',
        '$2a$11$MtzW1lFbyyCQ0ZP3brG7duVQSm21ztTjMkPGp.XmJgMyWOVnZBg96',
        1,
        'cliente'
    ),
    (
        4,
        'carlos',
        '$2a$11$ONdB3uklE6dUJWBPqoy1EuDNcQkKNv27rOYv6fYx0j.02G6lU3B9W',
        1,
        'cliente'
    ),
    (
        5,
        'ana',
        '$2a$11$qa.Cor2kaBDP7uhM1r33ie1PTjK7cwrRAXm3i6p8i2y1k4p4wlZlO',
        1,
        'cliente'
    );

-- Contas
INSERT INTO
    conta (
        numero_conta,
        tipo,
        saldo,
        cliente_id
    )
VALUES (
        '0001-1',
        'corrente',
        15000.00,
        1
    ),
    (
        '1234-5',
        'corrente',
        2500.00,
        2
    ),
    (
        '6789-0',
        'poupanca',
        3200.00,
        2
    ),
    (
        '2222-2',
        'corrente',
        5000.00,
        3
    ),
    (
        '3333-3',
        'poupanca',
        1500.00,
        4
    ),
    (
        '4444-4',
        'corrente',
        800.00,
        5
    );

-- Cartões NFC
INSERT INTO
    cartao (
        uid,
        apelido,
        pin_hash,
        conta_id
    )
VALUES (
        '0848182788',
        'Cartão João',
        '$2a$11$YxYiR9Gp5rEpBG8E.qDQ1.V5zY0UdlpLZ4yFRfppzMS9pOTyVjjci',
        2
    ),
    (
        '0278033935',
        'Poupança João',
        NULL,
        3
    ),
    (
        '0066507913',
        'Cartão Maria',
        '$2a$11$KXYFlV3fQYrNqaaPHmSmR.MUus7QfXfSuQ8kFW/Nydp9p7yDCtHdm',
        4
    ),
    (
        '0066581178',
        'Cartão Carlos',
        NULL,
        5
    ),
    (
        '0099999999',
        'Cartão Ana',
        NULL,
        6
    );

-- Terminais POS
INSERT INTO
    terminal_pos (
        nome,
        nome_loja,
        localizacao,
        uid,
        conta_id,
        ativo
    )
VALUES (
        'Terminal Padaria',
        'Padaria Central',
        'Centro',
        'POSPAD123',
        1,
        TRUE
    ),
    (
        'Terminal Mercado',
        'Mercado Popular',
        'Bairro Sul',
        'POSMER456',
        1,
        TRUE
    ),
    (
        'Terminal Restaurante',
        'Restaurante Bom Sabor',
        'Bairro Norte',
        'POSRES789',
        1,
        TRUE
    );

-- Transações
INSERT INTO
    transacao (
        tipo,
        valor,
        conta_origem_id,
        conta_destino_id,
        descricao
    )
VALUES (
        'deposito',
        1000.00,
        NULL,
        2,
        'Depósito inicial João'
    ),
    (
        'deposito',
        2000.00,
        NULL,
        4,
        'Depósito inicial Maria'
    ),
    (
        'transferencia',
        300.00,
        2,
        4,
        'Pagamento de serviços para Maria'
    ),
    (
        'transferencia',
        150.00,
        4,
        5,
        'Carlos pagou Ana'
    ),
    (
        'saque',
        100.00,
        2,
        NULL,
        'Saque em caixa eletrônico'
    ),
    (
        'deposito',
        500.00,
        NULL,
        6,
        'Depósito Ana'
    ),
    (
        'transferencia',
        200.00,
        6,
        2,
        'Ana pagou João'
    );

-- Pagamentos POS
INSERT INTO
    pagamento_pos (
        terminal_id,
        cartao_id,
        valor,
        data_pagamento,
        status,
        descricao
    )
VALUES (
        1,
        1,
        25.50,
        '2024-01-15 14:30:00',
        'aprovado',
        'Compra de pães e café'
    ),
    (
        2,
        1,
        120.00,
        '2024-01-15 12:15:00',
        'aprovado',
        'Compras no mercado'
    ),
    (
        3,
        3,
        75.90,
        '2024-01-15 10:45:00',
        'aprovado',
        'Almoço no restaurante'
    ),
    (
        1,
        5,
        12.00,
        '2024-01-14 16:20:00',
        'aprovado',
        'Café da manhã'
    ),
    (
        2,
        4,
        200.00,
        '2024-01-14 15:30:00',
        'saldo_insuficiente',
        'Tentativa de compra no mercado'
    );