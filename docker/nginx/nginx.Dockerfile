FROM nginx:1.25.4-alpine3.18-slim
COPY app.com.conf /etc/nginx/conf.d/app.com.conf
