FROM nginx:1.23.1-alpine
COPY app.com.conf /etc/nginx/conf.d/app.com.conf
