# Artilities.NET
An unofficial C# Wrapper for the [Artilities REST API](https://artilities.github.io/artilities-api/)

# What can this Wrapper do?
This wrapper currently supports `getting an Idea`, `Getting a challenge Idea`, `Looking up artist slang`. The other API functions like `getting patreons` and `getting banners` will hopefully follow soon.

# Where can I get the package?
You can download the package on [NuGet](https://www.nuget.org/packages/Artilities.NET) or soon here on GitHub



# DOCUMENTATION
### Getting an Idea
You can get a random Idea from the Artilities Database using the `getIdea()` function, this function will return a Dictionary with the following keys: `english`,       - - `russian`, `responseTime`, `responseCode`, `raw`.
- `english` returns the result Idea in English
- `russian` returns the result Idea in Russian (You might need to change the text output to `UTF-16` to be able to see it)
- `responseTime` returns the time it took for the server to respond in MS
- `responseCode` returns the Web Response (in best case its `200`)
- `raw` returns the raw response JSON
```CSharp

````

