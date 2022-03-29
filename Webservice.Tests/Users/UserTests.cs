using NUnit.Framework;

// User imports
using Webservice.DatabaseHelper;
using Webservice.ContextHelpers;
using Webservice.Providers;
using Webservice.Core;
using MySql.Data.MySqlClient;
using System.Data;

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

    }
}