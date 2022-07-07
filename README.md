# Goal

You have 5 steps to go through in order to achieve this program.

The firt one will be to be able to launch this application. After that, popups will guide you through the various exercises.

Some bugs are hidden in this application and you may have to correct them

You can fork this project and work on you own.

Please email me a screen of each step you resolved.

If you are stuck dont hesitate to contact me.

# Requirements

## software

- vscode (https://code.visualstudio.com/)

- dotnet sdk 6+ (https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

### database

The project uses a local sqlite database. You dont need any database service to get started

Some tools are required to update or initalize the database in case of a fresh start

You may need to install database tools

    dotnet tool install --global dotnet-ef

If you have to create a local database follow this tutorial :
https://docs.microsoft.com/fr-fr/ef/core/get-started/overview/first-app?tabs=netcore-cli#create-the-database

## Environment setup

### install frontend dependencies

    cd clientApp
    npm install

### launch dev environment

In vscode, start the debug by pressing F5. When the service is ready, a browser window will be openned automatically.

Remember

- All changes to client side code will be reloaded automatically
- If you change backend code (.cs), you will need to reload the debug process (Ctrl+Shift+F5)

### with docker

install docker if needed

https://docs.docker.com/desktop/windows/install/

    docker build -t <image_tag> .
    docker run -it --rm -p 8080:80 --name web <image_tag>
