# System Utilities Api

This is a quick sample of .net core 2.0 based application, that allows to show and stop running server's processes.

## Prerequisites. 

1. Visual Studio 2017
2. .Net Core 2.0 package installed

## Getting started

Open solution in Visual Studio
Build and Run application ( F5 )

Then just call the api ( from Postman for example )  

To get  (GET)    baseurl/api/SystemProcess  
To stop (DELETE) baseurl/api/SystemProcess/id  ( where id - some process number )  

## The process should be run under the User with enough access right to System processes. 