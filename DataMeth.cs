using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiadcode
{
    class DataMeth
    {
        public DataMeth()
        {
            string ToCon = "";
            ToCon = File.ReadAllText(@"C:\Users\Max\source\repos\wiadcode\wiadcode\Data.json");
            dataUsersList = JsonConvert.DeserializeObject<List<DataUser>>(ToCon);
        }
        public List<DataUser> dataUsersList = new List<DataUser>();
        private static int thisID = 1;

        public DataUser StartUser() {
            DataUser FirstUser = (DataUser)dataUsersList.Where(a => a.ID.Equals(1)).FirstOrDefault();
            return FirstUser;
        }

        public DataUser GiveNextUser(string mess)
        {
            DataUser ThisUser = dataUsersList.Where(a => a.ID.Equals(thisID)).FirstOrDefault();
            ThisUser.Message = mess;

            string ToFile = JsonConvert.SerializeObject(dataUsersList);
            File.WriteAllText(@"C:\Users\Max\source\repos\wiadcode\wiadcode\Data.json", ToFile);

            if (thisID == 17) {
                var Nuller = dataUsersList.Where(a => a.ID.Equals(17)).FirstOrDefault();
                return Nuller;
            }
            int NowID = thisID;
            thisID++;
            DataUser NextUser = dataUsersList.Where(a => a.ID.Equals(NowID + 1)).FirstOrDefault();
            return NextUser;
        }

        public DataUser GiveLastUser(string mess)
        {
            DataUser ThisUser = dataUsersList.Where(a => a.ID.Equals(thisID)).FirstOrDefault();
            ThisUser.Message = mess;

            string ToFile = JsonConvert.SerializeObject(dataUsersList);
            File.WriteAllText(@"C:\Users\Max\source\repos\wiadcode\wiadcode\Data.json", ToFile);

            if (thisID == 1)
            {
                DataUser Nuller = dataUsersList.Where(a => a.ID.Equals(1)).FirstOrDefault();
                return Nuller;
            }
            int NowID = thisID;
            thisID--;
            DataUser NextUser = dataUsersList.Where(a => a.ID.Equals(NowID - 1)).FirstOrDefault();
            return NextUser;
        }

        public void SafeData(string mess) {
            DataUser ThisUser = dataUsersList.Where(a => a.ID.Equals(thisID)).FirstOrDefault();
            ThisUser.Message = mess;

            string ToFile = JsonConvert.SerializeObject(dataUsersList);
            File.WriteAllText(@"C:\Users\Max\source\repos\wiadcode\wiadcode\Data.json", ToFile);
        }
    }
}
