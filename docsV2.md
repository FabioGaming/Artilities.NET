# What is different in Artilities.NET V2
## Artilities.NET comes with a set of new features, including the ability to use intellisense, meaning you no longer need to know the exact dictionary keys to work with this wrapper!

# Why does Artilities.NET v2 exist
## Artilities.NET V2 is **not** a replacement, but rather an alternative way of using this wrapper. Artilities.NEt v2 however, does not change the way of using the package completely, so it's recommended to read [The V1 Docs](https://github.com/FabioGaming/Artilities.NET/blob/master/README.md) to see more information about the package.

# Extras
## Big thanks to [Slimakoi](https://github.com/Slimakoi) for making this version possible!

# DOCUMENTATION
### Getting an Idea
You can get a random Idea from the Artilities Database using the `GetIdea()` function, this function will return an Object with the following values: `english`, `russian`, `delayTime`, `statusCode`, `raw`.
- `english` returns the result Idea in English
- `russian` returns the result Idea in Russian (You might need to change the text output to `UTF-8` to be able to see it)
- `delayTime` returns the time it took for the server to respond in MS
- `statusCode` returns the Web Response (in best case its `200`)
- `raw` returns the raw response JSON
#### Note
- If there was an error during the request, the Object will return some values as `null`
- You need to parse `Artilities.v2.main.GetIdea()` into an `Artilities.v2.Responses.Idea` value!
#### Example Usage
```CSharp
            Console.OutputEncoding = System.Text.Encoding.UTF8; //This line is to ensure that the russian language can be displayed!
            //You can use 'using Artilities.v2;' to avoid typing 'Artilities.v2.Responses...' each time!
            Artilities.v2.Responses.Idea idea = Artilities.v2.main.GetIdea();
            if(idea.statusCode == 200)
            {
                Console.WriteLine("Generated Idea");
                Console.WriteLine("English: " + idea.english);
                Console.WriteLine("Russian: " + idea.russian);
                Console.WriteLine("Server Response time: " + idea.delayTime + "ms");
                Console.WriteLine("Server response Code: " + idea.statusCode);
                Console.WriteLine("Raw JSON: " + idea.raw);
            } else
            {
                Console.WriteLine("Something went wrong!");
            }
```
#### Output
```
Generated Idea
English: Steampunk Pirate Spaceship
Russian: Пиратский космический корабль в стиле стимпанк
Server Response time: 153ms
Server response Code: 200
Raw JSON: {
  "status_code": 200,
  "generated_idea": {
    "ru": "Пиратский космический корабль в стиле стимпанк",
    "eng": "Steampunk Pirate Spaceship"
  },
  "execution_time": 153
}
```

### Getting a Challenge
You can get a random Challenge from the Artilities Database using the `GetChallenge()` function, this function will return an Object with the following values: `english`, `russian`, `delayTime`, `statusCode`, `raw`.
- `english` returns the result Idea in English
- `russian` returns the result Idea in Russian (You might need to change the text output to `UTF-8` to be able to see it)
- `delayTime` returns the time it took for the server to respond in MS
- `statusCode` returns the Web Response (in best case its `200`)
- `raw` returns the raw response JSON
#### Note
- If there was an error during the request, the Object will return some values as `null`
- You need to parse `Artilities.v2.main.GetChallenge()` into an `Artilities.v2.Responses.Challenge` value!
#### Example Usage
```CSharp
            Console.OutputEncoding = System.Text.Encoding.UTF8; //This line is to ensure that the russian language can be displayed!
            //You can use 'using Artilities.v2;' to avoid typing 'Artilities.v2.Responses...' each time!
            Artilities.v2.Responses.Challenge challenge = Artilities.v2.main.GetChallenge();
            if(challenge.statusCode == 200)
            {
                Console.WriteLine("Generated Challenge");
                Console.WriteLine("English: " + challenge.english);
                Console.WriteLine("Russian: " + challenge.russian);
                Console.WriteLine("Server Response time: " + challenge.delayTime + "ms");
                Console.WriteLine("Server response Code: " + challenge.statusCode);
                Console.WriteLine("Raw JSON: " + challenge.raw);
            } else
            {
                Console.WriteLine("Something went wrong!");
            }
```
#### Output
```
Generated Challenge
English: Draw your oc within only 50 brush strokes
Russian: Нарисуй своего ОСа используя только 50 мазков кистью
Server Response time: 28ms
Server response Code: 200
Raw JSON: {
  "status_code": 200,
  "generated_challenge": {
    "eng": "Draw your oc within only 50 brush strokes",
    "ru": "Нарисуй своего ОСа используя только 50 мазков кистью"
  },
  "execution_time": 28
}
```

### Getting a Dictionary Entry
You can get a dictionary entry from the Artilities Database using the `GetDictionaryEntry(string)` function, this function allows you to look up artist "slang" or specific art related terms from the Artilities database. This function will return an Object with the following values: `word`, `description`, `delayTime`, `statusCode`, `raw`.
- `word` returns the result of the target term
- `description` returns the description / meaning of the looked up term
- `delayTime` returns the time it took for the server to respond in MS
- `statusCode` returns the Web Response (in best case its `200`)
- `raw` returns the raw response JSON
#### Note
- If there was an error during the request, the Object will return some values as `null`
- You need to parse `Artilities.v2.main.GetDictionaryEntry()` into an `Artilities.v2.Responses.DictionaryEntry` value!
- The function `GetDictionaryEntry()` requires 1 `string` argument, this being the term you want to look up
#### Example Usage
```CSharp
            Artilities.v2.Responses.DictionaryEntry lookup = Artilities.v2.main.GetDictionaryEntry("UFO"); //In this case im looking up the term "UFO" which stands for "Up for offers"
            if(lookup.statusCode == 200)
            {
                Console.WriteLine("Database Lookup");
                Console.WriteLine("Word: " + lookup.word);
                Console.WriteLine("Meaning: " + lookup.description);
                Console.WriteLine("Server Response time: " + lookup.delayTime + "ms");
                Console.WriteLine("Server response Code: " + lookup.statusCode);
                Console.WriteLine("Raw JSON: " + lookup.raw);
            } else
            {
                Console.WriteLine("Something went wrong!");
            }
````
#### Ouput
```
Database Lookup
Word: UFO
Meaning: Short for Up For Offers.
Server Response time: 62ms
Server response Code: 200
Raw JSON: {
  "status_code": 200,
  "query_results": [
    [
      "UFO",
      "Short for Up For Offers."
    ]
  ],
  "execution_time": 62
}
```

### Getting Artilities Banners
You can get the Artilities Banners using the `GetBanners()` function, this function allows you to get the banners shown on the Artilities Website and get their information. This function will return an Object with the following values: `bannerUrl`, `bannerImage`, `delayTime`, `statusCode`, `language`, `raw`.
- `bannerUrl` returns the link the banner leads to
- `bannerImage` returns the link to the media file (image, gif, etc.) of the banner
- `language` returns the banners languages (usually returns `""`)
- `delayTime` returns the time it took for the server to respond in MS
- `statusCode` returns the Web Response (in best case its `200`)
- `raw` returns the raw response JSON
#### Note
- If there was an error during the request, the Object will return some values as `null`
- You need to parse `Artilities.v2.other.GetBanners()` into an `Artilities.v2.Responses.Banner` value!
- The function `GetBanners()` belongs to the `other` class, since its available on the Artilities `other` API endpoint
#### Example Usage
```CSharp
            Artilities.v2.Responses.Banner banner = Artilities.v2.other.GetBanners();
            if(banner.statusCode == 200)
            {
                Console.WriteLine("Banner info");
                Console.WriteLine("Banner Link: " + banner.bannerUrl);
                Console.WriteLine("Banner Image: " + banner.bannerImage);
                Console.WriteLine("Banner language: " + banner.language);
                Console.WriteLine("Server Response time: " + banner.delayTime + "ms");
                Console.WriteLine("Server response Code: " + banner.statusCode);
                Console.WriteLine("Raw JSON: " + banner.raw);
            } else
            {
                Console.WriteLine("Something went wrong!");
            }
```
#### Output
```
Banner info
Banner Link: https://discord.com/invite/u7dBmKyMWa
Banner Image: https://i.imgur.com/pKmfznm.gif
Banner language:
Server Response time: 55ms
Server response Code: 200
Raw JSON: {
  "status_code": 200,
  "details": {
    "banner_url": "https://discord.com/invite/u7dBmKyMWa",
    "banner_image": "https://i.imgur.com/pKmfznm.gif",
    "language": ""
  },
  "execution_time": 55
}
```

### Getting Information about an Artilities Users
You can get a users saved ideas, colors and challenges using the `GetUserInfo()` function, this function allows you to get a users saved / favorited things on the Artilities Website!. This function will return an Object with the following values: `challenges`, `colors`, `ideas`, `statusCode`, `delayTime`, `raw`.
- `challenges` returns a string of the saved challenges
- `colors` returns a list of the saved colors
- `ideas` returns a list of the saved ideas
- `delayTime` returns the time it took for the server to respond in MS
- `statusCode` returns the Web Response (in best case its `200`)
- `raw` returns the raw response JSON
#### Note
- Artilities.NET 1.1.6 (and above) adds the ability to look up a users saved stuff, tho this requires a `devKey`!
- To get a devKey you must apply for it on the Artilities Discord, which can be found on the [Website](https://artilities.herokuapp.com)
- If there was an error during the request, the Object will return some values as `null`
- You need to parse `Artilities.v2.users.GetUserInfo()` into an `Artilities.v2.Responses.UserInfo` value!
- The function `GetUserInfo()` belongs to the `users` class, since its available on the Artilities `users` API endpoint
- A user profile can be private, if thats the case the `statusCode` will return `403`
- A user can also not be found on the Artilities Database, in that case the `statusCode` returns `404`
- The values `colors`, `ideas`, `challenges` will all be returned as a string array, so you can easily access each value of it! In case you want to get the array as a string you can do ``string.Join(", ", yourArrayList);``
- If you look up your own profile, there will be an `isPrivate` key within the JSON, this wont be the case if you look up someone else
- If you dont specify a target user, this wrapper will automatically use your own ``userID``
- Your `userID` must match the Discord account of your `devKey``
#### Example Usage
```CSharp
            Artilities.v2.users.devkey = ""; //Your devKey here!
            Artilities.v2.users.userID = ""; //Your userID here!
            Artilities.v2.Responses.UserInfo user = Artilities.v2.users.GetUserInfo();

            if(user.statusCode == 200)
            {
                Console.WriteLine("User Information:");
                Console.WriteLine("Saved Ideas: " + string.Join(", ", user.ideas));
                Console.WriteLine("Saved Challenges: " + string.Join(", ", user.challenges));
                Console.WriteLine("Saved Colors: " + string.Join(", ", user.colors));
                if(user.isPrivate != null)
                {
                    Console.WriteLine("Is user Private: " + user.isPrivate);
                }
                Console.WriteLine("Raw JSON: " + user.raw);
            } else if(user.statusCode == 403)
            {
                Console.WriteLine("This users profile is private!");
            } else if(user.statusCode == 404)
            {
                Console.WriteLine("The target user could not be found in the Artilities Database!");
            } else
            {
                Console.WriteLine("Something went wrong!");
            }
```
#### Output
```
User Information:
Saved Ideas: Cat Battalion, Hippie is a music teacher, World without people
Saved Challenges: draw with two hands at once, paint the picture with different shades of a certain color, Draw your oc in 5 minutes, Draw your oc with only 1 brush (digital)
Saved Colors: #a89765, #d4c6c2, #ee10c3, #20d2a2, #ec4464, #157b46, #8c9c61, #475793, #647b7b, #8c3601
Is user Private: True
Raw JSON: {
  "status_code": 200,
  "data": {
    "ideas": [
      "Cat Battalion",
      "Hippie is a music teacher",
      "World without people"
    ],
    "challenges": [
      "draw with two hands at once",
      "paint the picture with different shades of a certain color",
      "Draw your oc in 5 minutes",
      "Draw your oc with only 1 brush (digital)"
    ],
    "colors": [
      [
        "#a89765",
        "#d4c6c2",
        "#ee10c3",
        "#20d2a2",
        "#ec4464",
        "#157b46"
      ],
      [
        "#8c9c61",
        "#475793",
        "#647b7b",
        "#8c3601"
      ]
    ],
    "settings": {
      "private": true
    }
  },
  "execution_time": 54
}
```

