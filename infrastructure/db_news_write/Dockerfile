FROM postgres:13
ENV POSTGRES_USER=postgres
ENV POSTGRES_PASSWORD=postgres
ADD 1-structure.sql /docker-entrypoint-initdb.d/
ADD 2-data.sql /docker-entrypoint-initdb.d/
EXPOSE 5432