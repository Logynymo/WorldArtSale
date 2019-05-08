// The class uses the System.Data and System.Data.SqlClient .NET libraries to be able to connect and
// communicate with a database. System.Data primarily is used handle datatypes we get
// from the database, and System.Data.SqlClient is for general communications with the database. 
using System.Data;
using System.Data.SqlClient;

namespace ProjectIO
{    
    /// <summary>
    /// The ClassDbCons purpose is to handle the connection to the DB.
    /// </summary>
    public class ClassDbCon
    {
        private string connectionString;
        private SqlConnection con;
        private SqlCommand command;

        /// <summary>
        /// Default constructor with no arguments
        /// </summary>
        public ClassDbCon()
        {
        }

        /// <summary>
        /// An overload construkter
        /// Set the SqlConnection based on the recived string
        /// Save the connectionstring in the field connectionString and the SqlConnection in the field con
        /// </summary>
        /// <param name="yourConString">A string with the connection settings</param> 
        public ClassDbCon(string yourConString)
        {
            connectionString = yourConString;
            con = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Set the SqlConnection based on the recived string
        /// Save the connectionstring in the field connectionString and the SqlConnection in the field con
        /// </summary>
        /// <param name="yourConString">A string with the connection settings</param>
        protected void SetCon(string yourConString)
        {
            connectionString = yourConString;
            con = new SqlConnection(connectionString);
        }

        /// <summary> 
        /// OpenDB is a method that trys to open the connection to the DB
        /// In the "if" statement it checks if con is not null,
        /// and if con.State is == ConnectionState.Closed then it use con.Open.
        /// if ConnectionState is open, or con is null
        /// it will Close the cennection and do recursive call of OpenDB
        /// </summary> 
        protected void OpenDB()
        {
            try
            {
                if (this.con != null && con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                else
                {
                    CloseDB();
                    OpenDB();
                }
            }
            catch (SqlException sqlEx)
            {

                throw sqlEx;
            }
        }

        /// <summary>
        /// This method closes the connection to the DB
        /// It will throw a exception if anything goes wrong
        /// </summary>
        protected void CloseDB()
        {
            try
            {
                con.Close();
            }
            catch (SqlException sqlEx)
            {

                throw sqlEx;
            }
        }

        /// <summary> 
        /// This method takes an SQL-query as a parameter.
        /// The res variable holds an integer value that represents the outcome of ExecuteNonQuery.
        /// Field command is set to a new SqlCommand where the SQL-query and connection is defined.
        /// A connection to the database is opened and the SQL-command is executed by calling the
        /// command.ExecuteNonQuery() method. The outcome of the operation is stored in res (1 for succesful,
        /// and 0 for unsuccesful).         
        /// If anything goes wrong, an exception is thrown. 
        /// In Finally the CloseDB() will be called to close the
        /// connection, independed of an exception is thrown or not.
        /// Lastly, res is returned to the method caller.
        /// </summary>
        /// <param name="sqlQuery">String with the SQL-query</param>
        /// <returns>An integer representing the outcome of the execution</returns>
        protected int ExecuteNonQuery(string sqlQuery)
        {
            int res = 0;
            command = new SqlCommand(sqlQuery, con);
            try
            {
                OpenDB();
                res = command.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {

                throw sqlEx;
            }
            finally
            {
                CloseDB();

            }
            return res;
        }

        /// <summary> 
        /// The method starts by creating a new empty DataTable.
        /// A connection to the database is then opened.
        /// Inside a using-statement, "command" is set to a new SqlCommand where
        /// the SQL-query and connection is defined.
        /// An SqlDataAdapter is instantialized with "command" as the parameter inside
        /// another using-statement. The adapter sends the SQL-command to the database and
        /// fills the data that is returned into the empty DataTable. 
        /// If anything goes wrong, an exception is thrown.
        /// In the finally statement, CloseDB() will then be called to close the connection.
        /// The DataTable is then returned to the method caller.
        /// </summary>
        /// <param name="sqlQuery">String containing the SQL-query</param>
        /// <returns>DataTable containing rows relevant to the SQL-query</returns> 
        /// 
        protected DataTable DbReturnDataTable(string sqlQuery)
        {
            DataTable dtRes = new DataTable();
            try
            {
                OpenDB();

                using (command = new SqlCommand(sqlQuery, con))
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dtRes);
                }
            }
            catch (SqlException sqlEx)
            {

                throw sqlEx;
            }
            finally
            {
                CloseDB();
            }
            return dtRes;
        }
    }
}
