using Newtonsoft.Json.Linq;

namespace Artilities.v2
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
}
