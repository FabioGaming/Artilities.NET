using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Artilities
{
    public class main
    {
        /// <summary>
        /// Returns a Random Idea from the Artilities Database
        /// </summary>
        /// <returns>
        /// <para>Success: Dictionary containing keys: russian, english, statusCode, delayTime</para>
        /// <para>Error: Returns null</para>
        /// </returns>
        public static Dictionary<string, string> GetIdea()
        {
            Dictionary<string, string> responseDictionary = new Dictionary<string, string>();
            dynamic response = JObject.Parse(Request.GET("https://artilities.herokuapp.com/api/ideas"));
            if (response == null)
            {
                return null;
            }

            var english = response.generated_idea.eng;
            var russian = response.generated_idea.ru;
            var statusCode = response.status_code;
            var delayTime = response.execution_time;
            if (statusCode == 200)
            {
                responseDictionary.Add("russian", russian.ToString());
                responseDictionary.Add("english", english.ToString());
                responseDictionary.Add("statusCode", statusCode.ToString());
                responseDictionary.Add("delayTime", delayTime.ToString());
                responseDictionary.Add("raw", response.ToString());
                return responseDictionary;
            }
            return null;
        }
        /// <summary>
        /// Returns a Random Challenge from the Artilities Database
        /// </summary>
        /// <returns>
        /// <para>Success: Dictionary containing keys: russian, english, statusCode, delayTime</para>
        /// <para>Error: Returns null</para>
        /// </returns>
        public static Dictionary<string, string> GetChallenge()
        {
            Dictionary<string, string> responseDictionary = new Dictionary<string, string>();
            dynamic response = JObject.Parse(Request.GET("https://artilities.herokuapp.com/api/challenges"));
            if (response == null)
            {
                return null;
            }
            var english = response.generated_challenge.eng;
            var russian = response.generated_challenge.ru;
            var statusCode = response.status_code;
            var delayTime = response.execution_time;
            if (statusCode == 200)
            {
                responseDictionary.Add("english", english.ToString());
                responseDictionary.Add("russian", russian.ToString());
                responseDictionary.Add("statusCode", statusCode.ToString());
                responseDictionary.Add("delayTime", delayTime.ToString());
                responseDictionary.Add("raw", response.ToString());
                return responseDictionary;
            }
            return null;
        }

        /// <summary>
        /// Returns Dictionary Entry from Artilities Database, based on given Query
        /// </summary>
        /// <param name="query"></param>
        /// <returns>
        /// <param>Success: Returns Dictionary containing keys: statusCode, delayTime, word, description</param>
        /// <param>Error: Returns null</param>
        /// <parm>Will return 'word' and 'description' as null, if word isn't found</parm>
        /// </returns>
        public static Dictionary<string, string> GetDictionaryEntry(string query)
        {
            int counter = 0;
            Dictionary<string, string> responseDictionary = new Dictionary<string, string>();
            query = query.Replace(" ", "%20");
            dynamic response = JObject.Parse(Request.GET("https://artilities.herokuapp.com/api/dict?query=" + query));
            if (response == null)
            {
                return null;
            }
            var statusCode = response.status_code;
            var delayTime = response.execution_time;
            foreach (var item in response.query_results)
            {
                counter++;

            }
            if (counter > 0)
            {
                var word = response.query_results[0][0];
                var description = response.query_results[0][1];
                if (statusCode == 200)
                {
                    responseDictionary.Add("statusCode", statusCode.ToString());
                    responseDictionary.Add("delayTime", delayTime.ToString());
                    responseDictionary.Add("word", word.ToString());
                    responseDictionary.Add("description", description.ToString());
                    responseDictionary.Add("raw", response.ToString());
                    return responseDictionary;
                }
                return responseDictionary;
            }
            else
            {
                responseDictionary.Add("statusCode", statusCode.ToString());
                responseDictionary.Add("delayTime", delayTime.ToString());
                responseDictionary.Add("word", null);
                responseDictionary.Add("description", null);
                responseDictionary.Add("raw", response.ToString());
                return responseDictionary;
            }
        }
    }

    public class other
    {
        /// <summary>
        /// Returns a Random Banner from the Artilities Database
        /// </summary>
        /// <returns>
        /// <para>Success: Dictionary containing keys: bannerUrl, bannerImage, language, statusCode, delayTime</para>
        /// <para>Error: Returns null</para>
        /// </returns>
        public static Dictionary<string, string> GetBanners()
        {
            Dictionary<string, string> responseDictionary = new Dictionary<string, string>();
            dynamic response = JObject.Parse(Request.GET("https://artilities.herokuapp.com/api/other/banners"));
            if (response == null)
            {
                return null;
            }

            var bannerUrl = response.details.banner_url;
            var bannerImage = response.details.banner_image;
            var language = response.details.language;
            var statusCode = response.status_code;
            var delayTime = response.execution_time;
            if (statusCode == 200)
            {
                responseDictionary.Add("bannerUrl", bannerUrl.ToString());
                responseDictionary.Add("bannerImage", bannerImage.ToString());
                responseDictionary.Add("language", language.ToString());
                responseDictionary.Add("statusCode", statusCode.ToString());
                responseDictionary.Add("delayTime", delayTime.ToString());
                responseDictionary.Add("raw", response.ToString());
                return responseDictionary;
            }
            return null;
            
        }
    }
    public class users
    {
        public static string devkey;
        public static string userID;

        /// <summary>
        /// Returns the saved challenges of a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        ///<para>Success: Dictionary containing keys: raw, challenges, statusCode, delayTime</para>
        /// </returns>
        public static Dictionary<string,string> getChallenges(string user = null)
        {
            if(String.IsNullOrEmpty(user)) { user = userID; }
            Dictionary<string, string> responseDictionary = new Dictionary<string, string>();
            dynamic response = JObject.Parse(Request.UGET("https://artilities.herokuapp.com/api/user/getinfo", user));
            var delayTime = response.execution_time;
            var statusCode = response.status_code;
            if(statusCode == 200)
            {
                List<dynamic> challengeList = new List<dynamic>();
                foreach (var item in response.data.challenges)
                {
                    challengeList.Add(item);
                }
                string challenges = string.Join(", ", challengeList.ToArray());


                responseDictionary.Add("delayTime", delayTime.ToString());
                responseDictionary.Add("statusCode", statusCode.ToString());
                responseDictionary.Add("challenges", challenges);
                responseDictionary.Add("raw", response.ToString());
            } else
            {
                responseDictionary.Add("delayTime", delayTime.ToString());
                responseDictionary.Add("statusCode", statusCode.ToString());
                responseDictionary.Add("raw", response.ToString());
                responseDictionary.Add("challenges", null);
            }

            return responseDictionary;
        }

        /// <summary>
        /// Returns the saved colors of a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        ///<para>Success: Dictionary containing keys: raw, colors, statusCode, delayTime</para>
        /// </returns>
        public static Dictionary<string,string> getColors(string user = null)
        {
            if (String.IsNullOrEmpty(user)) { user = userID; }
            Dictionary<string, string> responseDictionary = new Dictionary<string, string>();
            dynamic response = JObject.Parse(Request.UGET("https://artilities.herokuapp.com/api/user/getinfo", user));
            var delayTime = response.execution_time;
            var statusCode = response.status_code;
            if (statusCode == 200)
            {
                List<dynamic> colorList = new List<dynamic>();
                foreach (var colorbatch in response.data.colors)
                {
                    foreach (var color in JArray.Parse(colorbatch.ToString()))
                    {
                        colorList.Add(color);
                    }

                }


                string colors = string.Join(", ", colorList.ToArray());

                responseDictionary.Add("delayTime", delayTime.ToString());
                responseDictionary.Add("statusCode", statusCode.ToString());
                responseDictionary.Add("colors", colors);
                responseDictionary.Add("raw", response.ToString());
            }
            else
            {
                responseDictionary.Add("delayTime", delayTime.ToString());
                responseDictionary.Add("statusCode", statusCode.ToString());
                responseDictionary.Add("raw", response.ToString());
                responseDictionary.Add("colors", null);
            }

            return responseDictionary;
        }

        /// <summary>
        /// Returns the saved ideas of a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        ///<para>Success: Dictionary containing keys: raw, ideas, statusCode, delayTime</para>
        /// </returns>
        public static Dictionary<string, string> getIdeas(string user = null)
        {
            if (String.IsNullOrEmpty(user)) { user = userID; }
            Dictionary<string, string> responseDictionary = new Dictionary<string, string>();
            dynamic response = JObject.Parse(Request.UGET("https://artilities.herokuapp.com/api/user/getinfo", user));
            var delayTime = response.execution_time;
            var statusCode = response.status_code;
            if (statusCode == 200)
            {
                List<dynamic> ideaList = new List<dynamic>();
                foreach (var item in response.data.ideas)
                {
                    ideaList.Add(item);
                }
                string ideas = string.Join(", ", ideaList.ToArray());

                responseDictionary.Add("delayTime", delayTime.ToString());
                responseDictionary.Add("statusCode", statusCode.ToString());
                responseDictionary.Add("ideas", ideas);
                responseDictionary.Add("raw", response.ToString());
            }
            else
            {
                responseDictionary.Add("delayTime", delayTime.ToString());
                responseDictionary.Add("statusCode", statusCode.ToString());
                responseDictionary.Add("raw", response.ToString());
                responseDictionary.Add("ideas", null);
            }

            return responseDictionary;
        }
    }
    internal class Request
    {
        public static string GET(string URI)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch(Exception e)
            {
                Trace.WriteLine("Server response failed");
                throw new Exception("Something went wrong during the request. Error: " + e);
            }
        }
        public static string UGET(string URI, string searched_user)
        {

            try
            {
                if(String.IsNullOrEmpty(users.userID)) { throw new Exception("Please Specify a userID for the DevKey!"); }
                if(String.IsNullOrEmpty(users.devkey)) { throw new Exception("Please specify a DevKey!"); }
                URI = URI + $"/?devkey={users.devkey}&userid={users.userID}&searched_userid={searched_user}";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch(Exception e)
            {

                Trace.WriteLine("Server response failed");
                throw new Exception("Something went wrong during the request. Error: " + e);
                return null;
            }
        }
    }
}
