using lab6_RESTful.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace lab6_RESTful.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturer { get; set; } = null!;
        public DbSet<Model> Model { get; set; } = null!;
        public DbSet<Vehicle_Category> Vehicle_Category { get; set; } = null!;
        public DbSet<Vehicle> Vehicle { get; set; } = null!;
        public DbSet<Customer> Customer { get; set; } = null!;
        public DbSet<Booking_Status> Booking_Status { get; set; } = null!;
        public DbSet<Booking> Booking { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedManufacturerData(modelBuilder);
            SeedModelData(modelBuilder);
            SeedVehicle_CategoryData(modelBuilder);
            SeedVehicleData(modelBuilder);
            SeedCustomerData(modelBuilder);
            SeedBooking_StatusData(modelBuilder);
            SeedBookingData(modelBuilder);
        }

        private void SeedManufacturerData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().HasKey(e => e.manufacturer_code);

            // Seed data for the Manufacturer table
            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { manufacturer_code = "0000000001", manufacturer_name = "Toyota", manufacturer_details = "Japanese multinational automotive manufacturer known for reliable and fuel-efficient vehicles." },
                new Manufacturer { manufacturer_code = "0000000002", manufacturer_name = "Ford", manufacturer_details = "American multinational automaker with a wide range of vehicles, including trucks and SUVs." },
                new Manufacturer { manufacturer_code = "0000000003", manufacturer_name = "BMW", manufacturer_details = "German luxury automobile manufacturer with a focus on performance and elegance." },
                new Manufacturer { manufacturer_code = "0000000004", manufacturer_name = "Hyundai", manufacturer_details = "South Korean automaker producing a diverse range of vehicles, including sedans and SUVs." },
                new Manufacturer { manufacturer_code = "0000000005", manufacturer_name = "Ferrari", manufacturer_details = "Italian luxury sports car manufacturer synonymous with high-performance and exclusivity." }
            );
        }

        private void SeedModelData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().HasKey(e => e.model_code);

            // Seed data for the Model table
            modelBuilder.Entity<Model>().HasData(
                new Model { model_code = "0000000001", daily_hire_rate = 50.00, model_name = "Camry" },
                new Model { model_code = "0000000002", daily_hire_rate = 60.00, model_name = "F-150" },
                new Model { model_code = "0000000003", daily_hire_rate = 80.00, model_name = "X5" },
                new Model { model_code = "0000000004", daily_hire_rate = 40.00, model_name = "Elantra" },
                new Model { model_code = "0000000005", daily_hire_rate = 300.00, model_name = "488 GTB" }
            );
        }

        private void SeedVehicle_CategoryData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle_Category>().HasKey(e => e.vegicle_category_code);

            // Seed data for the Vehicle_Category table
            modelBuilder.Entity<Vehicle_Category>().HasData(
                new Vehicle_Category { vegicle_category_code = "00001", vegicle_category_description = "Sedan" },
                new Vehicle_Category { vegicle_category_code = "00002", vegicle_category_description = "Truck" },
                new Vehicle_Category { vegicle_category_code = "00003", vegicle_category_description = "SUV" },
                new Vehicle_Category { vegicle_category_code = "00004", vegicle_category_description = "Compact" },
                new Vehicle_Category { vegicle_category_code = "00005", vegicle_category_description = "Sports Car" }
            );
        }

        private void SeedVehicleData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasKey(e => e.reg_number);

            // Seed data for the Vehicle table
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { reg_number = "ABC123", ManufacturerId = "0000000001", ModelId = "0000000001", Vehicle_CategoryId = "00001", current_mileage = 50000, date_mot_due = new DateTime(2023, 12, 31) },
                new Vehicle { reg_number = "XYZ789", ManufacturerId = "0000000002", ModelId = "0000000002", Vehicle_CategoryId = "00002", current_mileage = 75000, date_mot_due = new DateTime(2024, 6, 30) },
                new Vehicle { reg_number = "DEF456", ManufacturerId = "0000000003", ModelId = "0000000003", Vehicle_CategoryId = "00003", current_mileage = 60000, date_mot_due = new DateTime(2024, 3, 15) },
                new Vehicle { reg_number = "GHI789", ManufacturerId = "0000000004", ModelId = "0000000004", Vehicle_CategoryId = "00004", current_mileage = 40000, date_mot_due = new DateTime(2023, 11, 15) },
                new Vehicle { reg_number = "JKL012", ManufacturerId = "0000000005", ModelId = "0000000005", Vehicle_CategoryId = "00005", current_mileage = 20000, date_mot_due = new DateTime(2024, 9, 1) }
            );
        }

        private void SeedCustomerData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(e => e.customer_id);

            // Seed data for the Customer table
            modelBuilder.Entity<Customer>().HasData(
                new Customer { customer_id = 1, customer_name = "John Doe", customer_details = "Regular customer with a long history of renting vehicles.", gender = "M", customer_email = "john.doe@example.com", customer_phone = "+1 123-456-7890", customer_address = "123 Main St", customer_country = "USA", town = "Anytown", county = "Anycounty" },
                new Customer { customer_id = 2, customer_name = "Jane Smith", customer_details = "Frequent business traveler in need of reliable transportation.", gender = "F", customer_email = "jane.smith@example.com", customer_phone = "+1 987-654-3210", customer_address = "456 Oak St", customer_country = "USA", town = "Businessville", county = "Business County" },
                new Customer { customer_id = 3, customer_name = "Sam Johnson", customer_details = "Adventure enthusiast exploring various locations.", gender = "M", customer_email = "sam.johnson@example.com", customer_phone = "+1 555-123-4567", customer_address = "789 Pine St", customer_country = "Canada", town = "Adventuretown", county = "Adventure County" },
                new Customer { customer_id = 4, customer_name = "Emily Davis", customer_details = "City dweller looking for a compact and fuel-efficient vehicle.", gender = "F", customer_email = "emily.davis@example.com", customer_phone = "+1 111-222-3333", customer_address = "987 Elm St", customer_country = "USA", town = "Cityville", county = "City County" },
                new Customer { customer_id = 5, customer_name = "Alex Turner", customer_details = "Luxury car enthusiast with a passion for sports cars.", gender = "M", customer_email = "alex.turner@example.com", customer_phone = "+1 444-555-6666", customer_address = "654 Birch St", customer_country = "UK", town = "Luxurytown", county = "Luxury County" }
            );
        }

        private void SeedBooking_StatusData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking_Status>().HasKey(e => e.booking_status_code);

            // Seed data for the Booking_Status table
            modelBuilder.Entity<Booking_Status>().HasData(
                new Booking_Status { booking_status_code = "001", booking_status_description = "Pending Approval" },
                new Booking_Status { booking_status_code = "002", booking_status_description = "Approved" },
                new Booking_Status { booking_status_code = "003", booking_status_description = "Cancelled" },
                new Booking_Status { booking_status_code = "004", booking_status_description = "Completed" },
                new Booking_Status { booking_status_code = "005", booking_status_description = "Refunded" }
            );
        }

        private void SeedBookingData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasKey(e => e.booking_id);

            // Seed data for the Booking table
            modelBuilder.Entity<Booking>().HasData(
                new Booking { booking_id = 1, Booking_StatusId = "001", CustomerId = 1, VehicleId = "ABC123", date_from = new DateTime(2023, 11, 01), date_to = new DateTime(2023, 11, 05), confirmation_letter_sent_yn = "Y", payment_recived_yn = "N" },
                new Booking { booking_id = 2, Booking_StatusId = "002", CustomerId = 2, VehicleId = "XYZ789", date_from = new DateTime(2023, 12, 10), date_to = new DateTime(2023, 12, 15), confirmation_letter_sent_yn = "Y", payment_recived_yn = "Y" },
                new Booking { booking_id = 3, Booking_StatusId = "003", CustomerId = 3, VehicleId = "DEF456", date_from = new DateTime(2024, 01, 20), date_to = new DateTime(2024, 01, 25), confirmation_letter_sent_yn = "N", payment_recived_yn = "N" },
                new Booking { booking_id = 4, Booking_StatusId = "004", CustomerId = 4, VehicleId = "GHI789", date_from = new DateTime(2024, 02, 15), date_to = new DateTime(2024, 02, 20), confirmation_letter_sent_yn = "Y", payment_recived_yn = "Y" },
                new Booking { booking_id = 5, Booking_StatusId = "005", CustomerId = 5, VehicleId = "JKL012", date_from = new DateTime(2024, 03, 05), date_to = new DateTime(2024, 03, 10), confirmation_letter_sent_yn = "Y", payment_recived_yn = "N" }
            );
        }
    }
}

