FROM mcr.microsoft.com/mssql/server:2022-latest
USER root

#WORKDIR /usr/src/
#WORKDIR /src

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=S3cur3P@ssW0rd!
ENV MSSQL_PID=Developer
ENV MSSQL_TCP_PORT=1433

# create directory within SQL container for database files
RUN mkdir -p /opt/mssql-scripts

COPY Scripts/kpproducts.sql /opt/mssql-scripts

RUN chmod +x /opt/mssql-scripts/kpproducts.sql

EXPOSE 1433

RUN (/opt/mssql/bin/sqlservr --accept-eula &) | grep -q "Service Broker manager has started" && sleep 5s && (/opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -Usa -PS3cur3P@ssW0rd! -d master -i /opt/mssql-scripts/kpproducts.sql)