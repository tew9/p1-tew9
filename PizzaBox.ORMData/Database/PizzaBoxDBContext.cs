using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.ORMData.Database
{
    public class DBContexts : DbContext
    {
        //Create table for stores.
        public DbSet<Store> Stores { get; set; }

        public DbSet<Pizza> Pizzas { get; set; }

        //public DbSet<Orders> Orders { get; set;}
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Size> Sizes { get; set; }

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
            builder.Entity<Order>().HasKey( order => order.orderId);
            builder.Entity<Size>().HasKey( size => size.Id);
            builder.Entity<Pizza>().HasKey( pizza => pizza.Id);
            builder.Entity<Store>().HasKey( store => store.Id);
            builder.Entity<PizzaOrder>().HasKey(p => new { p.Id, p.OrderId});
            builder.Entity<PizzaStore>().HasKey(s => new { s.StoreId, s.Id});

            //Navigational Relationships.
            builder.Entity<Order>().HasMany(po => po.PizzaOrders).WithOne(o => o.Order).HasForeignKey(o => o.OrderId);
            builder.Entity<Size>().HasMany(sp => sp.PizzaSizes).WithOne(s => s.Size).HasForeignKey(s => s.SizeId);
            builder.Entity<Pizza>().HasMany(ps => ps.PizzaSizes).WithOne(p => p.Pizza).HasForeignKey(p => p.PizzaId);
            //read as Pizza entity has many Pizzaorders relating with one pizza with PizzaId as a foreign key in PizzaOrders
            builder.Entity<Pizza>().HasMany(po => po.PizzaOrders).WithOne(p => p.Pizza).HasForeignKey(p => p.Id); 
            builder.Entity<Store>().HasMany(sp => sp.PizzaStore).WithOne(s => s.Store).HasForeignKey(s => s.StoreId);
            builder.Entity<Pizza>().HasMany(ps => ps.PizzaStores).WithOne(p => p.pizza).HasForeignKey(p => p.Id);

            //Seeding the data
            builder.Entity<User>().HasData(new User[]
            {
                new User() {Id = 1, Name = "tango", lastname = "Tew", username = "tango", password = "123", 
                            email = "tango@gmail.com",type = "user"},
                new User() {Id = 2, Name = "Mark", lastname = "John", username = "mark", password = "456",
                            email = "mark@gmail.com", type = "store"},
                new User() {Id = 3, Name = "Dr. Frank", lastname = "Fred", username = "fred", password = "123",
                            email = "fred@gmail.com", type = "store"}
            });
            
            builder.Entity<Store>().HasData(new Store[]
            {
                new Store(){Id=1, Name="Dominos", location="123 bcd st, Arlington tx", UserId = 2},
                new Store() {Id=2, Name="Pizza Hut", location="456 DeF, Arlington Tx", UserId = 3}
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
                new PizzaStore(){Id = 4,  StoreId = 2, Inventory = 6}
            });

            builder.Entity<Pizza>().HasData(new Pizza[]
            {
                new Pizza(){Id = 1, Name = "Vegies"},
                new Pizza(){Id =2, Name = "Chickens Pizza"},
                new Pizza(){Id = 3, Name = "Pepperoni"},
                new Pizza(){Id = 4, Name = "Cheese Pizza"}
            });

            builder.Entity<PizzaSize>().HasData(new PizzaSize[]
            {
                new PizzaSize(){PizzaId = 1, SizeId = 1},
                new PizzaSize(){PizzaId = 1, SizeId = 2},
                new PizzaSize(){PizzaId = 1, SizeId = 3},
                new PizzaSize(){PizzaId = 2, SizeId = 1},
                new PizzaSize(){PizzaId = 2, SizeId = 2},
                new PizzaSize(){PizzaId = 2, SizeId = 3},
                new PizzaSize(){PizzaId = 3, SizeId = 1},
                new PizzaSize(){PizzaId = 3, SizeId = 2},
                new PizzaSize(){PizzaId = 3, SizeId = 3},
                new PizzaSize(){PizzaId = 4, SizeId = 1},
                new PizzaSize(){PizzaId = 4, SizeId = 2},
                new PizzaSize(){PizzaId = 4, SizeId = 3},
            });

            builder.Entity<Size>().HasData(new Size[]
            {
                new Size(){Id = 1, Name = "Large", Price = 13.75M},
                new Size(){Id = 2, Name = "Medium", Price = 10.50M},
                new Size(){Id = 3, Name = "Small", Price = 8.25M}
            });
         }
        }
    }
