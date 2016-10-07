using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace TailgateLive.NFL_API
{
    public class GET_NFL
    {
        static List<List<string>> ShowResultNFLTeam(RootObjectNFLTeam nflRootObject)
        {
            NFLTeam nflTeam = new NFLTeam { };
            List<List<string>> teamsList = new List<List<string>>();
            string teams;
            for (int i = 0; i < nflRootObject.NFLTeams.Count; i++)
            {
                nflTeam = nflRootObject.NFLTeams[i];
                teams = nflTeam.code + "," + nflTeam.fullName + "," + nflTeam.shortName;
                teamsList.Add(teams.Split(',').ToList());
            }
            return teamsList;
        }
        static async Task<RootObjectNFLTeam> GetResultAsyncNFLTeam(string path)
        {
            RootObjectNFLTeam nflRootObject = null;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
            using (HttpContent content = response.Content)
            {
                if (response.IsSuccessStatusCode)
                {
                    nflRootObject = await content.ReadAsAsync<RootObjectNFLTeam>();
                }
            }
            return nflRootObject;
        }
        public static List<List<string>> RunAsyncNFLTeam()
        {
            try
            {
                RootObjectNFLTeam nflRootObject = new RootObjectNFLTeam { };
                string path = "http://www.fantasyfootballnerd.com/service/nfl-teams/json/whmbtmf4wbqd/";
                Task<RootObjectNFLTeam> tempTeams = GetResultAsyncNFLTeam(path);
                tempTeams.Wait();
                nflRootObject = tempTeams.Result;
                return ShowResultNFLTeam(nflRootObject);
            }
            catch (Exception e)
            {
                string message = e.Message;
                List<string> messageList = new List<string>() { message };
                List<List<string>> catchReturn = new List<List<string>>() { messageList };
                return catchReturn;
            }
        }
        static List<List<string>> ShowResultWeather(RootObjectWeather nflRootObject)
        {
            Games g = new Games();
            g = nflRootObject.Games;
            List<List<string>> gameWeatherList = new List<List<string>>();
            string gameWeather;
            if (g.ARI != null) { gameWeather = g.ARI.gameId + "," + g.ARI.forecast + "," + g.ARI.low + "," + g.ARI.high + "," + g.ARI.windChill + "," + g.ARI.windSpeed + "," + g.ARI.geoLat + "," + g.ARI.geoLong + "," + g.ARI.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.ATL != null) { gameWeather = g.ATL.gameId + "," + g.ATL.forecast + "," + g.ATL.low + "," + g.ATL.high + "," + g.ATL.windChill + "," + g.ATL.windSpeed + "," + g.ATL.geoLat + "," + g.ATL.geoLong + "," + g.ATL.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.BAL != null) { gameWeather = g.BAL.gameId + "," + g.BAL.forecast + "," + g.BAL.low + "," + g.BAL.high + "," + g.BAL.windChill + "," + g.BAL.windSpeed + "," + g.BAL.geoLat + "," + g.BAL.geoLong + "," + g.BAL.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.BUF != null) { gameWeather = g.BUF.gameId + "," + g.BUF.forecast + "," + g.BUF.low + "," + g.BUF.high + "," + g.BUF.windChill + "," + g.BUF.windSpeed + "," + g.BUF.geoLat + "," + g.BUF.geoLong + "," + g.BUF.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.CAR != null) { gameWeather = g.CAR.gameId + "," + g.CAR.forecast + "," + g.CAR.low + "," + g.CAR.high + "," + g.CAR.windChill + "," + g.CAR.windSpeed + "," + g.CAR.geoLat + "," + g.CAR.geoLong + "," + g.CAR.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.CHI != null) { gameWeather = g.CHI.gameId + "," + g.CHI.forecast + "," + g.CHI.low + "," + g.CHI.high + "," + g.CHI.windChill + "," + g.CHI.windSpeed + "," + g.CHI.geoLat + "," + g.CHI.geoLong + "," + g.CHI.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.CIN != null) { gameWeather = g.CIN.gameId + "," + g.CIN.forecast + "," + g.CIN.low + "," + g.CIN.high + "," + g.CIN.windChill + "," + g.CIN.windSpeed + "," + g.CIN.geoLat + "," + g.CIN.geoLong + "," + g.CIN.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.CLE != null) { gameWeather = g.CLE.gameId + "," + g.CLE.forecast + "," + g.CLE.low + "," + g.CLE.high + "," + g.CLE.windChill + "," + g.CLE.windSpeed + "," + g.CLE.geoLat + "," + g.CLE.geoLong + "," + g.CLE.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.DAL != null) { gameWeather = g.DAL.gameId + "," + g.DAL.forecast + "," + g.DAL.low + "," + g.DAL.high + "," + g.DAL.windChill + "," + g.DAL.windSpeed + "," + g.DAL.geoLat + "," + g.DAL.geoLong + "," + g.DAL.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.DEN != null) { gameWeather = g.DEN.gameId + "," + g.DEN.forecast + "," + g.DEN.low + "," + g.DEN.high + "," + g.DEN.windChill + "," + g.DEN.windSpeed + "," + g.DEN.geoLat + "," + g.DEN.geoLong + "," + g.DEN.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.DET != null) { gameWeather = g.DET.gameId + "," + g.DET.forecast + "," + g.DET.low + "," + g.DET.high + "," + g.DET.windChill + "," + g.DET.windSpeed + "," + g.DET.geoLat + "," + g.DET.geoLong + "," + g.DET.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.GB != null) { gameWeather = g.GB.gameId + "," + g.GB.forecast + "," + g.GB.low + "," + g.GB.high + "," + g.GB.windChill + "," + g.GB.windSpeed + "," + g.GB.geoLat + "," + g.GB.geoLong + "," + g.GB.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.HOU != null) { gameWeather = g.HOU.gameId + "," + g.HOU.forecast + "," + g.HOU.low + "," + g.HOU.high + "," + g.HOU.windChill + "," + g.HOU.windSpeed + "," + g.HOU.geoLat + "," + g.HOU.geoLong + "," + g.HOU.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.IND != null) { gameWeather = g.IND.gameId + "," + g.IND.forecast + "," + g.IND.low + "," + g.IND.high + "," + g.IND.windChill + "," + g.IND.windSpeed + "," + g.IND.geoLat + "," + g.IND.geoLong + "," + g.IND.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.JAC != null) { gameWeather = g.JAC.gameId + "," + g.JAC.forecast + "," + g.JAC.low + "," + g.JAC.high + "," + g.JAC.windChill + "," + g.JAC.windSpeed + "," + g.JAC.geoLat + "," + g.JAC.geoLong + "," + g.JAC.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.KC != null) { gameWeather = g.KC.gameId + "," + g.KC.forecast + "," + g.KC.low + "," + g.KC.high + "," + g.KC.windChill + "," + g.KC.windSpeed + "," + g.KC.geoLat + "," + g.KC.geoLong + "," + g.KC.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.MIA != null) { gameWeather = g.MIA.gameId + "," + g.MIA.forecast + "," + g.MIA.low + "," + g.MIA.high + "," + g.MIA.windChill + "," + g.MIA.windSpeed + "," + g.MIA.geoLat + "," + g.MIA.geoLong + "," + g.MIA.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.MIN != null) { gameWeather = g.MIN.gameId + "," + g.MIN.forecast + "," + g.MIN.low + "," + g.MIN.high + "," + g.MIN.windChill + "," + g.MIN.windSpeed + "," + g.MIN.geoLat + "," + g.MIN.geoLong + "," + g.MIN.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.NYG != null) { gameWeather = g.NYG.gameId + "," + g.NYG.forecast + "," + g.NYG.low + "," + g.NYG.high + "," + g.NYG.windChill + "," + g.NYG.windSpeed + "," + g.NYG.geoLat + "," + g.NYG.geoLong + "," + g.NYG.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.NYJ != null) { gameWeather = g.NYJ.gameId + "," + g.NYJ.forecast + "," + g.NYJ.low + "," + g.NYJ.high + "," + g.NYJ.windChill + "," + g.NYJ.windSpeed + "," + g.NYJ.geoLat + "," + g.NYJ.geoLong + "," + g.NYJ.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.NE != null) { gameWeather = g.NE.gameId + "," + g.NE.forecast + "," + g.NE.low + "," + g.NE.high + "," + g.NE.windChill + "," + g.NE.windSpeed + "," + g.NE.geoLat + "," + g.NE.geoLong + "," + g.NE.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.NO != null) { gameWeather = g.NO.gameId + "," + g.NO.forecast + "," + g.NO.low + "," + g.NO.high + "," + g.NO.windChill + "," + g.NO.windSpeed + "," + g.NO.geoLat + "," + g.NO.geoLong + "," + g.NO.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.OAK != null) { gameWeather = g.OAK.gameId + "," + g.OAK.forecast + "," + g.OAK.low + "," + g.OAK.high + "," + g.OAK.windChill + "," + g.OAK.windSpeed + "," + g.OAK.geoLat + "," + g.OAK.geoLong + "," + g.OAK.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.PHI != null) { gameWeather = g.PHI.gameId + "," + g.PHI.forecast + "," + g.PHI.low + "," + g.PHI.high + "," + g.PHI.windChill + "," + g.PHI.windSpeed + "," + g.PHI.geoLat + "," + g.PHI.geoLong + "," + g.PHI.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.PIT != null) { gameWeather = g.PIT.gameId + "," + g.PIT.forecast + "," + g.PIT.low + "," + g.PIT.high + "," + g.PIT.windChill + "," + g.PIT.windSpeed + "," + g.PIT.geoLat + "," + g.PIT.geoLong + "," + g.PIT.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.SD != null) { gameWeather = g.SD.gameId + "," + g.SD.forecast + "," + g.SD.low + "," + g.SD.high + "," + g.SD.windChill + "," + g.SD.windSpeed + "," + g.SD.geoLat + "," + g.SD.geoLong + "," + g.SD.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.SF != null) { gameWeather = g.SF.gameId + "," + g.SF.forecast + "," + g.SF.low + "," + g.SF.high + "," + g.SF.windChill + "," + g.SF.windSpeed + "," + g.SF.geoLat + "," + g.SF.geoLong + "," + g.SF.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.SEA != null) { gameWeather = g.SEA.gameId + "," + g.SEA.forecast + "," + g.SEA.low + "," + g.SEA.high + "," + g.SEA.windChill + "," + g.SEA.windSpeed + "," + g.SEA.geoLat + "," + g.SEA.geoLong + "," + g.SEA.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.LA != null) { gameWeather = g.LA.gameId + "," + g.LA.forecast + "," + g.LA.low + "," + g.LA.high + "," + g.LA.windChill + "," + g.LA.windSpeed + "," + g.LA.geoLat + "," + g.LA.geoLong + "," + g.LA.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.TB != null) { gameWeather = g.TB.gameId + "," + g.TB.forecast + "," + g.TB.low + "," + g.TB.high + "," + g.TB.windChill + "," + g.TB.windSpeed + "," + g.TB.geoLat + "," + g.TB.geoLong + "," + g.TB.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.TEN != null) { gameWeather = g.TEN.gameId + "," + g.TEN.forecast + "," + g.TEN.low + "," + g.TEN.high + "," + g.TEN.windChill + "," + g.TEN.windSpeed + "," + g.TEN.geoLat + "," + g.TEN.geoLong + "," + g.TEN.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.WAS != null) { gameWeather = g.WAS.gameId + "," + g.WAS.forecast + "," + g.WAS.low + "," + g.WAS.high + "," + g.WAS.windChill + "," + g.WAS.windSpeed + "," + g.WAS.geoLat + "," + g.WAS.geoLong + "," + g.WAS.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            return gameWeatherList;
        }
        static async Task<RootObjectWeather> GetResultAsyncWeather(string path)
        {
            RootObjectWeather nflRootObject = null;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
            using (HttpContent content = response.Content)
            {
                if (response.IsSuccessStatusCode)
                {
                    nflRootObject = await content.ReadAsAsync<RootObjectWeather>();
                }
            }
            return nflRootObject;
        }
        public static List<List<string>> RunAsyncWeather()
        {
            try
            {
                RootObjectWeather nflRootObject = new RootObjectWeather { };
                string path = "http://www.fantasyfootballnerd.com/service/weather/json/whmbtmf4wbqd/";
                Task<RootObjectWeather> tempWeather = GetResultAsyncWeather(path);
                tempWeather.Wait();
                nflRootObject = tempWeather.Result;
                return ShowResultWeather(nflRootObject);
            }
            catch (Exception e)
            {
                string message = e.Message;
                List<string> messageList = new List<string>() { message };
                List<List<string>> catchReturn = new List<List<string>>() { messageList };
                return catchReturn;
            }
        }
        static List<List<string>> ShowResultSchedule(RootObjectSchedule nflRootObject)
        {
            Schedule schedule = new Schedule { };
            List<List<string>> gameScheduleList = new List<List<string>>();
            string gameSchedule;
            for (int i = 0; i < nflRootObject.Schedule.Count; i++)
            {
                schedule = nflRootObject.Schedule[i];
                gameSchedule = schedule.gameId + "," + schedule.gameWeek + "," + schedule.gameDate + "," + schedule.awayTeam + "," + schedule.homeTeam + "," + schedule.gameTimeET + "," + schedule.tvStation + "," + schedule.winner;
                gameScheduleList.Add(gameSchedule.Split(',').ToList());
            }
            return gameScheduleList;
        }
        static async Task<RootObjectSchedule> GetResultAsyncSchedule(string path)
        {
            RootObjectSchedule nflRootObject = null;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
            using (HttpContent content = response.Content)
            {
                if (response.IsSuccessStatusCode)
                {
                    nflRootObject = await content.ReadAsAsync<RootObjectSchedule>();
                }
            }
            return nflRootObject;
        }
        public static List<List<string>> RunAsyncSchedule()
        {
            try
            {
                RootObjectSchedule nflRootObject = new RootObjectSchedule { };
                string path = "http://www.fantasyfootballnerd.com/service/schedule/json/whmbtmf4wbqd/";
                Task<RootObjectSchedule> tempSchedule = GetResultAsyncSchedule(path);
                tempSchedule.Wait();
                nflRootObject = tempSchedule.Result;
                return ShowResultSchedule(nflRootObject);
            }
            catch (Exception e)
            {
                string message = e.Message;
                List<string> messageList = new List<string>() { message };
                List<List<string>> catchReturn = new List<List<string>>() { messageList };
                return catchReturn;
            }
        }
        #region Teams
        public class ARI
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class ATL
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class BAL
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class BUF
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class CAR
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class CHI
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class CIN
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class CLE
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class DAL
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class DEN
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class DET
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class GB
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class HOU
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class IND
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class JAC
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class KC
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class MIA
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class MIN
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class NYG
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class NYJ
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class NE
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class NO
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class OAK
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class PHI
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class PIT
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class SD
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class SF
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class SEA
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class LA
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class TB
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class TEN
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        public class WAS
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
            public string stadium { get; set; }
            public string isDome { get; set; }
            public string geoLat { get; set; }
            public string geoLong { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string forecast { get; set; }
            public string windChill { get; set; }
            public string windSpeed { get; set; }
            public string domeImg { get; set; }
            public string smallImg { get; set; }
            public string mediumImg { get; set; }
            public string largeImg { get; set; }
        }
        #endregion Teams
        public class Games
        {
            public ARI ARI { get; set; }
            public ATL ATL { get; set; }
            public BAL BAL { get; set; }
            public BUF BUF { get; set; }
            public CAR CAR { get; set; }
            public CHI CHI { get; set; }
            public CIN CIN { get; set; }
            public CLE CLE { get; set; }
            public DAL DAL { get; set; }
            public DEN DEN { get; set; }
            public DET DET { get; set; }
            public GB GB { get; set; }
            public HOU HOU { get; set; }
            public IND IND { get; set; }
            public JAC JAC { get; set; }
            public KC KC { get; set; }
            public MIA MIA { get; set; }
            public MIN MIN { get; set; }
            public NYG NYG { get; set; }
            public NYJ NYJ { get; set; }
            public NE NE { get; set; }
            public NO NO { get; set; }
            public OAK OAK { get; set; }
            public PHI PHI { get; set; }
            public PIT PIT { get; set; }
            public SD SD { get; set; }
            public SF SF { get; set; }
            public SEA SEA { get; set; }
            public LA LA { get; set; }
            public TB TB { get; set; }
            public TEN TEN { get; set; }
            public WAS WAS { get; set; }
        }
        public class RootObjectWeather
        {
            public string Today { get; set; }
            public string Week { get; set; }
            public Games Games { get; set; }
        }
        public class NFLTeam
        {
            public string code { get; set; }
            public string fullName { get; set; }
            public string shortName { get; set; }
        }
        public class RootObjectNFLTeam
        {
            public List<NFLTeam> NFLTeams { get; set; }
        }
        public class Schedule
        {
            public string gameId { get; set; }
            public string gameWeek { get; set; }
            public string gameDate { get; set; }
            public string awayTeam { get; set; }
            public string homeTeam { get; set; }
            public string gameTimeET { get; set; }
            public string tvStation { get; set; }
            public string winner { get; set; }
        }
        public class RootObjectSchedule
        {
            public string currentWeek { get; set; }
            public List<Schedule> Schedule { get; set; }
        }
    }
}