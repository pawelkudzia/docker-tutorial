FROM nginx:1.23.2-alpine
COPY app.com.conf /etc/nginx/conf.d/app.com.conf
