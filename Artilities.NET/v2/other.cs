using Artilities.v2;
using Newtonsoft.Json.Linq;

namespace Artilities.v2
{
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
}
