using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // Problem 1: Find Pairs
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1]) continue; // skip words like "aa"

            var reversed = new string(new char[] { word[1], word[0] });

            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    // Problem 2: Degree Summary
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            if (fields.Length >= 4)
            {
                var degree = fields[3].Trim();
                if (!degrees.ContainsKey(degree))
                {
                    degrees[degree] = 0;
                }
                degrees[degree]++;
            }
        }
        return degrees;
    }

    // Problem 3: Anagram Check
    public static bool IsAnagram(string word1, string word2)
    {
        var clean1 = word1.Replace(" ", "").ToLower();
        var clean2 = word2.Replace(" ", "").ToLower();

        if (clean1.Length != clean2.Length)
            return false;

        var count1 = new Dictionary<char, int>();
        var count2 = new Dictionary<char, int>();

        foreach (var c in clean1)
        {
            if (!count1.ContainsKey(c)) count1[c] = 0;
            count1[c]++;
        }

        foreach (var c in clean2)
        {
            if (!count2.ContainsKey(c)) count2[c] = 0;
            count2[c]++;
        }

        foreach (var pair in count1)
        {
            if (!count2.ContainsKey(pair.Key) || count2[pair.Key] != pair.Value)
                return false;
        }

        return true;
    }

    // Problem 5: Earthquake Daily Summary
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        var result = new List<string>();

        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                var place = feature.Properties?.Place;
                var mag = feature.Properties?.Magnitude;
                result.Add($"{place} - Mag {mag}");
            }
        }

        return result.ToArray();
    }
} 
