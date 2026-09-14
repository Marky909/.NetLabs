Write-Host "Installing .NET packages..." -ForegroundColor Cyan

dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Swashbuckle.AspNetCore

Write-Host ""
Write-Host "All packages installed successfully!" -ForegroundColor Green