# Use a imagem base do .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

COPY . /app

EXPOSE 8080

# Comando para rodar a aplicação
CMD ["dotnet", "WebhookService.dll"]
