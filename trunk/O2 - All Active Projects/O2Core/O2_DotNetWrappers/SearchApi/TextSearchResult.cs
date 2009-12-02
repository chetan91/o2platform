using System;
using System.Text.RegularExpressions;

namespace O2.DotNetWrappers.SearchApi
{
    public class TextSearchResult
    {
        public int iLength;
        public int iLineNumber;
        public int iPosition;
        public Regex rRegExUsed;
        public String sFile;
        public String sMatchLine;
        public String sMatchText;

        public TextSearchResult(Regex rRegExUsed, String sMatchText, String sMatchLine, String sFile,
                                int iLineNumber, int iPosition, int iLength)
        {
            this.rRegExUsed = rRegExUsed;
            this.sMatchText = sMatchText;
            this.sMatchLine = sMatchLine;
            this.sFile = sFile;
            this.iLineNumber = iLineNumber;
            this.iPosition = iPosition;
            this.iLength = iLength;
        }
    }
}