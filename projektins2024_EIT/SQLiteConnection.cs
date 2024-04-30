using System;
using System.Data.SQLite;

namespace HairCareRecommendation
{
    internal class SQLiteConnection
    {
        private string connectionString;

        public SQLiteConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }

        internal SQLiteCommand CreateCommand()
        {
            throw new NotImplementedException();
        }
    }
}