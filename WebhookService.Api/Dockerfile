# Use a imagem base do .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Copia os arquivos da aplicação
COPY . /app

# Expondo a porta do Webhook
EXPOSE 8080

# Comando para rodar a aplicação
CMD ["dotnet", "WebhookService.dll"]
