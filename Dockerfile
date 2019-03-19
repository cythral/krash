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
ENTRYPOINt ["dotnet", "krash.dll"]
