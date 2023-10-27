# WebAPI
IMPORTANTE - para fazer migrations: Github Codespace usa o sistema Linux

Execute o seguinte comando para adicionar o diretório de ferramentas do .NET Core ao seu PATH no seu perfil:

cat << \EOF >> ~/.bash_profile
# Adicionar ferramentas do .NET Core SDK
export PATH="$PATH:/home/codespace/.dotnet/tools"
EOF


Para que a configuração seja aplicada à sessão atual, execute o seguinte comando:

export PATH="$PATH:/home/codespace/.dotnet/tools"

você deve ser capaz de executar o dotnet-ef corretamente 
               _/\__       
               ---==/    \\      
         ___  ___   |.    \|\    
        | __|| __|  |  )   \\\   
        | _| | _|   \_/ |  //|\\ 
        |___||_|       /   \\\/\\

Ao gerar a migration, um código C# é criado, representando as operações que serão executadas no banco.

Add-Migration: dotnet ef migrations add CriandoTabelaDeFilme
Update-Database: dotnet ef database update

Instação do AutoMapper: 

dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

instalação do Microsoft.AspNetCore.Mvc.NewtonsoftJson 
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
