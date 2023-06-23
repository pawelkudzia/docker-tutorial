FROM nginx:1.25.1-alpine3.17-slim
COPY app.com.conf /etc/nginx/conf.d/app.com.conf
