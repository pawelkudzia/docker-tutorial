FROM nginx:1.25.2-alpine3.18-slim
COPY app.com.conf /etc/nginx/conf.d/app.com.conf
