# GSLumiNET

Lumi é uma aplicação desenvolvida para gerenciar registros de dados e fazer previsões de intensidade de lâmpadas com base na iluminação interna e externa. O sistema utiliza Machine Learning para realizar a previsão da intensidade da lâmpada.

## Instalação

1. Clone o repositório:

   ```bash
   git clone https://github.com/EzequielBispo/GSLumiNET.git
   cd GSLumiNET
2. Restaure as dependencias do projeto:
   ```bash
   dotnet restore

## Migrations

1. Definir as Migrations:
   ```bash
   dotnet ef migrations add InitialMigration --project GSLumiNET.Infrastructure/GSLumiNET.Infrastructure.csproj --startup-project GSLumiNET.API/GSLumiNET.API.csproj
2. Aplicando as Migrations:
   ```bash
   dotnet ef database update --project GSLumiNET.Infrastructure/GSLumiNET.Infrastructure.csproj --startup-project GSLumiNET.API/GSLumiNET.API.csproj

## Executando a aplicação
   ```bash
   dotnet run --project GSLumiNET.API/GSLumiNET.API.csproj


  
