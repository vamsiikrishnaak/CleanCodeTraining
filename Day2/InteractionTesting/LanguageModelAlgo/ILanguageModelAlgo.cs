﻿namespace LanguageModelAlgorithms;

public interface ILanguageModelAlgo {
    public String predictUsingMonogram(String word);

    public String predictUsingBigram(String word) ;
}
