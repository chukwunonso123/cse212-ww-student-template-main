using System.Collections.Generic;
using System.Text.Json.Serialization;

// Root object
public class FeatureCollection
{
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }
}

// Each item in the "features" array
public class Feature
{
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }

    [JsonPropertyName("geometry")]
    public Geometry Geometry { get; set; }
}

// "properties" contains metadata like magnitude and location
public class Properties
{
    [JsonPropertyName("mag")]
    public double? Magnitude { get; set; }

    [JsonPropertyName("place")]
    public string Place { get; set; }

    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
}

// "geometry" contains the coordinates of the quake
public class Geometry
{
    [JsonPropertyName("coordinates")]
    public List<double> Coordinates { get; set; }

    public double Longitude => Coordinates.Count > 0 ? Coordinates[0] : 0;
    public double Latitude => Coordinates.Count > 1 ? Coordinates[1] : 0;
    public double Depth => Coordinates.Count > 2 ? Coordinates[2] : 0;
}
