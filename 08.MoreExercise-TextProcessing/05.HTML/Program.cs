namespace _05.HTML;

class Program
{
    static void Main(string[] args)
    {
        string title = Console.ReadLine();
        string content = Console.ReadLine();

        Console.WriteLine($"<h1>\n" +
                          $"{title}\n" +
                          $"</h1>\n" +
                          $"<article>\n" +
                          $"{content}\n" +
                          $"</article>");

        string comment = default;
        while ((comment = Console.ReadLine()) != "end of comments")
        {
            Console.WriteLine($"<div>\n" +
                              $"{comment}\n" +
                              $"</div>");
        }
    }
}
