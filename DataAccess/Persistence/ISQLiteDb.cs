﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
