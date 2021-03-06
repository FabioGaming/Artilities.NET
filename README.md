# Artilities.NET
An unofficial C# Wrapper for the [Artilities REST API](https://artilities.github.io/artilities-api/)

# What can this Wrapper do?
This wrapper currently supports `getting an Idea`, `Getting a challenge Idea`, `Looking up artist slang`, `getting Atilities Banners`. The other API functions like `getting patreons` will hopefully follow soon.

# Where can I get the package?
You can download the package on [NuGet](https://www.nuget.org/packages/Artilities.NET) or soon here on GitHub
You can also: 
- Type `Install-Package Artilities.NET -Version 1.1.5` into the Package Manager
- Type `dotnet add package Artilities.NET --version 1.1.5` into the command prompt, note that you need to have `dotnet` installed
- Reference the Dependency using `<PackageReference Include="Artilities.NET" Version="1.1.5" />`




# DOCUMENTATION
### Getting an Idea
You can get a random Idea from the Artilities Database using the `getIdea()` function, this function will return a Dictionary with the following keys: `english`, `russian`, `delayTime`, `statusCode`, `raw`.
- `english` returns the result Idea in English
- `russian` returns the result Idea in Russian (You might need to change the text output to `UTF-16` to be able to see it)
- `delayTime` returns the time it took for the server to respond in MS
- `statusCode` returns the Web Response (in best case its `200`)
- `raw` returns the raw response JSON
#### Note
- If there was an error during the request, the Dictionary will return `null`
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
Russian: ??????????-??????????????????
Server Response: 200
Server Response Time: 149ms
Raw output: {
  "status_code": 200,
  "generated_idea": {
    "ru": "??????????-??????????????????",
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
- If there was an error during the request, the Dictionary will return `null`
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
Russian: ?????????????? ??????-????????????, ?????????????????? ???????????? ?????? ??????????
Server Response: 200
Server Response Time: 30ms
Raw output: {
  "status_code": 200,
  "generated_challenge": {
    "ru": "?????????????? ??????-????????????, ?????????????????? ???????????? ?????? ??????????",
    "eng": "draw something using only two colors"
  },
  "execution_time": 30
}
```

### Looking up artist slang in the Artilities Database
You can look up artist slang from the artilities database using the `GetDictionaryEntry()` function, this function will return a Dictionary with the following keys: `word`, `description`, `delayTime`, `statusCode`, `raw`.
- `word` returns the first best word result from the database
- `description` returns the description / meaning of the returned `word`
- `delayTime` returns the time it took for the server to respond in MS
- `statusCode` returns the Web Response (in best case its `200`)
- `raw` returns the raw response JSON
#### Note
- If there was an error during the request, the Dictionary will return `null`
- In case the database has found no words to return, `word` and `description` will return `null`
- The function `GetDictionaryEntry()` requires a string as search query input
#### Example Usage
```CSharp
            Dictionary<string, string> DictLookup = Artilities.main.GetDictionaryEntry("UFO"); //In this case I'm looking up the term "UFO", which means "up for offer"
            if (DictLookup != null && DictLookup["word"] != null)
            {
                Console.WriteLine("Word: " + DictLookup["word"]);
                Console.WriteLine("Description: " + DictLookup["description"]);
                Console.WriteLine("Server response Time: " + DictLookup["delayTime"] + "ms");
                Console.WriteLine("Server response Code: " + DictLookup["statusCode"]);
                Console.WriteLine("Raw response: " + DictLookup["raw"]);
            }
            else
            {
                Console.WriteLine("There was an error in the request.");
            }
```
#### Output
```
Word: UFO
Description: Short for Up For Offers.
Server response Time: 58ms
Server response Code: 200
Raw response: {
  "status_code": 200,
  "query_results": [
    [
      "UFO",
      "Short for Up For Offers."
    ]
  ],
  "execution_time": 58
}

```
### Get Artilities Banners (Contributed by [Slimakoi](https://github.com/Slimakoi))
You can get Artilities Banners and their properties using the `getBanners()` function, this function will return a Dictionary with the following keys: `bannerUrl`, `bannerImage`, `delayTime`, `statusCode`, `raw`, `language`.
- `bannerUrl` returns the URL the banner is linked to
- `bannerImage` returns the source URL of the banner
- `language` returns the banners language (usually `null`)
- `delayTime` returns the time it took for the server to respond in MS
- `statusCode` returns the Web Response (in best case its `200`)
- `raw` returns the raw response JSON
#### Note
- If there was an error during the request, the Dictionary will return `null`
- The function `getBanners()` does not share the class `main` like the other functions, instead it uses the class `other`, as it is part of other features of the Artilities API
#### Example Usage
```CSharp
            Dictionary<string, string> bannerDict = Artilities.other.GetBanners();
            if (bannerDict != null)
            {
                Console.WriteLine("Banner Image: " + bannerDict["bannerImage"]);
                Console.WriteLine("Banner Link: " + bannerDict["bannerUrl"]);
                Console.WriteLine("Response Code: " + bannerDict["statusCode"]);
                Console.WriteLine("Response Time: " + bannerDict["delayTime"] + "ms");
                Console.WriteLine("Language: " + bannerDict["language"]);
                Console.WriteLine("Raw Json: " + bannerDict["raw"]);
            }
            else
            {
                Console.WriteLine("There was an error in the request");
            }
```
#### Output
```
Banner Image: https://i.imgur.com/pKmfznm.gif
Banner Link: https://discord.com/invite/u7dBmKyMWa
Response Code: 200
Response Time: 57ms
Language:
Raw Json: {
  "status_code": 200,
  "details": {
    "banner_url": "https://discord.com/invite/u7dBmKyMWa",
    "banner_image": "https://i.imgur.com/pKmfznm.gif",
    "language": ""
  },
  "execution_time": 57
}

```

### Versions etc
  <a href="https://www.nuget.org/packages/Artilities.Net/">
    <img src="https://img.shields.io/nuget/vpre/Artilities.Net.svg?maxAge=2592000?style=plastic" alt="NuGet">
