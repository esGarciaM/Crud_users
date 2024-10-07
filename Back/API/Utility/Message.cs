using Microsoft.AspNetCore.Mvc;
namespace API.Utility
{
    public class Message : ControllerBase
    {
        public string message = "success!";
        public bool error  = false;
        public List<string> Errors = new List<string>();
        public Message() {}
        public Message(string msg) {
            message = msg;
        }
        public void SetError(string msg) {
            error = true;
            message = msg;
        }
        public void AddError(string msg)
        {
            error = true;
            Errors.Add(msg);
            if (message == "success!") {
                message = "Fail!";
            }
        }
        public void EvaluateInt(int result, string msg) {
            if (result < 1) {
                this.AddError(msg);
            }
        }
        public IActionResult ActionResult() {
            ResponseMessage _rm = new ResponseMessage
            {
                error = error,
                message = message,
                Errors = Errors
            };

            if (error)
            {
                return BadRequest(_rm);
            }
            else
            {
                return Ok(_rm);
            }
        }

        public class ResponseMessage{
            public string message { get; set; }
            public bool error { get; set; }
            public List<string> Errors { get; set; }
        }



    }
}
