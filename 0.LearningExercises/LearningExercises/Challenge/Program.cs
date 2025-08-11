namespace Challenge
{
    internal class Program
    {
        /*
         * 
         * You will be provided with the full text of the Frankenstein novel, by Mary Shelley, in a text file.
         *
         * Using this text file, your task is to write a C# program that performs the following:
         *
         * 1. The text contains licensing information at the beginning and end. For the purpose of this challenge, 
         *    we only care about the main content of the novel. You will need to remove this licensing information from the text. 
         *    TIP: the novel starts with "CHAPTER I" and ends with "THE END".
         * 2. Find and print the top 10 most frequently used words in the novel, as well as how many times each of them appears in the text. 
         *    A word is defined as a sequence of characters separated by whitespace or punctuation. Ignore case when counting words. 
         *    TIP: You can use `Regex.Replace(text, @"[^\w\s]", "");` to remove punctuation.
         * 3. Find all the paragraphs in the novel that contain the word "monster", and print how many they are. 
         *    TIP: paragraphs are delimited by two newlines (`\n\n`).
         * 4. Replace all occurrences of the word "monster" with "misunderstood creature" in the novel text, 
         *    and print all the paragraphs that contain the word "misunderstood creature". 
         *    They should match the original count of paragraphs that contained "monster".
        */

        static void Main(string[] args)
        {
            // This will load the contents of the Frankenstein novel from a text file.
            string frankenstein = LoadText();
        }

        private static string LoadText()
        {
            string frankenstein = File.ReadAllText("..\\..\\..\\frankenstein.txt");

            // This normalizes line endings to ensure consistent processing.
            // All new lines in this file will be treated as "\n".
            return frankenstein.ReplaceLineEndings("\n");
        }
    }
}
