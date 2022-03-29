using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
// User imports
using Webservice.Core;

namespace Webservice.Tests;

[TestFixture]
public class UserTests
{
    // Class variables for testing
    DBContext context = null;

    [SetUp]
    public void Setup()
    {
        // Setup a DBContext for unit testing
        context = new Webservice.Providers.MySQLContext("Server = gymdb.chrisarc.com;" +
            " Port = 3306;" +
            " Database = GymDB;" +
            " Uid = gym-api;" +
            " Pwd=jmQydEITu3UxcXEb;");
        string message;
        bool stat = context.Initialize(out message);
        Assert.IsTrue(stat, message);
    }


    [Test]
    public void TestAdminExists()
    {
        // Setup
        string username = "Admin";
        string expected_password = "Admin@123";

        try
        {
            DataTable table = context.ExecuteDataQueryCommand(
                commandText: "SELECT Password FROM Users WHERE `UserName` = @username",
                parameters: new Dictionary<string, object>
                {
                        {"@username", username},
                },
                message: out string sql
                );


            // Assert that admin exists and password matches
            Assert.That(table.Rows, Has.Count.EqualTo(1));
            Assert.That(table.Rows[0]["Password"], Is.EqualTo(expected_password));
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }

    }
}