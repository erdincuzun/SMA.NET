# SMA.NET
This project is library for evaluating string matching algorithms.
## USAGE
Search all positions:
```csharp
List<int> result_int = ESMAJ.SearchAlgoritms.Search(pattern, source_text, ESMAJ.SearchAlgoritms.SearchAlgorithm.AlgorithmName);
//patterns and source_text are string variables.
//AlgorithmName:
public enum SearchAlgorithm { ApostolicoCrochemore, ApostolicoGiancarlo, BackwardNondeterministicDawgMatching,
            BackwardOracleMatching, BerryRavindran, BoyerMoore, BruteForce,
            Colussi, DeterministicFiniteAutomaton, ForwardDawgMatching, GalilGiancarlo, Horspool,
            KarpRabin, KMPSkipSearch, KnuthMorrisPratt, MaximalShift, MorrisPratt,
            NotSoNaive, OptimalMismatch, QuickSearch, Raita, ReverseColussi, ReverseFactor, ShiftOr, Simon,
            SkipSearch, Smith, StringMatchingonOrderedAlphabets, TunedBoyerMoore,
            TurboBM, TurboReverseFactor, TwoWay, ZhuTakaoka, NET_IndexOf, NET_IndexOf_Ordinal
        };
```
Find first and break;
```csharp
int res = ESMAJ.SearchAlgoritms.Search(tagname, source, startIndex, ESMAJ.SearchAlgoritms.SearchAlgorithm.AlgorithmName);
//startIndex is an integer value for reducing the search time of an algorithm.
```

# Publications
<b>Comparison of string matching algorithms in web documents. </b> Buluş, H., N.; Uzun, E.; and Doruk, A. In International Scientific Conference’2017 (UNITECH’17), volume 2, pages 279-282, 2017. 

<a href="https://www.e-adys.com/yayinlar/" target="_blank">Click for bibtex, downloads, all publications...</a>
