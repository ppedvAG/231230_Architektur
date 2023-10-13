// See https://aka.ms/new-console-template for more information
using RESTClient;

Console.WriteLine("Hello, World!");



var url = "https://www.googleapis.com/books/v1/volumes?q=dotnet";


var http = new HttpClient();
var json = http.GetStringAsync(url).Result;

//Console.WriteLine(json);


var books = System.Text.Json.JsonSerializer.Deserialize<Books>(json);


foreach (var book in books.items)
    Console.WriteLine($"{book.volumeInfo.title}");

