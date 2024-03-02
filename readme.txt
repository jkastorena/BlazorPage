// Copyright (C) 2024 Javier Castorena
// 
// This file is part of Caxivari_cs.
// 
// Caxivari_cs is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Caxivari_cs is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Caxivari_cs.  If not, see <http://www.gnu.org/licenses/>.


dotnet add caxivari.API.csproj reference ../caxivari.DATA/caxivari.DATA.csproj

dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.2 
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.2

dotnet ef --startup-project ../caxivari.API migrations add caxivariINIT -c CaxivariContext
dotnet ef --startup-project ../caxivari.API database update
