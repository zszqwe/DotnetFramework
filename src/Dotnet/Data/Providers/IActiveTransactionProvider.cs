﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dotnet.Data.Providers
{
    public interface IActiveTransactionProvider
    {
        IDbContext DbContext { get; set; }

        /// <summary>
        ///     Gets the active transaction or null if current UOW is not transactional.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        IDbTransaction GetActiveTransaction(ActiveTransactionProviderArgs args);

        /// <summary>
        ///     Gets the active database connection.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        IDbConnection GetActiveConnection(ActiveTransactionProviderArgs args);
    }
}
