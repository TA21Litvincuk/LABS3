# ������������� .NET SDK 8.0 ��� ��������
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# ������������ ������ ���������
WORKDIR /src

# ������� csproj ����� �� ���������� ���������
COPY ["Lab4MZRP/Lab4MZRP.csproj", "Lab4MZRP/"]
RUN dotnet restore "Lab4MZRP/Lab4MZRP.csproj"

# ������� ����� ����� ������
COPY . .

# �������� �������
RUN dotnet publish "Lab4MZRP.csproj" -c Release -o /app/publish

# ������������� ��������� � runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# ������� ������� ��� ������� ��������
ENTRYPOINT ["dotnet", "Lab4MZRP.dll"]
