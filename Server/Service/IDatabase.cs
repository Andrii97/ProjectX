using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDatabase" in both code and config file together.
    [ServiceContract]
    public interface IDatabase
    {
        [OperationContract]
        void BDOpen();
        [OperationContract]
        void BDClose();
        [OperationContract]
        bool Authorization(string @name, string @password);
        [OperationContract]
        bool AddPerson(string @name, string @password);
        [OperationContract]
        Statistic ShowInfo(string name);
        [OperationContract]
        bool Update(string Name, bool win);
    }
}
