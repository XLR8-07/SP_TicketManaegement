using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.Repositories
{
    public class UserRepository
    {
        public IEnumerable<User> ReadAll()
        {
            return LoadData();
        }

        private List<User> LoadData()
        {
            var dataString = File.ReadAllText("E:\\A C A D E M I C\\IUT SWE\\SEM 5\\CSE     4539         SERVER PROGRAMMING\\L A B\\TicketManagement\\WebApplication1\\Data\\User.json");
            return JsonConvert.DeserializeObject<List<User>>(dataString);
        }

        internal User Read(Guid id)
        {
            var users = LoadData();
            return users.Find(user => user.ID == id);
        }

        internal void Create(User user)
        {
            user.ID = Guid.NewGuid();
            var users = LoadData();
            users.Add(user);
            SaveData(users);

        }

        internal void Update(Guid id, User user)
        {
            var users = LoadData();
            var userToUpdate = users.Find(user => user.ID == id);
            userToUpdate.UserName = user.UserName;
            userToUpdate.PhoneNo = user.PhoneNo;
            SaveData(users);
        }

        internal void Delete(Guid id)
        {
            var users = LoadData();
            var usertoRemove = users.Find(user => user.ID == id);
            users.Remove(usertoRemove);
            SaveData(users);
        }

        private void SaveData(List<User> data)
        {
            var dataString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("E:\\A C A D E M I C\\IUT SWE\\SEM 5\\CSE     4539         SERVER PROGRAMMING\\L A B\\TicketManagement\\WebApplication1\\Data\\User.json", dataString);
        }
    }
}
