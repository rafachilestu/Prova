using Newtonsoft.Json;
using Questao2;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;

public class Program
{
    private static string url = "https://jsonmock.hackerrank.com/api/football_matches";

    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        Console.ReadLine();

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        // Recupera quando time 1
        FootballData? footballData1 = GetByTeamAndYear(team, year, 1);

        // Recupera quando time 2
        FootballData? footballData2 = GetByTeamAndYear(team, year, 2);

        var total = getTotal(footballData1, footballData2);

        return total;
    }

    private static int getTotal(FootballData? footballData1, FootballData? footballData2)
    {
        var totalGoals1 = 0;
        var totalGoals2 = 0;

        if (footballData1 != null)
            totalGoals1 = GetTeamGoals(footballData1);

        if (footballData2 != null)
            totalGoals2 = GetTeamGoals(footballData2);

        return totalGoals1 + totalGoals2;
    }

    private static int GetTeamGoals(FootballData footballData)
    {
        var totalGoals = 0;

        foreach (var football in footballData.data)
        {
            totalGoals += Convert.ToInt16(football.team1goals);
        }

        return totalGoals;
    }

    public static FootballData? GetByTeamAndYear(string team, int year, int posicao)
    {
        var footballData = new FootballData();

        using (var client = new HttpClient())
        {
            var response = client.GetAsync(url + "?year=" + year + "&team" + posicao + "=" + team).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;
                footballData = JsonConvert.DeserializeObject<FootballData>(responseString);
            }
        }

        return footballData;
    }
}