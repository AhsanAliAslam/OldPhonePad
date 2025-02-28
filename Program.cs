/*
 
Author: Ahsan Ali Aslam
Dated: 28-Feb-2025
License: MIT 
Project: Old Phone Pad
Description: I have developed an old phone pad keys
             which uses key press multiple times to 
             write the message.
 */

OldPhonePad("33#");
OldPhonePad("227 *#");
OldPhonePad("4433555 555666#");
OldPhonePad("4433555 555666#");
OldPhonePad("8 88777444666 * 664#");

static string OldPhonePad(string input = "4433555 555666#")
{

    string returnStr = "";
    string[] alphaNumerics = ["&'(", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"]; // Segregate keys group depending upon the old phone pad. 
    Dictionary<string, int> alphabetsToCount = new Dictionary<string, int>(); // Dictionary to maintain how many times a key is pressed.
    int count = 0; // Number of time a key is pressed.
    char prev = ' '; // maintain the previous value to track the key counts.
    string tempStr = ""; // It keeps the group of alphabets which key is pressed.

    for (int i = 0; i < input.Length; i++)
    {

        if (input[i] == '#') // End of string
            break;

        if (input[i] == '*') // Condition to check backspace
        {
            returnStr = returnStr.Substring(0, returnStr.Length - 1);
            continue;
        }

        if (alphabetsToCount.Count > 0 && (input[i] == ' ' || (input[i] != ' ' && prev != ' ' && prev != input[i])))
        {
            returnStr += alphabetsToCount.Keys.Where(q => q.Contains(tempStr)).First()[alphabetsToCount[tempStr] - 1]; // It retreives the pressed key and concatinated in the result string.

            count = 0;
            alphabetsToCount.Clear();
            if (input[i] == ' ')
                continue;
        }

        if (input[i] != ' ')
        {
            tempStr = alphaNumerics[int.Parse(input[i].ToString()) - 1];
            if (!alphabetsToCount.ContainsKey(tempStr))
                alphabetsToCount.Add(tempStr, ++count);
            else
                alphabetsToCount[tempStr] = ++count;
        }
        prev = input[i];

    }
    if (alphabetsToCount.Count > 0)
        returnStr += alphabetsToCount.Keys.Where(q => q.Contains(tempStr)).First()[alphabetsToCount[tempStr] - 1];
   
    alphabetsToCount.Clear();
    returnStr = returnStr.ToUpper();
    Console.WriteLine(returnStr.ToUpper());

    return returnStr;
}