using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTrasfFile.sendClass
{
    public class SendController
    {
        public Send SelectSend(string shipping)
        {
            return new SendData().SelectSend(shipping);
        }

        public bool InsertSend(Send send)
        {
            return new SendData().InsertSend(send);
        }
        
        public List<Send> ListSends(string id)
        {
            return new SendData().ListSends(int.Parse(id));
        }

    }
}
