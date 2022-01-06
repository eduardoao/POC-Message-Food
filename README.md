# POC-Food-Test
Para subir a aplicação é necessário ter o docker instalado.

Entre na pasta docker-compose e execute os seguintes comandos:

docker-compose build
docker-compose up -d

Esse irá realizar o setup da estrutura dos seguintes serviços: 

1 - Kafka, serviço de mensageria; 
2 - Kafdrop, gerenciamento de filas do Kafka. Poderá ser acessado no seguinte endereço: http://localhost:19000/
3 - MySQL 
4 - Adminer, serviço de gerenciamento da base de dados MySql. Poderá ser acessado no endereço: http://localhost:8080/. 
4.1 - Para realizar o login no Adminer. 
    - Servidor: db
    - Usuário: root
    - Senha: root
    - Base de Dados: POC

Para a execução da solução. No visual studio aperte F5

Acessar o endereço: https://localhost:5001/swagger/index.html

Em Post Orders, colocar o sequinte body: 

{
  "customerId": "8e2911be-bc52-490e-8769-a90f1b47b9fd",
  "orderId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "orderProductItem": [
     {
      "title": "Fries",
      "description": "Fries",      
      "price": 2,
      "quantity": 1,
      "eAreas": 1
    },
     {
      "title": "Grill",
      "description": "Grill",      
      "price": 2,
      "quantity": 1,
      "eAreas": 2
    },
    {
      "title": "Salad",
      "description": "Salad",      
      "price": 2,
      "quantity": 1,
      "eAreas": 3
    },    
       {
      "title": "Desert",
      "description": "Desert",      
      "price": 2,
      "quantity": 1,
      "eAreas": 5
    }
  ]
}






