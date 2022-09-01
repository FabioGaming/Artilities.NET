using System;
using System.Collections.Generic;
using System.Text;
using Artilities.v2;
using Newtonsoft.Json.Linq;

namespace Artilities.v2
{
    public class main
    {
        /// <summary>
        /// Returns a Random Idea from the Artilities Database
        /// </summary>
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
}
