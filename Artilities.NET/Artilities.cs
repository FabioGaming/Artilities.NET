using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;
using static Artilities.users;

namespace Artilities
{
    public class Responses
    {
        public class Idea
        {
            public Idea(JObject json)
            {
                english = (string?)json["generated_idea"]["eng"];
                russian = (string?)json["generated_idea"]["ru"];
                statusCode = (int?)json["status_code"];
                delayTime = (int?)json["execution_time"];
                raw = json;
            }

            public string? english { get; set; }
            public string? russian { get; set; }
            public int? statusCode { get; set; }
            public int? delayTime { get; set; }
            public JObject raw { get; set; }
        }

        public class Challenge
        {
            public Challenge(JObject json)
            {
                english = (string?)json["generated_challenge"]["eng"];
                russian = (string?)json["generated_challenge"]["ru"];
                statusCode = (int?)json["status_code"];
                delayTime = (int?)json["execution_time"];
                raw = json;
            }

            public string? english { get; set; }
            public string? russian { get; set; }
            public int? statusCode { get; set; }
            public int? delayTime { get; set; }
            public JObject raw { get; set; }
        }


        public class DictionaryEntry
        {
            public DictionaryEntry(JObject json)
            {
                word = (string?)json["query_results"][0][0];
                description = (string?)json["query_results"][0][1];
                statusCode = (int?)json["status_code"];
                delayTime = (int?)json["execution_time"];
                raw = json;
            }

            public string? word { get; set; }
            public string? description { get; set; }
            public int? statusCode { get; set; }
            public int? delayTime { get; set; }
            public JObject raw { get; set; }
        }

        public class Banner
        {
            public Banner(JObject json)
            {
                bannerUrl = (string?)json["details"]["banner_url"];
                bannerImage = (string?)json["details"]["bannerImage"];
                language = (string?)json["details"]["language"];
                statusCode = (int?)json["status_code"];
                delayTime = (int?)json["execution_time"];
                raw = json;
            }

            public string? bannerUrl { get; set; }
            public string? bannerImage { get; set; }
            public string? language { get; set; }
            public int? statusCode { get; set; }
            public int? delayTime { get; set; }
            public JObject raw { get; set; }
        }

        public class UserInfo
        {
            public UserInfo(JObject json)
            {
                ideas = (JArray?)json["data"]["ideas"];
                challenges = (JArray?)json["data"]["challenges"];
                colors = (JArray?)json["data"]["colors"];
                isPrivate = (bool?)json["data"]["settings"]["private"];
                statusCode = (int?)json["status_code"];
                delayTime = (int?)json["execution_time"];
                raw = json;
            }

            public JArray? ideas { get; set; }
            public JArray? challenges { get; set; }
            public JArray? colors { get; set; }
            public bool? isPrivate { get; set; }
            public int? statusCode { get; set; }
            public int? delayTime { get; set; }
            public JObject raw { get; set; }
        }
    }

    public class main
    {
        /// <summary>
        /// Returns a Random Idea from the Artilities Database
        /// </summary>
        /// <returns>
        /// <para>Success: Dictionary containing keys: russian, english, statusCode, delayTime</para>
        /// <para>Error: Returns null</para>
        /// </returns>
        public static Responses.Idea? GetIdea()
        {
            dynamic response = JObject.Parse(Request.GET("https://artilities.herokuapp.com/api/ideas"));
            if (response == null)
            {
                return null;
            }

            if (response["status_code"] == 200)
            {
                Responses.Idea r = new Responses.Idea(response);
                return r;
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
        public static Responses.Challenge? GetChallenge()
        {
            dynamic response = JObject.Parse(Request.GET("https://artilities.herokuapp.com/api/challenges"));
            if (response == null)
            {
                return null;
            }

            if (response["status_code"] == 200)
            {
                Responses.Challenge r = new Responses.Challenge(response);
                return r;
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
        public static Responses.DictionaryEntry? GetDictionaryEntry(string query)
        {
            int counter = 0;
            query = query.Replace(" ", "%20");
            dynamic response = JObject.Parse(Request.GET("https://artilities.herokuapp.com/api/dict?query=" + query));
            if (response == null)
            {
                return null;
            }

            if (response["status_code"] == 200)
            {
                Responses.DictionaryEntry r = new Responses.DictionaryEntry(response);
                return r;
            }
            return null;
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
        public static Responses.Banner? GetBanners()
        {
            dynamic response = JObject.Parse(Request.GET("https://artilities.herokuapp.com/api/other/banners"));
            if (response == null)
            {
                return null;
            }

            if (response["status_code"] == 200)
            {
                Responses.Banner r = new Responses.Banner(response);
                return r;
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
        public static Responses.UserInfo? GetUserInfo(string user = null)
        {
            if (String.IsNullOrEmpty(user)) { user = userID; }
            dynamic response = JObject.Parse(Request.UGET("https://artilities.herokuapp.com/api/user/getinfo", user));
            if (response["status_code"] == 200)
            {
                Responses.UserInfo r = new Responses.UserInfo(response);
                return r;
            }

            return null;
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
                catch (Exception e)
                {
                    Trace.WriteLine("Server response failed");
                    throw new Exception("Something went wrong during the request. Error: " + e);
                }
            }
            public static string UGET(string URI, string searched_user)
            {

                try
                {
                    if (String.IsNullOrEmpty(users.userID)) { throw new Exception("Please Specify a userID for the DevKey!"); }
                    if (String.IsNullOrEmpty(users.devkey)) { throw new Exception("Please specify a DevKey!"); }
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
                catch (Exception e)
                {
                    Trace.WriteLine("Server response failed");
                    throw new Exception("Something went wrong during the request. Error: " + e);
                    return null;
                }
            }
        }
    }
}
