﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

//Useful extension methods to use and port over
namespace WebApplication3
{
    public static class ExtensionMethods 
    {
        public static void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }


        public static void ResetDropDownLists(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is DropDownList)
                {
                    DropDownList t = ctrl as DropDownList;
                    t.SelectedIndex = 0;
                }               
            }
        }

        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static void Execute_Insert(string name, int phone, string ic)
        {
            string Conn = ConfigurationManager.ConnectionStrings["SecondConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(Conn);

            string sql = "Insert INTO HRTable (Name, Phone,IC, Job_ID, " +
                "Department_ID) VALUES " 
                + " (@Name,@Phone,@IC, @jobId, @departId)";    
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlParameter[] param = new SqlParameter[5];
                
                param[0] = new SqlParameter("@Name", SqlDbType.NChar, 10);
                param[1] = new SqlParameter("@Phone", SqlDbType.NVarChar, 8);
                param[2] = new SqlParameter("@IC", SqlDbType.NChar, 9);
                param[3] = new SqlParameter("@jobId", SqlDbType.NChar, 9);
                param[4] = new SqlParameter("@departId", SqlDbType.NChar, 9);

                param[0].Value = name;
                param[1].Value = phone;
                param[2].Value = ic;    
               

                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
                
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void Redirect(this HttpResponse response, string url, string target, string windowFeatures)
        {
            if ((String.IsNullOrEmpty(target) || target.Equals("_self", StringComparison.OrdinalIgnoreCase)) && String.IsNullOrEmpty(windowFeatures))
            {
                response.Redirect(url);
            }
            else
            {
                Page page = (Page)HttpContext.Current.Handler;

                if (page == null)
                {
                    throw new InvalidOperationException("Cannot redirect to new window outside Page context.");
                }
                url = page.ResolveClientUrl(url);

                string script;
                if (!String.IsNullOrEmpty(windowFeatures))
                {
                    script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
                }
                else
                {
                    script = @"window.open(""{0}"", ""{1}"");";
                }
                script = String.Format(script, url, target, windowFeatures);
                ScriptManager.RegisterStartupScript(page, typeof(Page), "Redirect", script, true);
            }
        }

    }
}