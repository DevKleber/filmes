using System.Diagnostics;
using System.Text.Json;
using FilmesApi.TestArrayList;


class Person
{
    private Dictionary<string, dynamic> arGithubEventPrepared;
    private List<GithubEvent> arGithubEvent;

    public Person(string id_pessoa)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        LoadData();
        // PrepareData();
        FindPerson(id_pessoa);

        stopwatch.Stop();
        TimeSpan elapsed = stopwatch.Elapsed;
        Console.WriteLine("Total time [benchmark]: " + elapsed.Milliseconds + " ms");
    }

    private void LoadData()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        using (FileStream stream = File.OpenRead("Controllers/TextArrayList/large-file.json"))
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                arGithubEvent = JsonSerializer.Deserialize<List<GithubEvent>>(json);
            }
        }

        stopwatch.Stop();
        TimeSpan elapsed = stopwatch.Elapsed;
        Console.WriteLine("LoadData [benchmark]: " + elapsed.Milliseconds + " ms");
    }

    // private void LoadData()
    // {
    //     Stopwatch stopwatch = new Stopwatch();
    //     stopwatch.Start();
    //     string json = File.ReadAllText("large-file.json");
    //     arGithubEvent = JsonSerializer.Deserialize<List<dynamic>>(json);
    //     // string json = File.ReadAllText("large-file.json");
    //     // arGithubEvent = JsonConvert.DeserializeObject<List<dynamic>>(json);
    //     stopwatch.Stop();
    //     TimeSpan elapsed = stopwatch.Elapsed;
    //     Console.WriteLine("LoadData [benchmark]: " + elapsed.Milliseconds + " ms");
    // }

    private void PrepareData()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        arGithubEventPrepared = new Dictionary<string, dynamic>();
        foreach (dynamic githubEvent in arGithubEvent)
        {
            if (githubEvent.TryGetProperty("id", out JsonElement idElement))
            {
                string id = idElement.GetString();
                arGithubEventPrepared.Add(id, githubEvent);

            }
        }

        stopwatch.Stop();
        TimeSpan elapsed = stopwatch.Elapsed;
        Console.WriteLine("PrepareData [benchmark]: " + elapsed.Milliseconds + " ms");
    }

    private void FindPerson(string id_pessoa)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        GithubEvent foundEvent = arGithubEvent.FirstOrDefault(eventObj => eventObj.Id == id_pessoa);

        if (foundEvent != null)
        {
            // Console.WriteLine("Event found: " + foundEvent.Id);
        }
        else
        {
            Console.WriteLine("Event not found with id: " + id_pessoa);
        }

        stopwatch.Stop();
        TimeSpan elapsed = stopwatch.Elapsed;
        Console.WriteLine("FindPerson [benchmark]: " + elapsed.Milliseconds + " ms");
    }
}
