CREATE TABLE ContasAPagar (
    Numero INT PRIMARY KEY,
    CodigoFornecedor INT NOT NULL,
    DataVencimento DATE NOT NULL,
    Valor DECIMAL(10,2) NOT NULL
);

CREATE TABLE ContasPagas (
    Numero INT PRIMARY KEY,
    DataPagamento DATE,
    Desconto DECIMAL(10,2),
    Acrescimo DECIMAL(10,2),
    FOREIGN KEY (Numero) REFERENCES ContasAPagar(Numero)
);

CREATE TABLE Pessoas (
    Codigo INT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL
);


INSERT INTO ContasAPagar (Numero, CodigoFornecedor, DataVencimento, Valor)
VALUES
    (12345, 1, '2024-03-31', 1000.00),
    (67890, 2, '2024-04-15', 500.00),
    (34567, 3, '2024-04-20', 750.00);

INSERT INTO ContasPagas (Numero, DataPagamento, Desconto, Acrescimo)
VALUES
    (12345, '2024-04-10', 50.00, 0.00),
    (34567, NULL, 0.00, 25.00);

INSERT INTO Pessoas (Codigo, Nome)
VALUES
    (1, 'ACME Inc.'),
    (2, 'XYZ Company'),
    (3, 'Construtora Omega');

SELECT
P.Numero AS NumeroProcesso,
C.Nome AS NomeFornecedor,
P.DataVencimento,
COALESCE(CP.DataPagamento, P.DataVencimento) AS DataPagamento,
P.Valor - COALESCE(CP.Desconto, 0) + COALESCE(CP.Acrescimo, 0) AS ValorLiquido,
CASE WHEN CP.Numero IS NULL THEN 'A Pagar' ELSE 'Paga' END AS Situacao
FROM ContasAPagar P
LEFT JOIN ContasPagas CP ON P.Numero = CP.Numero
JOIN Pessoas C ON P.CodigoFornecedor = C.Codigo;

-------------------------------------------------