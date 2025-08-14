-- Script para testar o TerminalPOS corrigido
-- Este script adiciona um terminal para o usuário "loja" para testar o sistema

USE digibank;

-- Verificar dados existentes
SELECT '=== DADOS EXISTENTES ===' as info;

SELECT 'Clientes:' as info;

SELECT id, nome, cpf FROM cliente;

SELECT 'Usuários:' as info;

SELECT u.id, u.login, u.tipo, c.nome as nome_cliente
FROM usuario u
    JOIN cliente c ON u.cliente_id = c.id;

SELECT 'Contas:' as info;

SELECT c.id, c.numero_conta, c.tipo, c.saldo, cl.nome as nome_cliente
FROM conta c
    JOIN cliente cl ON c.cliente_id = cl.id;

SELECT 'Terminais:' as info;

SELECT t.id, t.nome, t.nome_loja, t.uid, t.conta_id, c.numero_conta
FROM terminal_pos t
    JOIN conta c ON t.conta_id = c.id;

SELECT 'Cartões:' as info;

SELECT ca.id, ca.uid, ca.apelido, ca.conta_id, c.numero_conta
FROM cartao ca
    JOIN conta c ON ca.conta_id = c.id;

-- Adicionar terminal para o usuário "loja" se não existir
SELECT '=== ADICIONANDO TERMINAL PARA LOJA ===' as info;

-- Verificar se já existe terminal para a conta da loja
SELECT COUNT(*) as total_terminais_loja
FROM
    terminal_pos t
    JOIN conta c ON t.conta_id = c.id
    JOIN cliente cl ON c.cliente_id = cl.id
WHERE
    cl.nome = 'Loja Teste';

-- Inserir terminal se não existir
INSERT INTO
    terminal_pos (
        nome,
        nome_loja,
        localizacao,
        uid,
        conta_id,
        ativo
    )
SELECT 'Terminal Loja Teste', 'Loja Teste', 'Centro Comercial', 'TERM_LOJA_001', c.id, 1
FROM conta c
    JOIN cliente cl ON c.cliente_id = cl.id
WHERE
    cl.nome = 'Loja Teste'
    AND NOT EXISTS (
        SELECT 1
        FROM terminal_pos t
        WHERE
            t.conta_id = c.id
    );

-- Verificar se foi inserido
SELECT '=== VERIFICANDO INSERÇÃO ===' as info;

SELECT t.id, t.nome, t.nome_loja, t.uid, t.conta_id, c.numero_conta
FROM terminal_pos t
    JOIN conta c ON t.conta_id = c.id
WHERE
    c.numero_conta = '0001-1';

-- Dados finais para teste
SELECT '=== DADOS FINAIS PARA TESTE ===' as info;

SELECT 'Para testar o TerminalPOS:' as instrucao;

SELECT '1. Faça login com usuário: loja' as passo;

SELECT '2. Senha: 123456' as passo;

SELECT '3. Vá para Maquininha POS' as passo;

SELECT '4. Digite valor (ex: 50.00)' as passo;

SELECT '5. Digite UID do cartão cliente: 0066581178' as passo;

SELECT '6. Clique em 💳 Aproximar Cartão' as passo;

SELECT '=== RESULTADO ESPERADO ===' as info;

SELECT 'O pagamento deve ser processado e o valor transferido da conta do cliente (1234-5) para a conta da loja (0001-1)' as resultado;