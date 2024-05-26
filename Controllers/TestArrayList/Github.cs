namespace FilmesApi.TestArrayList;

using System;

using System;
using System.Text.Json.Serialization;

public class GithubEvent
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("actor")]
    public Actor Actor { get; set; }

    [JsonPropertyName("repo")]
    public Repo Repo { get; set; }

    [JsonPropertyName("payload")]
    public Payload Payload { get; set; }

    [JsonPropertyName("public")]
    public bool Public { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}

public class Actor
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("login")]
    public string Login { get; set; }

    [JsonPropertyName("gravatar_id")]
    public string GravatarId { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; set; }
}

public class Repo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class Payload
{
    [JsonPropertyName("ref")]
    public string Ref { get; set; }

    [JsonPropertyName("ref_type")]
    public string RefType { get; set; }

    [JsonPropertyName("master_branch")]
    public string MasterBranch { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("pusher_type")]
    public string PusherType { get; set; }
}
