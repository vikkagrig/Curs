using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PCMob
{
    public class Reposit
    {
        public SQLiteConnection database;
        public Reposit(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Entrant>();
            database.CreateTable<User>();
            database.CreateTable<List>();
            database.CreateTable<Faculty>();
            database.CreateTable<Spaciality>();
        }
        public IEnumerable<Entrant> GetItems()
        {
            return database.Table<Entrant>().ToList();
        }
        public Entrant GetItem(int id)
        {
            return database.Get<Entrant>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Entrant>(id);
        }
        public int SaveItem(Entrant item)
        {
            if (item.IDEntrant != 0)
            {
                database.Update(item);
                return item.IDEntrant;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public IEnumerable<User> UGetItems()
        {
            return database.Table<User>().ToList();
        }
        public User UGetItem(int id)
        {
            return database.Get<User>(id);
        }
        public int UDeleteItem(int id)
        {
            return database.Delete<User>(id);
        }
        public int USaveItem(User item)
        {
            if (item.IDUser != 0)
            {
                database.Update(item);
                return item.IDUser;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public IEnumerable<Faculty> FGetItems()
        {
            return database.Table<Faculty>().ToList();
        }
        public Faculty FGetItem(int id)
        {
            return database.Get<Faculty>(id);
        }
        public int FDeleteItem(int id)
        {
            return database.Delete<Faculty>(id);
        }
        public int FSaveItem(Faculty item)
        {
            if (item.IDFac != 0)
            {
                database.Update(item);
                return item.IDFac;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public IEnumerable<Spaciality> SGetItems()
        {
            return database.Table<Spaciality>().ToList();
        }
        public Spaciality SGetItem(int id)
        {
            return database.Get<Spaciality>(id);
        }
        public int SDeleteItem(int id)
        {
            return database.Delete<Spaciality>(id);
        }
        public int SSaveItem(Spaciality item)
        {
            if (item.IDSpec != 0)
            {
                database.Update(item);
                return item.IDSpec;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public IEnumerable<List> LGetItems()
        {
            return database.Table<List>().ToList();
        }
        public List LGetItem(int id)
        {
            return database.Get<List>(id);
        }
        public int LDeleteItem(int id)
        {
            return database.Delete<List>(id);
        }
        public int LSaveItem(List item)
        {
            if (item.IDList != 0)
            {
                database.Update(item);
                return item.IDList;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
