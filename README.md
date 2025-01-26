# **Sistema de Categorização de Trades**

Este repositório contém uma aplicação de console desenvolvida em C# para classificar trades em um portfólio bancário com base em categorias pré-definidas. A solução foi projetada com **princípios de orientação a objetos** e segue **boas práticas** para garantir um código limpo, extensível e de fácil manutenção.

## **Funcionalidades**
- Classificação de trades em categorias pré-definidas:
  - **EXPIRED**: Trades com a próxima data de pagamento vencida há mais de 30 dias em relação à data de referência.
  - **HIGHRISK**: Trades com valor superior a $1.000.000 e cliente do setor privado.
  - **MEDIUMRISK**: Trades com valor superior a $1.000.000 e cliente do setor público.
- Estrutura extensível para adicionar novas categorias sem alterar o funcionamento existente.
- Leitura de entrada no formato esperado (data de referência, número de trades e detalhes de cada trade).

## **Tecnologias Utilizadas**
- **Linguagem**: C#
- **Paradigmas**: Orientação a Objetos (OOP)
- **Entrada e Saída**: Aplicação de Console para leitura e processamento dos dados.

## **Como Executar**
1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/nome-do-repositorio.git
2. Abra o projeto em um ambiente de desenvolvimento C# (ex.: Visual Studio ou Visual Studio Code).
3. Compile e execute o programa.
4. Forneça os dados de entrada conforme o exemplo abaixo.

## **Exemplo de Entrada**
12/11/2020  
4  
2000000 Private 12/29/2025  
400000 Public 07/01/2020  
5000000 Public 01/02/2024  
3000000 Public 10/26/2023  

## ** Exemplo de Saída**
HIGHRISK  
EXPIRED  
MEDIUMRISK  
MEDIUMRISK  

## Resposta da Questão 2

Para implementar a categoria **PEP** (Politically Exposed Person), basta adicionar uma nova verificação no classificador de trades. 
A interface `ITrade` precisa ser atualizada com uma propriedade booleana chamada `IsPoliticallyExposed`, assim, ao classificar um trade, se a propriedade `IsPoliticallyExposed` for `true`, a categoria "PEP" será atribuída ao trade. 
Essa lógica deve ser adicionada como uma verificação adicional, antes das outras categorias, para garantir que o trade seja corretamente classificado como "PEP" quando aplicável.
OBS: o PEP deve ser adicionado no Dicionário junto as outras funcionalidades, a implementação do dicionário é a adoção de um padrão de desing chamado Chain of Responsability.



## ** Autor: João Leite**
