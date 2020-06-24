using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    /// <summary>
    /// Refactor the code below to make it more object oriented and remove the switch statement.
    /// The likely result of this will end up with a boolean property on the service class
    /// 
    /// You are permitted to write as many additional classes, methods or code as you see necessary.
    /// </summary>
    public class Question3
    {
        private Service _service;

        private Question3(Service service)
        {
            _service = service;
        }

        public string GetString(string theInput)
        {
            bool hasPermission = _service.AskForPermission();
            return _service.FormatString(hasPermission, theInput);
        }

        private class Service
        {
            internal bool AskForPermission()
            {
                throw new NotImplementedException();
            }

            internal string FormatString(bool hasPermission, string theInput) =>
                hasPermission ? string.Format("{0} {1}", theInput, theInput) : "error";
        }
    }
}
