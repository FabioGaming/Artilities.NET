using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Artilities
{ 
    public class main
    {
        /// <summary>
        /// Gets a random idea from the Artilities Database
        /// </summary>
        /// <returns>
        /// <para>Success: Dictionary containing keys: russian, english, statusCode, delayTime</para>
        /// <para>Error: Returns null</para>
        /// </returns>
        public static Dictionary<string, string> GetIdea()
        {
            Dictionary<string, string> responseDictionary = new Dictionary<string, string>();
            dynamic response = JObject.Parse(GETRequest("https://artilities.herokuapp.com/api/ideas"));
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
        /// Returns a random Challenge from the artilities database
        /// </summary>
        /// <returns>
        /// <para>Success: Dictionary containing keys: russian, english, statusCode, delayTime</para>
        /// <para>Error: Returns null</para>
        /// </returns>
        public static Dictionary<string, string> GetChallenge()
        {
            Dictionary<string, string> responseDictionary = new Dictionary<string, string>();
            dynamic response = JObject.Parse(GETRequest("https://artilities.herokuapp.com/api/challenges"));
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
        /// </returns>
        public static Dictionary<string, string> GetDictionaryEntry(string query)
        {
            int counter = 0;
            Dictionary<string, string> responseDictionary = new Dictionary<string, string>();
            query = query.Replace(" ", "%20");
            dynamic response = JObject.Parse(GETRequest("https://artilities.herokuapp.com/api/dict?query=" + query));
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
        private static string GETRequest(string URI)
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
            catch
            {
                Trace.WriteLine("Server response failed");
                return null;
            }
        }

    }
}
