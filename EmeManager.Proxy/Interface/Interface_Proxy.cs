﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JProxy
{
    interface Interface_Proxy
    {
        object DoProxy(string ClassName, string MethodName, object[] args);
        DataTable DoProxyDataTable(string ClassName, string MethodName, object[] args);
        DataSet DoProxyDataSet(string ClassName, string MethodName, object[] args);
        void DoProxyNoResult(string ClassName, string MethodName, object[] args);
    }
}
