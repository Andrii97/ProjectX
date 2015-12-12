using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Database" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Database.svc or Database.svc.cs at the Solution Explorer and start debugging.
    public class Database : IDatabase
    {
        public void BDOpen()
        {
            BD.BDOpen();
        }

        public void BDClose()
        {
            BD.BDClose();
        }


        public bool Authorization(string @name, string @password)
        {
            return BD.Authorization(@name, @password);
        }

        public bool AddPerson(string @name, string @password)
        {
            return BD.AddPerson(@name, @password);
        }

        public Statistic ShowInfo(string name)
        {
            return BD.ShowInfo(name);
        }

        public bool Update(string Name, bool win)
        {
            return BD.Update(Name, win);
        }

    }

}
