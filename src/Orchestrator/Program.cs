// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Orchestrator.Injection;

Console.WriteLine("Hello, World!");


var services = new ServiceCollection();

services.ConfigureQueue();