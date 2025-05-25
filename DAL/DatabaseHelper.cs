using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.DTO;
using System.Drawing;

namespace QuanLyTruongHoc.DAL
{
    public class DatabaseHelper
    {
        private SqlConnection sqlConn;
        private SqlDataAdapter da;
        private DataSet ds;

        //Phúc toàn
        //private string strCnn = "Data Source=LAPTOP-CC2MRJ2T\\SQLEXPRESS;Initial Catalog=QuanLyTruongHoc;Persist Security Info=True;User ID=sa;Password=SIN235.sql.login";
        //Tuấn
        // private string strCnn = "Data Source=localhost;Initial Catalog=QuanLyTruongHoc;User ID=sa;Password=123";
        //Nhân
        string strCnn = "Data Source=JOHNNYBUIII; Database=backup1; " + "user id=sa;password=1;MultipleActiveResultSets=True;";
        public SqlConnection GetConnection()
        {
            return sqlConn;
        }

        public DatabaseHelper()
        {
            sqlConn = new SqlConnection(strCnn);
        }

        /// <summary>
        /// Mở kết nối đến cơ sở dữ liệu
        /// </summary>
        public void OpenConnection()
        {
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();
        }

        /// <summary>
        /// Đóng kết nối đến cơ sở dữ liệu
        /// </summary>
        public void CloseConnection()
        {
            if (sqlConn.State == ConnectionState.Open)
                sqlConn.Close();
        }

        /// <summary>
        /// Thực thi truy vấn SELECT và trả về DataTable
        /// </summary>
        /// <param name="sqlStr">Câu lệnh SQL</param>
        /// <returns>DataTable chứa kết quả truy vấn</returns>
        public DataTable ExecuteQuery(string sqlStr)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                da = new SqlDataAdapter(sqlStr, sqlConn);
                ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
        }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn: " + ex.Message);
            }
            finally
            {
                CloseConnection();
}
return dt;
        }

        /// <summary>
        /// Thực thi truy vấn SELECT với tham số và trả về DataTable
        /// </summary>
        /// <param name="sqlStr">Câu lệnh SQL</param>
        /// <param name="parameters">Dictionary chứa các tham số và giá trị</param>
        /// <returns>DataTable chứa kết quả truy vấn</returns>
        public DataTable ExecuteQuery(string sqlStr, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(strCnn))
            using (SqlCommand cmd = new SqlCommand(sqlStr, connection))
            {
                try
                {
                    connection.Open();
                    // Add parameters
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            if (param.Value is DateTime dateValue)
                            {
                                SqlParameter sqlParam = new SqlParameter(param.Key, SqlDbType.DateTime);
                                sqlParam.Value = dateValue; 
                                cmd.Parameters.Add(sqlParam);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn: " + ex.Message);
                }
            }
            return dt;
        }

        /// <summary>
        /// Thực thi câu lệnh INSERT, UPDATE, DELETE không có tham số
        /// </summary>
        /// <param name="sqlStr">Câu lệnh SQL</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        public bool ExecuteNonQuery(string sqlStr)
        {
            bool result = false;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sqlStr, sqlConn))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi lệnh: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        /// Thực thi câu lệnh INSERT, UPDATE, DELETE có tham số
        /// </summary>
        /// <param name="sqlStr">Câu lệnh SQL</param>
        /// <param name="parameters">Dictionary chứa các tham số và giá trị</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        public bool ExecuteNonQuery(string sqlStr, Dictionary<string, object> parameters)
        {
            bool result = false;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sqlStr, sqlConn))
                {
                    // Thêm các tham số
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            if (param.Value is DateTime dateValue)
                            {
                                // Sử dụng SqlDbType.DateTime2 để lưu cả ngày và giờ
                                SqlParameter sqlParam = new SqlParameter(param.Key, SqlDbType.DateTime2);
                                sqlParam.Value = dateValue; // Không lấy .Date nữa để giữ thông tin giờ
                                cmd.Parameters.Add(sqlParam);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi lệnh: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        /// Thực thi câu lệnh truy vấn trả về giá trị đơn (ví dụ: COUNT, SUM, MAX, MIN, AVG...)
        /// </summary>
        /// <param name="sqlStr">Câu lệnh SQL</param>
        /// <returns>Kết quả trả về từ câu lệnh</returns>
        public object ExecuteScalar(string sqlStr)
        {
            object result = null;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sqlStr, sqlConn))
                {
                    result = cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi lệnh: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        /// Thực thi câu lệnh truy vấn có tham số trả về giá trị đơn
        /// </summary>
        /// <param name="sqlStr">Câu lệnh SQL</param>
        /// <param name="parameters">Dictionary chứa các tham số và giá trị</param>
        /// <returns>Kết quả trả về từ câu lệnh</returns>
        public object ExecuteScalar(string sqlStr, Dictionary<string, object> parameters)
        {
            object result = null;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sqlStr, sqlConn))
                {
                    // Thêm các tham số
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    object queryResult = cmd.ExecuteScalar();

                    // Kiểm tra nếu kết quả là DBNull thì trả về null
                    if (queryResult != DBNull.Value)
                    {
                        result = queryResult;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi lệnh: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        /// Thực thi stored procedure không trả về dữ liệu
        /// </summary>
        /// <param name="procName">Tên stored procedure</param>
        /// <param name="parameters">Dictionary chứa các tham số và giá trị</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        public bool ExecuteProcedure(string procName, Dictionary<string, object> parameters = null)
        {
            bool result = false;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(procName, sqlConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi procedure: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        /// Thực thi stored procedure trả về DataTable
        /// </summary>
        /// <param name="procName">Tên stored procedure</param>
        /// <param name="parameters">Dictionary chứa các tham số và giá trị</param>
        /// <returns>DataTable chứa kết quả truy vấn</returns>
        public DataTable ExecuteProcedureQuery(string procName, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(procName, sqlConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi procedure: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        /// <summary>
        /// Thực thi transaction với nhiều câu lệnh SQL
        /// </summary>
        /// <param name="sqlCommands">Danh sách các câu lệnh SQL cần thực thi</param>
        /// <returns>True nếu tất cả câu lệnh thực thi thành công, False nếu có lỗi</returns>
        public bool ExecuteTransaction(List<string> sqlCommands)
        {
            bool result = false;
            SqlTransaction transaction = null;

            try
            {
                OpenConnection();
                transaction = sqlConn.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.Transaction = transaction;

                    foreach (string sql in sqlCommands)
                    {
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show("Lỗi thực thi transaction: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return result;
        }

        /// <summary>
        /// Thực thi transaction với nhiều câu lệnh SQL và tham số
        /// </summary>
        /// <param name="commands">Danh sách các câu lệnh SQL và tham số tương ứng</param>
        /// <returns>True nếu tất cả câu lệnh thực thi thành công, False nếu có lỗi</returns>
        public bool ExecuteParameterizedTransaction(List<SqlCommandData> commands)
        {
            bool result = false;
            SqlTransaction transaction = null;

            try
            {
                OpenConnection();
                transaction = sqlConn.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConn;
                    cmd.Transaction = transaction;

                    foreach (var command in commands)
                    {
                        cmd.CommandText = command.CommandText;
                        cmd.Parameters.Clear();

                        if (command.Parameters != null)
                        {
                            foreach (var param in command.Parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show("Lỗi thực thi transaction: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return result;
        }

        /// <summary>
        /// Thực thi câu lệnh INSERT và trả về ID của bản ghi mới
        /// </summary>
        /// <param name="sqlStr">Câu lệnh SQL INSERT kèm theo SCOPE_IDENTITY()</param>
        /// <returns>ID của bản ghi vừa insert hoặc -1 nếu thất bại</returns>
        public int ExecuteInsertAndGetId(string sqlStr)
        {
            int newId = -1;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sqlStr, sqlConn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        newId = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi lệnh: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return newId;
        }

        /// <summary>
        /// Thực thi câu lệnh INSERT có tham số và trả về ID của bản ghi mới
        /// </summary>
        /// <param name="sqlStr">Câu lệnh SQL INSERT kèm theo SCOPE_IDENTITY()</param>
        /// <param name="parameters">Dictionary chứa các tham số và giá trị</param>
        /// <returns>ID của bản ghi vừa insert hoặc -1 nếu thất bại</returns>
        public int ExecuteInsertAndGetId(string sqlStr, Dictionary<string, object> parameters)
        {
            int newId = -1;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sqlStr, sqlConn))
                {
                    // Thêm các tham số
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        newId = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi lệnh: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return newId;
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của bản ghi trong bảng
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="whereClause">Điều kiện WHERE (không bao gồm từ khóa WHERE)</param>
        /// <returns>True nếu bản ghi tồn tại, False nếu không tồn tại</returns>
        public bool RecordExists(string tableName, string whereClause)
        {
            bool exists = false;
            string sqlStr = $"SELECT COUNT(*) FROM {tableName} WHERE {whereClause}";

            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sqlStr, sqlConn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    exists = count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra dữ liệu: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return exists;
        }

        /// <summary>
        /// Upload tệp nhị phân (binary) vào cơ sở dữ liệu
        /// </summary>
        /// <param name="sqlStr">Câu lệnh SQL INSERT/UPDATE với tham số @FileData</param>
        /// <param name="fileData">Dữ liệu tệp tin dạng byte[]</param>
        /// <param name="additionalParameters">Các tham số bổ sung (nếu có)</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        public bool UploadFile(string sqlStr, byte[] fileData, Dictionary<string, object> additionalParameters = null)
        {
            bool result = false;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sqlStr, sqlConn))
                {
                    // Tạo tham số cho file
                    SqlParameter fileParam = new SqlParameter("@FileData", SqlDbType.VarBinary);
                    fileParam.Value = fileData;
                    cmd.Parameters.Add(fileParam);

                    // Thêm các tham số bổ sung
                    if (additionalParameters != null)
                    {
                        foreach (var param in additionalParameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lên tệp: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

    }
    public class SqlCommandData
    {
        public string CommandText { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
}
