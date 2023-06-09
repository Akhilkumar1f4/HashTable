class Program
{
    static void Main()
    {
        // Use Case 1 - Frequency Counter for a sentence
        SentenceFrequencyCounter sentenceCounter = new SentenceFrequencyCounter(10);

        string sentence = "To be or not to be";
        string[] words = sentence.Split(' ');

        foreach (string word in words)
            sentenceCounter.InsertOrUpdate(word);

        Console.WriteLine("Frequency of words in the sentence:");
        foreach (string word in words)
            Console.WriteLine($"{word}: {sentenceCounter.GetFrequency(word)}");

        Console.WriteLine();

        // Use Case 2 - Frequency Counter for a paragraph
        ParagraphFrequencyCounter paragraphCounter = new ParagraphFrequencyCounter(20);

        string paragraph = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
        string[] paraWords = paragraph.Split(' ');

        foreach (string word in paraWords)
            paragraphCounter.InsertOrUpdate(word);

        Console.WriteLine("Frequency of words in the paragraph:");
        foreach (string word in paraWords)
            Console.WriteLine($"{word}: {paragraphCounter.GetFrequency(word)}");

        Console.WriteLine();

        // Use Case 3 - Removal of a word from a paragraph
        WordRemover wordRemover = new WordRemover(20);

        string modifiedParagraph = paragraph.Replace("avoidable", "");
        string[] modifiedWords = modifiedParagraph.Split(' ');

        foreach (string word in paraWords)
            wordRemover.InsertOrUpdate(word);

        wordRemover.Remove("avoidable");

        Console.WriteLine("Frequency of words in the modified paragraph:");
        foreach (string word in modifiedWords)
            Console.WriteLine($"{word}: {wordRemover.GetFrequency(word)}");
    }
}