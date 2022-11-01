# Advanced .NET Framework features

[![.NET](https://github.com/jsowndarrajan/advanced-dotnet-features/actions/workflows/dotnet.yml/badge.svg)](https://github.com/jsowndarrajan/advanced-dotnet-features/actions/workflows/dotnet.yml)

## Channel

A channel is simply a data structure that is used to store produced data for a consumer to retrieve, and an appropriate synchronization to enable that to happen safely, while also enabling appropriate notifications in both directions. 

For example, The fast food employee places the completed burgers in a stand that the register worker pulls from to fill the customer’s bag. Here the channel is nothing but the stand that helps to place the burger.

`System.Threading.Channels` provides two types of channels:
* Bounded 
* Unbounded


