using FaceRecognizer.Common;
using FaceRecognizer.Common.Enums;
using System.Collections.Generic;
using System.Linq;

namespace FaceRecognizer.Models
{
    public class LogicResult<TOutput> where TOutput : LogicOutput
    {
        public TOutput Output { get; set; }
        public List<Error> ErrorList { get; set; } = new List<Error>();
        public bool IsSuccess => ErrorList.All(e => e.StatusCode == ErrorHttpStatus.WARNING);
    }
}
