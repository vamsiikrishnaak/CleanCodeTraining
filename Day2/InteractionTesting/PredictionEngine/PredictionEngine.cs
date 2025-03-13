/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2025, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LanguageModelAlgorithms;



namespace PredictionEngine
{
    public class PredictionEngine
    {
        private ILanguageModelAlgo languageModelAlgo;

        public PredictionEngine(ILanguageModelAlgo algo)
        {
            this.languageModelAlgo = algo;
        }

        public string Predict(string inputPhrase)
        {
            string lastWord = inputPhrase.Trim().Split(' ').Last();
            if (inputPhrase.EndsWith(' '))
            {
                return languageModelAlgo.predictUsingBigram(lastWord);
            }
            return languageModelAlgo.predictUsingMonogram(lastWord);
        }
    }
}
