using Humanizer; 

namespace System;

public static class StringExtensions
{
    public static string ToLowerSnakeCase(this string word)
    {
        var underscoredWord = word.Humanize().Underscore();
        return underscoredWord.Hyphenate();
    }
}