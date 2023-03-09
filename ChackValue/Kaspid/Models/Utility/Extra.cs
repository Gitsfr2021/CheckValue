using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Kaspid.Models.Utility
{

    public static class Extra
    {

        public static string Prop(this object Source, string propertyName)
        {
            PropertyInfo result = Source.GetType().GetProperty(propertyName);
            if (result == null)
            {
                return "this is wrong property";
            }
            object x = result.GetValue(Source, null);
            if (x != null)
                return x.ToString();
            return "";
        }

        public static DataTable getTable(string cmdText)
        {
            DataTable dtItems = new DataTable();
            SqlDataAdapter sqlCom = new SqlDataAdapter(cmdText, ConfigurationManager.ConnectionStrings["DalEntities"].ToString());
            dtItems.Clear();
            DataSet objDS = new DataSet();
            sqlCom.Fill(objDS);
            dtItems = objDS.Tables[0];
            return dtItems;
        }
    }
}