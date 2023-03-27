#FROM  microsoft/mssql-server-windows-developer:latest
FROM mcr.microsoft.com/mssql/server:2022-latest
USER root
#FROM mcr.microsoft.com/mssql/server:2022-latest
ENV ACCEPT_EULA = Y
ENV SA_PASSWORD = S3cur3P@ssW0rd!

COPY ./kpproducts.sql .
COPY ./start.sh .
COPY ./entrypoint.sh .
#COPY kpproducts.sql /docker-entrypoint-initdb.d/
#EXPOSE 3306
EXPOSE 1433
#ENTRYPOINT ["/bin/bash", "start.sh"]
#CMD [ "/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Pa55W0rd!1234* -d master -i KPProducts.sql" ]
#ENTRYPOINT ["/bin/bash", "/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Pa55W0rd!1234* -d master -i KPProducts.sql"]

#RUN sudo ./start.sh
RUN chmod +x ./start.sh
USER docker
CMD /bin/bash ./entrypoint.sh