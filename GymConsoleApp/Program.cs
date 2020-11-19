using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymConsoleApp
{
    class Program
    {
        static Context context = new Context();

        static void Main(string[] args)
        {
            GetAllUsers();

            context.Dispose();
        }

        public static void AddTrainings()
        {
            Context context = new Context();
            context.Add(new Training { Name = "Circular", Date = new DateTime(2020, 09, 09) });
            context.Add(new Training { Name = "CX", Date = new DateTime(2020, 09, 15) });
            context.Add(new Training { Name = "Pilates", Date = new DateTime(2020, 10, 03) });
            context.Add(new Training { Name = "Box", Date = new DateTime(2020, 11, 11) });

            context.SaveChanges();
            context.Dispose();
        }

        public static void GetAllTrainings()
        {
            using (Context context = new Context())
            {

                List<Training> result = context.Trainings.ToList();
                result.ForEach(t => Console.WriteLine(t));
            }
        }

        public static void UpdateTracking()
        {
            List<Training> trainings = context.Trainings.ToList();
            Training update = trainings[1];
            update.Name = "CoreCX";
            context.SaveChanges();
        }

        public static void UpdateNoTracking()
        {
            Training update = new Training { TrainingId = 9, Name = "CORE CX" };
            context.Update(update);
            context.SaveChanges();
        }


        public static void AddUsers()
        {
            //int id = 1;
            //Training training = context.Trainings.Single(t => t.TrainingId == id);
            User user = new User
            {
                FirstName = "Pera",
                LastName = "Peric",
                Address = "Jove Ilica",
                TrainingId = 10
            };
            context.Add(user);
            context.Add(new User { FirstName = "Jelena", LastName= "Jelenic", Address ="Vojvode Stepe", TrainingId=8 });
            context.SaveChanges();
        }


        public static void UpdateUser()
        {
            User user = context.Users.Find(1);
            user.TrainingId = 8;
            context.SaveChanges();
        }

        public static void GetAllUsers()
        {
            List<User> users = context.Users.Include(u => u.Training).ToList();
            users.ForEach(u => Console.WriteLine(u));
        }


        public static void GetAllUsersWhere()
        {
            using (Context context = new Context())
            {
                List<User> result = context.Users.Where(u => u.LastName.Contains("ic")).ToList();
                result.ForEach(user => Console.WriteLine(user));
            }
        }

        public static void UpdateUsersTrainingTracking()
        {
            List<User> users = context.Users.Include(u => u.Training).ToList();
            User user = users[0];
            user.Training.Name = "Training 55";
            context.SaveChanges();
        }

        public static void UpdateUsersTrainingNoTracking()
        {
            List<User> users = context.Users.Include(u => u.Training).ToList();

            using (Context newcontext = new Context())
            {

                User user = users[0];
                user.Training.Name = "Training 55 No Tracking";
                newcontext.Update(user);
                newcontext.SaveChanges();
            }
        }


        public static void UpdateOnlyTrainingNoTracking()
        {
            List<User> users = context.Users.Include(u => u.Training).ToList();


            using (Context newcontext = new Context())
            {

                User user = users[0];
                user.Training.Name = "Training 55 No Tracking";
                newcontext.Attach(user);
                newcontext.Entry(user.Training).State = EntityState.Modified;
                newcontext.SaveChanges();

            }
        }

        public static void RemoveUserNoTracking()
        {
            List<User> users = context.Users.ToList();

            using (Context newcontext = new Context())
            {

                User user = users[2];
                newcontext.Remove(user);
                newcontext.SaveChanges();
            }
        }

        public static void RemoveUserTracking()
        {
            List<User> users = context.Users.ToList();

            using (Context newcontext = new Context())
            {

                User user = users[2];
                newcontext.Attach(user);
                newcontext.Remove(user);
                newcontext.Entry(user).State = EntityState.Deleted;
                newcontext.SaveChanges();
            }
        }


    }
}
