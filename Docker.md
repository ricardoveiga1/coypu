# Ambiente de testes

## Baixar as imagens

docker pull postgres
docker pull dpage/pgadmin4
docker pull qaninja/ninjaplus-api
docker pull qaninja/ninjaplus-web

### Visualiar imagens

docker images
clear - limpar terminal

### Criar a rede  Docker com nome skynet

docker network create --driver bridge skynet

### Subir o Banco de Dados

docker run --name pgdb --network=skynet -e "POSTGRES_PASSWORD=qaninja" -p 5432:5432 -v var/lib/postgresql/data -d postgres

### Visualizar container que estão sendo executado(de pé)

docker ps

## Configurar o host - mostrado no vídeo(para win e mac são distintos) - so fiz para mac
rotear os containers

sudo vim /etc/hosts
digitar senha admin
teclar i para entrar no modo insert
ponho curso até o final da linhas e clico enter
digito 
127.0.0.1 + TAB + pgdb
127.0.0.1         pgadmin
127.0.0.1		  ninjaplus-api
127.0.0.1         ninjaplus-web
teclar ESC para sair do modo insert
Shift + :wq! + Enter para salvar

Listar o arquivo host para ver se salvou: cat /etc/hosts

Passo mais fácil - editar com vscode: sudo code /etc/hosts



### Subir o Administrador do Banco de Dados (PgAdmin)

docker run --name pgadmin --network=skynet -p 15432:80 -e "PGADMIN_DEFAULT_EMAIL=root@qaninja.io" -e "PGADMIN_DEFAULT_PASSWORD=qaninja" -d dpage/pgadmin4
docker ps
no naveador: pgadmin:15432

### Subir a API 

docker run --name ninjaplus-api --network=skynet -e "DATABASE=pgdb" -p 3000:3000 -d qaninja/ninjaplus-api
docker ps
no navegador: ninjaplus-api:3000
documentação: ninjaplus-api:3000/apidoc


### Subir a Aplicação Web

docker run --name ninjaplus-web --network=skynet -e "VUE_APP_API=http://ninjaplus-api:3000" -p 5000:5000 -d qaninja/ninjaplus-web
docker ps
no navegador: ninjaplus-web:5000


### Importante:​
### Quando você reiniciar o seu computador, certifique-se que o Docker esteja online e suba containers​ novamente:

docker start pgdb
docker start pgadmin
​docker start ninjaplus-api
​docker start ninjaplus-web

### Se alguma coisa der errado e for necessário refazer a aula, voce poderá remover os containers com os seguintes comandos:

docker rm -f ​pgdb
docker rm -f ​pgadmin
docker rm -f ​ninjaplus-api
docker rm -f ​ninjaplus-web


acessar 127.0.0.1
