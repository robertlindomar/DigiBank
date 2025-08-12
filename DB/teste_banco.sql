-- Teste do banco de dados
USE digibank;

-- Verificar tabelas
SHOW TABLES;

-- Verificar terminais
SELECT 'TERMINAIS:' as info;

SELECT id, nome, nome_loja, ativo FROM terminal_pos;

-- Verificar cartões
SELECT 'CARTÕES:' as info;

SELECT id, apelido, uid, ativo FROM cartao;

-- Verificar contas
SELECT 'CONTAS:' as info;

SELECT id, numero_conta, tipo, saldo FROM conta;