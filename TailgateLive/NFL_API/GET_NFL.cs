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
        public static string[] GetWeather(string team)
        {
            List<List<string>> weatherList = new List<List<string>>();
            weatherList = NFL_API.GET_NFL.RunAsyncWeather();
            string[] tempWeather = new string[weatherList[0].Count];
            for (int i = 0; i < weatherList.Count; i++)
            {
                for (int ii = 0; ii < weatherList[0].Count; ii++)
                {
                    tempWeather[ii] = weatherList[i][ii];
                }
                if (tempWeather[3] == team || tempWeather[4] == team)
                {
                    return tempWeather;
                }
            }
            return tempWeather;
        }
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
            if (g.ARI != null) { gameWeather = g.ARI.gameId + "," + g.ARI.gameWeek + "," + g.ARI.gameDate + "," + g.ARI.awayTeam + "," + g.ARI.homeTeam + "," + g.ARI.gameTimeET + "," + g.ARI.tvStation + "," + g.ARI.winner + "," + g.ARI.stadium + "," + g.ARI.isDome + "," + g.ARI.geoLat + "," + g.ARI.geoLong + "," + g.ARI.low + "," + g.ARI.high + "," + g.ARI.forecast + "," + g.ARI.windChill + "," + g.ARI.windSpeed + "," + g.ARI.domeImg + "," + g.ARI.smallImg + "," + g.ARI.mediumImg + "," + g.ARI.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.ATL != null) { gameWeather = g.ATL.gameId + "," + g.ATL.gameWeek + "," + g.ATL.gameDate + "," + g.ATL.awayTeam + "," + g.ATL.homeTeam + "," + g.ATL.gameTimeET + "," + g.ATL.tvStation + "," + g.ATL.winner + "," + g.ATL.stadium + "," + g.ATL.isDome + "," + g.ATL.geoLat + "," + g.ATL.geoLong + "," + g.ATL.low + "," + g.ATL.high + "," + g.ATL.forecast + "," + g.ATL.windChill + "," + g.ATL.windSpeed + "," + g.ATL.domeImg + "," + g.ATL.smallImg + "," + g.ATL.mediumImg + "," + g.ATL.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.BAL != null) { gameWeather = g.BAL.gameId + "," + g.BAL.gameWeek + "," + g.BAL.gameDate + "," + g.BAL.awayTeam + "," + g.BAL.homeTeam + "," + g.BAL.gameTimeET + "," + g.BAL.tvStation + "," + g.BAL.winner + "," + g.BAL.stadium + "," + g.BAL.isDome + "," + g.BAL.geoLat + "," + g.BAL.geoLong + "," + g.BAL.low + "," + g.BAL.high + "," + g.BAL.forecast + "," + g.BAL.windChill + "," + g.BAL.windSpeed + "," + g.BAL.domeImg + "," + g.BAL.smallImg + "," + g.BAL.mediumImg + "," + g.BAL.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.BUF != null) { gameWeather = g.BUF.gameId + "," + g.BUF.gameWeek + "," + g.BUF.gameDate + "," + g.BUF.awayTeam + "," + g.BUF.homeTeam + "," + g.BUF.gameTimeET + "," + g.BUF.tvStation + "," + g.BUF.winner + "," + g.BUF.stadium + "," + g.BUF.isDome + "," + g.BUF.geoLat + "," + g.BUF.geoLong + "," + g.BUF.low + "," + g.BUF.high + "," + g.BUF.forecast + "," + g.BUF.windChill + "," + g.BUF.windSpeed + "," + g.BUF.domeImg + "," + g.BUF.smallImg + "," + g.BUF.mediumImg + "," + g.BUF.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.CAR != null) { gameWeather = g.CAR.gameId + "," + g.CAR.gameWeek + "," + g.CAR.gameDate + "," + g.CAR.awayTeam + "," + g.CAR.homeTeam + "," + g.CAR.gameTimeET + "," + g.CAR.tvStation + "," + g.CAR.winner + "," + g.CAR.stadium + "," + g.CAR.isDome + "," + g.CAR.geoLat + "," + g.CAR.geoLong + "," + g.CAR.low + "," + g.CAR.high + "," + g.CAR.forecast + "," + g.CAR.windChill + "," + g.CAR.windSpeed + "," + g.CAR.domeImg + "," + g.CAR.smallImg + "," + g.CAR.mediumImg + "," + g.CAR.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.CHI != null) { gameWeather = g.CHI.gameId + "," + g.CHI.gameWeek + "," + g.CHI.gameDate + "," + g.CHI.awayTeam + "," + g.CHI.homeTeam + "," + g.CHI.gameTimeET + "," + g.CHI.tvStation + "," + g.CHI.winner + "," + g.CHI.stadium + "," + g.CHI.isDome + "," + g.CHI.geoLat + "," + g.CHI.geoLong + "," + g.CHI.low + "," + g.CHI.high + "," + g.CHI.forecast + "," + g.CHI.windChill + "," + g.CHI.windSpeed + "," + g.CHI.domeImg + "," + g.CHI.smallImg + "," + g.CHI.mediumImg + "," + g.CHI.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.CIN != null) { gameWeather = g.CIN.gameId + "," + g.CIN.gameWeek + "," + g.CIN.gameDate + "," + g.CIN.awayTeam + "," + g.CIN.homeTeam + "," + g.CIN.gameTimeET + "," + g.CIN.tvStation + "," + g.CIN.winner + "," + g.CIN.stadium + "," + g.CIN.isDome + "," + g.CIN.geoLat + "," + g.CIN.geoLong + "," + g.CIN.low + "," + g.CIN.high + "," + g.CIN.forecast + "," + g.CIN.windChill + "," + g.CIN.windSpeed + "," + g.CIN.domeImg + "," + g.CIN.smallImg + "," + g.CIN.mediumImg + "," + g.CIN.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.CLE != null) { gameWeather = g.CLE.gameId + "," + g.CLE.gameWeek + "," + g.CLE.gameDate + "," + g.CLE.awayTeam + "," + g.CLE.homeTeam + "," + g.CLE.gameTimeET + "," + g.CLE.tvStation + "," + g.CLE.winner + "," + g.CLE.stadium + "," + g.CLE.isDome + "," + g.CLE.geoLat + "," + g.CLE.geoLong + "," + g.CLE.low + "," + g.CLE.high + "," + g.CLE.forecast + "," + g.CLE.windChill + "," + g.CLE.windSpeed + "," + g.CLE.domeImg + "," + g.CLE.smallImg + "," + g.CLE.mediumImg + "," + g.CLE.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.DAL != null) { gameWeather = g.DAL.gameId + "," + g.DAL.gameWeek + "," + g.DAL.gameDate + "," + g.DAL.awayTeam + "," + g.DAL.homeTeam + "," + g.DAL.gameTimeET + "," + g.DAL.tvStation + "," + g.DAL.winner + "," + g.DAL.stadium + "," + g.DAL.isDome + "," + g.DAL.geoLat + "," + g.DAL.geoLong + "," + g.DAL.low + "," + g.DAL.high + "," + g.DAL.forecast + "," + g.DAL.windChill + "," + g.DAL.windSpeed + "," + g.DAL.domeImg + "," + g.DAL.smallImg + "," + g.DAL.mediumImg + "," + g.DAL.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.DEN != null) { gameWeather = g.DEN.gameId + "," + g.DEN.gameWeek + "," + g.DEN.gameDate + "," + g.DEN.awayTeam + "," + g.DEN.homeTeam + "," + g.DEN.gameTimeET + "," + g.DEN.tvStation + "," + g.DEN.winner + "," + g.DEN.stadium + "," + g.DEN.isDome + "," + g.DEN.geoLat + "," + g.DEN.geoLong + "," + g.DEN.low + "," + g.DEN.high + "," + g.DEN.forecast + "," + g.DEN.windChill + "," + g.DEN.windSpeed + "," + g.DEN.domeImg + "," + g.DEN.smallImg + "," + g.DEN.mediumImg + "," + g.DEN.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.DET != null) { gameWeather = g.DET.gameId + "," + g.DET.gameWeek + "," + g.DET.gameDate + "," + g.DET.awayTeam + "," + g.DET.homeTeam + "," + g.DET.gameTimeET + "," + g.DET.tvStation + "," + g.DET.winner + "," + g.DET.stadium + "," + g.DET.isDome + "," + g.DET.geoLat + "," + g.DET.geoLong + "," + g.DET.low + "," + g.DET.high + "," + g.DET.forecast + "," + g.DET.windChill + "," + g.DET.windSpeed + "," + g.DET.domeImg + "," + g.DET.smallImg + "," + g.DET.mediumImg + "," + g.DET.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.GB  != null) { gameWeather = g.GB.gameId  + "," + g.GB.gameWeek  + "," +  g.GB.gameDate + "," +  g.GB.awayTeam + "," +  g.GB.homeTeam + "," +  g.GB.gameTimeET + "," +  g.GB.tvStation + "," +  g.GB.winner + "," + g.GB.stadium  + "," +  g.GB.isDome + "," +  g.GB.geoLat + "," +  g.GB.geoLong + "," + g.GB.low  + "," + g.GB.high  + "," +  g.GB.forecast + "," + g.GB.windChill  + "," + g.GB.windSpeed  + "," +  g.GB.domeImg + "," +  g.GB.smallImg + "," +  g.GB.mediumImg + "," + g.GB.largeImg;  gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.HOU != null) { gameWeather = g.HOU.gameId + "," + g.HOU.gameWeek + "," + g.HOU.gameDate + "," + g.HOU.awayTeam + "," + g.HOU.homeTeam + "," + g.HOU.gameTimeET + "," + g.HOU.tvStation + "," + g.HOU.winner + "," + g.HOU.stadium + "," + g.HOU.isDome + "," + g.HOU.geoLat + "," + g.HOU.geoLong + "," + g.HOU.low + "," + g.HOU.high + "," + g.HOU.forecast + "," + g.HOU.windChill + "," + g.HOU.windSpeed + "," + g.HOU.domeImg + "," + g.HOU.smallImg + "," + g.HOU.mediumImg + "," + g.HOU.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.IND != null) { gameWeather = g.IND.gameId + "," + g.IND.gameWeek + "," + g.IND.gameDate + "," + g.IND.awayTeam + "," + g.IND.homeTeam + "," + g.IND.gameTimeET + "," + g.IND.tvStation + "," + g.IND.winner + "," + g.IND.stadium + "," + g.IND.isDome + "," + g.IND.geoLat + "," + g.IND.geoLong + "," + g.IND.low + "," + g.IND.high + "," + g.IND.forecast + "," + g.IND.windChill + "," + g.IND.windSpeed + "," + g.IND.domeImg + "," + g.IND.smallImg + "," + g.IND.mediumImg + "," + g.IND.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.JAC != null) { gameWeather = g.JAC.gameId + "," + g.JAC.gameWeek + "," + g.JAC.gameDate + "," + g.JAC.awayTeam + "," + g.JAC.homeTeam + "," + g.JAC.gameTimeET + "," + g.JAC.tvStation + "," + g.JAC.winner + "," + g.JAC.stadium + "," + g.JAC.isDome + "," + g.JAC.geoLat + "," + g.JAC.geoLong + "," + g.JAC.low + "," + g.JAC.high + "," + g.JAC.forecast + "," + g.JAC.windChill + "," + g.JAC.windSpeed + "," + g.JAC.domeImg + "," + g.JAC.smallImg + "," + g.JAC.mediumImg + "," + g.JAC.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.KC  != null) { gameWeather = g.KC.gameId  + "," + g.KC.gameWeek  + "," +  g.KC.gameDate + "," +  g.KC.awayTeam + "," +  g.KC.homeTeam + "," +  g.KC.gameTimeET + "," +  g.KC.tvStation + "," +  g.KC.winner + "," + g.KC.stadium  + "," +  g.KC.isDome + "," +  g.KC.geoLat + "," +  g.KC.geoLong + "," + g.KC.low  + "," + g.KC.high  + "," +  g.KC.forecast + "," + g.KC.windChill  + "," + g.KC.windSpeed  + "," +  g.KC.domeImg + "," +  g.KC.smallImg + "," +  g.KC.mediumImg + "," + g.KC.largeImg;  gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.MIA != null) { gameWeather = g.MIA.gameId + "," + g.MIA.gameWeek + "," + g.MIA.gameDate + "," + g.MIA.awayTeam + "," + g.MIA.homeTeam + "," + g.MIA.gameTimeET + "," + g.MIA.tvStation + "," + g.MIA.winner + "," + g.MIA.stadium + "," + g.MIA.isDome + "," + g.MIA.geoLat + "," + g.MIA.geoLong + "," + g.MIA.low + "," + g.MIA.high + "," + g.MIA.forecast + "," + g.MIA.windChill + "," + g.MIA.windSpeed + "," + g.MIA.domeImg + "," + g.MIA.smallImg + "," + g.MIA.mediumImg + "," + g.MIA.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.MIN != null) { gameWeather = g.MIN.gameId + "," + g.MIN.gameWeek + "," + g.MIN.gameDate + "," + g.MIN.awayTeam + "," + g.MIN.homeTeam + "," + g.MIN.gameTimeET + "," + g.MIN.tvStation + "," + g.MIN.winner + "," + g.MIN.stadium + "," + g.MIN.isDome + "," + g.MIN.geoLat + "," + g.MIN.geoLong + "," + g.MIN.low + "," + g.MIN.high + "," + g.MIN.forecast + "," + g.MIN.windChill + "," + g.MIN.windSpeed + "," + g.MIN.domeImg + "," + g.MIN.smallImg + "," + g.MIN.mediumImg + "," + g.MIN.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.NYG != null) { gameWeather = g.NYG.gameId + "," + g.NYG.gameWeek + "," + g.NYG.gameDate + "," + g.NYG.awayTeam + "," + g.NYG.homeTeam + "," + g.NYG.gameTimeET + "," + g.NYG.tvStation + "," + g.NYG.winner + "," + g.NYG.stadium + "," + g.NYG.isDome + "," + g.NYG.geoLat + "," + g.NYG.geoLong + "," + g.NYG.low + "," + g.NYG.high + "," + g.NYG.forecast + "," + g.NYG.windChill + "," + g.NYG.windSpeed + "," + g.NYG.domeImg + "," + g.NYG.smallImg + "," + g.NYG.mediumImg + "," + g.NYG.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.NYJ != null) { gameWeather = g.NYJ.gameId + "," + g.NYJ.gameWeek + "," + g.NYJ.gameDate + "," + g.NYJ.awayTeam + "," + g.NYJ.homeTeam + "," + g.NYJ.gameTimeET + "," + g.NYJ.tvStation + "," + g.NYJ.winner + "," + g.NYJ.stadium + "," + g.NYJ.isDome + "," + g.NYJ.geoLat + "," + g.NYJ.geoLong + "," + g.NYJ.low + "," + g.NYJ.high + "," + g.NYJ.forecast + "," + g.NYJ.windChill + "," + g.NYJ.windSpeed + "," + g.NYJ.domeImg + "," + g.NYJ.smallImg + "," + g.NYJ.mediumImg + "," + g.NYJ.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.NE  != null) { gameWeather = g.NE.gameId  + "," + g.NE.gameWeek  + "," +  g.NE.gameDate + "," +  g.NE.awayTeam + "," +  g.NE.homeTeam + "," +  g.NE.gameTimeET + "," +  g.NE.tvStation + "," +  g.NE.winner + "," + g.NE.stadium  + "," +  g.NE.isDome + "," +  g.NE.geoLat + "," +  g.NE.geoLong + "," + g.NE.low  + "," + g.NE.high  + "," +  g.NE.forecast + "," + g.NE.windChill  + "," + g.NE.windSpeed  + "," +  g.NE.domeImg + "," +  g.NE.smallImg + "," +  g.NE.mediumImg + "," + g.NE.largeImg;  gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.NO  != null) { gameWeather = g.NO.gameId  + "," + g.NO.gameWeek  + "," +  g.NO.gameDate + "," +  g.NO.awayTeam + "," +  g.NO.homeTeam + "," +  g.NO.gameTimeET + "," +  g.NO.tvStation + "," +  g.NO.winner + "," + g.NO.stadium  + "," +  g.NO.isDome + "," +  g.NO.geoLat + "," +  g.NO.geoLong + "," + g.NO.low  + "," + g.NO.high  + "," +  g.NO.forecast + "," + g.NO.windChill  + "," + g.NO.windSpeed  + "," +  g.NO.domeImg + "," +  g.NO.smallImg + "," +  g.NO.mediumImg + "," + g.NO.largeImg;  gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.OAK != null) { gameWeather = g.OAK.gameId + "," + g.OAK.gameWeek + "," + g.OAK.gameDate + "," + g.OAK.awayTeam + "," + g.OAK.homeTeam + "," + g.OAK.gameTimeET + "," + g.OAK.tvStation + "," + g.OAK.winner + "," + g.OAK.stadium + "," + g.OAK.isDome + "," + g.OAK.geoLat + "," + g.OAK.geoLong + "," + g.OAK.low + "," + g.OAK.high + "," + g.OAK.forecast + "," + g.OAK.windChill + "," + g.OAK.windSpeed + "," + g.OAK.domeImg + "," + g.OAK.smallImg + "," + g.OAK.mediumImg + "," + g.OAK.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.PHI != null) { gameWeather = g.PHI.gameId + "," + g.PHI.gameWeek + "," + g.PHI.gameDate + "," + g.PHI.awayTeam + "," + g.PHI.homeTeam + "," + g.PHI.gameTimeET + "," + g.PHI.tvStation + "," + g.PHI.winner + "," + g.PHI.stadium + "," + g.PHI.isDome + "," + g.PHI.geoLat + "," + g.PHI.geoLong + "," + g.PHI.low + "," + g.PHI.high + "," + g.PHI.forecast + "," + g.PHI.windChill + "," + g.PHI.windSpeed + "," + g.PHI.domeImg + "," + g.PHI.smallImg + "," + g.PHI.mediumImg + "," + g.PHI.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.PIT != null) { gameWeather = g.PIT.gameId + "," + g.PIT.gameWeek + "," + g.PIT.gameDate + "," + g.PIT.awayTeam + "," + g.PIT.homeTeam + "," + g.PIT.gameTimeET + "," + g.PIT.tvStation + "," + g.PIT.winner + "," + g.PIT.stadium + "," + g.PIT.isDome + "," + g.PIT.geoLat + "," + g.PIT.geoLong + "," + g.PIT.low + "," + g.PIT.high + "," + g.PIT.forecast + "," + g.PIT.windChill + "," + g.PIT.windSpeed + "," + g.PIT.domeImg + "," + g.PIT.smallImg + "," + g.PIT.mediumImg + "," + g.PIT.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.SD  != null) { gameWeather = g.SD.gameId  + "," + g.SD.gameWeek  + "," +  g.SD.gameDate + "," +  g.SD.awayTeam + "," +  g.SD.homeTeam + "," +  g.SD.gameTimeET + "," +  g.SD.tvStation + "," +  g.SD.winner + "," + g.SD.stadium  + "," +  g.SD.isDome + "," +  g.SD.geoLat + "," +  g.SD.geoLong + "," + g.SD.low  + "," + g.SD.high  + "," +  g.SD.forecast + "," + g.SD.windChill  + "," + g.SD.windSpeed  + "," +  g.SD.domeImg + "," +  g.SD.smallImg + "," +  g.SD.mediumImg + "," + g.SD.largeImg;  gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.SF  != null) { gameWeather = g.SF.gameId  + "," + g.SF.gameWeek  + "," +  g.SF.gameDate + "," +  g.SF.awayTeam + "," +  g.SF.homeTeam + "," +  g.SF.gameTimeET + "," +  g.SF.tvStation + "," +  g.SF.winner + "," + g.SF.stadium  + "," +  g.SF.isDome + "," +  g.SF.geoLat + "," +  g.SF.geoLong + "," + g.SF.low  + "," + g.SF.high  + "," +  g.SF.forecast + "," + g.SF.windChill  + "," + g.SF.windSpeed  + "," +  g.SF.domeImg + "," +  g.SF.smallImg + "," +  g.SF.mediumImg + "," + g.SF.largeImg;  gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.SEA != null) { gameWeather = g.SEA.gameId + "," + g.SEA.gameWeek + "," + g.SEA.gameDate + "," + g.SEA.awayTeam + "," + g.SEA.homeTeam + "," + g.SEA.gameTimeET + "," + g.SEA.tvStation + "," + g.SEA.winner + "," + g.SEA.stadium + "," + g.SEA.isDome + "," + g.SEA.geoLat + "," + g.SEA.geoLong + "," + g.SEA.low + "," + g.SEA.high + "," + g.SEA.forecast + "," + g.SEA.windChill + "," + g.SEA.windSpeed + "," + g.SEA.domeImg + "," + g.SEA.smallImg + "," + g.SEA.mediumImg + "," + g.SEA.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.LA  != null) { gameWeather = g.LA.gameId  + "," + g.LA.gameWeek  + "," +  g.LA.gameDate + "," +  g.LA.awayTeam + "," +  g.LA.homeTeam + "," +  g.LA.gameTimeET + "," +  g.LA.tvStation + "," +  g.LA.winner + "," + g.LA.stadium  + "," +  g.LA.isDome + "," +  g.LA.geoLat + "," +  g.LA.geoLong + "," + g.LA.low  + "," + g.LA.high  + "," +  g.LA.forecast + "," + g.LA.windChill  + "," + g.LA.windSpeed  + "," +  g.LA.domeImg + "," +  g.LA.smallImg + "," +  g.LA.mediumImg + "," + g.LA.largeImg;  gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.TB  != null) { gameWeather = g.TB.gameId  + "," + g.TB.gameWeek  + "," +  g.TB.gameDate + "," +  g.TB.awayTeam + "," +  g.TB.homeTeam + "," +  g.TB.gameTimeET + "," +  g.TB.tvStation + "," +  g.TB.winner + "," + g.TB.stadium  + "," +  g.TB.isDome + "," +  g.TB.geoLat + "," +  g.TB.geoLong + "," + g.TB.low  + "," + g.TB.high  + "," +  g.TB.forecast + "," + g.TB.windChill  + "," + g.TB.windSpeed  + "," +  g.TB.domeImg + "," +  g.TB.smallImg + "," +  g.TB.mediumImg + "," + g.TB.largeImg;  gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.TEN != null) { gameWeather = g.TEN.gameId + "," + g.TEN.gameWeek + "," + g.TEN.gameDate + "," + g.TEN.awayTeam + "," + g.TEN.homeTeam + "," + g.TEN.gameTimeET + "," + g.TEN.tvStation + "," + g.TEN.winner + "," + g.TEN.stadium + "," + g.TEN.isDome + "," + g.TEN.geoLat + "," + g.TEN.geoLong + "," + g.TEN.low + "," + g.TEN.high + "," + g.TEN.forecast + "," + g.TEN.windChill + "," + g.TEN.windSpeed + "," + g.TEN.domeImg + "," + g.TEN.smallImg + "," + g.TEN.mediumImg + "," + g.TEN.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
            if (g.WAS != null) { gameWeather = g.WAS.gameId + "," + g.WAS.gameWeek + "," + g.WAS.gameDate + "," + g.WAS.awayTeam + "," + g.WAS.homeTeam + "," + g.WAS.gameTimeET + "," + g.WAS.tvStation + "," + g.WAS.winner + "," + g.WAS.stadium + "," + g.WAS.isDome + "," + g.WAS.geoLat + "," + g.WAS.geoLong + "," + g.WAS.low + "," + g.WAS.high + "," + g.WAS.forecast + "," + g.WAS.windChill + "," + g.WAS.windSpeed + "," + g.WAS.domeImg + "," + g.WAS.smallImg + "," + g.WAS.mediumImg + "," + g.WAS.largeImg; gameWeatherList.Add(gameWeather.Split(',').ToList()); }
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