using Events;

namespace EventAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder();
            var mailService=new MailService();
           videoEncoder.VideoEncoded+= mailService.onVideoEncoded;
            
            videoEncoder.Encode(video);
        }
    }
    public class MailService
    {
        public void onVideoEncoded(object source,EventArgs e)
        {
            Console.WriteLine("MailService: Sending an email...");
            Thread.Sleep(1000);
        }
    }
}