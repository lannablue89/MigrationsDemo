using Common.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Web;

namespace EFBookService.EF
{
    public class CustomEFInterceptor : IDbCommandInterceptor
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            WriteLog(string.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            WriteLog(string.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            WriteLog(string.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            WriteLog(string.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            WriteLog(string.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            WriteLog(string.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        private void WriteLog(string command)
        {
            Log.Debug(m => m(command));

            // or use the verbose option
            /*if (Log.IsDebugEnabled)
            {
                Log.Debug(command);
            }*/
        }
    }
}