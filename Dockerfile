FROM microsoft/dotnet:sdk AS development
WORKDIR /app
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o out
CMD ["dotnet", "watch", "run"]

FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=development /app/out .

RUN apt-get update && \
    apt-get install -y python3 python3-pip && \
    pip3 install awscli

COPY entrypoint.sh /
RUN chmod +x /entrypoint.sh

ENTRYPOINT /entrypoint.sh
