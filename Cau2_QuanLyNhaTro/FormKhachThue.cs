using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Cau2_QuanLyNhaTro.Data;
using Cau2_QuanLyNhaTro.Models;
using Cau2_QuanLyNhaTro.Services;

namespace Cau2_QuanLyNhaTro
{
    public class KhachThueDisplayDTO
    {
        public int MaKhach { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public string GioiTinh { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string SoDienThoai { get; set; } = string.Empty;
        public string TenPhong { get; set; } = string.Empty;
        public decimal GiaThue { get; set; }
        public string QueQuan { get; set; } = string.Empty;
        public bool DaDangKyTamTru { get; set; }

        public int MaPhong { get; set; }
        public int MaTinh { get; set; }
        public string TenTinh { get; set; } = string.Empty;
        public int MaPhuongXa { get; set; }
        public string TenPhuongXa { get; set; } = string.Empty;
    }

    public partial class FormKhachThue : Form
    {
        private List<KhachThueDisplayDTO> _allKhach = new();
        private List<PhongTro> _allPhong = new();
        private List<AdministrativeUnit> _provinces = new();
        private bool _isApiWorking = true;

        public FormKhachThue()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            this.Load += async (s, e) => await FormKhachThue_LoadAsync();
            cboTinh.SelectedIndexChanged += async (s, e) => await CboTinh_SelectedIndexChangedAsync();
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += (s, e) => ClearInputs();
            btnBoLoc.Click += BtnBoLoc_Click;
            txtTimKiem.TextChanged += (s, e) => ApplyFilter();
            cboLocPhong.SelectedIndexChanged += (s, e) => ApplyFilter();
            cboLocTinh.SelectedIndexChanged += (s, e) => ApplyFilter();
            dgvKhachThue.CellClick += DgvKhachThue_CellClick;
            btnGayLoiThu.Click += (s, e) => throw new InvalidOperationException("Thử nghiệm lỗi toàn cục (Global Exception Handling)!");
        }

        private async Task FormKhachThue_LoadAsync()
        {
            ConfigureGridColumns();
            LoadPhongToCombos();
            LoadKhachThueFromDatabase();
            await LoadProvincesApiAsync();
        }

        private void ConfigureGridColumns()
        {
            dgvKhachThue.AutoGenerateColumns = false;
            dgvKhachThue.Columns.Clear();

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaKhach",
                HeaderText = "Mã",
                Width = 50
            });

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HoTen",
                HeaderText = "Họ và tên",
                Width = 160
            });

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GioiTinh",
                HeaderText = "Giới tính",
                Width = 70
            });

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoDienThoai",
                HeaderText = "Số điện thoại",
                Width = 110
            });

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenPhong",
                HeaderText = "Tên phòng",
                Width = 90
            });

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GiaThue",
                HeaderText = "Giá thuê (đ/tháng)",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight },
                Width = 120
            });

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "QueQuan",
                HeaderText = "Quê quán (Phường/Xã - Tỉnh)",
                Width = 260
            });

            dgvKhachThue.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "DaDangKyTamTru",
                HeaderText = "Đã tạm trú",
                Width = 90
            });
        }

        private void LoadPhongToCombos()
        {
            try
            {
                using var context = new QLNhaTroContext();
                _allPhong = context.PhongTros.OrderBy(p => p.TenPhong).ToList();

                cboPhong.DataSource = null;
                cboPhong.DisplayMember = "TenPhong";
                cboPhong.ValueMember = "MaPhong";
                cboPhong.DataSource = _allPhong.ToList();

                // Lọc phòng
                var locPhongList = new List<string> { "Tất cả phòng" };
                locPhongList.AddRange(_allPhong.Select(p => p.TenPhong));
                cboLocPhong.DataSource = locPhongList;
                cboLocPhong.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex, "Lỗi khi nạp danh sách phòng trọ.");
                MessageBox.Show("Không thể nạp danh sách phòng trọ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadProvincesApiAsync()
        {
            try
            {
                cboTinh.Enabled = false;
                cboTinh.Text = "Đang tải tỉnh/thành...";

                _provinces = await ProvinceApiService.GetProvincesAsync();

                cboTinh.DisplayMember = "name";
                cboTinh.ValueMember = "code";
                cboTinh.DataSource = _provinces;

                // Lọc tỉnh
                var locTinhList = new List<string> { "Tất cả tỉnh" };
                locTinhList.AddRange(_provinces.Select(p => p.name));
                cboLocTinh.DataSource = locTinhList;
                cboLocTinh.SelectedIndex = 0;

                _isApiWorking = true;
                txtPhuongXaManual.Visible = false;
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException || ex is Exception)
            {
                _isApiWorking = false;
                LoggerService.LogWarning("Không tải được danh sách địa chỉ từ Open-API: " + ex.Message);
                MessageBox.Show("Không tải được danh sách địa chỉ từ Open-API, vui lòng kiểm tra mạng! Bạn có thể nhập tay địa chỉ.",
                    "Cảnh báo mạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtPhuongXaManual.Visible = true;
                cboPhuongXa.Enabled = false;
            }
            finally
            {
                cboTinh.Enabled = true;
            }
        }

        private async Task CboTinh_SelectedIndexChangedAsync()
        {
            if (!_isApiWorking || cboTinh.SelectedItem is not AdministrativeUnit selectedProvince)
            {
                return;
            }

            try
            {
                cboPhuongXa.Enabled = false;
                cboPhuongXa.Text = "Đang tải phường/xã...";

                var wards = await ProvinceApiService.GetWardsAsync(selectedProvince.code);

                cboPhuongXa.DisplayMember = "name";
                cboPhuongXa.ValueMember = "code";
                cboPhuongXa.DataSource = wards;
            }
            catch (Exception ex)
            {
                LoggerService.LogWarning($"Lỗi khi tải phường xã của tỉnh {selectedProvince.name}: " + ex.Message);
                txtPhuongXaManual.Visible = true;
                cboPhuongXa.Enabled = false;
            }
            finally
            {
                cboPhuongXa.Enabled = true;
            }
        }

        private void LoadKhachThueFromDatabase()
        {
            try
            {
                using var context = new QLNhaTroContext();
                _allKhach = context.KhachThues
                    .Include(k => k.PhongTro)
                    .OrderByDescending(k => k.MaKhach)
                    .Select(k => new KhachThueDisplayDTO
                    {
                        MaKhach = k.MaKhach,
                        HoTen = k.HoTen,
                        GioiTinh = k.GioiTinh,
                        NgaySinh = k.NgaySinh,
                        SoDienThoai = k.SoDienThoai,
                        TenPhong = k.PhongTro != null ? k.PhongTro.TenPhong : string.Empty,
                        GiaThue = k.PhongTro != null ? k.PhongTro.GiaThue : 0,
                        QueQuan = $"{k.TenPhuongXa} - {k.TenTinh}",
                        DaDangKyTamTru = k.DaDangKyTamTru,
                        MaPhong = k.MaPhong,
                        MaTinh = k.MaTinh,
                        TenTinh = k.TenTinh,
                        MaPhuongXa = k.MaPhuongXa,
                        TenPhuongXa = k.TenPhuongXa
                    })
                    .ToList();

                ApplyFilter();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex, "Lỗi khi nạp danh sách khách thuê.");
                MessageBox.Show("Không thể kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            var query = _allKhach.AsEnumerable();

            string keyword = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(k => k.HoTen.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                         k.SoDienThoai.Contains(keyword));
            }

            string phong = cboLocPhong.SelectedItem?.ToString() ?? "Tất cả phòng";
            if (phong != "Tất cả phòng")
            {
                query = query.Where(k => k.TenPhong == phong);
            }

            string tinh = cboLocTinh.SelectedItem?.ToString() ?? "Tất cả tỉnh";
            if (tinh != "Tất cả tỉnh")
            {
                query = query.Where(k => k.TenTinh.Contains(tinh, StringComparison.OrdinalIgnoreCase));
            }

            dgvKhachThue.DataSource = query.ToList();
        }

        private void DgvKhachThue_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvKhachThue.Rows.Count) return;

            var item = dgvKhachThue.Rows[e.RowIndex].DataBoundItem as KhachThueDisplayDTO;
            if (item == null) return;

            txtMaKhach.Text = item.MaKhach.ToString();
            txtHoTen.Text = item.HoTen;
            if (item.GioiTinh == "Nữ") radNu.Checked = true;
            else radNam.Checked = true;

            dtpNgaySinh.Value = item.NgaySinh;
            txtSDT.Text = item.SoDienThoai;
            cboPhong.SelectedValue = item.MaPhong;
            chkTamTru.Checked = item.DaDangKyTamTru;

            // Đồng bộ tỉnh/xã nếu có
            if (_provinces.Any())
            {
                var prov = _provinces.FirstOrDefault(p => p.code == item.MaTinh || p.name == item.TenTinh);
                if (prov != null)
                {
                    cboTinh.SelectedItem = prov;
                }
            }
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách thuê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            if (cboPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng trọ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhong = (int)cboPhong.SelectedValue;
            int maTinh = 0;
            string tenTinh = string.Empty;
            int maPhuongXa = 0;
            string tenPhuongXa = string.Empty;

            if (cboTinh.SelectedItem is AdministrativeUnit prov)
            {
                maTinh = prov.code;
                tenTinh = prov.name;
            }

            if (cboPhuongXa.SelectedItem is AdministrativeUnit ward)
            {
                maPhuongXa = ward.code;
                tenPhuongXa = ward.name;
            }
            else if (!string.IsNullOrWhiteSpace(txtPhuongXaManual.Text))
            {
                tenPhuongXa = txtPhuongXaManual.Text.Trim();
                if (string.IsNullOrEmpty(tenTinh)) tenTinh = "Chưa rõ tỉnh";
            }

            try
            {
                using var context = new QLNhaTroContext();
                var khach = new KhachThue
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = radNam.Checked ? "Nam" : "Nữ",
                    NgaySinh = dtpNgaySinh.Value.Date,
                    SoDienThoai = txtSDT.Text.Trim(),
                    MaPhong = maPhong,
                    MaTinh = maTinh,
                    TenTinh = tenTinh,
                    MaPhuongXa = maPhuongXa,
                    TenPhuongXa = tenPhuongXa,
                    DaDangKyTamTru = chkTamTru.Checked
                };

                context.KhachThues.Add(khach);

                // Tự động cập nhật phòng thành "Đang thuê"
                var phong = context.PhongTros.FirstOrDefault(p => p.MaPhong == maPhong);
                if (phong != null)
                {
                    phong.TinhTrang = "Đang thuê";
                }

                context.SaveChanges();

                LoggerService.LogInfo($"Thêm khách thuê thành công: MaKhach={khach.MaKhach}, HoTen={khach.HoTen}, Phong={phong?.TenPhong}");
                MessageBox.Show("Thêm khách thuê thành công và đã cập nhật trạng thái phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadKhachThueFromDatabase();
                LoadPhongToCombos();
                ClearInputs();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex, "Lỗi khi thêm khách thuê.");
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKhach.Text))
            {
                MessageBox.Show("Vui lòng chọn khách thuê cần sửa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maKhach = int.Parse(txtMaKhach.Text);
            int maPhong = (int)cboPhong.SelectedValue!;

            try
            {
                using var context = new QLNhaTroContext();
                var khach = context.KhachThues.FirstOrDefault(k => k.MaKhach == maKhach);
                if (khach == null)
                {
                    MessageBox.Show("Không tìm thấy khách thuê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int oldMaPhong = khach.MaPhong;

                khach.HoTen = txtHoTen.Text.Trim();
                khach.GioiTinh = radNam.Checked ? "Nam" : "Nữ";
                khach.NgaySinh = dtpNgaySinh.Value.Date;
                khach.SoDienThoai = txtSDT.Text.Trim();
                khach.MaPhong = maPhong;
                khach.DaDangKyTamTru = chkTamTru.Checked;

                if (cboTinh.SelectedItem is AdministrativeUnit prov)
                {
                    khach.MaTinh = prov.code;
                    khach.TenTinh = prov.name;
                }

                if (cboPhuongXa.SelectedItem is AdministrativeUnit ward)
                {
                    khach.MaPhuongXa = ward.code;
                    khach.TenPhuongXa = ward.name;
                }
                else if (!string.IsNullOrWhiteSpace(txtPhuongXaManual.Text))
                {
                    khach.TenPhuongXa = txtPhuongXaManual.Text.Trim();
                }

                // Cập nhật trạng thái nếu đổi phòng
                if (oldMaPhong != maPhong)
                {
                    var newPhong = context.PhongTros.FirstOrDefault(p => p.MaPhong == maPhong);
                    if (newPhong != null) newPhong.TinhTrang = "Đang thuê";

                    // Kiểm tra phòng cũ còn khách nào không
                    bool oldRoomHasOtherGuests = context.KhachThues.Any(k => k.MaPhong == oldMaPhong && k.MaKhach != maKhach);
                    if (!oldRoomHasOtherGuests)
                    {
                        var oldPhong = context.PhongTros.FirstOrDefault(p => p.MaPhong == oldMaPhong);
                        if (oldPhong != null) oldPhong.TinhTrang = "Trống";
                    }
                }

                context.SaveChanges();

                LoggerService.LogInfo($"Cập nhật khách thuê MaKhach={maKhach} thành công.");
                MessageBox.Show("Cập nhật thông tin khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadKhachThueFromDatabase();
                LoadPhongToCombos();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex, $"Lỗi khi sửa khách thuê MaKhach={maKhach}.");
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKhach.Text))
            {
                MessageBox.Show("Vui lòng chọn khách thuê cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maKhach = int.Parse(txtMaKhach.Text);

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa khách thuê [{txtHoTen.Text}] không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using var context = new QLNhaTroContext();
                var khach = context.KhachThues.FirstOrDefault(k => k.MaKhach == maKhach);
                if (khach != null)
                {
                    int maPhong = khach.MaPhong;
                    context.KhachThues.Remove(khach);

                    // Kiểm tra xem phòng còn khách nào khác không
                    bool remaining = context.KhachThues.Any(k => k.MaPhong == maPhong && k.MaKhach != maKhach);
                    if (!remaining)
                    {
                        var phong = context.PhongTros.FirstOrDefault(p => p.MaPhong == maPhong);
                        if (phong != null)
                        {
                            phong.TinhTrang = "Trống";
                        }
                    }

                    context.SaveChanges();

                    LoggerService.LogInfo($"Xóa khách thuê MaKhach={maKhach} thành công. Trạng thái phòng được tự động cập nhật.");
                    MessageBox.Show("Xóa khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadKhachThueFromDatabase();
                    LoadPhongToCombos();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex, $"Lỗi khi xóa khách thuê MaKhach={maKhach}.");
                MessageBox.Show("Đã xảy ra lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBoLoc_Click(object? sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocPhong.SelectedIndex = 0;
            cboLocTinh.SelectedIndex = 0;
            ApplyFilter();
        }

        private void ClearInputs()
        {
            txtMaKhach.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            radNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Today;
            chkTamTru.Checked = false;
            txtPhuongXaManual.Clear();
            dgvKhachThue.ClearSelection();
        }
    }
}
