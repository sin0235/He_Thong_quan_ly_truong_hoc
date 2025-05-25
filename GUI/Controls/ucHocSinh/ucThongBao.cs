using QuanLyTruongHoc.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucThongBao : UserControl
    {
        // Danh sách lưu trữ tất cả các thông báo
        private List<NotificationItem> allNotifications = new List<NotificationItem>();
        // Danh sách lưu trữ các thông báo chung
        private List<NotificationItem> commonNotifications = new List<NotificationItem>();
        // Danh sách lưu trữ các thông báo cá nhân
        private List<NotificationItem> personalNotifications = new List<NotificationItem>();
        // Biến đánh dấu đang hiển thị thông báo chung hay cá nhân
        private bool isShowingCommonNotifications = true;
        // Control hiển thị chi tiết thông báo
        private ucTBChiTiet tbChiTiet;
        // Object để gọi các phương thức thao tác với CSDL
        private ThongBaoDAO thongBaoDAL;
        // Thông tin người dùng hiện tại
        private int maNguoiDung;
        private int maVaiTro;
        private int? maLop;
        // Biến lưu trữ trạng thái đọc các thông báo để hiệu suất tốt hơn
        private Dictionary<int, bool> notificationReadStatus = new Dictionary<int, bool>();
        private int id;
        // Control hiển thị đang tải
        private Guna.UI2.WinForms.Guna2Panel pnlLoading;

        public ucThongBao(int maHS, int ID)
        {
            InitializeComponent();
            thongBaoDAL = new ThongBaoDAO();
            maNguoiDung = maHS;
            id = ID;
        }

        private void ucThongBao_Load(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị chỉ báo đang tải (nếu có)
                ShowLoadingIndicator(true);

                // Tải dữ liệu từ CSDL dưới dạng Task để không làm đơ giao diện
                Task.Run(() =>
                {
                    try
                    {
                        LoadUserInformation();
                        return LoadDataFromDatabase();
                    }
                    catch (Exception ex)
                    {
                        // Ghi lại lỗi chi tiết để debug
                        Console.WriteLine($"Lỗi trong Task: {ex.Message}");
                        Console.WriteLine($"StackTrace: {ex.StackTrace}");
                        return false;
                    }
                }).ContinueWith(task =>
                {
                    // Trở về UI thread để cập nhật giao diện
                    if (this.IsDisposed || !this.IsHandleCreated)
                        return;

                    this.Invoke(new Action(() =>
                    {
                        try
                        {
                            // Ẩn chỉ báo đang tải
                            ShowLoadingIndicator(false);

                            // Hiển thị thông báo chung ban đầu
                            DisplayCommonNotifications();

                            if (!task.Result)
                            {
                                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu thông báo. Vui lòng thử lại sau.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Lỗi khi cập nhật UI: {ex.Message}");
                            MessageBox.Show($"Không thể hiển thị thông báo: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }));
                });
            }
            catch (Exception ex)
            {
                ShowLoadingIndicator(false);
                MessageBox.Show($"Lỗi khởi tạo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hiển thị hoặc ẩn chỉ báo đang tải
        /// </summary>
        private void ShowLoadingIndicator(bool show)
        {
            // Kiểm tra nếu control đã được tạo
            if (pnlLoading == null && show)
            {
                // Tạo panel loading mới
                pnlLoading = new Guna.UI2.WinForms.Guna2Panel
                {
                    BackColor = Color.White,
                    Dock = DockStyle.Fill,
                    Location = new Point(0, 0),
                    Name = "pnlLoading",
                    Size = new Size(pnlContent.Width, pnlContent.Height),
                    TabIndex = 3
                };

                // Tạo loading spinner
                Guna.UI2.WinForms.Guna2WinProgressIndicator progressIndicator = new Guna.UI2.WinForms.Guna2WinProgressIndicator
                {
                    AutoStart = true,
                    CircleSize = 80,
                    Location = new Point((pnlContent.Width - 80) / 2, (pnlContent.Height - 80) / 2),
                    Name = "loadingIndicator",
                    Size = new Size(80, 80),
                    TabIndex = 0,
                    ForeColor = Color.FromArgb(0, 120, 215)
                };

                // Tạo nhãn "Đang tải..."
                Label lblLoading = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                    ForeColor = Color.FromArgb(100, 120, 140),
                    Location = new Point((pnlContent.Width - 100) / 2, (pnlContent.Height + 80) / 2 + 10),
                    Name = "lblLoading",
                    Size = new Size(100, 25),
                    TabIndex = 1,
                    Text = "Đang tải...",
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // Thêm các control vào panel loading
                pnlLoading.Controls.Add(progressIndicator);
                pnlLoading.Controls.Add(lblLoading);

                // Thêm panel loading vào panel nội dung
                pnlContent.Controls.Add(pnlLoading);
                pnlLoading.BringToFront();
            }

            // Nếu panel loading đã được tạo
            if (pnlLoading != null)
            {
                // Hiển thị hoặc ẩn panel loading tùy thuộc vào tham số show
                pnlLoading.Visible = show;

                // Nếu ẩn loading thì đưa các control khác lên phía trước
                if (!show)
                {
                    if (flowLayoutPanel != null) flowLayoutPanel.BringToFront();
                    if (guna2VScrollBar1 != null) guna2VScrollBar1.BringToFront();
                    if (isShowingCommonNotifications)
                        DisplayCommonNotifications();
                    else
                        DisplayPersonalNotifications();
                }
            }
        }

        /// <summary>
        /// Tải thông tin người dùng hiện tại
        /// </summary>
        private void LoadUserInformation()
        {
            try
            {
                // Thiết lập mã vai trò (4 là mã vai trò của học sinh)
                maVaiTro = 4;

                // Truy vấn để lấy mã lớp của học sinh từ CSDL
                string queryMaLop = "SELECT MaLop FROM HocSinh WHERE MaNguoiDung = @MaNguoiDung";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaNguoiDung", maNguoiDung }
                };

                DatabaseHelper dbHelper = new DatabaseHelper();
                DataTable dt = dbHelper.ExecuteQuery(queryMaLop, parameters);

                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["MaLop"] != DBNull.Value)
                {
                    maLop = Convert.ToInt32(dt.Rows[0]["MaLop"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi truy vấn thông tin người dùng: " + ex.Message);
            }
        }

        /// <summary>
        /// Tải dữ liệu thông báo từ cơ sở dữ liệu
        /// </summary>
        private bool LoadDataFromDatabase()
        {
            try
            {
                // Xóa dữ liệu cũ
                allNotifications.Clear();
                commonNotifications.Clear();
                personalNotifications.Clear();
                notificationReadStatus.Clear();

                // Lấy thông báo chung (không có người nhận cụ thể)
                List<ThongBaoDTO> thongBaoChung = null;
                // Lấy thông báo cá nhân (có người nhận cụ thể)
                List<ThongBaoDTO> thongBaoCaNhan = null;

                try
                {
                    // Sử dụng phương thức có sẵn để lấy thông báo chung
                    thongBaoChung = thongBaoDAL.GetRoleNotifications(maVaiTro, id);

                    // Bổ sung thông báo lớp học và thông báo hệ thống chung vào danh sách thông báo chung
                    if (maLop.HasValue)
                    {
                        string query = @"
                            SELECT 
                                TB.MaTB, TB.TieuDe, TB.NoiDung, TB.NgayGui,  
                                CASE 
                                    WHEN GV.HoTen IS NOT NULL THEN GV.HoTen 
                                    WHEN HS.HoTen IS NOT NULL THEN HS.HoTen
                                    WHEN ND.MaVaiTro = 1 THEN (SELECT HoTen FROM GiaoVien WHERE MaNguoiDung = TB.MaNguoiGui)
                                    ELSE N'Không xác định' 
                                END AS NguoiGui,
                                (SELECT TenLop FROM LopHoc WHERE MaLop = TB.MaLop) AS NguoiNhan,
                                CASE 
                                    WHEN TB.isActive = 0 THEN 1
                                    ELSE 0 
                                END AS DaDoc
                            FROM ThongBao TB
                            LEFT JOIN NguoiDung ND ON TB.MaNguoiGui = ND.MaNguoiDung
                            LEFT JOIN GiaoVien GV ON ND.MaNguoiDung = GV.MaNguoiDung
                            LEFT JOIN HocSinh HS ON ND.MaNguoiDung = HS.MaNguoiDung
                            WHERE TB.MaLop = @MaLop
                            ORDER BY TB.NgayGui DESC";

                        Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            { "@MaLop", maLop.Value }
                        };

                        DatabaseHelper dbHelper = new DatabaseHelper();
                        DataTable dt = dbHelper.ExecuteQuery(query, parameters);
                        List<ThongBaoDTO> thongBaoLop = ConvertDataTableToList(dt);

                        // Nếu thongBaoChung là null thì khởi tạo mới
                        if (thongBaoChung == null)
                            thongBaoChung = new List<ThongBaoDTO>();

                        // Thêm thông báo lớp vào danh sách thông báo chung
                        thongBaoChung.AddRange(thongBaoLop);
                    }

                    // Lấy thông báo hệ thống chung (không có người nhận, không có vai trò, không có lớp)
                    string querySystemNotifications = @"
                        SELECT 
                            TB.MaTB, TB.TieuDe, TB.NoiDung, TB.NgayGui,  
                            CASE 
                                WHEN GV.HoTen IS NOT NULL THEN GV.HoTen 
                                WHEN HS.HoTen IS NOT NULL THEN HS.HoTen
                                WHEN ND.MaVaiTro = 1 THEN (SELECT HoTen FROM GiaoVien WHERE MaNguoiDung = TB.MaNguoiGui)
                                ELSE N'Không xác định' 
                            END AS NguoiGui,
                            N'Tất cả' AS NguoiNhan,
                            CASE 
                                WHEN TB.isActive = 0 THEN 1
                                ELSE 0 
                            END AS DaDoc
                        FROM ThongBao TB
                        LEFT JOIN NguoiDung ND ON TB.MaNguoiGui = ND.MaNguoiDung
                        LEFT JOIN GiaoVien GV ON ND.MaNguoiDung = GV.MaNguoiDung
                        LEFT JOIN HocSinh HS ON ND.MaNguoiDung = HS.MaNguoiDung
                        WHERE TB.MaNguoiNhan IS NULL AND TB.MaVaiTroNhan IS NULL AND TB.MaLop IS NULL
                        ORDER BY TB.NgayGui DESC";

                    DatabaseHelper dbHelperSystem = new DatabaseHelper();
                    DataTable dtSystem = dbHelperSystem.ExecuteQuery(querySystemNotifications);
                    List<ThongBaoDTO> thongBaoSystem = ConvertDataTableToList(dtSystem);

                    // Nếu thongBaoChung là null thì khởi tạo mới
                    if (thongBaoChung == null)
                        thongBaoChung = new List<ThongBaoDTO>();

                    // Thêm thông báo hệ thống vào danh sách thông báo chung
                    thongBaoChung.AddRange(thongBaoSystem);

                    // Sử dụng phương thức có sẵn để lấy thông báo cá nhân
                    thongBaoCaNhan = thongBaoDAL.GetPersonalNotifications(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi gọi phương thức lấy thông báo: {ex.Message}");
                    throw; // Re-throw để xử lý ở mức cao hơn
                }

                // Xử lý thông báo chung
                if (thongBaoChung != null && thongBaoChung.Count > 0)
                {
                    ProcessNotifications(thongBaoChung, false);
                }

                // Xử lý thông báo cá nhân
                if (thongBaoCaNhan != null && thongBaoCaNhan.Count > 0)
                {
                    ProcessNotifications(thongBaoCaNhan, true);
                }

                return commonNotifications.Count > 0 || personalNotifications.Count > 0;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"Lỗi SQL: {sqlEx.Message}, Mã lỗi: {sqlEx.Number}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi chung khi tải thông báo: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Phương thức hỗ trợ để chuyển đổi DataTable sang danh sách ThongBaoDTO
        /// </summary>
        private List<ThongBaoDTO> ConvertDataTableToList(DataTable dt)
        {
            List<ThongBaoDTO> thongBaoList = new List<ThongBaoDTO>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        ThongBaoDTO thongBaoDTO = new ThongBaoDTO
                        {
                            MaTB = Convert.ToInt32(row["MaTB"]),
                            TieuDe = row["TieuDe"].ToString(),
                            NoiDung = row["NoiDung"].ToString(),
                            Ngay = Convert.ToDateTime(row["NgayGui"]),
                            NguoiGui = row["NguoiGui"].ToString(),
                            NguoiNhan = row["NguoiNhan"].ToString(),
                            DaDoc = Convert.ToBoolean(row["DaDoc"])
                        };

                        // Thiết lập mã người nhận nếu có
                        if (dt.Columns.Contains("MaNguoiNhan") && row["MaNguoiNhan"] != DBNull.Value)
                        {
                            thongBaoDTO.maNguoiNhan = Convert.ToInt32(row["MaNguoiNhan"]);
                        }

                        thongBaoList.Add(thongBaoDTO);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xử lý thông báo: {ex.Message}");
                    }
                }
            }

            return thongBaoList;
        }

        /// <summary>
        /// Xử lý danh sách thông báo
        /// </summary>
        private void ProcessNotifications(List<ThongBaoDTO> thongBaoList, bool isPersonal)
        {
            foreach (var thongBao in thongBaoList)
            {
                // Lưu trữ trạng thái đọc
                notificationReadStatus[thongBao.MaTB] = thongBao.DaDoc;

                // Tạo một NotificationItem mới cho mỗi thông báo
                var notificationItem = new NotificationItem(
                    thongBao.MaTB,
                    thongBao.TieuDe,
                    thongBao.NguoiGui,
                    thongBao.Ngay,
                    thongBao.NoiDung,
                    null, // Không có avatar
                    thongBao.DaDoc
                );

                // Đăng ký sự kiện khi nhấp vào thông báo
                notificationItem.Click += (s, e) =>
                {
                    try
                    {
                        NotificationItem clickedItem = s as NotificationItem;
                        if (clickedItem != null)
                        {
                            int maTB = clickedItem.NotificationId;
                            ShowNotificationDetails(maTB, clickedItem.Title, clickedItem.Sender,
                                clickedItem.Date, clickedItem.Content);
                            UpdateReadStatus(maTB);
                            clickedItem.IsRead = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xử lý sự kiện Click: {ex.Message}");
                    }
                };

                // Phân loại thông báo vào danh sách thích hợp
                if (isPersonal)
                {
                    personalNotifications.Add(notificationItem);
                }
                else
                {
                    commonNotifications.Add(notificationItem);
                }

                // Thêm vào danh sách tổng hợp
                allNotifications.Add(notificationItem);
            }
        }

        /// <summary>
        /// Cập nhật trạng thái đã đọc của thông báo trong cơ sở dữ liệu
        /// </summary>
        /// <param name="maTB">Mã thông báo cần cập nhật</param>
        private void UpdateReadStatus(int maTB)
        {
            try
            {
                // Kiểm tra xem thông báo đã được đọc chưa
                if (notificationReadStatus.ContainsKey(maTB) && !notificationReadStatus[maTB])
                {
                    // Cập nhật trạng thái trong cache
                    notificationReadStatus[maTB] = true;

                    // Thực hiện cập nhật trạng thái đã đọc trong CSDL
                    Task.Run(() =>
                    {
                        // Pass the current user's ID when updating the read status
                        bool success = thongBaoDAL.UpdateReadStatus(maTB, id);
                        if (!success)
                        {
                            Console.WriteLine($"Không thể cập nhật trạng thái đọc cho thông báo {maTB}");
                        }
                        return success;
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật trạng thái đọc: {ex.Message}");
            }
        }

        /// <summary>
        /// Hiển thị chi tiết thông báo khi người dùng nhấp vào một thông báo
        /// </summary>
        public void ShowNotificationDetails(int maTB, string tieuDe, string nguoiGui, DateTime date, string noiDung)
        {
            try
            {
                // Lưu trạng thái hiện tại của các điều khiển
                bool currentVisibilityOfFlowPanel = flowLayoutPanel.Visible;
                bool currentVisibilityOfNoData = pnlNoData.Visible;

                // Ẩn tất cả các điều khiển hiển thị danh sách thông báo
                flowLayoutPanel.Visible = false;
                btnTBChung.Visible = false;
                btnTBCaNhan.Visible = false;
                txtSearch.Visible = false;
                pnlNoData.Visible = false;
                guna2VSeparator1.Visible = false;
                guna2VScrollBar1.Visible = false;

                // Tạo mới hoặc tái sử dụng control chi tiết thông báo
                if (tbChiTiet == null)
                {
                    tbChiTiet = new ucTBChiTiet();
                    tbChiTiet.Dock = DockStyle.Fill;

                    // Đăng ký sự kiện đóng chi tiết thông báo
                    tbChiTiet.OnClose += (s, e) =>
                    {
                        // Khi đóng chi tiết, ẩn control chi tiết
                        tbChiTiet.Visible = false;

                        flowLayoutPanel.Visible = currentVisibilityOfFlowPanel;
                        btnTBChung.Visible = true;
                        btnTBCaNhan.Visible = true;
                        txtSearch.Visible = true;
                        pnlNoData.Visible = currentVisibilityOfNoData;
                        guna2VSeparator1.Visible = true;
                        guna2VScrollBar1.Visible = true;

                        // Làm mới lại danh sách thông báo
                        RefreshNotifications();
                    };

                    // Thêm control chi tiết vào panel nội dung
                    pnlContent.Controls.Add(tbChiTiet);
                }

                // Cập nhật trạng thái đã đọc trước khi hiển thị chi tiết
                UpdateReadStatus(maTB);

                // Lấy thông tin chi tiết về thông báo từ CSDL sau khi đã cập nhật trạng thái đọc
                Task.Run(() =>
                {
                    var thongBaoDetails = thongBaoDAL.GetThongBaoById(maTB);
                    var attachments = thongBaoDAL.GetAttachments(maTB);
                    return new { ThongBao = thongBaoDetails, Attachments = attachments };
                }).ContinueWith(task =>
                {
                    if (this.IsDisposed || !this.IsHandleCreated) return;

                    this.Invoke(new Action(() =>
                    {
                        var result = task.Result;
                        string receiver = result.ThongBao != null ? result.ThongBao.NguoiNhan : "Không xác định";
                        Image nguoiGuiAvatar = GetnguoiGuiAvatar(nguoiGui);

                        // Hiển thị chi tiết thông báo
                        tbChiTiet.LoadThongBao(maTB, tieuDe, nguoiGui, receiver, date, noiDung, nguoiGuiAvatar, result.Attachments);
                        tbChiTiet.Visible = true;
                        tbChiTiet.BringToFront();
                    }));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi hiển thị chi tiết thông báo: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetReceiverForNotification(int maTB)
        {
            // Lấy thông tin chi tiết về thông báo từ CSDL
            ThongBaoDTO thongBao = thongBaoDAL.GetThongBaoById(maTB);
            if (thongBao != null)
            {
                return thongBao.NguoiNhan;
            }
            return "Không xác định";
        }

        private Image GetnguoiGuiAvatar(string nguoiGui)
        {
            // Trong thực tế, sẽ truy vấn ảnh đại diện từ cơ sở dữ liệu
            // Hiện tại, trả về null (control có avatar mặc định)
            return null;
        }

        private List<ucTBChiTiet.AttachmentInfo> GetAttachmentsForNotification(int maTB)
        {
            // Gọi phương thức mới từ ThongBaoDAL để lấy danh sách file đính kèm
            return thongBaoDAL.GetAttachments(maTB);
        }

        /// <summary>
        /// Hiển thị danh sách thông báo chung
        /// </summary>
        private void DisplayCommonNotifications()
        {
            try
            {
                // Xóa các thông báo cũ trong panel hiển thị
                flowLayoutPanel.Controls.Clear();

                // Đánh dấu đang hiển thị thông báo chung
                isShowingCommonNotifications = true;

                // Cập nhật UI để hiển thị tab thông báo chung được chọn
                btnTBChung.FillColor = Color.FromArgb(0, 120, 215);
                btnTBChung.ForeColor = Color.White;
                btnTBCaNhan.FillColor = Color.White;
                btnTBCaNhan.ForeColor = Color.FromArgb(0, 120, 215);

                if (commonNotifications.Count > 0)
                {
                    // Thêm từng thông báo chung vào panel hiển thị
                    foreach (var notification in commonNotifications)
                    {
                        flowLayoutPanel.Controls.Add(notification);
                    }

                    // Ẩn panel "không có dữ liệu"
                    pnlNoData.Visible = false;
                }
                else
                {
                    // Hiển thị thông báo khi không có dữ liệu
                    pnlNoData.Visible = true;
                    lblNoData.Text = "Không có thông báo chung nào";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị thông báo chung: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hiển thị danh sách thông báo cá nhân
        /// </summary>
        private void DisplayPersonalNotifications()
        {
            try
            {
                // Xóa các thông báo cũ trong panel hiển thị
                flowLayoutPanel.Controls.Clear();

                // Đánh dấu đang hiển thị thông báo cá nhân
                isShowingCommonNotifications = false;

                // Cập nhật UI để hiển thị tab thông báo cá nhân được chọn
                btnTBCaNhan.FillColor = Color.FromArgb(0, 120, 215);
                btnTBCaNhan.ForeColor = Color.White;
                btnTBChung.FillColor = Color.White;
                btnTBChung.ForeColor = Color.FromArgb(0, 120, 215);

                if (personalNotifications.Count > 0)
                {
                    // Thêm từng thông báo cá nhân vào panel hiển thị
                    foreach (var notification in personalNotifications)
                    {
                        flowLayoutPanel.Controls.Add(notification);
                    }

                    // Ẩn panel "không có dữ liệu"
                    pnlNoData.Visible = false;
                }
                else
                {
                    // Hiển thị thông báo khi không có dữ liệu
                    pnlNoData.Visible = true;
                    lblNoData.Text = "Không có thông báo cá nhân nào";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị thông báo cá nhân: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTBChung_Click(object sender, EventArgs e)
        {
            DisplayCommonNotifications();
        }

        private void btnTBCaNhan_Click(object sender, EventArgs e)
        {
            DisplayPersonalNotifications();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterNotifications(txtSearch.Text);
        }

        /// <summary>
        /// Lọc thông báo theo từ khóa tìm kiếm
        /// </summary>
        private void FilterNotifications(string searchText)
        {
            try
            {
                searchText = searchText.ToLower();

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị lại danh sách ban đầu
                    if (isShowingCommonNotifications)
                        DisplayCommonNotifications();
                    else
                        DisplayPersonalNotifications();

                    return;
                }

                // Xóa các thông báo cũ trong panel hiển thị
                flowLayoutPanel.Controls.Clear();

                // Xác định danh sách thông báo cần tìm kiếm (chung hoặc cá nhân)
                List<NotificationItem> notificationsToSearch = isShowingCommonNotifications ?
                                                            commonNotifications :
                                                            personalNotifications;

                // Lọc các thông báo theo từ khóa tìm kiếm với cách tìm kiếm tối ưu hơn
                var filteredNotifications = notificationsToSearch.Where(n =>
                {
                    // Kiểm tra tiêu đề, người gửi và nội dung tóm tắt
                    bool matches = false;

                    foreach (var ctrl in n.Controls)
                    {
                        if (ctrl is Label lbl && lbl.Text.ToLower().Contains(searchText))
                        {
                            matches = true;
                            break;
                        }
                    }

                    return matches;
                }).ToList();

                if (filteredNotifications.Count > 0)
                {
                    // Hiển thị các thông báo đã lọc
                    foreach (var notification in filteredNotifications)
                    {
                        flowLayoutPanel.Controls.Add(notification);
                    }

                    // Ẩn panel "không có dữ liệu"
                    pnlNoData.Visible = false;
                }
                else
                {
                    // Hiển thị thông báo khi không tìm thấy kết quả
                    pnlNoData.Visible = true;
                    lblNoData.Text = $"Không tìm thấy thông báo nào với từ khóa \"{searchText}\"";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lọc thông báo: {ex.Message}");
            }
        }

        /// <summary>
        /// Làm mới dữ liệu thông báo
        /// </summary>
        public void RefreshNotifications()
        {
            // Hiển thị loading indicator nếu có
            ShowLoadingIndicator(true);

            // Tải dữ liệu dưới dạng Task để không làm đơ giao diện
            Task.Run(() => LoadDataFromDatabase())
                .ContinueWith(task =>
                {
                    if (this.IsDisposed || !this.IsHandleCreated) return;

                    this.Invoke(new Action(() =>
                    {
                        ShowLoadingIndicator(false);

                        if (isShowingCommonNotifications)
                            DisplayCommonNotifications();
                        else
                            DisplayPersonalNotifications();
                    }));
                });
        }
    }
}
