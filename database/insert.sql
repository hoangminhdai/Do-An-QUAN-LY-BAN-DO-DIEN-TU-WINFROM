insert into khachhang(MKH,HOTEN,DIACHIKH,SODTKH) values('kh1','Nguyen Van A','Thu Duc','0978349987')
insert into khachhang(MKH,HOTEN,DIACHIKH,SODTKH)  values('kh2','Nguyen Van B','Phu Nhuan','0978349988')
insert into khachhang(MKH,HOTEN,DIACHIKH,SODTKH)  values('kh3','Nguyen Van C','Quan 1','0978349989')
insert into khachhang(MKH,HOTEN,DIACHIKH,SODTKH)  values('kh4','Nguyen Van D','Quan 2','0978349123')
insert into khachhang(MKH,HOTEN,DIACHIKH,SODTKH)  values('kh5','Nguyen Van E','Quan 5','0978349124')
---
insert into nhanvien values('nv1','Nguyen Van A','Nam','Thu Duc','0908912312','12/05/1986')
insert into nhanvien values('nv2','Nguyen Van B','Nam','Thu Duc','0908912322','11/05/1986')
insert into nhanvien values('nv3','Nguyen Van C','Nam','Thu Duc','0908912316','12/06/1986')
insert into nhanvien values('nv4','Nguyen Thi D','Nu','Phu Nhuan','0908912000','12/06/1986')
insert into nhanvien values('nv5','Nguyen Thi E','Nu','Binh Thanh','0908123000','12/06/1986')
--
insert into loaisp values('LT','Laptop')
insert into loaisp values('PC','Máy tính')
insert into loaisp values('MA','Máy ảnh')
insert into loaisp values('TV','Ti Vi')
insert into loaisp values('TL','Tủ Lạnh')
--
insert into nhasx values('nsx1','toshiba','123','b')
insert into nhasx values('nsx2','apple','234','c')
insert into nhasx values('nsx3','intel','345','d')
insert into nhasx values('nsx4','del','678','e')
insert into nhasx values('nsx5','samsung','789','f')
--
insert into nhacungcap values('ncc1','Nha cung cap 1','123','Thu Duc')
insert into nhacungcap values('ncc2','Nha cung cap 2','234','Binh Thanh')
insert into nhacungcap values('ncc3','Nha cung cap 3','345','Phu Nhuan')
insert into nhacungcap values('ncc4','Nha cung cap 4','567','Quan 1')
insert into nhacungcap values('ncc5','Nha cung cap 5','678','Quan 3')
--
insert into sanpham values('sp1','LT','nsx1','Lap top Toshiba','chiec',10,12,100)
insert into sanpham values('sp2','PC','nsx2','Máy tính A','chiec',10,12,100)
insert into sanpham values('sp3','TV','nsx3','Ti vi sam sung ','chiec',10,12,100)
insert into sanpham values('sp4','MA','nsx4','may anh canon','chiec',10,12,100)
insert into sanpham values('sp5','TL','nsx5','Tu lanh Sam sung','chiec',10,12,100)
--
insert into hoadon(MKH,MNV) values('kh1','nv1')
insert into hoadon(MKH,MNV) values('kh2','nv2')
insert into hoadon(MKH,MNV) values('kh3','nv3')
insert into hoadon(MKH,MNV) values('kh4','nv4')
insert into hoadon(MKH,MNV) values('kh5','nv5')
insert into hoadon(MKH,MNV) values('kh1','nv2')

--
--insert into cthd values (19,'sp1',12,1,12)
--insert into cthd values (20,'sp1',12,1,12)
--insert into cthd values (21,'sp1',12,1,12)
--insert into cthd values (22,'sp1',12,1,12)
--insert into cthd values (23,'sp1',12,1,12)

insert into cthd values (1,'sp1',12,1,12)
insert into cthd values (2,'sp1',12,1,12)
insert into cthd values (3,'sp1',12,1,12)
insert into cthd values (4,'sp1',12,1,12)
insert into cthd values (5,'sp1',12,1,12)
insert into cthd values (6,'sp1',12,1,12)
insert into cthd values (6,'sp2',12,1,12)
insert into cthd values (6,'sp3',12,1,12)
insert into cthd values (1,'sp4',12,1,12)
insert into cthd values (1,'sp5',12,1,12)
--
insert into phieunhap(MNCC,MNV) values('ncc1','nv1')
insert into phieunhap(MNCC,MNV) values('ncc2','nv2')
insert into phieunhap(MNCC,MNV) values('ncc3','nv3')
insert into phieunhap(MNCC,MNV) values('ncc5','nv5')
insert into phieunhap(MNCC,MNV) values('ncc4','nv4')
--
insert into ctphieunhap values(1,'sp1',12,2,24)
insert into ctphieunhap values(2,'sp1',12,2,24)
insert into ctphieunhap values(3,'sp1',12,2,24)
insert into ctphieunhap values(4,'sp1',12,2,24)
insert into ctphieunhap values(5,'sp1',12,2,24)
insert into ctphieunhap values(4,'sp2',12,2,24)

--
set dateformat dmy
insert into dathang(MKH,MNV,NGAYGIAOHANG) values('kh1','nv1','22/06/2011')
insert into dathang(MKH,MNV,NGAYGIAOHANG) values('kh2','nv1','1/1/2011')
insert into dathang(MKH,MNV,NGAYGIAOHANG) values('kh3','nv1','22/06/2011')
--insert into dathang(MKH,MNV,NGAYGIAOHANG) values('kh4','nv2','22/06/2011')
--insert into dathang(MKH,MNV,NGAYGIAOHANG) values('kh1','nv2','22/06/2011')
--insert into chitiet_pdh values(13,'sp1',12,2,24)

insert into chitiet_pdh values(1,'sp1',12,2,24)
insert into chitiet_pdh values(2,'sp2',12,2,24)
insert into chitiet_pdh values(3,'sp3',12,2,24)

set DATEFORMAT dmy
insert into quyen values ('admin','admin')
insert into quyen values ('sell','nhan vien ban hang')
insert into quyen values ('manager','quan ly')
insert into quyen values ('banhang','banhang')



insert into nguoidung values('u1','admin','nv1','123456')
insert into nguoidung values('u2','sell','nv2','123456')
insert into nguoidung values('u3','manager','nv3','123456')

