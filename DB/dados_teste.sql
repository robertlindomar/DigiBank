-- Dados mínimos para testes com 2 usuários e 2 cartões
-- IMPORTANTE: isso apaga dados atuais! Execute somente em ambiente de teste

USE digibank;

SET FOREIGN_KEY_CHECKS = 0;

TRUNCATE TABLE pagamento_pos;

TRUNCATE TABLE transacao;

TRUNCATE TABLE terminal_pos;

TRUNCATE TABLE cartao;

TRUNCATE TABLE usuario;

TRUNCATE TABLE conta;

TRUNCATE TABLE cliente;

SET FOREIGN_KEY_CHECKS = 1;

-- Clientes (2 usuários)
INSERT INTO
    cliente (id, nome, cpf)
VALUES (
        1,
        'Loja Teste',
        '000.000.000-00'
    ),
    (
        2,
        'Cliente Teste',
        '111.111.111-11'
    );

-- Usuários (logins) - senhas são hashes bcrypt de exemplo
-- senha: 123456 (para ambos)
INSERT INTO
    usuario (
        id,
        cliente_id,
        login,
        senha,
        ativo,
        tipo
    )
VALUES (
        1,
        1,
        'loja',
        '$2a$11$9CaOWUQHHzwgDdsgvfKMZOnBRZRvbCtE55QkfudF83tHg3SR5aYEq',
        1,
        'cliente'
    ),
    (
        2,
        2,
        'cliente',
        '$2a$11$9CaOWUQHHzwgDdsgvfKMZOnBRZRvbCtE55QkfudF83tHg3SR5aYEq',
        1,
        'cliente'
    );

-- Contas (1 por usuário)
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
        uid,
        conta_id,
        ativo
    )
VALUES (
        1,
        'Terminal Loja',
        'Loja Teste',
        'Centro',
        'POS001',
        1,
        1
    );

-- Cartões NFC (um para cada usuário) com os UIDs solicitados
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

-- Opcional: pagamentos de exemplo (comentado)
-- INSERT INTO pagamento_pos (terminal_id, cartao_id, valor, data_pagamento, status, descricao) VALUES
-- (1, 2, 50.00, NOW(), 'aprovado', 'Venda teste');


-- Resumo das correções:
-- ✅ Adicionei as declarações dos controles no TerminalPos.Designer.cs:
-- private System.Windows.Forms.Label lblUidCartao;
-- private System.Windows.Forms.TextBox txtUidCartao;
-- ✅ Criei o script DB/dados_teste.sql com dados mínimos:
-- Loja Teste (conta 1, recebedora) - UID: 0848182788
-- Cliente Teste (conta 2, pagador) - UID: 0066581178
-- Terminal POS ativo
-- Contas com saldo inicial
-- ✅ Ajustei a lógica no TerminalPos.cs para:
-- Validar o UID digitado
-- Buscar o cartão pelo UID no backend
-- Processar transferência real entre contas
-- Para testar:
-- Execute o script SQL: mysql -u root -p < DB/dados_teste.sql
-- Abra a aplicação e vá para Maquininha POS
-- Digite:
-- Valor: 50,00
-- UID do Cartão: 0066581178 (cartão do cliente)
-- Clique em 💳 Aproximar Cartão
-- A transferência deve debitar R$ 50,00 da conta do cliente (ID 2) e creditar na conta da loja (ID 1), funcionando como uma maquininha real! 🎉