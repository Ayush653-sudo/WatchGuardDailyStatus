using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{        public class VideoEventArgs:EventArgs
    {
        public Video Video { get; set; }
    } 
    public class VideoEncoder 
    {
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args)//or VideoEncodedEventHandler(object source, VideoEventArgs args);
        //public event VideoEncodedEventHandler VideoEncoded;
        public event EventHandler<VideoEventArgs> VideoEncoded;
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
                //Console.WriteLine("in onVideoEncoded");
                VideoEncoded(this,new VideoEventArgs() { Video=video});
            }
        }
    }
}
