using PNotes.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PNotes.Data
{
    class SQLiteHelper
    {
        static object locker = new object();
        SQLiteConnection database;

        public SQLiteHelper()
        {
            //create database istance
            //database = GetConnection();
            // create the tables  
            database.CreateTable<UserInfo>();
            ///create bookinDetail table
            database.CreateTable<ComplaintInfo>();
        }

        public SQLiteHelper(string dbPath)
        {
            //create database istance
            database = new SQLiteConnection(dbPath);
            // create the tables  
            database.CreateTable<UserInfo>();

            ///create bookinDetail table
            database.CreateTable<ComplaintInfo>();
        }

       

        public UserInfo GetItem(string userName)
        {
            lock (locker)
            {
                return database.Table<UserInfo>().FirstOrDefault(x => x.Name == userName);
            }
        }

        public UserInfo GetItemUserAthentication(string userEmail, string usersPassward)
        {
            lock (locker)
            {
                return database.Table<UserInfo>().FirstOrDefault(x => x.Email == userEmail && x.Password == usersPassward);
            }
        }

        //sdave new user in dabase
        public int SaveUser(UserInfo item)
        {
            lock (locker)
            {
                if (item.UserID != 0)
                {
                    //Update Item  
                    database.Update(item);
                    return item.UserID;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }

        //save new booking in database


        public int SaveNewUserComplaint(ComplaintInfo newUC)
        {
            lock (locker)
            {
                if (newUC.ComplaintID != 0)
                {
                    //Update Item  
                    database.Update(newUC);
                    return newUC.ComplaintID;
                }
                else
                {
                    //Insert item  
                    return database.Insert(newUC);
                }
            }
        }

        public IEnumerable<ComplaintInfo> GetComplaintAsync()
        {
            lock (locker)
            {
                //return database.Table<UserDetail>().FirstOrDefault(i-> select i).ToString();
                return (from i in database.Table<ComplaintInfo>() select i).ToList();
            }
        }


        //delete item
        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<UserInfo>(id);
            }
        }

    }
}
