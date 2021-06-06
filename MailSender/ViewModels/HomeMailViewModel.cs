using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.ViewModels
{
    public class HomeMailViewModel : HomeIndexViewModel
    {
        public string Topic { get; set; }
        public string Message { get; set; }
    }
}
