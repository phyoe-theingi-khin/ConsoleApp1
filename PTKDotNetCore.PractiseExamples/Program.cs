// See https://aka.ms/new-console-template for more information
using PTKDotNetCore.PractiseExamples.DapperExample;
using PTKDotNetCore.PractiseExamples.EFCoreExample;

Console.WriteLine("Hello, World!");
//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Create("ProductNew", "CategoryNew", 100);
//dapperExample.Create("ProductNew1", "CategoryNew1", 100);
//dapperExample.Edit(20);
//dapperExample.Edit(3);
//dapperExample.Update(3, "ProductNew1", "CategoryNew1", 100);
//dapperExample.Delete(1);
EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
eFCoreExample.Create("ProductNew11", "CategoryNew11", 100);

Console.ReadKey();
