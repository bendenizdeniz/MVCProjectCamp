﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
        void MessageAddBL(Message message);
        Message GetByIDBL(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        void MessageRead(Message message);
        void MessageNotRead(Message message);
    }
}
