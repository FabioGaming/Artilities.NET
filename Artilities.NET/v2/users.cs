using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using Artilities.v2;
using Newtonsoft.Json.Linq;

namespace Artilities.v2
{
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
                }
            }
        }
    }
}
