use cSharp
INSERT INTO loaiSP(maLoai, tenLoai, tinhTrang ) VALUES
	(1, 'Iphone', 1),
	(2, 'Samsung', 1),
	(3, 'Google Pixel', 1),
	(4, 'Huawei', 1),
	(5, 'Xiaomi', 1),
	(6, 'Realme', 1),
	(7, 'OPPO', 1),
	(8, 'Vivo', 1),
	(9, 'OnePlus', 1),
	(10, 'Asus', 1),
	(11, 'Motorola', 1),
	(12, 'Nokia', 1),
	(13, 'HTC', 1);
INSERT INTO sanPham(maSP, tenSP, giaBan, soLuong, thoiGian, tinhTrang, maLoai ) VALUES
	('iphone-01', 'iPhone 14', 25000000, 40, 12, 1, 1),
	('samsung-01', 'Samsung Galaxy S23', 20000000, 20, 12, 1, 2),
	('pixel-01', 'Google Pixel 7', 25000000, 20, 12, 1, 3),
	('huawei-01', 'Huawei Mate Xs 2', 25000000, 20, 12, 1, 4),
	('xiaomi-01', 'Xiaomi Redmi Note 11T Pro', 15000000, 20, 12, 1, 5),
	('realme-01', 'Realme GT Neo 3', 12000000, 20, 12, 1, 6),
	('oppo-01', 'OPPO Find X5 Pro', 20000000, 20, 12, 1, 7),
	('vivo-01', 'Vivo X80 Pro', 25000000, 20, 12, 1, 8),
	('oneplus-01', 'OnePlus 10 Pro', 25000000, 20, 12, 1, 9),
	('asus-01', 'Asus ROG Phone 6', 25000000, 20, 12, 1, 10),
	('motorola-01', 'Motorola Edge 30 Pro', 20000000, 0, 12, 1, 11),
	('nokia-01', 'Nokia G21', 7000000, 0, 12, 1, 12),
	('htc-01', 'HTC Desire 22 Pro', 20000000, 0, 12, 1, 13),
	('iphone-02', 'iPhone 14', 25000000, 40, 12, 1, 1),
	('samsung-02', 'Samsung Galaxy S23', 20000000, 20, 12, 1, 2),
	('pixel-02', 'Google Pixel 7', 25000000, 20, 12, 1, 3),
	('huawei-02', 'Huawei Mate Xs 2', 25000000, 20, 12, 1, 4),
	('xiaomi-02', 'Xiaomi Redmi Note 11T Pro', 15000000, 20, 12, 1, 5),
	('realme-02', 'Realme GT Neo 3', 12000000, 20, 12, 1, 6),
	('oppo-02', 'OPPO Find X5 Pro', 20000000, 20, 12, 1, 7),
	('vivo-02', 'Vivo X80 Pro', 25000000, 20, 12, 1, 8),
	('oneplus-02', 'OnePlus 10 Pro', 25000000, 20, 12, 1, 9),
	('asus-02', 'Asus ROG Phone 6', 25000000, 20, 12, 1, 10),
	('motorola-02', 'Motorola Edge 30 Pro', 20000000, 0, 12, 1, 11),
	('nokia-02', 'Nokia G21', 7000000, 0, 12, 1, 12),
	('htc-02', 'HTC Desire 22 Pro', 20000000, 0, 12, 1, 13),
	('iphone-03', 'iPhone 14', 25000000, 40, 12, 1, 1),
	('samsung-03', 'Samsung Galaxy S23', 20000000, 20, 12, 1, 2),
	('pixel-03', 'Google Pixel 7', 25000000, 20, 12, 1, 3),
	('huawei-03', 'Huawei Mate Xs 2', 25000000, 20, 12, 1, 4),
	('xiaomi-03', 'Xiaomi Redmi Note 11T Pro', 15000000, 20, 12, 1, 5),
	('realme-03', 'Realme GT Neo 3', 12000000, 20, 12, 1, 6),
	('oppo-03', 'OPPO Find X5 Pro', 20000000, 20, 12, 1, 7),
	('vivo-03', 'Vivo X80 Pro', 25000000, 20, 12, 1, 8),
	('oneplus-03', 'OnePlus 10 Pro', 25000000, 20, 12, 1, 9),
	('asus-03', 'Asus ROG Phone 6', 25000000, 20, 12, 1, 10),
	('motorola-03', 'Motorola Edge 30 Pro', 20000000, 0, 12, 1, 11),
	('nokia-03', 'Nokia G21', 7000000, 0, 12, 1, 12),
	('htc-03', 'HTC Desire 22 Pro', 20000000, 0, 12, 1, 13);
INSERT INTO khuyenMai(maKM, tenKM, ngayBD, ngayKT, tinhTrang) VALUES
	(1, N'Giảm giá 10%', '2023-10-10', '2023-10-31', 1),
	(2, N'Tặng đồng hồ thông minh 500.000đ', '2023-11-01', '2023-11-30', 1),
	(3, N'Mua 2 tặng thêm 1 năm bảo hành', '2023-12-01', '2023-12-31', 1),
	(4, N'Giảm 10% cho điện thoại mới ra mắt', '2023-10-10', '2023-12-31', 1),
	(5, N'Giảm giá 5% cho điện thoại Pixel', '2023-10-10', '2023-12-31', 1),
	(6, N'Tặng ốp lưng 200.000đ cho điện thoại iPhone', '2023-10-10', '2023-11-30', 1),
	(7, N'Giảm giá 10% cho điện thoại Samsung', '2023-10-10', '2023-12-31', 1),
	(8, N'Tặng tai nghe 500.000đ cho điện thoại Oppo', '2023-10-10', '2023-11-30', 1),
	(9, N'Giảm giá 5% cho điện thoại Vivo', '2023-10-10', '2023-12-31', 1),
	(10, N'Tặng sạc dự phòng 1 triệu đồng cho điện thoại Xiaomi', '2023-10-10', '2023-11-30', 1),
	(11, N'Giảm giá 10% cho điện thoại Realme', '2023-10-10', '2023-12-31', 1),
	(12, N'Tặng loa bluetooth 500.000đ cho điện thoại motorola', '2023-10-10', '2023-11-30', 1),
	(13, N'Giảm giá 5% cho điện thoại Nokia', '2023-10-10', '2023-12-31', 1),
	(14, N'Tặng bộ sạc nhanh 300.000đ cho điện thoại Sony', '2023-10-10', '2023-11-30', 1);
INSERT INTO CT_KhuyenMai (maKM, maSP, donViGiam, giaTriGiam, tinhTrang) VALUES
	(6, 'iphone-01', 0, 200000, 1),
	(2, 'samsung-01', 0, 500000, 1),
	(5, 'pixel-01', 5, 1250000, 1),
	(3, 'huawei-01', 0, 0, 1),
	(10, 'xiaomi-01', 0, 1000000, 1),
	(11, 'realme-01', 10, 1200000, 1),
	(8, 'oppo-01', 0, 500000, 1),
	(9, 'vivo-01', 5, 1250000, 1),
	(4, 'oneplus-01', 10, 2500000, 1),
	(1, 'asus-01', 10, 2500000, 1),
	(12, 'motorola-01', 0, 500000, 1),
	(13, 'nokia-01', 5, 350000, 1);
INSERT INTO khachHang (maKH, tenKH, sdt, tichDiem, tongChi) VALUES 
	(1, N'Nguyễn Văn An', '0123456789', 0, 0),
	(2, N'Trần Thị Bình', '0987654321', 0, 0),
	(3, N'Lê Văn Chiến', '0129876543', 0, 0),
	(4, N'Đinh Thị Dung', '0987654320', 0, 0),
	(5, N'Vũ Văn Ên', '0123456788', 0, 0),
	(6, N'Hoàng Thị Gái', '0987654319', 0, 0),
	(7, N'Phạm Văn Hải', '0123456787', 0, 0),
	(8, N'Trương Thị Ích', '0987654318', 0, 0),
	(9, N'Bùi Văn Khiêm', '0123456786', 0, 0),
	(10, N'Nguyễn Thị Linh', '0987654317', 0, 0),
	(11, N'Đỗ Thị Mai', '0123456785', 0, 0),
	(12, N'Phan Thị Ngọc', '0987654316', 0, 0),
	(13, N'Hồ Văn Oanh', '0123456784', 0, 0),
	(14, N'Lý Thị Phượng', '0987654315', 0, 0),
	(15, N'Mai Văn Quỳnh', '0123456783', 0, 0),
	(16, N'Chu Thị Rành', '0987654314', 0, 0),
	(17, N'Sơn Văn Sách', '0123456782', 0, 0);
INSERT INTO nhanVien (maNV, tenNV, gioiTinh, sdt, diaChi, chucVu, ngaySinh, tinhTrang) VALUES
	('NV01', N'Nguyễn Văn Anh', 'Nam', '0123456789', N'123 Đường Nguyễn Văn Trỗi, Phường 12, Quận Phú Nhuận', N'Quản lý', '1990-01-01', 1),
	('NV02', N'Trần Thị Bảo', N'Nữ','0987654321', N'456 Đường Lê Văn Sỹ, Phường 14, Quận 3', N'NV kho', '1991-02-02', 1),
	('NV03', N'Lê Văn Chu', 'Nam','0129876543', N'789 Đường Nguyễn Đình Chiểu, Phường 3, Quận 1', N'Nhân viên', '1992-03-03', 1),
	('NV04', N'Đinh Thị Duyên', N'Nữ','0987654320', N'1011 Đường Võ Thị Sáu, Phường 7, Quận 3', N'Nhân viên', '1993-04-04', 1),
	('NV05', N'Vũ Văn Ếch', 'Nam','0123456788', N'1213 Đường Nguyễn Thị Minh Khai, Phường Bến Nghé, Quận 1', N'Nhân viên', '1994-05-05', 1),
	('NV06', N'Hoàng Thị Gánh', N'Nữ','0987654319', N'789 Đường Điện Biên Phủ, Phường 15, Quận Bình Thạnh', N'Nhân viên', '1995-06-06', 1),
	('NV07', N'Phạm Văn Hinh', 'Nam','0123456787', N'1011 Đường Phạm Văn Đồng, Phường 3, Quận Gò Vấp', N'Nhân viên', '1996-07-07', 1),
	('NV08', N'Trương Thị Ích', N'Nữ','0987654318', N'1213 Đường Nguyễn Hữu Thọ, Phường Tân Hưng, Quận 7', N'Nhân viên', '1997-08-08', 1),
	('NV09', N'Bùi Văn Khải', 'Nam','0123456786', N'457 Đường Xa lộ Hà Nội, Phường Tam Hiệp, Quận 9', N'Nhân viên', '1998-09-09', 1),
	('NV10', N'Nguyễn Thị Lài', N'Nữ','0987654317', N'789 Đường Trường Chinh, Phường Tây Thạnh, Quận Tân Phú', N'Nhân viên', '1999-10-10', 1);
INSERT INTO phanQuyen (maQuyen, qLyNV, qLySP, qLyNH, qLyBH, qLyKH, xemThongKe) VALUES
	(1, 1, 1, 1, 1, 0, 1),
	(2, 0, 1, 0, 1, 1, 0),
	(3, 0, 1, 1, 0, 0, 0);
INSERT INTO taiKhoan (maNV, maQuyen, tenDangNhap, matKhau, tinhTrang) VALUES
  ('NV01', 1, 'nhanvien1', 'nhanvien1', 1),
  ('NV02', 2, 'nhanvien2', 'nhanvien2', 1),
  ('NV03', 2, 'nhanvien3', 'nhanvien3', 1),
  ('NV04', 2, 'nhanvien4', 'nhanvien4', 1),
  ('NV05', 2, 'nhanvien5', 'nhanvien5', 1),
  ('NV06', 2, 'nhanvien6', 'nhanvien6', 1),
  ('NV07', 2, 'nhanvien7', 'nhanvien7', 1),
  ('NV08', 3, 'nhanvien8', 'nhanvien8', 1),
  ('NV09', 3, 'nhanvien9', 'nhanvien9', 1),
  ('NV10', 3, 'nhanvien10', 'nhanvien10', 1);
INSERT INTO ncc (maNCC, tenNCC, sdt, diaChi, tinhTrang) VALUES
	(1, N'Công ty Cổ phần MISA', '0243796868', N'Số 42 Trần Đăng Ninh, Cầu Giấy, Hà Nội', 1),
	(2, N'Công ty Cổ phần FPT Software', '0243056464', N'Tầng 5, Tòa nhà FPT Tower, 17 Phạm Hùng, Mỹ Đình 1, Nam Từ Liêm, Hà Nội', 1),
	(3, N'Công ty Cổ phần Viettel Business Solutions', '0246268595', N'Số 1, đường Giang Văn Minh, phường Kim Mã, quận Ba Đình, Hà Nội', 1),
	(4, N'Công ty Cổ phần VNG', '0247305644', N'Tầng 8, Tòa nhà VNG Building, 17 Phạm Hùng, Mỹ Đình 1, Nam Từ Liêm, Hà Nội', 1),
	(5, N'Công ty Cổ phần Thế Giới Di Động', '0282685959', N'Số 126 Nguyễn Trãi, phường Nguyễn Cư Trinh, quận 1, Thành phố Hồ Chí Minh', 1),
	(6, N'Công ty Cổ phần FPT Retail', '0287305464', N'Số 260 Khánh Hội, phường An Lạc, quận Bình Tân, Thành phố Hồ Chí Minh', 1),
	(7, N'Công ty Cổ phần Điện máy Xanh', '0286285959', N'Số 260 Đường 3-2, phường 12, quận 10, Thành phố Hồ Chí Minh', 1),
	(8, N'Công ty Cổ phần Thế Giới Số', '0287306464', N'Số 388 Trường Chinh, phường 13, quận Tân Bình, Thành phố Hồ Chí Minh', 1),
	(9, N'Công ty Cổ phần VinPro', '0286268595', N'Số 144 Nguyễn Văn Cừ, phường Long Biên, quận Long Biên, Hà Nội', 1),
	(10, N'Công ty Cổ phần M.2', '0247305646', N'Số 262 Nguyễn Trãi, phường Thanh Xuân Trung, quận Thanh Xuân, Hà Nội', 1);
insert into phieuNhap(maPN, maNV, maNCC, ngayLap, tongTien, tinhTrang) values
	(1, 'NV02', 1, '2023-10-10', 375000000, 1),
	(2, 'NV02', 2, '2023-10-11', 200000000, 1),
	(3, 'NV01', 3, '2023-10-12', 180000000, 1),
	(4, 'NV02', 4, '2023-10-13', 395000000, 1),
	(5, 'NV02', 5, '2023-10-14', 175000000, 1),
	(6, 'NV02', 6, '2023-10-15', 215000000, 1),
	(7, 'NV01', 7, '2023-10-16', 75000000, 1),
	(8, 'NV01', 8, '2023-10-17', 295000000, 1),
	(9, 'NV01', 9, '2023-10-18', 275000000, 1),
	(10, 'NV02', 10, '2023-10-19', 245000000, 1),
	(11, 'NV01', 2, '2023-10-20', 125000000, 1),
	(12, 'NV02', 2, '2023-10-21', 90000000, 1),
	(13, 'NV01', 3, '2023-10-22', 190000000, 1),
	(14, 'NV02', 4, '2023-10-23', 210000000, 1),
	(15, 'NV02', 5, '2023-10-24', 270000000, 1),
	(16, 'NV02', 6, '2023-10-25', 55000000, 1),
	(17, 'NV01', 7, '2023-10-26', 125000000, 1),
	(18, 'NV02', 1, '2023-10-27', 190000000, 1),
	(19, 'NV02', 9, '2023-10-28', 95000000, 1);
insert into CT_PhieuNhap(maPN, maSP, giaNhap, soLuong, tinhTrang) values
	(1, 'iphone-01', 20000000, 10, 1), --200tr
	(1, 'samsung-01', 16000000, 5, 1),	--80tr
	(1, 'pixel-01', 19000000, 5, 1),	--95tr
	(2, 'huawei-01', 20000000, 5, 1),	--100tr
	(2, 'xiaomi-01', 11000000, 5, 1),	--55tr
	(2, 'realme-01', 9000000, 5, 1),	--45tr
	(3, 'oppo-01', 16000000, 5, 1),	--80tr
	(3, 'vivo-01', 20000000, 5, 1),	--100tr
	(4, 'oneplus-01', 21000000, 5, 1), --105tr
	(4, 'asus-01', 20000000, 5, 1),		--100tr
	(4, 'iphone-01', 19000000, 10, 1),	--190tr
	(5, 'samsung-01', 16000000, 5, 1),	--80tr
	(5, 'pixel-01', 19000000, 5, 1),	--95tr
	(6, 'huawei-01', 21000000, 5, 1),	--105tr
	(6, 'xiaomi-01', 12000000, 5, 1),	--60tr
	(6, 'realme-01', 10000000, 5, 1),	--50tr
	(7, 'oppo-01', 15000000, 5, 1),		--75tr
	(8, 'vivo-01', 19000000, 5, 1),		--95tr
	(8, 'oneplus-01', 21000000, 5, 1),	--105tr
	(8, 'asus-01', 19000000, 5, 1),		--95tr
	(9, 'iphone-01', 20000000, 10, 1),	--200tr
	(9, 'samsung-01', 15000000, 5, 1),	--75tr
	(10, 'pixel-01', 18000000, 5, 1),	--90tr
	(10, 'huawei-01', 19000000, 5, 1),	--95tr
	(10, 'xiaomi-01', 12000000, 5, 1),	--60tr
	(11, 'realme-01', 10000000, 5, 1),	--50tr
	(11, 'oppo-01', 15000000, 5, 1),	--75tr
	(12, 'vivo-01', 18000000, 5, 1),	--90tr
	(13, 'oneplus-01', 20000000, 5, 1),	--100tr
	(13, 'asus-01', 18000000, 5, 1),	--90tr
	(14, 'iphone-01', 21000000, 10, 1),	--210tr
	(15, 'samsung-01', 16000000, 5, 1),	--80tr
	(15, 'pixel-01', 19000000, 5, 1),	--95tr
	(15, 'huawei-01', 19000000, 5, 1),	--95tr
	(16, 'xiaomi-01', 11000000, 5, 1),	--55tr
	(17, 'realme-01', 9000000, 5, 1),	--45tr
	(17, 'oppo-01', 16000000, 5, 1),	--80tr
	(18, 'vivo-01', 18000000, 5, 1),	--90tr
	(18, 'oneplus-01', 20000000, 5, 1),	--100tr
	(19, 'asus-01', 19000000, 5, 1);	--95tr

INSERT INTO hoaDon(maHD, maNV, maKH, ngayLap, tongTien, tinhTrang)
VALUES
	(1, 'NV01', 1, '2023-11-01 00:00:00.000', 62500000, 1),
	(2, 'NV02', 2, '2023-11-02 00:00:00.000', 64000000, 1),
	(3, 'NV03', 3, '2023-11-03 00:00:00.000', 7000000, 1),
	(4, 'NV04', 4, '2023-11-04 00:00:00.000', 25000000, 1),
	(5, 'NV05', 5, '2023-11-08 00:00:00.000', 40000000, 1),
	(6, 'NV06', 6, '2023-11-10 00:00:00.000', 25000000, 1),
	(7, 'NV07', 7, '2023-11-14 00:00:00.000', 12000000, 1),
	(8, 'NV08', 8, '2023-11-15 00:00:00.000', 39000000, 1),
	(9, 'NV09', 9, '2023-11-17 00:00:00.000', 25000000, 1),
	(10, 'NV10', 10, '2023-11-20 00:00:00.000', 15000000, 1);

INSERT INTO CT_HoaDon(maHD, maSP, giaBan, soLuong, tongTien, maKM) VALUES
	(1, 'asus-01', 25000000, 1, 22500000, 1),
	(1, 'htc-01', 20000000, 2, 40000000, NULL),
	(2, 'huawei-01', 25000000, 1, 25000000, 3),
	(2, 'motorola-01', 20000000, 2, 39000000, 12),
	(3, 'nokia-01', 7000000, 1, 7000000, NULL),
	(4, 'oneplus-01', 25000000, 1, 25000000, NULL),
	(5, 'oppo-01', 20000000, 2, 40000000, NULL),
	(6, 'pixel-01', 25000000, 1, 25000000, NULL),
	(7, 'realme-01', 12000000, 1, 12000000, NULL),
	(8, 'samsung-01', 20000000, 2, 39000000, 2),
	(9, 'vivo-01', 25000000, 1, 25000000, NULL),
	(10, 'xiaomi-01', 15000000, 1, 15000000, NULL);