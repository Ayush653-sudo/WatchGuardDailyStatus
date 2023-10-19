using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{           
    public class VideoEncoder 
    {
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);
        public event VideoEncodedEventHandler VideoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video..");
            Thread.Sleep(1000);
            onVideoEncoded();
        }
        protected void onVideoEncoded()
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this,EventArgs.Empty);
            }
        }
    }
}
