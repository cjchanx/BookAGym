using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using Webservice.Core;
using Webservice.DatabaseHelper;
using Webservice.Models;

namespace Webservice.Tests.DatabaseHelper
{
    [TestFixture]
    public class Booking_dbTests
    {

        // Class variables for testing
        Mock<DBContext> mock_context;
        DataTable mock_bookings_table;

        [SetUp]
        public void Setup()
        {
            mock_context = new Mock<DBContext>("unusedhost");
            mock_bookings_table = new DataTable();
            mock_bookings_table.Columns.Add("Id", typeof(int));
            mock_bookings_table.Columns.Add("username", typeof(string));
            mock_bookings_table.Columns.Add("booktime", typeof(DateTime));

        }

        [Test] // TC 3
               // 4 bookings, 5 max, bookingsAvailable should return 1
        public void bookingsAvailable_ExpectedBehavior()
        {
            // Arrange
            DateTime date = DateTime.Parse("2022-04-04 03:00:00");
            string message;

            mock_bookings_table.Rows.Add(new Object[] { 1, "Sean", date });
            mock_bookings_table.Rows.Add(new Object[] { 2, "Neeraj", date });
            mock_bookings_table.Rows.Add(new Object[] { 3, "Chris", date });
            mock_bookings_table.Rows.Add(new Object[] { 4, "Isaiah", date });

            DataTable mock_config_table = new DataTable();
            mock_config_table.Columns.Add("MAX_BOOKINGS_PER_HOUR");
            mock_config_table.Rows.Add(new Object[] { 5 });

            mock_context.SetupSequence(x => x.ExecuteDataQueryCommand(It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>(),
                out It.Ref<string>.IsAny))
                .Returns(mock_bookings_table)
                .Returns(mock_config_table);

            // Act
            var result = Booking_db.bookingsAvailable(
                date,
                mock_context.Object);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test] // TC 4 
               // should only return bookings 3 and 4 that have matching datetime
        public void getBookingsByHour_ExpectedBehavior()
        {
            // Arrange
            DateTime date = default(global::System.DateTime);

            mock_bookings_table.Rows.Add(new Object[] { 1, "Sean", date.AddDays(1) });
            mock_bookings_table.Rows.Add(new Object[] { 2, "Neeraj", date.AddDays(2) });
            mock_bookings_table.Rows.Add(new Object[] { 3, "Chris", date });
            mock_bookings_table.Rows.Add(new Object[] { 4, "Isaiah", date });

            List<Booking> expected_bookings = new List<Booking>();
            expected_bookings.Add(new Booking(1, date.AddDays(1), "Sean"));
            expected_bookings.Add(new Booking(2, date.AddDays(2), "Neeraj"));
            expected_bookings.Add(new Booking(3, date, "Chris"));
            expected_bookings.Add(new Booking(4, date, "Isaiah"));

            mock_context.Setup(x => x.ExecuteDataQueryCommand(It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>(),
                out It.Ref<string>.IsAny))
                .Returns(mock_bookings_table);

            // Act
            var result = Booking_db.getBookingsByHour(
                date,
                mock_context.Object);

            // Assert
            Assert.That(result, Has.Count.EqualTo(expected_bookings.Count));
        }

        [Test] // TC 5
        public void ForceDelete_ExpectedBehavior()
        {
            // Arrange
            DateTime date = default(global::System.DateTime);

            int expected_deletions = 1;

            mock_context.Setup(x => x.ExecuteNonQueryCommand(It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>(),
                out It.Ref<string>.IsAny))
                .Returns(1);

            // Act
            var result = Booking_db.ForceDelete(
                mock_context.Object,
                3);

            // Assert
            Assert.That(result, Is.EqualTo(expected_deletions));
        }

        [Test] // TC 6
        public void Update_ExpectedBehavior()
        {
            // Arrange
            DateTime date = default(global::System.DateTime);

            mock_bookings_table.Rows.Add(new Object[] { 3, "Chris", date });
            mock_bookings_table.Rows.Add(new Object[] { 4, "Isaiah", date });

            List<Booking> expected_bookings = new List<Booking>();
            expected_bookings.Add(new Booking(3, date, "Chris"));
            expected_bookings.Add(new Booking(4, date, "Isaiah"));

            mock_context.Setup(x => x.ExecuteDataQueryCommand(It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>(),
                out It.Ref<string>.IsAny))
                .Returns(mock_bookings_table);

            // Act
            var result = Booking_db.getBookingsByHour(
                date,
                mock_context.Object);

            // Assert
            Assert.That(result, Has.Count.EqualTo(expected_bookings.Count));
        }

        [Test] // TC 7
        public void Add_ExpectedBehavior()
        {
            // Arrange
            DateTime date = default(global::System.DateTime);

            mock_bookings_table.Rows.Add(new Object[] { 3, "Chris", date });
            mock_bookings_table.Rows.Add(new Object[] { 4, "Isaiah", date });

            List<Booking> expected_bookings = new List<Booking>();
            expected_bookings.Add(new Booking(3, date, "Chris"));
            expected_bookings.Add(new Booking(4, date, "Isaiah"));

            mock_context.Setup(x => x.ExecuteDataQueryCommand(It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>(),
                out It.Ref<string>.IsAny))
                .Returns(mock_bookings_table);

            // Act
            var result = Booking_db.getBookingsByHour(
                date,
                mock_context.Object);

            // Assert
            Assert.That(result, Has.Count.EqualTo(expected_bookings.Count));
        }

        [Test] // TC 8
        public void getCollection_ExpectedBehavior()
        {
            // Arrange
            DateTime date = default(global::System.DateTime);

            mock_bookings_table.Rows.Add(new Object[] { 3, "Chris", date });
            mock_bookings_table.Rows.Add(new Object[] { 4, "Isaiah", date });

            List<Booking> expected_bookings = new List<Booking>();
            expected_bookings.Add(new Booking(3, date, "Chris"));
            expected_bookings.Add(new Booking(4, date, "Isaiah"));

            mock_context.Setup(x => x.ExecuteDataQueryCommand(It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>(),
                out It.Ref<string>.IsAny))
                .Returns(mock_bookings_table);

            // Act
            var result = Booking_db.getBookingsByHour(
                date,
                mock_context.Object);

            // Assert
            Assert.That(result, Has.Count.EqualTo(expected_bookings.Count));
        }

        [Test] // TC 9
        public void getBookingById_ExpectedBehavior()
        {
            // Arrange
            DateTime date = default(global::System.DateTime);

            mock_bookings_table.Rows.Add(new Object[] { 3, "Chris", date });
            mock_bookings_table.Rows.Add(new Object[] { 4, "Isaiah", date });

            List<Booking> expected_bookings = new List<Booking>();
            expected_bookings.Add(new Booking(3, date, "Chris"));
            expected_bookings.Add(new Booking(4, date, "Isaiah"));

            mock_context.Setup(x => x.ExecuteDataQueryCommand(It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>(),
                out It.Ref<string>.IsAny))
                .Returns(mock_bookings_table);

            // Act
            var result = Booking_db.getBookingsByHour(
                date,
                mock_context.Object);

            // Assert
            Assert.That(result, Has.Count.EqualTo(expected_bookings.Count));
        }

        [Test] // TC 10
        public void getCollection_ExpectedBehavior1()
        {
            // Arrange
            DateTime date = default(global::System.DateTime);

            mock_bookings_table.Rows.Add(new Object[] { 3, "Chris", date });
            mock_bookings_table.Rows.Add(new Object[] { 4, "Isaiah", date });

            List<Booking> expected_bookings = new List<Booking>();
            expected_bookings.Add(new Booking(3, date, "Chris"));
            expected_bookings.Add(new Booking(4, date, "Isaiah"));

            mock_context.Setup(x => x.ExecuteDataQueryCommand(It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>(),
                out It.Ref<string>.IsAny))
                .Returns(mock_bookings_table);

            // Act
            var result = Booking_db.getBookingsByHour(
                date,
                mock_context.Object);

            // Assert
            Assert.That(result, Has.Count.EqualTo(expected_bookings.Count));
        }
    }
}
