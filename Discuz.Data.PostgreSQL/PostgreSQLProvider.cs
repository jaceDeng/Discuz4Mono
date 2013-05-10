using System;
using System.Data;
using System.Data.Common;
using Npgsql;
using NpgsqlTypes;

namespace Discuz.Data
{
    public class PostgreSQLProvider : IDbProvider
    {
        public DbProviderFactory Instance()
        {
            return NpgsqlFactory.Instance;
        }

        public void DeriveParameters(IDbCommand cmd)
        {
            if ((cmd as NpgsqlCommand) != null)
            {
                NpgsqlCommandBuilder.DeriveParameters(cmd as NpgsqlCommand);
            }
        }

        public DbParameter MakeParam(string ParamName, DbType DbType, Int32 Size)
        {
            NpgsqlParameter param;
            ParamName = ParamName.Replace("@", ":");
            if (Size > 0)
                param = new NpgsqlParameter(ParamName, (NpgsqlDbType)DbType, Size);
            else
                param = new NpgsqlParameter(ParamName, (NpgsqlDbType)DbType);

            return param;
        }

        public bool IsFullTextSearchEnabled()
        {
            return true;
        }

        public bool IsCompactDatabase()
        {
            return false;
        }

        public bool IsBackupDatabase()
        {
            return false;
        }

        public string GetLastIdSql()
        {
            return "SELECT SCOPE_IDENTITY()";
        }

        public bool IsDbOptimize()
        {
            return false;
        }

        public bool IsShrinkData()
        {
            return true;
        }

        public bool IsStoreProc()
        {
            return true;
        }
    }
}
