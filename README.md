# Artilities.NET
An unofficial C# Wrapper for the [Artilities REST API](https://artilities.github.io/artilities-api/)

# What can this Wrapper do?
This wrapper currently supports `getting an Idea`, `Getting a challenge Idea`, `Looking up artist slang`, `getting Atilities Banners`, `getting a users saved Ideas, Challenges and Colors`. The other API functions like `getting patreons` will hopefully follow soon.

# Where can I get the package?
You can download the package on [NuGet](https://www.nuget.org/packages/Artilities.NET) or soon here on GitHub
You can also: 
- Type `Install-Package Artilities.NET -Version 1.2.1` into the Package Manager
- Type `dotnet add package Artilities.NET --version 1.2.1` into the command prompt, note that you need to have `dotnet` installed
- Reference the Dependency using `<PackageReference Include="Artilities.NET" Version="1.2.1" />`
- Install the package in your Editors NuGet Package Manager


# DOCUMENTATION
## Artilities 1.2.0 has added a V2 wrapper
## If you want to use Artilities.NET v2, consider reading the v2 docs right [HERE](https://github.com/FabioGaming/Artilities.NET/blob/master/docsV2.md)


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

#### Get Artilities User Information (v1.1.6 and above)
Since Artilities 1.1.6 you can get someones saved favorite ideas, challenges and colors
#### Note
- Artilities.NET 1.1.6 adds the ability to look up a users saved stuff, tho this requires a `devKey`!
- To get a devKey you must apply for it on the Artilities Discord, which can be found on the [Website](https://artilities.herokuapp.com)
- If a user has been found the `statusCode` key, will return `200`
- If a user has been found but have their profile on private, the `statusCode` key will return `403`
- If a user doesn't exist as an Artilities Account, the `statusCode` key will return `404`
#### Using the devKey
```CSharp
            Artilities.users.devkey = "yourKey"; //Input your devKey here!
            Artilities.users.userID = "yourID"; //If you registered for a devKey, your Discord ID will be registered to this key, so make sure to input your discord ID here
```
### Get a users saved Ideas
You can get someones saved ideas using the `getIdeas()` function, this function will return a Dictionary with the following keys: `delayTime`, `statusCode`, `ideas`, `raw`
- `delayTime` will return the time it took for the server to respond (in ms)
- `statusCode` will return the HTTP response code (in best case `200` (note that this can return `403`))
- `ideas` will return the list of saved ideas (it will return a `string` not an `array`!)
- `raw` will return the raw JSON output of the request
#### Note
- The function `getIdeas()` belongs to the `users` class, so make sure you call it using `Artilities.users.getIdeas()`.
- `getIdeas()` accepts 1 `string` argument, this being the `userID` you want to look up, leaving this field empty, will make the program use the devKeys `userID`
- Profiles can be set to private, if this is the case you can't access the users saved data, and `statusCode` will return `403`, so make sure you check for that!
- If you lookup your own userID, there will be a `private` key in the JSON response, which is NOT included in Artilities.NET 1.1.6. If you want the private key to be usable, consider using [Artilities.NET V2](https://github.com/FabioGaming/Artilities.NET/blob/master/docsV2.md)
#### Example Usage
```CSharp
            Artilities.users.devkey = "devKey";
            Artilities.users.userID = "userID";
            Dictionary<string, string> ideaDictionary = Artilities.users.getIdeas(); // In this case I don't input any user, which will make Artilities.NET use Artilities.user.userID as lookup query!
            if(ideaDictionary["statusCode"] != "200")
            {
                if(ideaDictionary["statusCode"] == "403")
                {
                    Console.WriteLine("This profile is Private.");
                } else
                {
                    Console.WriteLine("Something went wrong!");
                }
            } else
            {
                Console.WriteLine("Server response: " + ideaDictionary["statusCode"]);
                Console.WriteLine("Server response Time: " + ideaDictionary["delayTime"] + "ms");
                Console.WriteLine("Saved Ideas:");
                string[] ideas = ideaDictionary["ideas"].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries); // This is how to split the output string into an array!
                foreach(string idea in ideas)
                {
                    Console.WriteLine(idea);
                }
                Console.WriteLine("Raw JSON: " + ideaDictionary["raw"]);
            }
```
#### Output
```
Server response: 200
Server response Time: 58ms
Saved Ideas:
Pinocchio lost his nose
Raw JSON: {
  "status_code": 200,
  "data": {
    "ideas": [
      "Pinocchio lost his nose"
    ],
    "challenges": [
      "draw using anything but your hands",
      "draw with two hands at once"
    ],
    "colors": [
      [
        "#2855a7",
        "#58b3aa",
        "#3166b9",
        "#3a3695"
      ],
      [
        "#a6d4aa",
        "#d4166d",
        "#4108c7",
        "#7ba55c"
      ]
    ],
    "settings": {
      "private": false
    }
  },
  "execution_time": 58
}
```
### Get a users saved challenges
You can get someones saved challenges using the `getChallenges()` function, this function will return a Dictionary with the following keys: `delayTime`, `statusCode`, `challenges`, `raw`
- `delayTime` will return the time it took for the server to respond (in ms)
- `statusCode` will return the HTTP response code (in best case `200` (note that this can return `403`))
- `challenges` will return the list of saved challenges (it will return a `string` not an `array`!)
- `raw` will return the raw JSON output of the request
#### Note
- The function `getChallenges()` belongs to the `users` class, so make sure you call it using `Artilities.users.getChallenges()`.
- `getChallenges()` accepts 1 `string` argument, this being the `userID` you want to look up, leaving this field empty, will make the program use the devKeys `userID`
- Profiles can be set to private, if this is the case you can't access the users saved data, and `statusCode` will return `403`, so make sure you check for that!
- If you lookup your own userID, there will be a `private` key in the JSON response, which is NOT included in Artilities.NET 1.1.6. If you want the private key to be usable, consider using [Artilities.NET V2](https://github.com/FabioGaming/Artilities.NET/blob/master/docsV2.md)
#### Example Usage
```CSharp
            Artilities.users.devkey = "devKey";
            Artilities.users.userID = "userID";
            Dictionary<string, string> challengeDictionary = Artilities.users.getChallenges(); // In this case I don't input any user, which will make Artilities.NET use Artilities.user.userID as lookup query!
            if(challengeDictionary["statusCode"] != "200")
            {
                if(challengeDictionary["statusCode"] == "403")
                {
                    Console.WriteLine("This profile is Private.");
                } else
                {
                    Console.WriteLine("Something went wrong!");
                }
            } else
            {
                Console.WriteLine("Server response: " + challengeDictionary["statusCode"]);
                Console.WriteLine("Server response Time: " + challengeDictionary["delayTime"] + "ms");
                Console.WriteLine("Saved challenges:");
                string[] ideas = challengeDictionary["challenges"].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries); // This is how to split the output string into an array!
                foreach(string idea in ideas)
                {
                    Console.WriteLine(idea);
                }
                Console.WriteLine("Raw JSON: " + challengeDictionary["raw"]);
            }
```
#### Output
```
Server response: 200
Server response Time: 57ms
Saved challenges:
draw using anything but your hands
draw with two hands at once
Raw JSON: {
  "status_code": 200,
  "data": {
    "ideas": [
      "Pinocchio lost his nose"
    ],
    "challenges": [
      "draw using anything but your hands",
      "draw with two hands at once"
    ],
    "colors": [
      [
        "#2855a7",
        "#58b3aa",
        "#3166b9",
        "#3a3695"
      ],
      [
        "#a6d4aa",
        "#d4166d",
        "#4108c7",
        "#7ba55c"
      ]
    ],
    "settings": {
      "private": false
    }
  },
  "execution_time": 57
}
```
### Get a users saved colors
You can get someones saved challenges using the `getColors()` function, this function will return a Dictionary with the following keys: `delayTime`, `statusCode`, `colors`, `raw`
- `delayTime` will return the time it took for the server to respond (in ms)
- `statusCode` will return the HTTP response code (in best case `200` (note that this can return `403`))
- `colors` will return the list of saved challenges (it will return a `string` not an `array`!)
- `raw` will return the raw JSON output of the request
#### Note
- The function `getColors()` belongs to the `users` class, so make sure you call it using `Artilities.users.getColors()`.
- `getColors()` accepts 1 `string` argument, this being the `userID` you want to look up, leaving this field empty, will make the program use the devKeys `userID`
- Profiles can be set to private, if this is the case you can't access the users saved data, and `statusCode` will return `403`, so make sure you check for that!
- If you lookup your own userID, there will be a `private` key in the JSON response, which is NOT included in Artilities.NET 1.1.6. If you want the private key to be usable, consider using [Artilities.NET V2](https://github.com/FabioGaming/Artilities.NET/blob/master/docsV2.md)
#### Example Usage
```CSharp
            Artilities.users.devkey = "devKey";
            Artilities.users.userID = "userID";
            Dictionary<string, string> colorDictionary = Artilities.users.getColors(); // In this case I don't input any user, which will make Artilities.NET use Artilities.user.userID as lookup query!
            if(colorDictionary["statusCode"] != "200")
            {
                if(colorDictionary["statusCode"] == "403")
                {
                    Console.WriteLine("This profile is Private.");
                } else
                {
                    Console.WriteLine("Something went wrong!");
                }
            } else
            {
                Console.WriteLine("Server response: " + colorDictionary["statusCode"]);
                Console.WriteLine("Server response Time: " + colorDictionary["delayTime"] + "ms");
                Console.WriteLine("Saved colors:");
                string[] ideas = colorDictionary["colors"].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries); // This is how to split the output string into an array!
                foreach(string idea in ideas)
                {
                    Console.WriteLine(idea);
                }
                Console.WriteLine("Raw JSON: " + colorDictionary["raw"]);
            }
```
#### Output
```
Server response: 200
Server response Time: 53ms
Saved Colors:
#2855a7
#58b3aa
#3166b9
#3a3695
#a6d4aa
#d4166d
#4108c7
#7ba55c
Raw JSON: {
  "status_code": 200,
  "data": {
    "ideas": [
      "Pinocchio lost his nose"
    ],
    "challenges": [
      "draw using anything but your hands",
      "draw with two hands at once"
    ],
    "colors": [
      [
        "#2855a7",
        "#58b3aa",
        "#3166b9",
        "#3a3695"
      ],
      [
        "#a6d4aa",
        "#d4166d",
        "#4108c7",
        "#7ba55c"
      ]
    ],
    "settings": {
      "private": false
    }
  },
  "execution_time": 53
}
```

### Versions etc
  <a href="https://www.nuget.org/packages/Artilities.Net/">
    <img src="https://img.shields.io/nuget/vpre/Artilities.Net.svg?maxAge=2592000?style=plastic" alt="NuGet">
