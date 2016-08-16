using System.Web.Http;
using Time.Models;
namespace Time.Controllers
{
    public class TimeController : ApiController
    {
        
        public TimeData GetTime()
        {
           var time = GlobalProxy.TimeManager.CurrentTime;
            return new TimeData
            {
                Hour = time.Hour,
                Minutes = time.Minute,
                Seconds = time.Second
            };
        }
        [HttpGet]
        public void AddHour()
        {
            GlobalProxy.TimeManager.AddHour();
        }
        [HttpGet]
        public void SubtractHour()
        {
            GlobalProxy.TimeManager.SubtractHour();
        }
    }
}
