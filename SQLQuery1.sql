create database cSharp;
go
use cSharp
create table loaiSP(
	maLoai int not null primary key,
	tenLoai nVarChar(20),
	tinhTrang bit,
);
create table sanPham(
	maSP nVarChar(20) not null primary key,
	tenSP nVarChar(40),
	giaBan float,
	soLuong int,
	img nVarChar(50),
	thoiGian int, --thoiGian bảo hành 1donVi=1thang
	tinhTrang bit,
	maLoai int foreign key references loaiSP(maLoai)
);
create table khuyenMai(
	maKM int not null primary key,
	tenKM nVarChar(70),
	ngayBD datetime,
	ngayKT datetime,
	tinhTrang bit
)
create table CT_KhuyenMai(
	maKM int foreign key references khuyenMai(maKM),
	maSP nVarChar(20) foreign key references sanPham(maSP),
	constraint pk_CTKM primary key (maKM,maSP),
	donViGiam int,
	giaTriGiam int,
	tinhTrang bit
);
create table khachHang(
	maKH int not null primary key,
	tenKH nVarChar(30),
	sdt char(10),
	tichDiem int,
	tongChi float
);
create table nhanVien(
	maNV nVarChar(10) not null primary key,
	tenNV nVarChar(30),
	gioiTinh bit,
	sdt char(10),
	diaChi nVarChar(60),
	chucVu nVarChar(10),
	ngaySinh datetime,
	tinhTrang bit
);
create table phanQuyen(
	maQuyen int not null primary key,
	qLyNV bit,
	qLySP bit,
	qLyNH bit,
	qLyBH bit,
	qLyKH bit,
	xemThongKe bit
);
create table taiKhoan(
	maNV nVarChar(10) foreign key references nhanVien(maNV),
	maQuyen int foreign key references phanQuyen(maQuyen),
	tenDangNhap nVarChar(20),
	matKhau nVarChar(20),
	tinhTrang bit
);
create table ncc(
	maNCC int not null primary key,
	tenNCC nVarChar(50),
	sdt char(10),
	diaChi nVarChar(90),
	tinhTrang bit
);
create table phieuNhap(
	maPN int not null primary key,
	maNV nVarChar(10) foreign key references nhanVien(maNV),
	maNCC int foreign key references ncc(maNCC),
	ngayLap datetime,
	tongTien float,
	tinhTrang bit
);
create table CT_PhieuNhap(
	maPN int foreign key references phieuNhap(maPN),
	maSP nVarChar(20) foreign key references sanPham(maSP),
	constraint pk_CTPN primary key (maPN,maSP),
	giaNhap float,
	soLuong int,
	tinhTrang bit
);
create table hoaDon(
	maHD int not null primary key,
	maNV nVarChar(10) foreign key references nhanVien(maNV),
	maKH int foreign key references khachHang(maKH),
	ngayLap datetime,
	tongTien float,
	tinhTrang bit
);
create table CT_HoaDon(
	maHD int foreign key references hoaDon(maHD),
	maSP nVarChar(20) foreign key references sanPham(maSP),
	constraint pk_CTHD primary key (maHD,maSP),
	giaBan float,
	soLuong int,
	tongTien float,
	maKM int foreign key references khuyenMai(maKM)
);
create table baoHanh(
	maBH int not null primary key,
	maHD int foreign key references hoaDon(maHD),
	maSP nVarChar(20) foreign key references sanPham(maSP),
	ngayBD datetime,
	ngayKT datetime,
	soLan int,
	chiPhi float,
	trangThai bit
);
--loai sp
--san pham
--khuyen mai
--ct_khuyen mai
--khach hang
--nhan vien
--phan quyen
--tai khoan
--ncc
--phieu nhap
--chi tiet phieu nhap
--hoa don
--cT_hoa don
--bao hanh
