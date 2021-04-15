using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkPlayground
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchmarks
    {
        private const string SampleDateTime = "2021-04-15T00:20:53Z";
        private static readonly DateParser Parser = new DateParser();

        [Benchmark]
        public void ParseUsingDateTimeParser()
        {
            Parser.UsingDateTimeParser(SampleDateTime);
        }

        [Benchmark]
        public void ParseUsingStringSplitThenIntParse() 
        {
            Parser.UsingStringSplitThenIntParse(SampleDateTime);
        }
        [Benchmark]
        public void ParseUsingSubstringThenIntParse() 
        {
            Parser.UsingSubstringThenIntParse(SampleDateTime);
        }
        [Benchmark]
        public void ParseUsingReadOnlySpan() 
        {
            Parser.UsingSpan(SampleDateTime);
        }
        [Benchmark]
        public void ParseUsingSpanAndManualConversion() 
        {
            Parser.UsingSpanAndManualConversion(SampleDateTime);
        }
    }
}
