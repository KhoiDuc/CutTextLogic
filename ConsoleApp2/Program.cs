using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string originalText = "Whether you’re looking to experience a different culture far from home, or the splendor of the world with those you love, we're on hand, to make sure every experience is the best it can be.";
        int maxLength = 136;

        string[] englishWords = {
            "a", "an", "the", "some", "any", "few", "many", "all", "both", "each",
            "every", "another", "either", "neither", "this", "that", "these", "those",
            "my", "your", "his", "her", "its", "our", "their", "whose", "which", "what",
            "who", "whom", "whatever", "whichever", "and", "but", "or", "nor", "for", "so",
            "yet", "am", "is", "are", "was", "were", "been", "being", "in", "inside",
            "within", "into", "among", "amongst", "between", "betwixt", "by", "beside",
            "beyond", "through", "via", "with", "alongside", "you", "I", "he", "she", "it",
            "we", "they", "me", "him", "us", "them", "don't", "doesn't", "can't", "won't",
            "shouldn't", "haven't", "wouldn't", "couldn't", "isn't", "did", "didn't", "does",
            "do", "to", "too", "toward", "onto", "unto", "upon", "when", "whenever", "where",
            "wherever", "while", "whilst", "until", "till", "before", "after", "of", "off",
            "on", "out", "over", "above", "below", "beneath", "besides", "along", "around",
            "throughout", "since", "as", "because", "due", "owing", "from", "against", "during",
            "not", "at", "up", "down", "about", "near", "past", "next", "across", "behind",
            "under", "unless", "if", "whether", "without", "wherein", "may", "might", "can",
            "could", "will", "shall", "would", "should", "mightn't", "mustn't", "mayn't",
            "needn't", "shan't", "mustn't", "I'm", "you're", "he's", "she's", "it's", "we're",
            "they're", "I've", "you've", "we've", "they've", "I'd", "you'd", "he'd", "she'd",
            "we'd", "they'd", "I'll", "you'll", "he'll", "she'll", "we'll", "they'll"
        };
        char[] specialCharacters = "!?.'\"".ToCharArray();
        // Declare trimmedText
        string trimmedText = string.Empty;

        // Find the first space after maxLength
        if (originalText.Length > maxLength)
        {
            int nextSpace = originalText.IndexOf(' ', maxLength);
            if (nextSpace == -1)
            {
                trimmedText = originalText;
            }
            else
            {
                trimmedText = originalText.Substring(0, nextSpace).Trim();

                // Keep trimming until the last word is not in englishWords
                while (true)
                {
                    // Get the last word after trimming
                    string[] words = trimmedText.Split(' ');
                    string lastWord = words.Last();
                    char lastChar = lastWord.TrimEnd().Last();
                    bool isCharOfWordSpecialCharacter = false;
                    if (!specialCharacters.Contains(lastChar) && !char.IsLetterOrDigit(lastChar))
                    {
                        isCharOfWordSpecialCharacter = true;
                        lastWord = lastWord.TrimEnd(lastChar);
                    }

                    // Check if the last word is in englishWords list
                    if (!englishWords.Contains(lastWord))
                    {
                        if (isCharOfWordSpecialCharacter)
                        {
                            trimmedText = trimmedText.TrimEnd(lastChar);
                        }
                        break; // Exit if the last word is not in the list
                    }

                    // Find the next space after the current trimmedText length
                    nextSpace = originalText.IndexOf(' ', trimmedText.Length + 1);
                    if (nextSpace == -1)
                    {
                        trimmedText = originalText; // No more spaces, take the whole text
                        break;
                    }

                    // Trim the text up to the next space
                    trimmedText = originalText.Substring(0, nextSpace);
                }
            }
        }
        else
        {
            // If original text is shorter than maxLength, take the full text
            trimmedText = originalText;
        }

        Console.WriteLine(trimmedText);
    }
}
