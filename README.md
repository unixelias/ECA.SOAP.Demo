ECA.SOAP.Demo
============

Para rodar o projeto, é necessário ter o git e Dotnet SDK 6.0 instalados.

Executar os comandos a seguir:

####Clone o repositório:

```sh
git clone https://github.com/unixelias/ECA.SOAP.Demo.git
```


####Restaure os pacotes Nuget:

```sh
dotnet restore
```


####Compile a solução:

```sh
dotnet publish -c Release
```


####Acesse o ditetório de compilação e execute a aplicação:

```sh
cd ECA.SOAP.Demo/bin/Release/net6.0/publish/

./ECA.SOAP.Demo
```

####Acesse o swagger pelo seu navegador e use a API:

```sh
cd ECA.SOAP.Demo/bin/Release/net6.0/publish/

./ECA.SOAP.Demo
```