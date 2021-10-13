using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Common
{
    public class SqlHelper
    {
        public static int ExecuteNonQuery(string procedureName, SqlParameter[] parameters)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            SqlConnection oConnection = new SqlConnection(appConfiguration.ConnectionString.ToString());
            SqlCommand oCommand = new SqlCommand(procedureName, oConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            int iReturnValue;
            oConnection.Open();
            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    if (parameters != null)
                    {
                        oCommand.Parameters.AddRange(parameters);
                    }

                    oCommand.Transaction = oTransaction;
                    iReturnValue = oCommand.ExecuteNonQuery();
                    oTransaction.Commit();
                }
                catch (Exception ex)
                {

                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                    {
                        oConnection.Close();
                    }

                    oConnection.Dispose();
                    oCommand.Dispose();
                }
            }
            return iReturnValue;
        }

        public static void Fill(DataTable dataTable, string procedureName, SqlParameter[] parameters)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            SqlConnection oConnection = new SqlConnection(appConfiguration.ConnectionString.ToString());
            SqlCommand oCommand = new SqlCommand(procedureName, oConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
            {
                oCommand.Parameters.AddRange(parameters);
            }

            SqlDataAdapter oAdapter = new SqlDataAdapter
            {
                SelectCommand = oCommand
            };
            oConnection.Open();
            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oAdapter.SelectCommand.Transaction = oTransaction;
                    oAdapter.Fill(dataTable);
                    oTransaction.Commit();
                }
                catch (Exception ex)
                {

                    oTransaction.Rollback();
                    //throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                    {
                        oConnection.Close();
                    }

                    oConnection.Dispose();
                    oAdapter.Dispose();
                }
            }
        }

        public static void FillDataset(DataSet dataSet, string procedureName, SqlParameter[] parameters)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            SqlConnection oConnection = new SqlConnection(appConfiguration.ConnectionString.ToString());
            SqlCommand oCommand = new SqlCommand(procedureName, oConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
            {
                oCommand.Parameters.AddRange(parameters);
            }

            SqlDataAdapter oAdapter = new SqlDataAdapter
            {
                SelectCommand = oCommand
            };
            oConnection.Open();
            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oAdapter.SelectCommand.Transaction = oTransaction;
                    oAdapter.Fill(dataSet);
                    oTransaction.Commit();
                }
                catch (Exception ex)
                {

                    oTransaction.Rollback();
                    //throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                    {
                        oConnection.Close();
                    }

                    oConnection.Dispose();
                    oAdapter.Dispose();
                }
            }
        }
    }
}
