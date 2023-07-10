
## Técnologias

- C# (Backend) / .Net Core 6
  - Entity Framework
  - Mediator
- React (Frontend)
- Docker / Docker Compose

## Passos para instalação:

- Garanta que as portas 5000  e 3000 não estão sendo usadas no seu sistema operacional
- Vá até a pasta raiz, onde está o arquivo: docker-compose.yml
- Rode o seguinte comando para criar as imagens e containers: docker-compose up -d
- **(Quando finalizar de testar)** Rode o comando para finalizar os containers: docker-compose down


## Kanban

- Para usar o kanban, ir até o browser e digitar: http://localhost:3000, conforme a imagem abaixo
![image](https://github.com/ffonseca1985/adatech/assets/12939890/0293ad3b-a63b-4fa2-93ac-3559eb4f4b2f)

- Garanta que o titulo e a descrição estão sendo preenchidos

## Swagger

- Para verificar o swagger ir até: http://localhost:5000/swagger/index.html
- Para gerar o token, adicionar os dados de login, conforme a imagem abaixo:

![image](https://github.com/ffonseca1985/adatech/assets/12939890/e6e11e5e-c591-4588-a375-e2ff62854db1)
 
- Para usar qquer service da api, adicionar o token com o formato: Bearer <Token>, clicar em autorize e fechar, conforme a imagem abaixo:

![image](https://github.com/ffonseca1985/adatech/assets/12939890/2e516602-846c-4da6-a2fb-fdf0c2c5a24a)

- Depois é só consultar e adicionar o que quiser;

![image](https://github.com/ffonseca1985/adatech/assets/12939890/206e8f0d-27c0-4094-ba0c-a98fd707bf1f)
