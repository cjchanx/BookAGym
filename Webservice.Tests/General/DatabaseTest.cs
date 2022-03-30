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
public class DatabaseTest
{
    [SetUp]
    public void Setup()
    {

    }

    [Test] // TC 1
    public void TestDBConnects()
    {
        // Manually generate connection
        string con_string = "Server = gymdb.chrisarc.com;" +
            " Port = 3306;" +
            " Database = GymDB;" +
            " Uid = gym-api;" +
            " Pwd=jmQydEITu3UxcXEb;";

        MySqlConnection con = new MySqlConnection(con_string);

        try
        {
            // Open connection
            con.Open();
        }
        catch (MySqlException e)
        {
            Assert.Fail(e.Message);
        }

        // Assert that the connection is open
        Assert.AreEqual(con.State, ConnectionState.Open);

        // Close the temporary connection
        con.Close();
    }


}