FROM node:14-alpine as restore

WORKDIR /app
COPY package.json package-lock.json ./
RUN npm install -g npm@9.8.0
RUN npm install

FROM node:14-alpine as build
WORKDIR /app
COPY --from=restore /app .
COPY . .
RUN npm run build

FROM nginx:1.21.0-alpine as production
COPY --from=build /app/build /usr/share/nginx/html
COPY /nginx/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 3000
CMD ["nginx", "-g", "daemon off;"]

