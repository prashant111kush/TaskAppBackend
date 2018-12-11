FROM microsoft/dotnet:2-aspnetcore-runtime

WORKDIR /app
COPY bin/Debug/netcoreapp2.0/publish .

ENTRYPOINT ["dotnet", "/app/TaskAppBackend.dll"]