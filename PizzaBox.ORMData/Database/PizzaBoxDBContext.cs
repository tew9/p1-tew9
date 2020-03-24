using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.ORMData.Database
{
    public class PizzaBoxDBContext : DbContext
    {
        //Create table for stores.
        public DbSet<Store> Stores { get; set; }

        public DbSet<Pizza> Pizzas { get; set; }

        //public DbSet<Orders> Orders { get; set;}
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        // public DbSet<Size> Sizes { get; set; }

        //establish the connection
        #region Connection.
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345;");
        }
        #endregion

        //creating modeling entity(mapper).
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //setup mapping keys, keys that will be used to uniqely map c# object to the correct db table and viceversa
            builder.Entity<User>().HasKey( user => user.Id);
            builder.Entity<Order>().HasKey( order => order.OrderId);
            // builder.Entity<Size>().HasKey( size => size.Id);
            builder.Entity<Pizza>().HasKey( pizza => pizza.Id);
            builder.Entity<Store>().HasKey( store => store.Id);
            builder.Entity<PizzaOrder>().HasKey(po => new {po.OrderId, po.Id});
            builder.Entity<PizzaStore>().HasKey(ps => new {ps.Id, ps.StoreId});
          

            //Navigational Relationships.
            builder.Entity<Order>().HasMany(op => op.PizzaOrders).WithOne(o => o.Order).HasForeignKey(o => o.OrderId);
            builder.Entity<Pizza>().HasMany(po => po.PizzaOrders).WithOne(p => p.Pizza).HasForeignKey(p => p.Id); 
            builder.Entity<Store>().HasMany(sp => sp.PizzaStore).WithOne(s => s.Store).HasForeignKey(s => s.StoreId);
            builder.Entity<Pizza>().HasMany(ps => ps.PizzaStores).WithOne(p => p.pizza).HasForeignKey(p => p.Id);
            
            //Seeding the data
            builder.Entity<User>().HasData(new User[]
            {
                new User() {Id = 1, Name = "tango", lastname = "Tew", username = "tango", password = "123", 
                            email = "tango@gmail.com",type = "user"},
                new User() {Id = 4, Name = "Andrew", lastname = "AGatep", username = "drew", password = "123", 
                            email = "tango@gmail.com",type = "user"},
                new User() {Id = 2, Name = "Mark", lastname = "John", username = "mark", password = "456",
                            email = "mark@gmail.com", type = "store"},
                new User() {Id = 3, Name = "Dr. Frank", lastname = "Fred", username = "fred", password = "123",
                            email = "fred@gmail.com", type = "store"},
                new User() {Id = 5, Name = "William", lastname = "John", username = "john", password = "123",
                            email = "john@gmail.com", type = "store"}
            });
            
            builder.Entity<Store>().HasData(new Store[]
            {
                new Store(){Id=1, Name="Dominos", location="123 bcd st, Arlington tx", Manager = "fred"},
                new Store() {Id=2, Name="Pizza Hut", location="456 DeF, Arlington Tx", Manager = "john"},
                new Store() {Id=3, Name="Papa John's", location="456 DeF, Arlington Tx", Manager = "mark"}
            });

           //Seed data for the conjunction table because the store and pizza are pre-defined
            builder.Entity<PizzaStore>().HasData(new PizzaStore[]
            {
                new PizzaStore(){Id = 1,  StoreId = 1, Inventory = 5},
                new PizzaStore(){Id = 2,  StoreId = 1, Inventory = 10},
                new PizzaStore(){Id = 3,  StoreId = 1, Inventory = 20},
                new PizzaStore(){Id = 4,  StoreId = 1, Inventory = 6},
                 new PizzaStore(){Id = 1,  StoreId = 2, Inventory = 5},
                new PizzaStore(){Id = 2,  StoreId = 2, Inventory = 10},
                new PizzaStore(){Id = 3,  StoreId = 2, Inventory = 20},
                new PizzaStore(){Id = 4,  StoreId = 2, Inventory = 6},
                new PizzaStore(){Id = 5,  StoreId = 3, Inventory = 6},
                new PizzaStore(){Id = 6,  StoreId = 3, Inventory = 4},
                new PizzaStore(){Id = 1,  StoreId = 3, Inventory = 7},
                new PizzaStore(){Id = 2,  StoreId = 3, Inventory = 6}
            });

            builder.Entity<Pizza>().HasData(new Pizza[]
            {
                new Pizza(){Id = 5, Name = "Chicago Deep Dish", Price = 18.50M},
                new Pizza(){Id = 7, Name = "Vegie Pizza", Price = 13.5M},
                new Pizza(){Id =2, Name = "Chickens Pizza", Price = 14.00M},
                new Pizza(){Id = 3, Name = "Pepperoni", Price = 12.00M},
                new Pizza(){Id = 4, Name = "Cheese Pizza", Price = 12.25M},
                new Pizza(){Id = 1, Name = "The Original Neapolitan", Price = 16.25M},
                new Pizza(){Id = 6, Name = "California Style", Price = 15.50M}
               
            });

        //     builder.Entity<Size>().HasData(new Size[]
        //     {
        //         new Size(){Id = 1, Name = "Large", Price = 13.75M},
        //         new Size(){Id = 2, Name = "Medium", Price = 10.50M},
        //         new Size(){Id = 3, Name = "Small", Price = 8.25M}
        //     });
        //   }
            }
        }
    }
