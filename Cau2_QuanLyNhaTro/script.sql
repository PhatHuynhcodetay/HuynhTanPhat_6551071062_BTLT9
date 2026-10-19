-- ============================================================================
-- CÂU 2: CƠ SỞ DỮ LIỆU QL_NhaTro (ỨNG DỤNG QUẢN LÝ NHÀ TRỌ)
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
