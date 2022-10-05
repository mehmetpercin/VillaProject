FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
EXPOSE 80

COPY ./Core/VillaProject.Domain/*.csproj ./VillaProject.Domain/
COPY ./Core/VillaProject.Application/*.csproj ./VillaProject.Application/
COPY ./Infrastructure/VillaProject.Persistence/*.csproj ./VillaProject.Persistence/
COPY ./Infrastructure/VillaProject.Identity/*.csproj ./VillaProject.Identity/
COPY ./Tests/VillaProject.UnitTests/*.csproj ./VillaProject.UnitTests/
COPY ./Presentation/VillaProject.WebAPI/*.csproj ./VillaProject.WebAPI/
COPY *.sln .

RUN dotnet restore ./VillaProject.WebAPI/*.csproj
COPY . .

RUN dotnet test ./Tests/VillaProject.UnitTests/*.csproj
RUN dotnet publish ./Presentation/VillaProject.WebAPI/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet","VillaProject.WebAPI.dll"]