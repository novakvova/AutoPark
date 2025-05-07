# auto-asp

Create docker hub repository - publish
```
docker build -t auto-asp-api . 
docker run -it --rm -p 4391:8080 --name auto-asp_container auto-asp-api
docker run -d --restart=always --name auto-asp_container -p 4391:8080 auto-asp-api
docker run -d --restart=always -v d:/volumes/auto-asp/images:/app/uploading --name auto-asp_container -p 4391:8080 auto-asp-api
docker run -d --restart=always -v /volumes/auto-asp/images:/app/uploading --name auto-asp_container -p 4391:8080 auto-asp-api
docker ps -a
docker stop auto-asp_container
docker rm auto-asp_container

docker images --all
docker rmi auto-asp-api

docker login
docker tag auto-asp-api:latest novakvova/auto-asp-api:latest
docker push novakvova/auto-asp-api:latest

docker pull novakvova/auto-asp-api:latest
docker ps -a
docker run -d --restart=always --name auto-asp_container -p 4391:8080 novakvova/auto-asp-api

docker run -d --restart=always -v /volumes/auto-asp/images:/app/uploading --name auto-asp_container -p 4391:8080 novakvova/auto-asp-api


docker pull novakvova/auto-asp-api:latest
docker images --all
docker ps -a
docker stop auto-asp_container
docker rm auto-asp_container
docker run -d --restart=always --name auto-asp_container -p 4391:8080 novakvova/auto-asp-api
```

```nginx options /etc/nginx/sites-available/default
server {
    server_name   auto.itstep.click *.auto.itstep.click;
    client_max_body_size 200M;
    location / {
       proxy_pass         http://localhost:4391;
       proxy_http_version 1.1;
       proxy_set_header   Upgrade $http_upgrade;
       proxy_set_header   Connection keep-alive;
       proxy_set_header   Host $host;
       proxy_cache_bypass $http_upgrade;
       proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
       proxy_set_header   X-Forwarded-Proto $scheme;
    }
}


sudo systemctl restart nginx
certbot
```
