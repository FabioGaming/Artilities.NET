# Artilities.NET
An unofficial C# Wrapper for the [Artilities REST API](https://artilities.github.io/artilities-api/)

# What can this Wrapper do?
This wrapper currently supports `getting an Idea`, `Getting a challenge Idea`, `Looking up artist slang`. The other API functions like `getting patreons` and `getting banners` will hopefully follow soon.

# Where can I get the package?
You can download the package on [NuGet](https://www.nuget.org/packages/Artilities.NET) or soon here on GitHub



# DOCUMENTATION
### Getting an Idea
You can get a random Idea from the Artilities Database using the `getIdea()` function, this function will return a Dictionary with the following keys: `english`, `russian`, `delayTime`, `statusCode`, `raw`.
- `english` returns the result Idea in English
- `russian` returns the result Idea in Russian (You might need to change the text output to `UTF-16` to be able to see it)
- `delayTime` returns the time it took for the server to respond in MS
- `statusCode` returns the Web Response (in best case its `200`)
- `raw` returns the raw response JSON
#### Note
If there was an error during the request, the Dictionary will return `null`
#### Example Usage
```CSharp
            Console.OutputEncoding = System.Text.Encoding.UTF8; //This line is to make the console display the russian language
            Dictionary<string, string> IdeaDict = Artilities.main.GetIdea();
            if (IdeaDict != null)
            {
                Console.WriteLine("Your Idea: " + IdeaDict["english"]);
                Console.WriteLine("Russian: " + IdeaDict["russian"]);
                Console.WriteLine("Server Response: " + IdeaDict["statusCode"]);
                Console.WriteLine("Server Response Time: " + IdeaDict["delayTime"] + "ms");
                Console.WriteLine("Raw output: " + IdeaDict["raw"]);
            }
            else
            {
                Console.WriteLine("There was an error in the request.");
            }
````
#### Output
```
Your Idea: Secretary Cat
Russian: Котик-секретарь
Server Response: 200
Server Response Time: 149ms
Raw output: {
  "status_code": 200,
  "generated_idea": {
    "ru": "Котик-секретарь",
    "eng": "Secretary Cat"
  },
  "execution_time": 149
}
```

### Getting a challenge
You can get a random Challenge from Artilities using the `getChallenge()` function, this function will return a Dictionary with the following keys: `english`, `russian`, `delayTime`, `statusCode`, `raw`.
- `english` returns the result challenge in English
- `russian` returns the result challenge in Russian (You might need to change the text output to `UTF-16` to be able to see it)
- `delayTime` returns the time it took for the server to respond in MS
- `statusCode` returns the Web Response (in best case its `200`)
- `raw` returns the raw response JSON
#### Note
If there was an error during the request, the Dictionary will return `null`
#### Example Usage
```CSharp
            Console.OutputEncoding = System.Text.Encoding.UTF8; //This line is to make the console display the russian language
            Dictionary<string, string> challengeDict = Artilities.main.GetChallenge();
            if (challengeDict != null)
            {
                Console.WriteLine("Your challenge: " + challengeDict["english"]);
                Console.WriteLine("Russian: " + challengeDict["russian"]);
                Console.WriteLine("Server Response: " + challengeDict["statusCode"]);
                Console.WriteLine("Server Response Time: " + challengeDict["delayTime"] + "ms");
                Console.WriteLine("Raw output: " + challengeDict["raw"]);
            }
            else
            {
                Console.WriteLine("There was an error in the request.");
            }

```
#### Output
```
Your challenge: draw something using only two colors
Russian: нарисуй что-нибудь, используя только два цвета
Server Response: 200
Server Response Time: 30ms
Raw output: {
  "status_code": 200,
  "generated_challenge": {
    "ru": "нарисуй что-нибудь, используя только два цвета",
    "eng": "draw something using only two colors"
  },
  "execution_time": 30
}
```

### Looking up artist slang in the Artilities Database
You can look up artist slang from the artilities database using the `GetDictionaryEntry()` function, it will
