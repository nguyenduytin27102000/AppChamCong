/* CREATE DATABASE QLCHAMCONG
USE QLCHAMCONG 
GO  */
/* Create table */
/* Module 1: Quan Tri Nhan Su */
CREATE TABLE VanPhong  ( /*1*/
MaVP varchar(10) not null,
TenVP Nvarchar(100) not null,
DiaChi Nvarchar(100) not null,
SDT varchar(15) not null,
Email varchar(50) not null,
Xoa bit default(1)
);
CREATE TABLE LoaiLichLamViec ( /*1*/
MaLoaiLichLamViec varchar(10) not null,
TenLoaiLichLamViec Nvarchar(50) not null,
Xoa bit default(1)
);
CREATE TABLE ChinhSachCheckin (/*1*/
MaChinhSachCheckin varchar(10) not null,
TenChinhSachCheckin Nvarchar(50) not null,
Xoa bit default(1)
);
CREATE TABLE SoCaLamViec /*1*/
(
MaSoCaLamViec varchar(10) not null,
SoCaLamViec tinyint not null,
Xoa bit default(1)
);
CREATE TABLE NgayTrongTuan( /*1*/
MaNgayTrongTuan varchar(10) not null,
TenNgayTrongTuan Nvarchar(50) not null,
Xoa bit default(1)
);
CREATE TABLE LoaiCaLamViec( /*1*/
MaLoaiCaLamViec varchar(10) not null,
TenLoaiCaLamViec Nvarchar(50) not null,
Xoa bit default(1)
);
CREATE TABLE KhuVucNghiepVu ( /*1*/
MaKhuVuc varchar(10) not null,
TenKhuVuc Nvarchar(100) not null,
MoTa Nvarchar(100),
TrangThai bit default(1),
Xoa bit default(1)
);
CREATE TABLE LoaiViTri ( /*1*/
MaLoaiViTri varchar(10) not null,
TenLoaiViTri Nvarchar(50) not null,
MoTa Nvarchar(100),
Xoa bit default(1)
);
CREATE TABLE ChinhSachLuong ( /*1*/
MaChinhSachLuong varchar(10) not null,
TenChinhSachLuong Nvarchar(100) not null,
MoTa Nvarchar(100),
TrangThai bit default(1),
Xoa bit default(1)
);
CREATE TABLE LoaiHinhNhanSu ( /*1*/
MaLoaiHinhNhanSu varchar(10) not null,
TenLoaiHinhNhanSu Nvarchar(100) not null,
MoTa Nvarchar(100),
TrangThai bit default(1),
Xoa bit default(1)
);
CREATE TABLE LichLamViec ( /*2*/
MaLichLamViec varchar(10) not null,
TenLichLamViec Nvarchar(100) not null,
MaLoaiLichLamViec varchar(10) not null,
MaChinhSachCheckin varchar(10) not null,
MaSoCaLamViec varchar(10) not null,
YeuCauCheckout bit default(1) not null,
SoGioLamViecMoiNgay tinyint default(8) not null,
SoPhutDuocTre tinyint default(15) not null,
SoPhutVeSom tinyint default(15) not null,
QuyDinh Nvarchar(100),
TrangThai bit default(1),
Xoa bit default(1)
);
CREATE TABLE CaLamViec( /*2*/
MaLichLamViec varchar(10) not null,
MaNgayTrongTuan varchar(10) not null,
MaCaLamViec varchar(10) not null,
MaLoaiCaLamViec varchar(10) not null,
TenCaLamViec Nvarchar(50) not null, 
ThoiGianBatDau datetime not null,
ThoiGianKetThuc datetime not null,
NgayNghi bit default(1) not null,
Xoa bit default(1)
);
CREATE TABLE ViTri ( /*2*/
MaViTri varchar(10) not null,
TenViTri Nvarchar(100) not null,
MaKhuVuc varchar(10) not null,
MaLoaiViTri varchar(10) not null,
MucLuongThapNhat money not null,
MucLuongCaoNhat money not null,
Xoa bit default(1)
);
CREATE TABLE NhanSu ( /*2*/
MaNhanSu varchar(10) not null,
HoVaTenDem Nvarchar(100) not null,
Ten Nvarchar(100) not null,
Email varchar(100) not null,
MaVP varchar(10) not null,
MaLichLamViec varchar(10) not null,
MaKhuVuc varchar(10) not null,
MaViTri varchar(10) not null,
MaChinhSachLuong varchar(10) not null,
MaLoaiHinhNhanSu varchar(10) not null,
ChucDanh Nvarchar(100),
LuongThucNhan money not null,
LuongCoBan money not null,
NgayVaoLam datetime not null,
NgayChinhThuc datetime,
NgaySinh datetime not null,
SDT varchar(15),
GioiTinh bit not null,
DiaChi Nvarchar(100) not null,
Xoa bit default(1)
);
/* End: Module 1: Quan Tri Nhan Su------------------------------------------------------*/

/* Module 2: Timeoff */

CREATE TABLE LoaiNghiPhep( /*1*/
MaLoaiNghiPhep varchar(10) not null,
TenLoaiNghiPhep Nvarchar(50) not null,
Xoa bit default(1)
);
CREATE TABLE QuyTrinhPheDuyet( /*1*/
MaQuyTrinhPheDuyet  varchar(10) not null,
TenQuyTrinhPheDuyet Nvarchar(50) not null,
Xoa bit default(1)
);
CREATE TABLE MauNghiPhep( /*2*/
MaMauNghiPhep varchar(10) not null,
TenMauNghiPhep Nvarchar(50) not null,
MaLoaiNghiPhep varchar(10) not null,
YeuCauPheDuyet bit default(1) not null,
MaQuyTrinhPheDuyet  varchar(10) not null,
GioiHanNgayNghi bit default(1) not null,
ThoiHanXuLy tinyint default(24),
SoNgayTruocNgayNghi tinyint default(2),
GioiHanSoNgayNghi tinyint default(5),
QuiDinh Nvarchar(100),
Xoa bit default(1)
);
CREATE TABLE KhuVucApDungMauNghiPhep( /*3*/
MaKhuVuc varchar(10) not null,
MaMauNghiPhep varchar(10) not null,
Xoa bit default(1)
);
CREATE TABLE NguoiPheDuyetNghiPhep( /*3*/
MaNhanSu varchar(10) not null,
MaMauNghiPhep varchar(10) not null,
Xoa bit default(1)
);
CREATE TABLE NguoiTheoDoiNghiPhep( /*3*/
MaNhanSu varchar(10) not null,
MaMauNghiPhep varchar(10) not null,
Xoa bit default(1)
);
CREATE TABLE YeuCauNghiPhep( /*1*/
MaNhanSu varchar(10) not null,
MaYeuCauNghiPhep varchar(10) not null,
TieuDe Nvarchar(50) not null,
MaMauNghiPhep varchar(10) not null,
LyDoNghiPhep Nvarchar(200) not null,
BanGiaoCongViec bit not null, 
CacCongViecBanGiao Nvarchar(200),
MaNguoiQuanLy varchar(10) not null,
TaiLieuDinhKem Nvarchar(100),
NgayTao datetime not null,
TrangThai Nvarchar(50) not null,
PhanHoi Nvarchar(100),
Xoa bit default(1)
);
CREATE TABLE NgayNghiPhep( /*2*/
MaNgayNghiPhep varchar(10) not null,
MaYeuCauNghiPhep varchar(10) not null,
NgayNghi datetime not null,
Xoa bit default(1)
);
CREATE TABLE CaNghiPhep( /*3*/
MaNgayNghiPhep varchar(10) not null,
MaYeuCauNghiPhep varchar(10) not null,
MaCaLamViec varchar(10) not null,
Xoa bit default(1)
);
CREATE TABLE LoaiChinhSach( /*1*/
MaLoaiChinhSach varchar(10) not null,
TenLoaiChinhSach Nvarchar(50) not null,
Xoa bit default(1)
);
CREATE TABLE ChinhSachTheoThamNien( /*1*/
MaThamNien varchar(10) not null,
ThamNien int not null,
SoNgayTang tinyint not null,
Xoa bit default(1)
);
CREATE TABLE ChinhSachNghiPhep( /*2*/
MaChinhSachNghiPhep varchar(10) not null,
TenChinhSach Nvarchar(100) not null,
MaLoaiChinhSach varchar(10) not null,
SoLuongPhepChuanNam tinyint not null,
SoLuongPhepTon tinyint not null,
MoTa Nvarchar(100),
Xoa bit default(1)
);
CREATE TABLE ApDungThamNien( /*3*/
MaChinhSachNghiPhep varchar(10) not null,
MaThamNien varchar(10) not null,
);

CREATE TABLE NhanSuChinhSachNghiPhep( /*1*/
MaNhanSu varchar(10) not null,
MaChinhSachNghiPhep varchar(10) not null,
NgayCoHieuLuc datetime not null,
PhepTon tinyint not null,
PhepTrongNam tinyint not null,
PhepThamNien tinyint not null,
NghiBu tinyint not null,
GhiChu Nvarchar(100),
Xoa bit default(1)
);
/*End: Timeoff -----------------------------------------*/

/*Tao cac Key*/

/*Quan tri nhan su*/
/*Khoa Chinh*/
alter table VanPhong
add constraint PK_VanPhong primary key(MaVP)

alter table LoaiLichLamViec
add constraint PK_LoaiLichLamViec primary key(MaLoaiLichLamViec)

alter table ChinhSachCheckin
add constraint PK_ChinhSachCheckin primary key(MaChinhSachCheckin)

alter table SoCaLamViec
add constraint PK_SoCaLamViec primary key(MaSoCaLamViec)

alter table NgayTrongTuan
add constraint PK_NgayTrongTuan primary key(MaNgayTrongTuan)

alter table LoaiCaLamViec
add constraint PK_LoaiCaLamViec primary key(MaLoaiCaLamViec)

alter table KhuVucNghiepVu
add constraint PK_KhuVucNghiepVu primary key(MaKhuVuc)

alter table LoaiViTri
add constraint PK_LoaiViTri primary key(MaLoaiViTri)

alter table ChinhSachLuong
add constraint PK_ChinhSachLuong primary key(MaChinhSachLuong)

alter table LoaiHinhNhanSu
add constraint PK_LoaiHinhNhanSu primary key(MaLoaiHinhNhanSu)

alter table LichLamViec
add constraint PK_LichLamViec primary key(MaLichLamViec)

alter table CaLamViec
add constraint PK_CaLamViec primary key(MaCaLamViec)

alter table ViTri
add constraint PK_ViTri primary key(MaViTri)

alter table NhanSu
add constraint PK_NhanSu primary key(MaNhanSu)

/*Khoa Ngoai*/

ALTER TABLE LichLamViec
add constraint PR_LichLamViec_LoaiLichLamViec foreign key(MaLoaiLichLamViec) references LoaiLichLamViec(MaLoaiLichLamViec),
constraint PR_LichLamViec_ChinhSachCheckin foreign key(MaChinhSachCheckin) references ChinhSachCheckin(MaChinhSachCheckin),
constraint PR_LichLamViec_SoCaLamViec foreign key(MaSoCaLamViec) references SoCaLamViec(MaSoCaLamViec)



ALTER TABLE CaLamViec
add constraint PR_CaLamViec_LichLamViec foreign key(MaLichLamViec) references LichLamViec(MaLichLamViec),
constraint PR_CaLamViec_NgayTrongTuan foreign key(MaNgayTrongTuan) references NgayTrongTuan(MaNgayTrongTuan),
constraint PR_CaLamViec_LoaiCaLamViec foreign key(MaLoaiCaLamViec) references LoaiCaLamViec(MaLoaiCaLamViec)

ALTER TABLE ViTri
add constraint PR_ViTri_KhuVucNghiepVu foreign key(MaKhuVuc) references KhuVucNghiepVu(MaKhuVuc),
constraint PR_ViTri_LoaiViTri foreign key(MaLoaiViTri) references LoaiViTri(MaLoaiViTri)


ALTER TABLE NhanSu
add constraint PR_NhanSu_VanPhong foreign key(MaVP) references VanPhong(MaVP),
constraint PR_NhanSu_LichLamViec foreign key(MaLichLamViec) references LichLamViec(MaLichLamViec),
constraint PR_NhanSu_KhuVucNghiepVu foreign key(MaKhuVuc) references KhuVucNghiepVu(MaKhuVuc),
constraint PR_NhanSu_ViTri foreign key(MaViTri) references ViTri(MaViTri),
constraint PR_NhanSu_ChinhSachLuong foreign key(MaChinhSachLuong) references ChinhSachLuong(MaChinhSachLuong),
constraint PR_NhanSu_LoaiHinhNhanSu foreign key(MaLoaiHinhNhanSu) references LoaiHinhNhanSu(MaLoaiHinhNhanSu)


/*End module 1: Quan tri nhan su ------------------------------------------------*/


/*Modle 2: Timeoff*/

/*Khoa Chinh*/
alter table LoaiNghiPhep
add constraint PK_LoaiNghiPhep primary key(MaLoaiNghiPhep)

alter table QuyTrinhPheDuyet
add constraint PK_QuyTrinhPheDuyet primary key(MaQuyTrinhPheDuyet)

alter table MauNghiPhep
add constraint PK_MauNghiPhep primary key(MaMauNghiPhep)

alter table KhuVucApDungMauNghiPhep
add constraint PK_KhuVucApDungMauNghiPhep primary key(MaKhuVuc,MaMauNghiPhep)


alter table NguoiPheDuyetNghiPhep
add constraint PK_NguoiPheDuyetNghiPhep primary key(MaNhanSu, MaMauNghiPhep)

alter table NguoiTheoDoiNghiPhep
add constraint PK_NguoiTheoDoiNghiPhep primary key(MaNhanSu,MaMauNghiPhep)

alter table YeuCauNghiPhep
add constraint PK_YeuCauNghiPhep primary key(MaYeuCauNghiPhep)

alter table NgayNghiPhep
add constraint PK_NgayNghiPhep primary key(MaNgayNghiPhep)

alter table CaNghiPhep
add constraint PK_CaNghiPhep primary key(MaNgayNghiPhep,MaYeuCauNghiPhep,MaCaLamViec)


alter table LoaiChinhSach
add constraint PK_LoaiChinhSach primary key(MaLoaiChinhSach)

alter table ChinhSachTheoThamNien
add constraint PK_ChinhSachTheoThamNien primary key(MaThamNien)

alter table ChinhSachNghiPhep
add constraint PK_ChinhSachNghiPhep primary key(MaChinhSachNghiPhep)

alter table ApDungThamNien
add constraint PK_ApDungThamNien primary key(MaChinhSachNghiPhep,MaThamNien)

alter table NhanSuChinhSachNghiPhep
add constraint PK_NhanSuChinhSachNghiPhep primary key(MaNhanSu,MaChinhSachNghiPhep)

/*Khoa Ngoai*/

ALTER TABLE MauNghiPhep
add constraint PR_MauNghiPhep_LoaiNghiPhep foreign key(MaLoaiNghiPhep) references LoaiNghiPhep(MaLoaiNghiPhep),
constraint PR_MauNghiPhep_QuyTrinhPheDuyet foreign key(MaQuyTrinhPheDuyet) references QuyTrinhPheDuyet(MaQuyTrinhPheDuyet)

ALTER TABLE KhuVucApDungMauNghiPhep
add constraint PR_KhuVucApDungMauNghiPhep_KhuVucNghiepVu foreign key(MaKhuVuc) references KhuVucNghiepVu(MaKhuVuc),
constraint PR_KhuVucApDungMauNghiPhep_MauNghiPhep foreign key(MaMauNghiPhep) references MauNghiPhep(MaMauNghiPhep)

ALTER TABLE NguoiPheDuyetNghiPhep
add constraint PR_NguoiPheDuyetNghiPhep_NhanSu foreign key(MaNhanSu) references NhanSu(MaNhanSu),
constraint PR_NguoiPheDuyetNghiPhep_MauNghiPhep foreign key(MaMauNghiPhep) references MauNghiPhep(MaMauNghiPhep)

ALTER TABLE NguoiTheoDoiNghiPhep
add constraint PR_NguoiTheoDoiNghiPhep_NhanSu foreign key(MaNhanSu) references NhanSu(MaNhanSu),
constraint PR_NguoiTheoDoiNghiPhep_MauNghiPhep foreign key(MaMauNghiPhep) references MauNghiPhep(MaMauNghiPhep)

ALTER TABLE YeuCauNghiPhep
add constraint PR_YeuCauNghiPhep_NhanSu foreign key(MaNhanSu) references NhanSu(MaNhanSu),
constraint PR_YeuCauNghiPhep_MauNghiPhep foreign key(MaMauNghiPhep) references MauNghiPhep(MaMauNghiPhep),
constraint PR_YeuCauNghiPhep_NguoiQuanLy foreign key(MaNguoiQuanLy) references NhanSu(MaNhanSu)

ALTER TABLE NgayNghiPhep
add constraint PR_NgayNghiPhep_YeuCauNghiPhep foreign key(MaYeuCauNghiPhep) references YeuCauNghiPhep(MaYeuCauNghiPhep)


ALTER TABLE CaNghiPhep
add constraint PR_CaNghiPhep_YeuCauNghiPhep foreign key(MaYeuCauNghiPhep) references YeuCauNghiPhep(MaYeuCauNghiPhep),
constraint PR_CaNghiPhep_CaLamViec foreign key(MaCaLamViec) references CaLamViec(MaCaLamViec),
constraint PR_CaNghiPhep_NgayNghiPhep foreign key(MaNgayNghiPhep) references NgayNghiPhep(MaNgayNghiPhep)


ALTER TABLE ChinhSachNghiPhep
add constraint PR_ChinhSachNghiPhep_LoaiChinhSach foreign key(MaLoaiChinhSach) references LoaiChinhSach(MaLoaiChinhSach)

ALTER TABLE ApDungThamNien
add constraint PR_ApDungThamNien_ChinhSachNghiPhep foreign key(MaChinhSachNghiPhep) references ChinhSachNghiPhep(MaChinhSachNghiPhep),
constraint PR_ApDungThamNien_ThamNien foreign key(MaThamNien) references ChinhSachTheoThamNien(MaThamNien)

ALTER TABLE NhanSuChinhSachNghiPhep
add constraint PR_NhanSuChinhSachNghiPhep_NhanSu foreign key(MaNhanSu) references NhanSu(MaNhanSu),
constraint PR_NhanSuChinhSachNghiPhep_ChinhSachNghiPhep foreign key(MaChinhSachNghiPhep) references ChinhSachNghiPhep(MaChinhSachNghiPhep)

/*End : Timeoff -----------------------------------*/

