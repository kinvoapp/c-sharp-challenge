# Desafio

Um consultor de investimentos, precisa controlar os investimentos dos seus clientes através de um software, hoje ele faz isso através de uma planilha. Ele precisa saber quais são os investimentos dos seus clientes, em relação a o montante total dos investimentos, e também o histórico, o dia da compra e o dia do resgate. Os tipos de investimentos são : Ações.  Além de controlar o montante total, ele controla o preço médio das ações, e o percentual de lucro, quando é feito algum resgate.

Cliente: Luena Caires Monte

| Ação    | Preço  | Quantidade | Subtotal | Taxas | Tipo      | Data      |
|---------|--------|------------|----------|-------|-----------|-----------|
| PETR4   | 19.40  | 50         | 970,00   | 6,00  | Aplicação | 02/10/2020|
| B3SA3   | 54.97  | 27         | 1484,19  | 3,50  | Aplicação | 22/02/2021|
| B3SA3   | 65,00  | 8          | 520,00   | 4,00  | Aplicação | 25/02/2021|
| B3SA3   | 63,00  | 19         | 1197,00  | 4,00  | Aplicação | 25/02/2021|
| MGLU3   | 25,00  | 100        | 1876,00  | 3,50  | Aplicação | 01/09/2021|
| MGLU3   | 18,76  | 20         | 375,2    | 3,50  | Aplicação | 15/09/2021|
| MGLU3   | 11.75  | 120        | 1410,00  | 0,00  | Resgate   | 03/05/2022|




| Ação    | Preço Médio | Quantidade | Total   |
|---------|-------------|------------|---------|
| PETR4   | 19,52       | 50         | 970,00  |  
| B3SA3   | 59,49       | 54         | 3212,00 |
| MGLU3   | 18,81       | 00         | 0,00    |

O desafio consiste em desenvolver uma aplicação, que permita ao consultor controlar os investimentos sem a necessidade da planilha.
A solução deve ser desenvolvida  com linguagem C#, utilizando o framework .Net Core na versão 3.1 ou superior,  os critérios serão considerados de acordo com o nível da vaga que se está concorrendo (Júnior, Pleno ou Sênior). 


Para vagas com foco em backend:
  Se seu foco é apenas em backend, tudo bem entregar uma aplicação focada apenas em API, sem interface, mas sinta-se à vontade para entregar ambos.


    * Exigido :
        * Orientação a Objetos
        * Testes Unitários (TDD)
        * Clareza de Código
    * Diferenciais : 
        * Clean Architecture
        * ___SOLID___
        * ___Domain Driven Design(DDD)___
        * Behavior Driven Design(BDD)
        * ___Design Patterns___
        *___Clean Code___
      

___Observação: Para os níveis Pleno e Sênior é importante atender aos diferenciais,  no mínimo os destacados em negrito;___