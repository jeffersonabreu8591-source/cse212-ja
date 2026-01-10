public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Step 1: Need to create an array of the right size (length)
        //C# syntax to define array type `double[]`
        //name of the array is meuArray
        //declare it to be initiated with a `length`size
        double[] meuArray = new double[length];
        //Step 2: USe loop to fill up the array
        for (int i=0; i<length; i++ )
        {  
          //Step 3: Calculate the right values (need to remember that position 0 can not have value 0)  
          //Step 4: Save value in the array according with the position
            meuArray[i] = (number * i) + 1;
        }
        return meuArray;                      // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Understand how much it should rotate
    // how much elements goes from the end to the beginning of the list?
    // amount
    // Step 2: Where the final part starts
    // If the list has data.Count then the starting point should be data.Count - amount
    int startIndex = data.Count - amount;
    // Step 3: Separate the final elements that are coming to the beginning  of the listinto a temporary list
    List<int> finalPart = data.GetRange(startIndex, amount);
    // Step 4: Separate the rest of the list, everything before startIndex
    List<int> initialPart = data.GetRange(0, startIndex);
    // Step 5: Clear the list to rebuild
    data.Clear();

    // Step 6: Rebuild the list: Final 
    // Part + Initial part in this order now
    data.AddRange(finalPart);
    data.AddRange(initialPart);
    }
    public static void Run()
{
    Console.WriteLine("=== Testing MultiplesOf ===");
    double[] result = MultiplesOf(3, 5);
    Console.WriteLine("<double[]>{ " + string.Join(", ", result) + " }");

    Console.WriteLine("\n=== Testing RotateListRight ===");
    List<int> data = new List<int> { 1,2,3,4,5,6,7,8,9 };
    RotateListRight(data, 3);
    Console.WriteLine("<List>{ " + string.Join(", ", data) + " }");
}

}

