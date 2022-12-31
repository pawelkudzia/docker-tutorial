FROM nginx:1.23.3-alpine
COPY app.com.conf /etc/nginx/conf.d/app.com.conf
