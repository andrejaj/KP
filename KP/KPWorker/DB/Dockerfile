FROM mcr.microsoft.com/mssql/server:2022-latest

USER root

WORKDIR /src

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=S3cur3P@ssW0rd!
ENV MSSQL_PID=Developer
ENV MSSQL_TCP_PORT=1433

COPY /KPWorker/DB/kpproducts.sql ./kpproducts.sql
RUN chmod +x ./kpproducts.sql

RUN (/opt/mssql/bin/sqlservr --accept-eula &) | grep -q "Service Broker manager has started" && sleep 5s && (/opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -Usa -PS3cur3P@ssW0rd! -d master -i kpproducts.sql)