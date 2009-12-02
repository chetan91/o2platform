using System;

namespace O2.DotNetWrappers.DotNet
{
    public class O2Timer
    {
        private String description;
        private DateTime dtStart;
        public string timeSpanString = "";

        public O2Timer() // automatically start when we don't provide a description
        {
            start();
        }

        public O2Timer(String _description)
        {
            description = _description;
        }

        public O2Timer start()
        {
            dtStart = DateTime.Now;
            return this; // do this so that we can create this object and start it one line
        }

        /*public O2Timer start(String _description)
            {
                description = _description;
                return start();
            }*/

        public string stop()
        {
            return stop(true);
        }

        public string stop(bool showValueOnLog)
        {
            TimeSpan tsTime = DateTime.Now - dtStart;
            timeSpanString = getTimeSpanString(tsTime);
            //   if (description == "")
            //       return timeSpanString;
            if (showValueOnLog)
                DI.log.debug(getTimeSpanString(tsTime));
            return timeSpanString;
        }

        public string getTimeSpanString(TimeSpan tsTime)
        {
            if (description != "")
                description += " in ";
            if (tsTime.Hours > 0)
                return String.Format("{0}{1}h:{2}m:{3}s:{4}ms", description, tsTime.Hours, tsTime.Minutes,
                                     tsTime.Seconds, tsTime.Milliseconds);
            if (tsTime.Minutes > 0)
                return String.Format("{0}{1}m:{2}s:{3}ms", description, tsTime.Minutes, tsTime.Seconds,
                                     tsTime.Milliseconds);
            return String.Format("{0}{1}s:{2}ms", description, tsTime.Seconds, tsTime.Milliseconds);
        }
    }
}