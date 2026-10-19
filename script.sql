-- ============================================================================
-- BÀI TẬP CHƯƠNG 11: PUBLISH APP & TÍCH HỢP API
-- TỔNG HỢP SCRIPT TẠO CSDL VÀ DỮ LIỆU MẪU CHO 5 BÀI TẬP
-- ============================================================================

-- ============================================================================
-- CÂU 1: CSDL QL_ChiTieu
-- ============================================================================
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_ChiTieu')
BEGIN
    CREATE DATABASE QL_ChiTieu;
END
GO

USE QL_ChiTieu;
GO

IF OBJECT_ID(N'ChiTieu', N'U') IS NOT NULL
    DROP TABLE ChiTieu;
GO

CREATE TABLE ChiTieu (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    NgayChi DATE NOT NULL,
    NoiDung NVARCHAR(100) NOT NULL,
    SoTien DECIMAL(18,0) NOT NULL,
    LoaiChi NVARCHAR(30) NOT NULL,
    GhiChu NVARCHAR(200) NULL
);
GO

-- 10+ dòng dữ liệu mẫu
INSERT INTO ChiTieu (NgayChi, NoiDung, SoTien, LoaiChi, GhiChu) VALUES
('2026-10-01', N'Ăn sáng phở bò', 45000, N'Ăn uống', N'Phở bò Cầu Giấy'),
('2026-10-02', N'Đổ xăng xe máy', 70000, N'Đi lại', N'Đổ đầy bình xăng A95'),
('2026-10-03', N'Mua giáo trình C# nâng cao', 120000, N'Học tập', N'Sách thư viện ĐHQG'),
('2026-10-05', N'Xem phim rạp CGV', 110000, N'Giải trí', N'Vé phim cuối tuần'),
('2026-10-07', N'Ăn trưa cơm văn phòng', 40000, N'Ăn uống', N'Cơm tấm sườn bì'),
('2026-10-09', N'Nạp tiền điện thoại', 100000, N'Khác', N'Thẻ Viettel 100k'),
('2026-10-10', N'Mua vở và bút viết', 35000, N'Học tập', N'Vở Campus và bút bi'),
('2026-10-12', N'Bảo dưỡng thay nhớt xe', 150000, N'Đi lại', N'Nhớt Castrol Power1'),
('2026-10-15', N'Trà sữa đồng nghiệp', 65000, N'Ăn uống', N'Trà sữa trân châu đường đen'),
('2026-10-16', N'Đăng ký khóa học trực tuyến', 299000, N'Học tập', N'Khóa học EF Core'),
('2026-10-18', N'Đi bơi cuối tuần', 80000, N'Giải trí', N'Vé bể bơi 4 mùa'),
('2026-10-19', N'Mua cà phê sáng', 25000, N'Ăn uống', N'Cà phê sữa đá');
GO


-- ============================================================================
-- CÂU 2: CSDL QL_NhaTro
-- ============================================================================
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_NhaTro')
BEGIN
    CREATE DATABASE QL_NhaTro;
END
GO

USE QL_NhaTro;
GO

IF OBJECT_ID(N'KhachThue', N'U') IS NOT NULL
    DROP TABLE KhachThue;
GO

IF OBJECT_ID(N'PhongTro', N'U') IS NOT NULL
    DROP TABLE PhongTro;
GO

CREATE TABLE PhongTro (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(20) NOT NULL,
    GiaThue DECIMAL(18,0) NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL DEFAULT N'Trống'
);
GO

CREATE TABLE KhachThue (
    MaKhach INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(5) NOT NULL,
    NgaySinh DATE NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    MaTinh INT NOT NULL,
    TenTinh NVARCHAR(100) NOT NULL,
    MaPhuongXa INT NOT NULL,
    TenPhuongXa NVARCHAR(100) NOT NULL,
    DaDangKyTamTru BIT NOT NULL DEFAULT 0,
    MaPhong INT NOT NULL FOREIGN KEY REFERENCES PhongTro(MaPhong)
);
GO

-- 6 phòng trọ mẫu
INSERT INTO PhongTro (TenPhong, GiaThue, TinhTrang) VALUES
(N'P.101', 2500000, N'Đang thuê'),
(N'P.102', 2500000, N'Đang thuê'),
(N'P.103', 2800000, N'Trống'),
(N'P.201', 3000000, N'Đang thuê'),
(N'P.202', 3000000, N'Trống'),
(N'P.203', 3200000, N'Trống');
GO

-- Khách thuê mẫu
INSERT INTO KhachThue (HoTen, GioiTinh, NgaySinh, SoDienThoai, MaTinh, TenTinh, MaPhuongXa, TenPhuongXa, DaDangKyTamTru, MaPhong) VALUES
(N'Nguyễn Văn An', N'Nam', '2002-05-14', '0912345678', 1, N'Thành phố Hà Nội', 611, N'Phường Xuân Đỉnh', 1, 1),
(N'Trần Thị Bích', N'Nữ', '2003-08-22', '0987654321', 1, N'Thành phố Hà Nội', 643, N'Phường Thanh Liệt', 1, 2),
(N'Lê Hoàng Long', N'Nam', '2001-11-30', '0905112233', 48, N'Thành phố Đà Nẵng', 20197, N'Phường Thạch Thang', 0, 4);
GO


-- ============================================================================
-- CÂU 3: CSDL QL_DaNgoai
-- ============================================================================
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_DaNgoai')
BEGIN
    CREATE DATABASE QL_DaNgoai;
END
GO

USE QL_DaNgoai;
GO

IF OBJECT_ID(N'ChuyenDi', N'U') IS NOT NULL
    DROP TABLE ChuyenDi;
GO

CREATE TABLE ChuyenDi (
    MaChuyen INT IDENTITY(1,1) PRIMARY KEY,
    TenChuyen NVARCHAR(100) NOT NULL,
    DiaDiem NVARCHAR(100) NOT NULL,
    NgayDi DATE NOT NULL,
    SoNguoi INT NOT NULL,
    NganSach DECIMAL(18,0) NOT NULL,
    PhuongTien NVARCHAR(30) NOT NULL,
    DaHoanThanh BIT NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(200) NULL
);
GO

-- 8 chuyến đi mẫu (từ vài ngày đến vài tuần tới)
INSERT INTO ChuyenDi (TenChuyen, DiaDiem, NgayDi, SoNguoi, NganSach, PhuongTien, DaHoanThanh, GhiChu) VALUES
(N'Khám phá sương mù Đà Lạt', N'Đà Lạt', '2026-10-25', 4, 8000000, N'Máy bay', 0, N'Mang theo áo ấm, chuẩn bị máy ảnh'),
(N'Săn mây Fansipan Sa Pa', N'Sa Pa', '2026-10-28', 6, 12000000, N'Tàu hỏa', 0, N'Lên đỉnh Fansipan đi cáp treo'),
(N'Tắm biển Vũng Tàu cuối tuần', N'Vũng Tàu', '2026-10-22', 5, 5000000, N'Ô tô', 0, N'Thuê homestay gần Bãi Sau'),
(N'Dạo phố cổ Hội An về đêm', N'Hội An', '2026-11-01', 3, 9000000, N'Máy bay', 0, N'Thưởng thức cao lầu, thả đèn hoa đăng'),
(N'Cắm trại hồ Trị An', N'Đồng Nai', '2026-10-20', 8, 4000000, N'Xe máy', 0, N'Mang theo lều và bếp nướng than'),
(N'Du ngoạn Vịnh Hạ Long', N'Hạ Long', '2026-10-15', 2, 7000000, N'Xe khách', 1, N'Tour du thuyền 2 ngày 1 đêm (đã đi)'),
(N'Khám phá đảo ngọc Phú Quốc', N'Phú Quốc', '2026-11-03', 4, 16000000, N'Máy bay', 0, N'Lặn ngắm san hô tại Nam đảo'),
(N'Trekking Tà Năng Phan Dũng', N'Lâm Đồng', '2026-11-10', 10, 15000000, N'Ô tô', 0, N'Cần rèn luyện thể lực trước 1 tuần');
GO


-- ============================================================================
-- CÂU 4: CSDL QL_TraSua
-- ============================================================================
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_TraSua')
BEGIN
    CREATE DATABASE QL_TraSua;
END
GO

USE QL_TraSua;
GO

IF OBJECT_ID(N'ChiTietHoaDon', N'U') IS NOT NULL
    DROP TABLE ChiTietHoaDon;
GO

IF OBJECT_ID(N'HoaDon', N'U') IS NOT NULL
    DROP TABLE HoaDon;
GO

IF OBJECT_ID(N'MonUong', N'U') IS NOT NULL
    DROP TABLE MonUong;
GO

IF OBJECT_ID(N'DanhMucMon', N'U') IS NOT NULL
    DROP TABLE DanhMucMon;
GO

CREATE TABLE DanhMucMon (
    MaDM INT IDENTITY(1,1) PRIMARY KEY,
    TenDM NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE MonUong (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    GiaBan DECIMAL(18,0) NOT NULL,
    DangBan BIT NOT NULL DEFAULT 1,
    MaDM INT NOT NULL FOREIGN KEY REFERENCES DanhMucMon(MaDM)
);
GO

CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    TongTien DECIMAL(18,0) NOT NULL,
    HinhThucTT NVARCHAR(20) NOT NULL,
    DaThanhToan BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE ChiTietHoaDon (
    MaHD INT NOT NULL FOREIGN KEY REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    MaMon INT NOT NULL FOREIGN KEY REFERENCES MonUong(MaMon),
    SoLy INT NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL,
    PRIMARY KEY (MaHD, MaMon)
);
GO

-- 4 danh mục
INSERT INTO DanhMucMon (TenDM) VALUES
(N'Trà sữa truyền thống'),
(N'Trà trái cây nhiệt đới'),
(N'Cà phê & Đá xay'),
(N'Topping cao cấp');
GO

-- 12+ món uống
INSERT INTO MonUong (TenMon, GiaBan, DangBan, MaDM) VALUES
(N'Trà sữa Oolong nướng', 35000, 1, 1),
(N'Trà sữa Trân châu đen', 30000, 1, 1),
(N'Trà sữa Khoai môn dẻo', 38000, 1, 1),
(N'Trà sữa Matcha Nhật Bản', 42000, 1, 1),
(N'Trà đào cam sả', 39000, 1, 2),
(N'Trà dâu tây ổi hồng', 45000, 1, 2),
(N'Trà hoa đậu biếc chanh vàng', 35000, 1, 2),
(N'Cà phê muối Huế', 28000, 1, 3),
(N'Matcha đá xay kem cheese', 49000, 1, 3),
(N'Caramel Macchiato đá xay', 52000, 1, 3),
(N'Trân châu hoàng kim', 10000, 1, 4),
(N'Thạch pudding trứng', 10000, 1, 4),
(N'Kem phô mai Macchiato', 12000, 1, 4);
GO

-- Hóa đơn mẫu
INSERT INTO HoaDon (NgayLap, TongTien, HinhThucTT, DaThanhToan) VALUES
('2026-10-19 08:30:00', 74000, N'Tiền mặt', 1),
('2026-10-19 09:15:00', 84000, N'Chuyển khoản', 1);
GO

INSERT INTO ChiTietHoaDon (MaHD, MaMon, SoLy, DonGia) VALUES
(1, 1, 2, 35000),
(1, 11, 1, 10000);
GO

INSERT INTO ChiTietHoaDon (MaHD, MaMon, SoLy, DonGia) VALUES
(2, 4, 2, 42000);
GO


-- ============================================================================
-- CÂU 5: CSDL QL_DatTour
-- ============================================================================
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_DatTour')
BEGIN
    CREATE DATABASE QL_DatTour;
END
GO

USE QL_DatTour;
GO

IF OBJECT_ID(N'DatTour', N'U') IS NOT NULL
    DROP TABLE DatTour;
GO

IF OBJECT_ID(N'KhachHang', N'U') IS NOT NULL
    DROP TABLE KhachHang;
GO

IF OBJECT_ID(N'Tour', N'U') IS NOT NULL
    DROP TABLE Tour;
GO

CREATE TABLE Tour (
    MaTour INT IDENTITY(1,1) PRIMARY KEY,
    TenTour NVARCHAR(100) NOT NULL,
    DiemDen NVARCHAR(50) NOT NULL,
    NgoaiTe CHAR(3) NOT NULL,
    GiaNgoaiTe DECIMAL(18,2) NOT NULL,
    NgayKhoiHanh DATE NOT NULL,
    SoChoToiDa INT NOT NULL
);
GO

CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE DatTour (
    MaDat INT IDENTITY(1,1) PRIMARY KEY,
    MaKH INT NOT NULL FOREIGN KEY REFERENCES KhachHang(MaKH),
    MaTour INT NOT NULL FOREIGN KEY REFERENCES Tour(MaTour),
    SoNguoi INT NOT NULL,
    NgayDat DATETIME NOT NULL DEFAULT GETDATE(),
    TyGia DECIMAL(18,4) NOT NULL,
    TongTienVND DECIMAL(18,0) NOT NULL
);
GO

-- 5 tour mẫu
INSERT INTO Tour (TenTour, DiemDen, NgoaiTe, GiaNgoaiTe, NgayKhoiHanh, SoChoToiDa) VALUES
(N'Khám phá thiên đường Bangkok - Pattaya', N'Thái Lan', 'THB', 12500.00, '2026-11-15', 25),
(N'Mùa thu lá đỏ Seoul - Đảo Nami', N'Hàn Quốc', 'KRW', 850000.00, '2026-11-20', 20),
(N'Ngắm núi Phú Sĩ - Trải nghiệm Tokyo', N'Nhật Bản', 'JPY', 95000.00, '2026-12-05', 18),
(N'Du ngoạn bờ Tây Hoa Kỳ Los Angeles - Las Vegas', N'Mỹ', 'USD', 1800.00, '2026-12-20', 15),
(N'Khám phá Chiang Mai - Chiềng Rai cổ kính', N'Thái Lan', 'THB', 11000.00, '2026-11-28', 20);
GO

-- Khách hàng mẫu
INSERT INTO KhachHang (HoTen, SoDienThoai, Email) VALUES
(N'Phạm Quang Huy', '0912999888', 'quanghuy@gmail.com'),
(N'Vũ Mai Phương', '0988777666', 'maiphuong@outlook.com'),
(N'Đỗ Minh Trí', '0903123456', 'minhtri@gmail.com');
GO

-- Đơn đặt tour mẫu
INSERT INTO DatTour (MaKH, MaTour, SoNguoi, NgayDat, TyGia, TongTienVND) VALUES
(1, 1, 2, '2026-10-18 14:00:00', 772.0000, 19300000),
(2, 2, 1, '2026-10-19 09:30:00', 18.5000, 15725000);
GO
