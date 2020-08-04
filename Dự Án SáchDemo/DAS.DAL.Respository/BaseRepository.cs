using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAS.DAL
{
  public  class BaseRepository
    {
        public IDbConnection con;

        public BaseRepository()
        {
            string connectionString = @"Data Source=desktop-b8n6v6g\sqlexpress;Initial Catalog=BooksOnline;Integrated Security=True";
            con = new SqlConnection(connectionString);
        }

    }
}
