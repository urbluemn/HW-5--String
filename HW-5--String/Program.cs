//1.Visual studio - Console Application
//2.Считать строку текста из консоли (продвинутое задание: из файла). Строка содержит буквы латинского алфавита, знаки препинания и цифры. 
//3. Реализовать меню выбора действий:
////-Найти слова, содержащие максимальное количество цифр.
////- Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.
////- Заменить цифры от 0 до 9 на слова «ноль», «один», …, «девять».
///- Вывести на экран сначала вопросительные, а затем восклицательные предложения.
////- Вывести на экран только предложения, не содержащие запятых.
////- Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.
//4. Приложение не должно падать ни при каких условиях.


Console.WriteLine("Please enter your text(letters, numbers and symbols required)");
string userInput = Console.ReadLine();
string[] wordsFromUser = userInput.Split('-', ',' , '.' , ' ', '_', ':', '\n', '\t', '\r');

bool menuRepeat = false;
while (!menuRepeat)
{
    Console.WriteLine("\nSelect option: \n\t1.Find words with the maximum number of digits. \n\t2.Find the longest word and its amount in sentences. \n\t3.Change digits with words. \n\t4.View questionable and exclamation sentences. \n\t5.View sentences with no ','. \n\t6.Words that starts and ends with the same letter.");
    string menuChoise = Console.ReadLine();
    switch (menuChoise)
    {
        case "1":
            MaxDigitWord();
            break;
        case "2":
            LongestWord();
            break;
        case "3":
            AnotherUserInput();
            break;
        case "4":
            ExclamationQuestionableSentences();
            break;
        case "5":
            NonSeparatedSentences();
            break;
        case "6":
            StartsEndsWith();
            break;
        default:
            Console.WriteLine("Please select the correct option!");
            continue;
    }
}

void StartsEndsWith()
{
    int countWords = 0;
    Console.WriteLine("Words that starts and ends with the same letter: \n");
    foreach(var word in wordsFromUser)
    {
        if(word.Length > 1 && word[0] == word[word.Length-1])
        {
            Console.Write($"\t{word}\t");
            countWords++;
        }
        else if(countWords == 0)
            Console.WriteLine("No such words!");
    }
}
void NonSeparatedSentences()
{
    string[] NonSeparatedSenteces = userInput.Split(new[] { '!', '.', '?', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine("Sentences which are not containig ',': \n");
    int SetntWithOutSep = 0;
    for (int i = 0; i < NonSeparatedSenteces.Length; i++)
    {
        
        if (!NonSeparatedSenteces[i].Contains(','))
        {
            Console.WriteLine(NonSeparatedSenteces[i]);
            SetntWithOutSep++;
        }      
        if (SetntWithOutSep == 0)
        {
            Console.WriteLine("No such sentences!");
        }
    }
    

        
}
void ExclamationQuestionableSentences()
{
    string[] QuestionableStringSeparator = { ". ", "\n", "! " };
    string[] ExclamationStringSeparator = { ". ", "\n", "? " };
    string[] QuestionableSenteces = userInput.Split(QuestionableStringSeparator, StringSplitOptions.RemoveEmptyEntries);
    string[] ExclamationSenteces = userInput.Split(ExclamationStringSeparator, StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine();
    Console.WriteLine("Questionable senteces: \n");
    for (int i = 0; i < QuestionableSenteces.Length; i++)
    {
        if (QuestionableSenteces[i].Contains('?'))
        {
            
            Console.WriteLine( QuestionableSenteces[i]);
        }
    }
    Console.WriteLine("Exclamation senteces: \n");
    for (int i = 0; i < ExclamationSenteces.Length; i++)
    {

        if (ExclamationSenteces[i].Contains('!'))
        {
            
            Console.WriteLine( ExclamationSenteces[i]);
        }
    }
}
void AnotherUserInput()
{
    string NewString = userInput;
    string[] digitToWord = { " ноль ", " один ", " два ", " три ", " четыре ", " пять ", " шесть ", " семь ", " восемь ", " девять " };
    for (int i = 0; i < 10; i++)
    {
        NewString = NewString.Replace(i.ToString(), digitToWord[i]);
    }  
    Console.WriteLine(NewString);
}
void LongestWord()
{
    string LongestWord = wordsFromUser[0];
    int wordCount = 0;
    int MaxNumberIndex = 0;
    for (int word = 0; word < wordsFromUser.Length; word++)
    {
        if(wordsFromUser[word].Length > LongestWord.Length)
        {
            LongestWord = wordsFromUser[word];
            wordCount = 0;
        }
        else if (wordsFromUser[word].Length == LongestWord.Length)
        {
            wordCount++;
        }
    }
    Console.WriteLine($"The longest word is \"{LongestWord}\" and its amount in current sentence is \"{wordCount}\"");
}



void MaxDigitWord()
{
    int MaxNumber = 0;
    int ThisWordNumberOfDigits = 0;
    int MaxNumberIndex = 0;
    for (int word = 0; word < wordsFromUser.Length; word++)
    {
        for (int Char = 0; Char < wordsFromUser[word].Length; Char++)
        {
            if (char.IsNumber(wordsFromUser[word][Char]))
            {
                ThisWordNumberOfDigits++;
            }
        }
        if (ThisWordNumberOfDigits > MaxNumber)
        {
            MaxNumber = ThisWordNumberOfDigits;
            MaxNumberIndex = word;
        }
    }
    Console.WriteLine($"Word that contains max numbers is: {wordsFromUser[MaxNumberIndex]}");
}



Console.ReadLine();
