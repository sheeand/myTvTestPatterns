using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myTvTestPatterns.UserObjects
{
    public class TextPool
    {
        private string _BasicInstructions = "<h2>Basic Download Instructions</h2><br /><p>Please note: This can be a very lengthy process, depending on the speed of your internet connection. The size of the compressed color bar file is about 120 megabytes, and the compressed myTvTestDisc file is about 180 megabytes.</p><ol><li>Allow the compressed file to download.</li><li>When the download is complete, select &quot;Run&quot;.</li><li>A WinZip Self-Extractor will pop up and prompt you to &quot;Unzip to folder&quot;. Browse to the Desktop and select &quot;OK&quot;. Then select &quot;Unzip&quot;.</li><li>Depending on the speed of you computer, the length of time required to unzip the compressed file may be several minutes.</li><li>When you are prompted that the extraction (unzip process) is complete, select &quot;OK&quot; and &quot;Close&quot;.</li><li>Open a DVD burning application and select the new .iso file that was saved on the Desktop. Burn your new DVD!</li></ol>";
        public string BasicInstructions
        {
            get { return _BasicInstructions; }
        }
    }
}