# Moip - Teste

# Introdução

O Moip tem uma aplicação que envia webhooks para os ecommerces de seus clientes, esses webhooks possuem informações sobre pagamentos (se foram autorizados, cancelados, etc).

Esta aplicação gera logs bastante grandes, precisamos descobrir através do log quem são os clientes que mais recebem os webhooks e verificar todos o response status retornados pelo servidores dos clientes.

Task O arquivo de log em anexo contém informações de envio de webhooks no format:

level=info response_body="" request_to"" response_headers= response_status=""

Onde:

url: é a url para onde foi enviado o webhook code: é o status code retornado pelo servidor do cliente As outras informações são irrelevantes para esta task.

Você deve parsear o arquivo e no final mostrar as seguintes informações na saída:

3 urls mais chamadas com a quantidade Uma tabela mostrando a quantidade de webhooks por status

Ex:

https://woodenoyster.com.br - 100

https://grotesquemoon.de - 99

https://notoriouslonesome.com - 90

200 - 100

201 - 99

ps: o resultado acima não é o real.

# Abordagem

Após análises para saber o que melhor performaria, a melhor solução não foi usar paralelismo, pois às vezes algumas threads se perdem e a quantidade de itens na lista se torna menor, além de possíveis exceptions por referência nula. Neste caso, decidi usar um for comum, devido o problema citado.

Para a atribuição de string, fiz uso do StringBuilder, o qual no C#, é a maneira correta de concatenar strings quando há mais de 1000 linhas, caso contrário o string.join seria de melhor performance.

A fim de melhor a possibilidade de testes, separei em várias classes, assim elas podem ser testadas individualmente, além de poder atribuir alguma validação, até porque, a classe deve ser responsável por ela mesma.

# Testes

No projeto existe um projeto de testes com dois simples casos de teste. Criei apenas 2 para fins didáticos.

# Como executar a aplicação.

- Clone o projeto para a sua máquina.
- Abra o projeto e inicie sua aplicação.
- Execute-o
