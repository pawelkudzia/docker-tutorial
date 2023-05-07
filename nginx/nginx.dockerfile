FROM nginx:1.24.0-alpine
COPY app.com.conf /etc/nginx/conf.d/app.com.conf
