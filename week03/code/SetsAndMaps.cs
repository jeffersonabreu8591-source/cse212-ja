using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        //basically this needs to do this:
        //Take a word, invert that, check if this inverted version is in the list, if exists then it should form a pair
        //needs to do that but must be O(n)

        //hashSet to store the words
        var set = new HashSet<string>();
        //list to store match pairs 
        var result = new List<string>();
        //take the words and put into the hashset
         foreach (var word in words)
    {
        set.Add(word);
        //this way we can check quickly if the inverted word exist
    };

        foreach (var word in words)
    {
        //if words are equal ignore them
        if (word[0] == word[1])
            continue;
        // Invert the words: ex "am" turns "ma"
        var reversed = $"{word[1]}{word[0]}";
        //now check if the inverted words exists
                if (set.Contains(reversed))
            {
                //condition to avoid duplicated pairs
                if (string.Compare(word, reversed) < 0)
            {
                result.Add($"{word} & {reversed}");
            }
            }
    }
        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            //index 3 of the columns stores the scolarity field

            //takes the degree of the line
            var degree = fields[3]; //stores things like '''bachelous''

            //now verify if this degree already exists in the list
            if (degrees.ContainsKey(degree))
            {
                //if this is true then it means that someone in this list were already counted before

                //if it is true increment that
                    degrees[degree]++;

            }
            else
        {
            //if it does not exist creates tghe key
                degrees[degree] = 1;
        }

        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        //clean the words: take off spaces, put everything in lowercase
        //if the sizes are different: their are not anagrams
        //count the letters from the first letter
        //descount letters from the second
        //if something remains: false
        //if everything is zero: true
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();
        //check the sizes 
        if (word1.Length != word2.Length)
                return false;
        //create the  dictionary
            var letters = new Dictionary<char, int>();
        //count letter from the first word
        foreach (char c in word1)
        {
         if (letters.ContainsKey(c))
        letters[c]++;
         else
        letters[c] = 1;
        };

        //subtract from the second word to check
        foreach (char c in word2)
        {
            if (!letters.ContainsKey(c))
             return false;

                letters[c]--;

                if (letters[c] < 0)
             return false;
        }

    //if everything matches so it is anagram




        
        return true;
;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}