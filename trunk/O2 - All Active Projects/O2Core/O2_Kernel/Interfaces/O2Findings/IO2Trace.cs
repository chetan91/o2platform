using System;
using System.Collections.Generic;

namespace O2.Kernel.Interfaces.O2Findings
{
    public interface IO2Trace
    {
        List<IO2Trace> childTraces { get; set; }
        string caller { get; set; }
        string clazz { get; set; }
        uint columnNumber { get; set; }
        string context { get; set; }
        string file { get; set; }
        uint lineNumber { get; set; }
        string method { get; set; }
        uint ordinal { get; set; }
        string signature { get; set; }
        uint taintPropagation { get; set; }
        List<String> text { get; set; }
        TraceType traceType { get; set; }
        uint argument { get; set; }
        uint direction { get; set; }                    
        string ToString();
    }

    [Serializable]
    public class KO2Trace : IO2Trace
    {
        public List<IO2Trace> childTraces { get; set; }
        public string caller { get; set; }
        public string clazz { get; set; }
        public uint columnNumber { get; set; }
        public string context { get; set; }
        public string file { get; set; }
        public uint lineNumber { get; set; }
        public string method { get; set; }
        public uint ordinal { get; set; }
        public string signature { get; set; }
        public uint taintPropagation { get; set; }
        public List<string> text { get; set; }
        public TraceType traceType { get; set; }
        public uint argument { get; set; }
        public uint direction { get; set; }

        public KO2Trace()
        {
            childTraces = new List<IO2Trace>();
            caller = "";
            clazz = "";
            context = "";
            file = "";
            method = "";
            signature = "";
            text = new List<string>();
            traceType = TraceType.Type_0;
        }
    }
}