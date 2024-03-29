IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'ID' AND ss.name = N'dbo')
CREATE TYPE [dbo].[ID] FROM [char](10) NULL
GO
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'STRING' AND ss.name = N'dbo')
CREATE TYPE [dbo].[STRING] FROM [varchar](255) NULL
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DateOnly]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[DateOnly](@DateTime DateTime)
-- Returns @DateTime at midnight; i.e., it removes the time portion of a DateTime value.
returns datetime
AS
begin
RETURN dateadd(dd,0, datediff(dd,0,@DateTime))
end' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LOAISP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LOAISP](
	[ML] [char](10) NOT NULL,
	[TENLOAI] [varchar](100) NULL,
 CONSTRAINT [PK_LOAISP] PRIMARY KEY NONCLUSTERED 
(
	[ML] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CTHD]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CTHD](
	[MHD] [int] NOT NULL,
	[MSP] [char](10) NOT NULL,
	[GIAMUA] [money] NULL,
	[SOLUONG] [int] NOT NULL,
	[THANHTIEN] [money] NULL,
 CONSTRAINT [PK_CTHD] PRIMARY KEY CLUSTERED 
(
	[MHD] ASC,
	[MSP] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create trigger [insert_cthd_trig]
on [dbo].[CTHD]
after insert
as
begin
declare @tongtien money
declare @mhd int
declare @mkh char(10)
declare @tien money
declare @msp char(10)
declare @sl int
declare @soluong int
select @mhd = mhd from inserted 
select @msp = msp from inserted
select @mkh = mkh from hoadon where mhd=@mhd
select @sl=soluong from inserted
/*update cthd set thanhtien=soluong*giaban where mahd=@mhd and msp=(select msp from inserted)tu dong tinh thanh tien khi biet so luog va gia ban */
	select @tongtien=sum(thanhtien) from cthd where mhd =@mhd
	update hoadon set tongtrigia=@tongtien where mhd =@mhd
--tien cua khach hang
if(@mkh <> 'KHTD')
begin
	select @tien = TIEN from KHACHHANG where MKH=@mkh
	update KHACHHANG set TIEN = @tien + @tongtien  where MKH=@mkh
end
--so luong san pham
	select @soluong=soluong from sanpham where msp= @msp
	update sanpham set soluong = @soluong-@sl where msp = @msp
	if (@soluong < @sl)
		--print N'so luong lon hon'
		rollback
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CTPHIEUNHAP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CTPHIEUNHAP](
	[MPN] [int] NOT NULL,
	[MSP] [char](10) NOT NULL,
	[GIABAN] [money] NULL,
	[SLNHAP] [int] NULL,
	[THANHTIEN] [money] NULL,
 CONSTRAINT [PK_CTPHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[MPN] ASC,
	[MSP] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create trigger [delete_ctpn]
on [dbo].[CTPHIEUNHAP]
after delete
as
begin
declare @msp char(10)
declare @soluong int
declare @sl int
declare @tongtien money
declare @mpn character(10)

select @msp = msp from deleted
select @mpn=mpn from deleted
select @sl=slnhap from deleted
if exists(select mpn from ctphieunhap where mpn=@mpn)
begin
print N'thuc hien delete'
select @tongtien=sum(thanhtien) from ctphieunhap where mpn=@mpn
update phieunhap set tongtien=@tongtien where mpn=@mpn
end
else
update phieunhap set tongtien=0 where mpn=@mpn
--update
select @soluong =soluong from sanpham where msp=@msp
update sanpham set soluong=@soluong - @sl where msp = @msp
end
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create   trigger [insert_ctnh]
on [dbo].[CTPHIEUNHAP]
after insert
as
begin
declare @tongtien money
declare @msp char(10)
declare @sl int
declare @soluong int
declare @mpn character(10)

select @mpn=mpn from inserted
select @msp=msp from inserted
select @sl= slnhap from inserted
select @tongtien=sum(thanhtien) from ctphieunhap where mpn =@mpn
update phieunhap set tongtien=@tongtien where mpn=@mpn
--update so luong
select @soluong= soluong from sanpham where msp=@msp
update sanpham set soluong=@soluong + @sl where msp=@msp
end
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create trigger [update_ctpn]
on [dbo].[CTPHIEUNHAP]
after update
as
begin
declare @soluong int
declare @sl_del int
declare @sl_ins int
declare @tongtien money
declare @mpn character(10)
declare @msp char(10)

select @mpn=mpn from inserted
select @msp = msp from inserted
select @sl_del =slnhap from deleted
select @sl_ins =slnhap from inserted
select @tongtien=sum(thanhtien) from ctphieunhap where mpn=@mpn
update phieunhap set tongtien=@tongtien where mpn=@mpn
--update so luong
select @soluong = soluong from sanpham where msp=@msp
update sanpham set soluong =@soluong -@sl_del +@sl_ins where msp=@msp
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CHITIET_PDH]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CHITIET_PDH](
	[MDH] [int] NOT NULL,
	[MSP] [char](10) NOT NULL,
	[GIABAN] [money] NULL,
	[SLDATHANG] [int] NULL,
	[THANHTIEN] [money] NULL,
 CONSTRAINT [PK_CHITIET_PDH] PRIMARY KEY CLUSTERED 
(
	[MDH] ASC,
	[MSP] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create trigger [delete_ctpdh]
on [dbo].[CHITIET_PDH]
after delete
as 
begin
declare @tongtien money
declare @mdh int
declare @msp char(10)
--declare @soluong int
select @mdh=mdh from deleted 
select @msp=msp from deleted
--select @sl=sldathang from deleted
--update tong tien
if exists(select mdh from chitiet_pdh where mdh=@mdh)
begin
select @tongtien=sum(thanhtien) from chitiet_pdh
update dathang set tonggia_dh=@tongtien where mdh=@mdh
end
else
update dathang set tonggia_dh=0 where mdh=@mdh

end
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create  trigger [insert_ctpdh]
on [dbo].[CHITIET_PDH]
after insert
as
begin
declare @tongtien money
declare @mdh int
declare @msp char(10)
select @mdh=mdh from inserted 
select @msp=msp from inserted
--select @sl=sldathang from inserted
--dat hang
select @tongtien=sum(thanhtien) from chitiet_pdh where mdh=@mdh
update dathang set tonggia_dh=@tongtien where mdh=@mdh
--update so luong san pham

end
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create  trigger [update_ctpdh]
on [dbo].[CHITIET_PDH]
after update
as
begin
declare @tongtien money
declare @mdh int
declare @msp char(10)
--declare @soluong int
--declare @sl_del int
--declare @sl_ins int
select @mdh=mdh from inserted
select @msp=msp from inserted
--select @sl_del from deleted 
select @tongtien=sum(thanhtien) from chitiet_pdh where mdh=@mdh
update dathang set tonggia_dh=@tongtien where mdh=@mdh

end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SANPHAM]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SANPHAM](
	[MSP] [char](10) NOT NULL,
	[ML] [char](10) NOT NULL,
	[MNSX] [char](10) NOT NULL,
	[TENSP] [varchar](100) NULL,
	[DVT] [char](10) NULL,
	[GIAMUA] [money] NULL,
	[GIABAN] [money] NULL,
	[SOLUONG] [int] NULL CONSTRAINT [DISPLAY_SOLUONG_SP]  DEFAULT ((0)),
 CONSTRAINT [PK_SANPHAM] PRIMARY KEY NONCLUSTERED 
(
	[MSP] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HOADON]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HOADON](
	[MHD] [int] IDENTITY(1,1) NOT NULL,
	[MKH] [char](10) NOT NULL,
	[MNV] [dbo].[ID] NOT NULL,
	[NGAYLAP] [datetime] NULL CONSTRAINT [display_date_hoadon]  DEFAULT (getdate()),
	[TONGTRIGIA] [money] NULL CONSTRAINT [display_tongtrigia_hd]  DEFAULT ((0)),
 CONSTRAINT [PK_HOADON] PRIMARY KEY NONCLUSTERED 
(
	[MHD] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PHIEUNHAP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PHIEUNHAP](
	[MPN] [int] IDENTITY(1,1) NOT NULL,
	[MNCC] [char](10) NOT NULL,
	[MNV] [dbo].[ID] NOT NULL,
	[NGAYLAP] [datetime] NOT NULL CONSTRAINT [display_date_pn]  DEFAULT (getdate()),
	[TONGTIEN] [money] NOT NULL CONSTRAINT [display_tongtien_pn]  DEFAULT ((0)),
 CONSTRAINT [PK_PHIEUNHAP] PRIMARY KEY NONCLUSTERED 
(
	[MPN] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NHANVIEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NHANVIEN](
	[MNV] [dbo].[ID] NOT NULL,
	[TENNV] [dbo].[STRING] NOT NULL,
	[GIOITINH] [dbo].[STRING] NOT NULL,
	[DIACHINV] [char](10) NULL,
	[SODT] [dbo].[STRING] NOT NULL,
	[NGAYSINH] [datetime] NOT NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY NONCLUSTERED 
(
	[MNV] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NGUOIDUNG]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NGUOIDUNG](
	[ID] [dbo].[ID] NOT NULL,
	[MAQUYEN] [dbo].[ID] NOT NULL,
	[MNV] [dbo].[ID] NOT NULL,
	[PASS] [dbo].[STRING] NOT NULL,
 CONSTRAINT [PK_NGUOIDUNG] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QUYEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[QUYEN](
	[MAQUYEN] [dbo].[ID] NOT NULL,
	[TENQUYEN] [dbo].[STRING] NOT NULL,
 CONSTRAINT [PK_QUYEN] PRIMARY KEY NONCLUSTERED 
(
	[MAQUYEN] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATHANG]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATHANG](
	[MDH] [int] IDENTITY(1,1) NOT NULL,
	[MKH] [char](10) NOT NULL,
	[MNV] [dbo].[ID] NOT NULL,
	[TONGGIA_DH] [money] NULL CONSTRAINT [DISPLAY_TONGGIA_DH]  DEFAULT ((0)),
	[NGAYDATHANG] [datetime] NULL CONSTRAINT [DISPLAY_NGAYDATHANG]  DEFAULT (getdate()),
	[NGAYGIAOHANG] [datetime] NULL,
	[TINHTRANG] [int] NULL CONSTRAINT [DISPLAY_TINHTRANG]  DEFAULT ((0)),
 CONSTRAINT [PK_DATHANG] PRIMARY KEY NONCLUSTERED 
(
	[MDH] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NHACUNGCAP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NHACUNGCAP](
	[MNCC] [char](10) NOT NULL,
	[TENNCC] [varchar](100) NULL,
	[SODTNCC] [varchar](20) NULL,
	[DIACHINCC] [dbo].[STRING] NULL,
 CONSTRAINT [PK_NHACUNGCAP] PRIMARY KEY NONCLUSTERED 
(
	[MNCC] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NHASX]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NHASX](
	[MNSX] [char](10) NOT NULL,
	[TENNSX] [varchar](100) NULL,
	[SODTNSX] [varchar](20) NULL,
	[DIACHINSX] [dbo].[STRING] NULL,
 CONSTRAINT [PK_NHASX] PRIMARY KEY NONCLUSTERED 
(
	[MNSX] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KHACHHANG]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[KHACHHANG](
	[MKH] [char](10) NOT NULL,
	[HOTEN] [varchar](100) NULL,
	[DIACHIKH] [dbo].[STRING] NULL,
	[SODTKH] [varchar](20) NULL,
	[TIEN] [money] NULL CONSTRAINT [DISPLAY_TIEN_KH]  DEFAULT ((0)),
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY NONCLUSTERED 
(
	[MKH] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create trigger [del_kh]
on [dbo].[KHACHHANG]
after delete
as
begin
declare @mkh char(10)
select @mkh=mkh from deleted
if(@mkh = 'KHTD')
 rollback
end
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create trigger [update_kh]
on [dbo].[KHACHHANG]
after update
as
begin
declare @mkh char(10)
select @mkh = mkh from deleted
if(@mkh = 'KHTD')
 rollback
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INSERT_CTHD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[INSERT_CTHD]
@MHD INT,
@MSP  CHARACTER(10),
@GIABAN MONEY,
@SOLUONG INT,
@THANHTIEN MONEY
AS
INSERT INTO CTHD VALUES(@MHD,@MSP,@GIABAN,@SOLUONG,@THANHTIEN)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INSERT_CTPNH]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[INSERT_CTPNH]
@MPN CHAR(10),
@MSP CHAR(10),
@GIAMUA MONEY,
@SLNHAP INT,
@THANHTIEN MONEY
AS
INSERT INTO CTPHIEUNHAP VALUES(@MPN,@MSP,@GIAMUA,@SLNHAP,@THANHTIEN)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INSERT_CTDH]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[INSERT_CTDH]
@MDH INT,
@MSP  CHARACTER(10),
@GIABAN MONEY,
@SLDATHANG INT,
@THANHTIEN MONEY
AS
INSERT INTO CHITIET_PDH VALUES(@MDH,@MSP,@GIABAN,@SLDATHANG,@THANHTIEN)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INSERT_HOADON]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[INSERT_HOADON]
@MKH CHARACTER(10),
@MNV CHARACTER(10)
--@MHD CHAR(10) OUTPUT
AS
BEGIN
INSERT INTO HOADON(MKH,MNV)VALUES(@MKH,@MNV)
SELECT MAX(MHD) FROM HOADON 
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INSERT_PNH]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create  PROC [dbo].[INSERT_PNH]
@MNCC CHAR(10),
@MNV CHAR(10)
AS
INSERT INTO PHIEUNHAP(MNCC,MNV) VALUES(@MNCC,@MNV)
SELECT MAX(MPN) FROM PHIEUNHAP ' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INSERT_DATHANG]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[INSERT_DATHANG]
@MKH CHAR(10),
@MNV CHAR(10),
@DATE DATETIME
AS
BEGIN
INSERT INTO DATHANG(MKH,MNV,NGAYGIAOHANG) VALUES(@MKH,@MNV,@DATE)
SELECT MAX(MDH) FROM DATHANG
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SET_STATUS_DH]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[SET_STATUS_DH]
@MDH CHAR(10)
AS
UPDATE DATHANG SET TINHTRANG=1 WHERE MDH=@MDH' 
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CTHD_CTHD_HOADON]') AND parent_object_id = OBJECT_ID(N'[dbo].[CTHD]'))
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_CTHD_HOADON] FOREIGN KEY([MHD])
REFERENCES [dbo].[HOADON] ([MHD])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CTHD_CTHD2_SANPHAM]') AND parent_object_id = OBJECT_ID(N'[dbo].[CTHD]'))
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_CTHD2_SANPHAM] FOREIGN KEY([MSP])
REFERENCES [dbo].[SANPHAM] ([MSP])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_giamua_cthd]') AND parent_object_id = OBJECT_ID(N'[dbo].[CTHD]'))
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [valid_giamua_cthd] CHECK  (([giamua]>(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_soluong]') AND parent_object_id = OBJECT_ID(N'[dbo].[CTHD]'))
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [valid_soluong] CHECK  (([soluong]>(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_thanhtien_cthd]') AND parent_object_id = OBJECT_ID(N'[dbo].[CTHD]'))
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [valid_thanhtien_cthd] CHECK  (([thanhtien]>(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CTPHIEUN_CTPHIEUNH_PHIEUNHA]') AND parent_object_id = OBJECT_ID(N'[dbo].[CTPHIEUNHAP]'))
ALTER TABLE [dbo].[CTPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUN_CTPHIEUNH_PHIEUNHA] FOREIGN KEY([MPN])
REFERENCES [dbo].[PHIEUNHAP] ([MPN])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CTPHIEUN_CTPHIEUNH_SANPHAM]') AND parent_object_id = OBJECT_ID(N'[dbo].[CTPHIEUNHAP]'))
ALTER TABLE [dbo].[CTPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUN_CTPHIEUNH_SANPHAM] FOREIGN KEY([MSP])
REFERENCES [dbo].[SANPHAM] ([MSP])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_giamua_ctpn]') AND parent_object_id = OBJECT_ID(N'[dbo].[CTPHIEUNHAP]'))
ALTER TABLE [dbo].[CTPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [valid_giamua_ctpn] CHECK  (([giaban]>(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_slnhap_ctpn]') AND parent_object_id = OBJECT_ID(N'[dbo].[CTPHIEUNHAP]'))
ALTER TABLE [dbo].[CTPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [valid_slnhap_ctpn] CHECK  (([slnhap]>(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_thanhtien_ctpn]') AND parent_object_id = OBJECT_ID(N'[dbo].[CTPHIEUNHAP]'))
ALTER TABLE [dbo].[CTPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [valid_thanhtien_ctpn] CHECK  (([thanhtien]>(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CHITIET__CHITIET_P_DATHANG]') AND parent_object_id = OBJECT_ID(N'[dbo].[CHITIET_PDH]'))
ALTER TABLE [dbo].[CHITIET_PDH]  WITH CHECK ADD  CONSTRAINT [FK_CHITIET__CHITIET_P_DATHANG] FOREIGN KEY([MDH])
REFERENCES [dbo].[DATHANG] ([MDH])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CHITIET__CHITIET_P_SANPHAM]') AND parent_object_id = OBJECT_ID(N'[dbo].[CHITIET_PDH]'))
ALTER TABLE [dbo].[CHITIET_PDH]  WITH CHECK ADD  CONSTRAINT [FK_CHITIET__CHITIET_P_SANPHAM] FOREIGN KEY([MSP])
REFERENCES [dbo].[SANPHAM] ([MSP])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_giaban_ctdh]') AND parent_object_id = OBJECT_ID(N'[dbo].[CHITIET_PDH]'))
ALTER TABLE [dbo].[CHITIET_PDH]  WITH CHECK ADD  CONSTRAINT [valid_giaban_ctdh] CHECK  (([giaban]>(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_sldathang_ctdh]') AND parent_object_id = OBJECT_ID(N'[dbo].[CHITIET_PDH]'))
ALTER TABLE [dbo].[CHITIET_PDH]  WITH CHECK ADD  CONSTRAINT [valid_sldathang_ctdh] CHECK  (([sldathang]>(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_thanhtien_ctdh]') AND parent_object_id = OBJECT_ID(N'[dbo].[CHITIET_PDH]'))
ALTER TABLE [dbo].[CHITIET_PDH]  WITH CHECK ADD  CONSTRAINT [valid_thanhtien_ctdh] CHECK  (([thanhtien]>(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SANPHAM_DUOCSXBOI_NHASX]') AND parent_object_id = OBJECT_ID(N'[dbo].[SANPHAM]'))
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_DUOCSXBOI_NHASX] FOREIGN KEY([MNSX])
REFERENCES [dbo].[NHASX] ([MNSX])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SANPHAM_THUOC_LOAISP]') AND parent_object_id = OBJECT_ID(N'[dbo].[SANPHAM]'))
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_THUOC_LOAISP] FOREIGN KEY([ML])
REFERENCES [dbo].[LOAISP] ([ML])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_giaban_sp]') AND parent_object_id = OBJECT_ID(N'[dbo].[SANPHAM]'))
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [valid_giaban_sp] CHECK  (([giaban]>(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_giamua_sp]') AND parent_object_id = OBJECT_ID(N'[dbo].[SANPHAM]'))
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [valid_giamua_sp] CHECK  (([giamua]>(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_soluong_sp]') AND parent_object_id = OBJECT_ID(N'[dbo].[SANPHAM]'))
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [valid_soluong_sp] CHECK  (([soluong]>=(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HOADON_LAP_NHANVIEN]') AND parent_object_id = OBJECT_ID(N'[dbo].[HOADON]'))
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_LAP_NHANVIEN] FOREIGN KEY([MNV])
REFERENCES [dbo].[NHANVIEN] ([MNV])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_HOADON_THANH_TOA_KHACHHAN]') AND parent_object_id = OBJECT_ID(N'[dbo].[HOADON]'))
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_THANH_TOA_KHACHHAN] FOREIGN KEY([MKH])
REFERENCES [dbo].[KHACHHANG] ([MKH])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_tongtrigia]') AND parent_object_id = OBJECT_ID(N'[dbo].[HOADON]'))
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [valid_tongtrigia] CHECK  (([tongtrigia]>=(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PHIEUNHA_LAP2_NHANVIEN]') AND parent_object_id = OBJECT_ID(N'[dbo].[PHIEUNHAP]'))
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHA_LAP2_NHANVIEN] FOREIGN KEY([MNV])
REFERENCES [dbo].[NHANVIEN] ([MNV])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PHIEUNHA_NHAPTU_NHACUNGC]') AND parent_object_id = OBJECT_ID(N'[dbo].[PHIEUNHAP]'))
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHA_NHAPTU_NHACUNGC] FOREIGN KEY([MNCC])
REFERENCES [dbo].[NHACUNGCAP] ([MNCC])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_tongtien_pn]') AND parent_object_id = OBJECT_ID(N'[dbo].[PHIEUNHAP]'))
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [valid_tongtien_pn] CHECK  (([tongtien]>=(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_NGUOIDUN_LA_NHANVIEN]') AND parent_object_id = OBJECT_ID(N'[dbo].[NGUOIDUNG]'))
ALTER TABLE [dbo].[NGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUN_LA_NHANVIEN] FOREIGN KEY([MNV])
REFERENCES [dbo].[NHANVIEN] ([MNV])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_NGUOIDUN_QUYEN2_QUYEN]') AND parent_object_id = OBJECT_ID(N'[dbo].[NGUOIDUNG]'))
ALTER TABLE [dbo].[NGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUN_QUYEN2_QUYEN] FOREIGN KEY([MAQUYEN])
REFERENCES [dbo].[QUYEN] ([MAQUYEN])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DATHANG_DAT_HANG_KHACHHAN]') AND parent_object_id = OBJECT_ID(N'[dbo].[DATHANG]'))
ALTER TABLE [dbo].[DATHANG]  WITH CHECK ADD  CONSTRAINT [FK_DATHANG_DAT_HANG_KHACHHAN] FOREIGN KEY([MKH])
REFERENCES [dbo].[KHACHHANG] ([MKH])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DATHANG_GHI_PHIEU_NHANVIEN]') AND parent_object_id = OBJECT_ID(N'[dbo].[DATHANG]'))
ALTER TABLE [dbo].[DATHANG]  WITH CHECK ADD  CONSTRAINT [FK_DATHANG_GHI_PHIEU_NHANVIEN] FOREIGN KEY([MNV])
REFERENCES [dbo].[NHANVIEN] ([MNV])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[valid_tonggia_dh_dh]') AND parent_object_id = OBJECT_ID(N'[dbo].[DATHANG]'))
ALTER TABLE [dbo].[DATHANG]  WITH CHECK ADD  CONSTRAINT [valid_tonggia_dh_dh] CHECK  (([tonggia_dh]>=(0)))
