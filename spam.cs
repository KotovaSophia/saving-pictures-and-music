using System; 
using System.Diagnostics; 
using System.IO; 
using System.Net.Http; 
using System.Threading.Tasks; 

internal class Program 
{ 
private static async Task Main(string[] args) 
{ 
HttpClient client = new HttpClient(); 

Console.WriteLine("Введите ссылку для скачивания изображения: "); 
string imageLink = Console.ReadLine(); 
HttpResponseMessage imageResponse = await client.GetAsync(imageLink); 
byte[] imageData = await imageResponse.Content.ReadAsByteArrayAsync(); 

Console.WriteLine("Введите путь сохранения изображения: "); 
string imagePath = Console.ReadLine(); 
await File.WriteAllBytesAsync(imagePath, imageData); 

Process.Start(new ProcessStartInfo { FileName = imagePath, UseShellExecute = true }); 

HttpClient client1 = new HttpClient(); 
Console.WriteLine("Введите ссылку для скачивания аудиофайла: "); 
string audioLink = Console.ReadLine(); 

HttpResponseMessage audioResponse = await client1.GetAsync(audioLink); 
byte[] audioData = await audioResponse.Content.ReadAsByteArrayAsync(); 

Console.WriteLine("Введите путь сохранения аудиофайла: ");
string audioPath = Console.ReadLine(); 
await File.WriteAllBytesAsync(audioPath, audioData); 

Process.Start(new ProcessStartInfo { FileName = audioPath, UseShellExecute = true }); 
} 
}