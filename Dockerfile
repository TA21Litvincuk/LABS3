# Використовуємо .NET SDK 8.0 для побудови
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Встановлюємо робочу директорію
WORKDIR /src

# Копіюємо csproj файли та відновлюємо залежності
COPY ["Lab4MZRP/Lab4MZRP.csproj", "Lab4MZRP/"]
RUN dotnet restore "Lab4MZRP/Lab4MZRP.csproj"

# Копіюємо решту файлів проєкту
COPY . .

# Публікуємо додаток
RUN dotnet publish "Lab4MZRP.csproj" -c Release -o /app/publish

# Використовуємо контейнер з runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Вказуємо команду для запуску програми
ENTRYPOINT ["dotnet", "Lab4MZRP.dll"]
