-- Script para verificar e corrigir o banco de dados
USE digibank;

-- Verificar se as tabelas existem
SHOW TABLES;

-- Verificar se há terminais
SELECT * FROM terminal_pos;

-- Verificar se há cartões
SELECT * FROM cartao;

-- Verificar se há contas
SELECT * FROM conta;

-- Se não há terminais, inserir novamente
INSERT IGNORE INTO
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

-- Verificar novamente
SELECT COUNT(*) as total_terminais FROM terminal_pos;

SELECT COUNT(*) as total_cartoes FROM cartao;

SELECT COUNT(*) as total_contas FROM conta;